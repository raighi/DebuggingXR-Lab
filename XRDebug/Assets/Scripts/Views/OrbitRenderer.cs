using UnityEngine;
using System;

public class OrbitRenderer : MonoBehaviour
{
    public PlanetData.Planet planet;
    public int samples = 100;

    LineRenderer lr; // référence stockée
    IPlanetEphemerisService ephemeris;

    void Awake()
    {
        lr = GetComponent<LineRenderer>(); // récupéré dans Awake
    }

    public void Init(IPlanetEphemerisService ephemerisService)
    {
        ephemeris = ephemerisService;
        DrawOrbit();
    }

    void DrawOrbit()
    {
        if (lr == null)
        {
            Debug.LogError("[ORBIT] LineRenderer manquant sur " + gameObject.name);
            return;
        }

        lr.positionCount = samples + 1;
        lr.loop = true;

        DateTime start = DateTime.Now;

        for (int i = 0; i <= samples; i++)
        {
            DateTime t = start.AddDays(i * (365f / samples));
            lr.SetPosition(i, ephemeris.GetPlanetPosition(planet, t));
        }

        Debug.Log("[ORBIT] Orbite dessinée pour " + planet);
    }
}