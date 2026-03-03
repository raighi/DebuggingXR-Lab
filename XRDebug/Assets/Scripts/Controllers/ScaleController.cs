using UnityEngine;

public class ScaleController : MonoBehaviour
{
    public Transform solarSystemRoot;
    public float minScale = 0.5f;
    public float maxScale = 5f;
    public float currentScale = 1f;

    public void SetScale(float value)
    {
        if (value < minScale || value > maxScale)
        {
            Debug.LogWarning("[WARN] Scale clamped");
            value = Mathf.Clamp(value, minScale, maxScale);
        }

        currentScale = value;
        solarSystemRoot.localScale = Vector3.one * currentScale;
        Debug.Log("[XR] Scale applied : " + currentScale);
    }

    public void ScaleUp()
    {
        Debug.Log("[INPUT] Scale up requested");
        SetScale(currentScale + 0.1f);
    }

    public void ScaleDown()
    {
        Debug.Log("[INPUT] Scale down requested");
        SetScale(currentScale - 0.1f);
    }
}