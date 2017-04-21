﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour {

	public GameObject bulletPrefab;
	public float rotationSpeed = 35;

	void Update(){
		transform.Rotate (Vector3.up * Time.deltaTime * rotationSpeed, Space.World);
	}

	void OnTriggerEnter(Collider co) {
		// Was it a Monster? Then Shoot it
		if (co.GetComponent<Monster>()) {
			GameObject g = (GameObject)Instantiate(bulletPrefab, transform.position, Quaternion.identity);
			g.GetComponent<Bullet>().target = co.transform;
		}
	}
}
