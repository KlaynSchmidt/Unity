using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {
	float v;
	float h;
	Rigidbody rb;
	Transform tr;
	bool isGrounded = false;

	void Start () {
		tr = GetComponent<Transform> ();
		rb = GetComponent<Rigidbody> ();
	}
	

	void Update () {
		Vector3 force = new Vector3 (0, 0, v);
		v = Input.GetAxis ("Vertical");
		h = Input.GetAxis ("Horizontal");
		rb.AddForce (tr.forward * v * 100f);
		Vector3 rotation = new Vector3 (0, h, 0);
		tr.Rotate (rotation * 5f);

		if (Input.GetKeyDown (KeyCode.Space) && isGrounded == true) {
			Vector3 jump = new Vector3 (0, 10, 0);
			rb.velocity = jump;
			isGrounded = false;
			h = 0;v = 0;
		}
	}

	void OnCollisionStay(Collision arg){
		isGrounded = true;

	}
	void OnCollisionEnter(Collision arg){
		if (arg.gameObject.tag == "Enemy") {
			rb.AddForce (tr.forward * v * 1000f);
		}
	}
}
