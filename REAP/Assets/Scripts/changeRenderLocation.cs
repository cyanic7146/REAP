using UnityEngine;

public class changeRenderLocation : MonoBehaviour
{
    void OnRenderImage(RenderTexture src, RenderTexture dest)
{
    Graphics.Blit(src, dest); // Blit the RenderTexture to the screen
}

}
