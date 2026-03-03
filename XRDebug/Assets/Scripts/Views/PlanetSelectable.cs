using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using System;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class PlanetSelectable : MonoBehaviour
{
    public PlanetData.Planet planet;
    public static event Action<PlanetData.Planet> OnPlanetSelected;

    void OnEnable()
    {
        var interactable = GetComponent<XRSimpleInteractable>();
        if (interactable != null)
            interactable.selectEntered.AddListener(OnSelected);
    }

    void OnDisable()
    {
        var interactable = GetComponent<XRSimpleInteractable>();
        if (interactable != null)
            interactable.selectEntered.RemoveListener(OnSelected);
    }

    void OnSelected(SelectEnterEventArgs args)
    {
        Debug.Log("[XR] Planet selected : " + planet);
        OnPlanetSelected?.Invoke(planet);
    }
}