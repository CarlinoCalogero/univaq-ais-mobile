using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.GraphicsBuffer;

public class ClientManager : MonoBehaviour
{

    [Header("UI Components")]
    public GameObject startPanel;
    public TMP_InputField ipInputField;
    public TextMeshProUGUI debugText;

    [Header("Network Settings")]
    public int port = 8080;

    private string targetIP;
    private bool isReady = false;

    private static ClientManager instance;

    public static ClientManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindAnyObjectByType<ClientManager>();

                if (instance == null)
                {
                    GameObject obj = new GameObject("ClientManager");
                    instance = obj.AddComponent<ClientManager>();
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

        if (ipInputField != null)
        {
            ipInputField.text = PlayerPrefs.GetString("BackendIP", "192.168.1.12");
        }

        UpdateDebug("Waiting for IP...");
    }

    public void OnConnectClicked()
    {
        targetIP = ipInputField.text;

        if (string.IsNullOrEmpty(targetIP))
        {
            UpdateDebug("Error: Please enter a valid IP.");
            return;
        }

        PlayerPrefs.SetString("BackendIP", targetIP);
        PlayerPrefs.Save();

        startPanel.SetActive(false);
        isReady = true;

        UpdateDebug("Ready! Scan any image...");
    }

    public Task<Model> Get(string modelKey) {
        if(targetIP == null || targetIP.Length == 0) {
            return Task.FromResult<Model>(default);
        }
        string url = $"http://{targetIP}:{port}/api/models/{modelKey}";
        Debug.LogWarning($"Requesting model {url}");
        return Client.Get<Model>(url);
    }

    void UpdateDebug(string message)
    {
        if (debugText != null) debugText.text = message;
        Debug.Log(message);
    }

    public bool IsReady()
    {
        return isReady;
    }
    
}
