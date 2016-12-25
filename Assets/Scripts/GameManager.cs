using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static bool isComputer = true;
    public static bool mouseOccupied = false;

    public static bool isLaunched = false;
    public static float timeStep = 0.01f;
    public static Planet selectedPlanet;
    public static GameObject planetManipulationCanvas, launchCanvas, resetCanvas, halo;

    public float density = 1;

    public static Vector3 findAcceleration()
    {
        Rocket rocket = GameObject.Find("Rocket").GetComponent<Rocket>();
        Planet[] planets = GameObject.FindObjectsOfType<Planet>();

        Vector3 acceleration = Vector3.zero;
        foreach (Planet p in planets)
        {

            float squareDistance = Mathf.Pow(Vector3.Distance(p.getPosition(), rocket.getPosition()), 2);
            float magnitude = (6.67f * Mathf.Pow(10, -1)) * p.getMass() / (squareDistance);
            Vector3 newAcceleration = p.getPosition() - rocket.getPosition();
            newAcceleration.Normalize();
            newAcceleration *= magnitude;

            acceleration += newAcceleration;
        }
        //Debug.Log(acceleration.y);
        return acceleration;
    }

    public static void ActivatePlanetMode(Planet planet)
    {
        halo.transform.position = planet.getPosition();
        RenderSettings.haloStrength = planet.getRadius()/1.5f + Planet.haloSize;
        selectedPlanet = planet;
        planetManipulationCanvas.SetActive(true);
        Slider planetSizeSlider = GameObject.Find("Slider").GetComponent<Slider>();
        planetSizeSlider.normalizedValue = (selectedPlanet.getRadius() - selectedPlanet.getLowerSize()) /
            (selectedPlanet.getUpperSize() - selectedPlanet.getLowerSize());
    }

    public static void DeactivatePlanetMode()
    {
        halo.transform.position = new Vector3(0, 0, 200);
        planetManipulationCanvas.SetActive(false);
    }

    public void setPlanetSize()
    {
        float value = GameObject.Find("Slider").GetComponent<Slider>().normalizedValue;
        float newRadius = (selectedPlanet.getUpperSize() - selectedPlanet.getLowerSize()) * value
            + selectedPlanet.getLowerSize();
        RenderSettings.haloStrength = newRadius/1.5f + Planet.haloSize;
        selectedPlanet.setRadiusAndMass(newRadius);

        //Debug.Log("H");
    }

    public void reset()
    {
        isLaunched = false;
        GameObject.Find("Rocket").GetComponent<Rocket>().resetPosition();
        resetCanvas.SetActive(false);
        launchCanvas.SetActive(true);
    }
    public void launch()
    {
        isLaunched = true;
        DeactivatePlanetMode();
        launchCanvas.SetActive(false);
        resetCanvas.SetActive(true);
    }

    public static void fail()
    {
        isLaunched = false;
        Debug.Log("loss");
    }

    public static void win()
    {
        isLaunched = false;
        Debug.Log("win!");
        resetCanvas.SetActive(false);
    }

    // Use this for initialization
    void Start()
    {
        halo = GameObject.Find("Halo");
        planetManipulationCanvas = GameObject.Find("PlanetMode");
        launchCanvas = GameObject.Find("Launch");
        resetCanvas = GameObject.Find("Reset");

        DeactivatePlanetMode();
        resetCanvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
    }
}
