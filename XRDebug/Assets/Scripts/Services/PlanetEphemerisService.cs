using System;
using UnityEngine;

public class PlanetEphemerisService : IPlanetEphemerisService
{
    SolarSystemConfig config;

    public PlanetEphemerisService(SolarSystemConfig config)
    {
        this.config = config;
    }

    public Vector3 GetPlanetPosition(PlanetData.Planet planet, DateTime date)
    {
        return PlanetData.GetPlanetPosition(planet, date) * 0.5f;
    }
}