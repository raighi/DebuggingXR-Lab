using UnityEngine;
using TMPro;

public class FocusController : MonoBehaviour
{
    [Header("Panneau info")]
    public GameObject infoPanel;
    public TextMeshProUGUI planetNameText;
    public TextMeshProUGUI distanceText;
    public TextMeshProUGUI periodText;
    public TextMeshProUGUI currentDateText;

    TimeModel timeModel;

    public void Init(TimeModel model)
    {
        timeModel = model;
        infoPanel.SetActive(false);
        PlanetSelectable.OnPlanetSelected += OnPlanetFocused;
    }

    void OnDestroy()
    {
        PlanetSelectable.OnPlanetSelected -= OnPlanetFocused;
    }

    void OnPlanetFocused(PlanetData.Planet planet)
    {
        Debug.Log("[XR] Focus on : " + planet);

        infoPanel.SetActive(true);

        planetNameText.text = "Planète : " + planet.ToString();
        distanceText.text   = "Distance : " + GetDistance(planet) + " UA";
        periodText.text     = "Période : " + GetPeriod(planet) + " jours";
        currentDateText.text = "Date : " + timeModel.CurrentTime.ToString("dd/MM/yyyy");
    }

    string GetDistance(PlanetData.Planet planet)
    {
        switch (planet)
        {
            case PlanetData.Planet.Mercury: return "0.39";
            case PlanetData.Planet.Venus:   return "0.72";
            case PlanetData.Planet.Earth:   return "1.00";
            case PlanetData.Planet.Mars:    return "1.52";
            case PlanetData.Planet.Jupiter: return "5.20";
            case PlanetData.Planet.Saturn:  return "9.54";
            case PlanetData.Planet.Uranus:  return "19.19";
            case PlanetData.Planet.Neptune: return "30.07";
            default: return "?";
        }
    }

    string GetPeriod(PlanetData.Planet planet)
    {
        switch (planet)
        {
            case PlanetData.Planet.Mercury: return "88";
            case PlanetData.Planet.Venus:   return "225";
            case PlanetData.Planet.Earth:   return "365";
            case PlanetData.Planet.Mars:    return "687";
            case PlanetData.Planet.Jupiter: return "4333";
            case PlanetData.Planet.Saturn:  return "10759";
            case PlanetData.Planet.Uranus:  return "30687";
            case PlanetData.Planet.Neptune: return "60190";
            default: return "?";
        }
    }
}