using UnityEngine;
using System;

public class OrbitRenderer : MonoBehaviour
{
    public PlanetData.Planet planet;
    public int samples = 100000;
    TimeModel timeModel;

    LineRenderer lr; 
    IPlanetEphemerisService ephemeris;

    void Awake()
    {
        lr = GetComponent<LineRenderer>(); 
    }

    public void Init(IPlanetEphemerisService ephemerisService, TimeModel model)
{
    ephemeris = ephemerisService;
    timeModel = model;
    DrawOrbit();
}

void DrawOrbit()
{
    lr.useWorldSpace = false;
    lr.positionCount = samples + 1;
    lr.loop = true;

    float period = GetOrbitalPeriod();
    DateTime center = timeModel.CurrentTime; // utilise la date simulée
    DateTime start = center.AddDays(-period / 2f);

    for (int i = 0; i <= samples; i++)
    {
        DateTime t = start.AddDays(i * (period / samples));
        lr.SetPosition(i, ephemeris.GetPlanetPosition(planet, t));
    }

    Debug.Log("[ORBIT] Orbite dessinée pour " + planet);
}
float GetOrbitalPeriod()
{
    switch (planet)
    {
        case PlanetData.Planet.Mercury: return 88f;
        case PlanetData.Planet.Venus:   return 225f;
        case PlanetData.Planet.Earth:   return 365f;
        case PlanetData.Planet.Mars:    return 687f;
        case PlanetData.Planet.Jupiter: return 4333f;
        case PlanetData.Planet.Saturn:  return 10759f;
        case PlanetData.Planet.Uranus:  return 30687f;
        case PlanetData.Planet.Neptune: return 60190f;
        default: return 365f;
    }
}
}