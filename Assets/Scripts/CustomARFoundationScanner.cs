using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class CustomARFoundationScanner : MonoBehaviour
{
    [Header("AR Components")]
    public ARTrackedImageManager imageManager;
    public Camera arCamera;

    [Header("UI Components")]
    public TextMeshProUGUI debugText;

    [Header("Prefabs")]
    public GameObject loadingSpinnerPrefab;

    // CHANGED: We removed 'hasLockedPosition'. 
    // Instead, we use a HashSet to remember which IDs we already sent in this session
    // to prevent spamming the network if the camera flickers.
    private HashSet<string> sentImageIDs = new HashSet<string>();

    void Awake()
    {
        
    }

    void OnEnable()
    {
        if (imageManager != null)
            imageManager.trackedImagesChanged += OnImageChanged;
    }

    void OnDisable()
    {
        if (imageManager != null)
            imageManager.trackedImagesChanged -= OnImageChanged;
    }

    void OnImageChanged(ARTrackedImagesChangedEventArgs eventArgs)
    {
        // 1. If not connected yet, ignore everything
        if (!ClientManager.Instance.IsReady()) return;

        // 2. Helper function to process any list of images
        ProcessImages(eventArgs.added);
        ProcessImages(eventArgs.updated);
    }

    void ProcessImages(IEnumerable<ARTrackedImage> images)
    {
        foreach (var trackedImage in images)
        {
            // Only process if tracking is good
            if (trackedImage.trackingState == TrackingState.Tracking)
            {
                string id = trackedImage.referenceImage.name;

                // Only send if we haven't sent this ID yet
                if (!sentImageIDs.Contains(id))
                {
                    StartCoroutine(ScanCode(trackedImage));
                    sentImageIDs.Add(id);
                }
                else
                {
                    UpdateDebug($"<color=yellow>ALREADY SENT: {trackedImage.referenceImage.name}</color>");
                }
            }
        }
    }

    private IEnumerator ScanCode(ARTrackedImage trackedImage)
    {
        Transform imageTransform = trackedImage.transform;
        string imageID = trackedImage.referenceImage.name;



        UpdateDebug($"<color=yellow>DETECTED: {imageID}</color>");

        GameObject container = new GameObject(imageID);
        container.transform.position = imageTransform.position;
        container.transform.SetParent(imageTransform);

        GameObject spinner = null;
        if (loadingSpinnerPrefab != null)
        {
            spinner = Instantiate(loadingSpinnerPrefab, container.transform);
        }

        UpdateDebug($"<color=yellow>REQUESTED: {imageID}</color>");
        long startTime = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
        Task<Model> requestModelTask = ClientManager.Instance.Get(imageID);
        yield return new WaitUntil(() => requestModelTask.IsCompleted);
        Model model = requestModelTask.Result;
        long requestTime = DateTimeOffset.UtcNow.ToUnixTimeSeconds() - startTime;
        Debug.LogWarning($"Model found. Request time: {requestTime} seconds");
        UpdateDebug($"<color=green>DOWNLOADED: {imageID}</color>");
        if (model == null)
        {
            UpdateDebug($"<color=red>DOWNLOAD FAILED: {imageID}</color>");
            if (spinner != null) Destroy(spinner); // Clean up the spinner if we fail
            yield break;
        }
        yield return StartCoroutine(ModelSpawnManager.Instance.RenderModel(model, container));

        if (spinner != null)
        {
            Destroy(spinner);
        }
    }

    void UpdateDebug(string message)
    {
        if (debugText != null) debugText.text = message;
        Debug.Log(message);
    }
}