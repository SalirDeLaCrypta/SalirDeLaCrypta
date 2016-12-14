﻿using UnityEngine;
using System.Collections;

public class projectileEnnemi : MonoBehaviour {


	public float pointsDommage =1;

	void OnCollisionEnter2D (Collision2D coll){
		GameObject.Destroy (this.gameObject);
		//Debug.Log (coll.gameObject.transform.parent.name);

		Rigidbody2D rbTouche = coll.gameObject.GetComponent <Rigidbody2D>();
		if (coll.gameObject.transform.parent) {
			if (coll.gameObject.transform.parent.name == "Perso") {
				rbTouche.SendMessageUpwards ("Toucher", pointsDommage, SendMessageOptions.RequireReceiver);
			}

		}
	}

}
