using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class SolarSystemUI : MonoBehaviour
{
    [Header("Textes")]
    public TextMeshProUGUI dateText;
    public TextMeshProUGUI speedText;

    [Header("Boutons")]
    public Button btnPlay;
    public Button btnPause;
    public Button btnScaleUp;
    public Button btnScaleDown;
    public Button btnToggleOrbits;

    TimeModel timeModel;
    ScaleController scaleController;
    OrbitRenderer[] orbits;
    bool orbitsVisible = true;

    public void Init(TimeModel model, ScaleController scale, OrbitRenderer[] orbitRenderers)
    {
        timeModel = model;
        scaleController = scale;
        orbits = orbitRenderers;

        // Abonnement aux événements
        timeModel.OnTimeChanged += UpdateDateDisplay;

        // Boutons
        btnPlay.onClick.AddListener(() => {
            timeModel.Play();
            Debug.Log("[INPUT] Play");
        });

        btnPause.onClick.AddListener(() => {
            timeModel.Pause();
            Debug.Log("[INPUT] Pause");
        });

        btnScaleUp.onClick.AddListener(() => scaleController.ScaleUp());
        btnScaleDown.onClick.AddListener(() => scaleController.ScaleDown());

        btnToggleOrbits.onClick.AddListener(ToggleOrbits);

        UpdateDateDisplay(timeModel.CurrentTime);
        UpdateSpeedDisplay();
    }

    void UpdateDateDisplay(DateTime t)
    {
        if (dateText != null)
            dateText.text = "Date : " + t.ToString("dd/MM/yyyy");
    }

    void UpdateSpeedDisplay()
    {
        if (speedText != null)
            speedText.text = "Vitesse : x" + timeModel.TimeScale;
    }

    void ToggleOrbits()
    {
        orbitsVisible = !orbitsVisible;
        foreach (var orbit in orbits)
            orbit.gameObject.SetActive(orbitsVisible);

        Debug.Log("[INPUT] Orbits " + (orbitsVisible ? "shown" : "hidden"));
    }
}