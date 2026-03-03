using UnityEngine;
using System;

public class AppBootstrapper : MonoBehaviour
{
    public SolarSystemConfig config;

    public PlanetView[] planets;
    public OrbitRenderer[] orbits;
    public SolarSystemUI ui;
    public ScaleController scaleController;
    public FocusController focusController;


    TimeModel timeModel;
    PlanetSystemController controller;
    TimeController timeController;


    void Start()
    {
        Debug.Log("[BOOT] Initializing application");

        timeModel = new TimeModel();

        var ephemeris = new PlanetEphemerisService(config);

        controller = new PlanetSystemController(
            timeModel,
            ephemeris,
            planets
        );

        timeModel.SetTime(DateTime.Now);
        timeController = gameObject.AddComponent<TimeController>();
        timeController.Init(timeModel);
        foreach (var orbit in orbits)
        {
            orbit.Init(ephemeris);
        }

        scaleController = GetComponent<ScaleController>();
        scaleController.ScaleUp();
        ui.Init(timeModel, scaleController, orbits);
        focusController.Init(timeModel);
        Debug.Log("[BOOT] Application initialized");
    }
}
