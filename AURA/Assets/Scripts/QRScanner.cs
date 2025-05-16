using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Collections;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using ZXing;
using TMPro;

public class QRScanner : MonoBehaviour
{
    public ARCameraManager cameraManager;
    private Texture2D cameraTexture;
    public TextMeshProUGUI resultText;
    public GameObject uiPanelPrefab;
    private GameObject activePanel;
    private string lastScannedCode = "";

    void OnEnable()
    {
        if (cameraManager != null)
            cameraManager.frameReceived += OnCameraFrameReceived;
    }

    void OnDisable()
    {
        if (cameraManager != null)
            cameraManager.frameReceived -= OnCameraFrameReceived;
    }

    void OnCameraFrameReceived(ARCameraFrameEventArgs args)
    {
        if (!cameraManager.TryAcquireLatestCpuImage(out XRCpuImage image))
            return;

        // Convert to Texture2D
        var conversionParams = new XRCpuImage.ConversionParams
        {
            inputRect = new RectInt(0, 0, image.width, image.height),
            outputDimensions = new Vector2Int(image.width, image.height),
            outputFormat = TextureFormat.RGBA32,
            transformation = XRCpuImage.Transformation.MirrorY
        };

        var rawTextureData = new NativeArray<byte>(image.GetConvertedDataSize(conversionParams), Allocator.Temp);
        image.Convert(conversionParams, rawTextureData);
        image.Dispose();

        if (cameraTexture == null || cameraTexture.width != image.width || cameraTexture.height != image.height)
            cameraTexture = new Texture2D(image.width, image.height, TextureFormat.RGBA32, false);

        cameraTexture.LoadRawTextureData(rawTextureData);
        cameraTexture.Apply();
        rawTextureData.Dispose();

        DecodeQRCode(cameraTexture);
    }

    void DecodeQRCode(Texture2D texture)
    {
        IBarcodeReader reader = new BarcodeReader();
        var result = reader.Decode(texture.GetPixels32(), texture.width, texture.height);

        if (result != null && result.Text != lastScannedCode)
        {
            Debug.Log("QR Code Detected: " + result.Text);
            resultText.text = "Scanned: " + result.Text;
            lastScannedCode = result.Text;
            ShowUIPanel(result.Text);
        }
    }

    void ShowUIPanel(string qrValue)
    {
    if (activePanel != null)
        Destroy(activePanel);

    // Position: in front of the AR Camera
    Vector3 spawnPosition = cameraManager.GetComponent<Camera>().transform.position +
                            cameraManager.GetComponent<Camera>().transform.forward * 0.5f;

    activePanel = Instantiate(uiPanelPrefab, spawnPosition, Quaternion.identity);

    // Make sure it always faces the camera
    activePanel.AddComponent<FaceCamera>();

    // Set the text inside the panel (assumes it has a TextMeshProUGUI child)
    var text = activePanel.GetComponentInChildren<TextMeshProUGUI>();
    if (text != null)
        text.text = $"Item Info:\n{qrValue}";
    }

}