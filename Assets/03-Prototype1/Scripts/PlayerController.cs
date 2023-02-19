using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
	public float speed = 0;
	public bool dead = false;

	private Rigidbody rb;

	private float movementX;
	private float movementY;

	// Start is called before the first frame update
	void Start()
	{
		dead = false;
		rb = GetComponent<Rigidbody>();
	}

	void OnMove(InputValue movementValue)
	{
		Vector2 movementVector = movementValue.Get<Vector2>();

		movementX = movementVector.x;
		movementY = movementVector.y;
	}

	void FixedUpdate()
	{
		Vector3 movement = new Vector3(movementX, 0.0f, movementY);

		rb.AddForce(movement * speed);
	}

	private void OnCollisionEnter(Collision collision)
	{
		GameObject other = collision.gameObject;
			Pip pip = other.GetComponent<Pip>();
		if (pip != null)  { 
			GameController.eatPip(other, pip.value);
		}

	}

}