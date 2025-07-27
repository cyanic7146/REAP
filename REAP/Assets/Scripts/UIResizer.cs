using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.U2D;

public class UIResizer : MonoBehaviour
{
    public UIDocument uiDocument;
    int targetHeight = 180;
    int targetWidth = 320;

    void Update()
    {
        float scale = GetScale();

        float rightScale = Mathf.FloorToInt(scale);

        rightScale = Mathf.Max(rightScale, 1f);

        uiDocument.panelSettings.scale = (float)rightScale;

        
    }

    float GetScale()
    {
        return Mathf.Min(
            (float)Screen.width / targetWidth,
            (float)Screen.height / targetHeight
        );
    }
}
