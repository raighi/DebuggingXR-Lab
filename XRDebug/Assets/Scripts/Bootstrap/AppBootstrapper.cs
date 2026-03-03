using UnityEngine;
using System;

public class AppBootstrapper : MonoBehaviour
{
    public SolarSystemConfig config;

    public PlanetView[] planets;
    public OrbitRenderer[] orbits;


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

        Debug.Log("[BOOT] Application initialized");
    }
}
