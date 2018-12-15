using System.Collections;
using System.Collections.Generic;
using Project.Scripts;
using UnityEngine;

public class Enemy : Interactable, IDamagable {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void TakeDamage(int amount)
    {
        Debug.Log($"{transform.name} takes {amount} damage.");
    }
}
