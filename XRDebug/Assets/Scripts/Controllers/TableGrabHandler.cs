using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class TableGrabHandler : MonoBehaviour
{
    void OnEnable()
    {
        var interactable = GetComponent<UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable>();
        interactable.selectEntered.AddListener(OnGrabbed);
        interactable.selectExited.AddListener(OnReleased);
    }

    void OnDisable()
    {
        var interactable = GetComponent<UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable>();
        interactable.selectEntered.RemoveListener(OnGrabbed);
        interactable.selectExited.RemoveListener(OnReleased);
    }

    void OnGrabbed(SelectEnterEventArgs args)
    {
        Debug.Log("[XR] Table grabbed");
    }

    void OnReleased(SelectExitEventArgs args)
    {
        Debug.Log("[XR] Table released");
    }
}