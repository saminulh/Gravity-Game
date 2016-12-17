using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCollision : MonoBehaviour {

    void OnCollisionEnter(Collision collision)
    {
        if (GameManager.isLaunched)
        {
            if (collision.gameObject.name == "End Planet")
            {
                GameManager.win();
            }
            else
            {
                GameManager.fail();
            }
        }
    }
}
