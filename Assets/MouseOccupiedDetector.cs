using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MouseOccupiedDetector : MonoBehaviour, ISelectHandler, IDeselectHandler {

	public void OnSelect(BaseEventData eventData)
    {
        Debug.Log("HI");
        GameManager.mouseOccupied = true;
    }

    public void OnDeselect(BaseEventData eventData)
    {
        GameManager.mouseOccupied = false;
    }
}
