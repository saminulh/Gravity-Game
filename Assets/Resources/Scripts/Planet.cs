using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Planet : MonoBehaviour
{
    Vector3 position;
    float defaultRadius, radius, lowerSize, upperSize, density, mass;
    public float lowerSizePercentage = 0.25f, upperSizePercentage = 5;
    bool planetChanged;
    public static float haloSize = 2.5f;
    
    public bool endPlanet = false;

    void OnMouseUp()
    {
        if (!GameManager.isLaunched && !endPlanet && !EventSystem.current.IsPointerOverGameObject())
        {
            //Debug.Log("Pressed");
            GameManager.ActivatePlanetMode(this);
        }
    }

    public void setRadiusAndMass(float r)
    {
        radius = r;
        mass = density * 4 / 3 * Mathf.PI * Mathf.Pow(radius, 3);
        planetChanged = true;
    }

    public void incrementRadius(float increment)
    {
        setRadiusAndMass(radius + increment);
    }

    public float getRadius()
    {
        return radius;
    }

    public float getLowerSize()
    {
        return lowerSize;
    }

    public float getUpperSize()
    {
        return upperSize;
    }

    public float getMass()
    {
        return mass;
    }

    public Vector3 getPosition()
    {
        return position;
    }
    // Use this for initialization
    void Start()
    {
        defaultRadius = gameObject.transform.localScale.x;
        lowerSize = lowerSizePercentage * defaultRadius;
        upperSize = upperSizePercentage * defaultRadius;
        radius = defaultRadius;
        density = GameObject.Find("Game Manager").GetComponent<GameManager>().density;
        setRadiusAndMass(defaultRadius);
        position = gameObject.transform.position;
        planetChanged = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (planetChanged)
        {
            gameObject.transform.localScale = new Vector3(radius, radius, radius);
            planetChanged = false;
        }
    }
}
