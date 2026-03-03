using UnityEngine;
using System;

public class AppBootstrapper : MonoBehaviour
{
    public SolarSystemConfig config;

    public PlanetView[] planets;

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

        Debug.Log("[BOOT] Application initialized");
    }
}
