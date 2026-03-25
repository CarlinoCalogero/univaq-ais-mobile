using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;

public class ModelSpawnManager : MonoBehaviour
{

    [Header("UI Components")]
    public TextMeshProUGUI debugText;

    private static ModelSpawnManager instance;

    public static ModelSpawnManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindAnyObjectByType<ModelSpawnManager>();

                if (instance == null)
                {
                    GameObject obj = new GameObject("ModelSpawnManager");
                    instance = obj.AddComponent<ModelSpawnManager>();
                }
            }

            return instance;
        }
    }

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
    }

    public IEnumerator RenderModel(Model model, GameObject container){
        Debug.LogWarning("Starting to render model");
        UpdateDebug($"<color=yellow>RENDERING: {container.name}</color>");

        long renderStartTime = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
        
        Task<bool> renderModelTask = GLTFHandler.Instantiate(model.presignedUrl, container);
        yield return new WaitUntil(()=>renderModelTask.IsCompleted);
        
        long renderTime = DateTimeOffset.UtcNow.ToUnixTimeSeconds() - renderStartTime;
        
        Debug.LogWarning($"Model rendered. Time required: {renderTime} seconds");
        UpdateDebug($"<color=green>RENDERED: {container.name}</color>");
    }

    void UpdateDebug(string message)
    {
        if (debugText != null) debugText.text = message;
        Debug.Log(message);
    }

}
