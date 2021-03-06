﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public PlayerController player;
    public GameObject maletas;
    public float intervalTime = 2f;
    public float rangeCreation = 2f;

	// Use this for initialization
	void Start () {
        InvokeRepeating("Create", 0.0f, intervalTime);
        if (PlayerPrefs.GetInt("ayuda") == 1)
        {
            maletas.GetComponent<Rigidbody2D>().gravityScale = 0.02f; //baja la velocidad de las maletas porque tiene la ayuda
        }

        else
        {
            maletas.GetComponent<Rigidbody2D>().gravityScale = 0.05f; //velocidad estándar
        }
        
    }

    // Update is called once per frame
    void Update () {
		
	}

    public void Create ()
    {
        Vector3 SpawnPosition = new Vector3(0, 0, 0);
        SpawnPosition = this.transform.position + Random.onUnitSphere * rangeCreation;
        SpawnPosition = new Vector3(SpawnPosition.x, this.transform.position.y, 0);

        GameObject maleta = Instantiate(maletas, SpawnPosition, Quaternion.identity);
    }
}
