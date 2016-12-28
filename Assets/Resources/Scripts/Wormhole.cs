using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wormhole : MonoBehaviour {
    Light halo;
    public Wormhole pairup;
    GameObject pipeline;
    void OnMouseUp()
    {
        if (GameManager.selectedWormhole == null)
        {
            GameManager.DeactivateWormholeMode();
            halo.color = Color.green;
            GameManager.ActivateWormholeMode(this);
        }
        else
        {
            PairWormholes(GameManager.selectedWormhole, true);
            GameManager.DeactivateWormholeMode();
        }   
    }

    public void PairWormholes(Wormhole matchup, bool firstTime)
    {
        if (pairup != null)
        {
            pairup.UnpairWormholes();
            UnpairWormholes();
        }
        pairup = matchup;
        if (firstTime)
        {
            matchup.PairWormholes(this, false);
            pipeline = (GameObject) Instantiate(Resources.Load("Prefabs/Pipeline"));

            pipeline.transform.position = 0.5f * (gameObject.transform.position + pairup.gameObject.transform.position);

            Vector3 distVector = gameObject.transform.position - pairup.gameObject.transform.position;
            Debug.Log(distVector);
            pipeline.transform.localScale += new Vector3(0,
                Vector3.Magnitude(distVector)/ 2f - pipeline.transform.localScale.y, 0);

            Quaternion rotation = new Quaternion();

            distVector = new Vector3(-distVector.y, distVector.x, 0);

            rotation.SetLookRotation(distVector, Vector3.left);
            pipeline.transform.localRotation = rotation;

            pipeline.transform.parent = gameObject.transform;
        }
    }

    public void UnpairWormholes()
    {
        pairup = null;
        if (pipeline != null)
        {
            GameObject.Destroy(pipeline);
            pipeline = null;
        }
    }

    public void ActivateHalo()
    {
        halo.gameObject.SetActive(true);
    }

    public void DeactivateHalo()
    {
        halo.color = Color.red;
        halo.gameObject.SetActive(false);
    }

	// Use this for initialization
	void Start () {
        halo = GameObject.Find(gameObject.name + "/Halo").GetComponent<Light>();
        DeactivateHalo();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
