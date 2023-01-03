﻿using UnityEngine;
using System.Collections;

public class DoorTrigger : MonoBehaviour {

	public Door door;
	public bool ignoreTrigger;

	void OnTriggerEnter2D(Collider2D target){

		if (ignoreTrigger)
			return;

		if (target.gameObject.tag == "Player") {
			door.Open ();
		}
	}

	void OnTriggerExit2D(Collider2D target){

		if (ignoreTrigger)
			return;
		
		if (target.gameObject.tag == "Player") {
			StartCoroutine(WT());
			door.Close ();
		}
	}

	IEnumerator WT(){
		yield return new WaitForSeconds (5f);
	}

	public void Toggle(bool value){
		if (value) {
			door.Open ();
		} else {
			door.Close ();
		}
	}

	void OnDrawGizmos(){

		Gizmos.color = ignoreTrigger ? Color.gray : Color.green;

		var bc2D = GetComponent<BoxCollider2D> ();
		var pos = bc2D.transform.position;

		var newPos = new Vector2 (pos.x + bc2D.offset.x, pos.y + bc2D.offset.y);
		Gizmos.DrawWireCube (newPos, new Vector2 (bc2D.size.x, bc2D.size.y));

	}
}
