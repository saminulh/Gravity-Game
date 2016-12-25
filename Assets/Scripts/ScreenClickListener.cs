using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ScreenClickListener : MonoBehaviour {

    void OnMouseDown()
    {
        if (!EventSystem.current.IsPointerOverGameObject())
        {
            GameManager.DeactivatePlanetMode();
        }
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
