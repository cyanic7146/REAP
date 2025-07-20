using UnityEngine;
using UnityEngine.UI;

public class PixelPerfectRenderer : MonoBehaviour
{
    public Camera targetCamera;
    public RawImage yourRawImage;
    public int targetWidth = 320;
    public int targetHeight = 180;
    private RenderTexture rt;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Build320x180RenderTexture();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void Build320x180RenderTexture()
    {
        rt = new RenderTexture(320, 180, 24);
        rt.filterMode = FilterMode.Point;
        rt.useMipMap = false;
        rt.autoGenerateMips = false;
        targetCamera.targetTexture = rt;
        yourRawImage.texture = rt;
    }
}
