using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ScreenClickListener : MonoBehaviour {
    float startTime, endTime;

    void OnMouseDown()
    {
        startTime = Time.time;

    }
    void OnMouseUp()
    {
        endTime = Time.time;
        //Debug.Log(endTime - startTime);
        if (!EventSystem.current.IsPointerOverGameObject() && endTime-startTime < 0.03)
        {
            GameManager.DeactivatePlanetMode();
            GameManager.DeactivateWormholeMode();
        }
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
