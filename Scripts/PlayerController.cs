using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float speed;
	private Rigidbody rb;
	public float jumpForce;
	private bool isJumping;

	void Start ()
	{
		rb = GetComponent<Rigidbody> ();
		isJumping = false;
	}

	void FixedUpdate ()
	{
		float mvHorizontal = Input.GetAxis ("Horizontal");
		float mvVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (mvHorizontal, 0.0f, mvVertical);

		if (Input.GetButton ("Jump") && isJumping == false) {
			movement.y = jumpForce;
			isJumping = true;
		}

		rb.AddForce (movement * speed);

		if (rb.velocity.y == 0) { isJumping = false; }
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag ("Pick Up")) {
			other.gameObject.SetActive (false);
		} else if (other.gameObject.CompareTag ("Respawn")) {
			transform.position = new Vector3 (0.0f, 0.5f, 0.0f);
			rb.velocity = new Vector3 (0.0f, 0.0f, 0.0f);
		}
	}
}