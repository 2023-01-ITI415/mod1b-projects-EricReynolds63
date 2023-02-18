using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour
{
	public float rot;
	public float speed = 3;
	public int despawn = 50;
	private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
		
        rb = GetComponent<Rigidbody>();
		Vector2 move = new Vector2();
		switch (rot) {

		case 0:		//South (-1/2 , Range) Rot = 0
			move.x = 0;
			move.y = 100;
			break;

		case 90:	//East	(Range, +1/2) Rot = 90
			move.x = -100;
			move.y = 0;
			break;

		case 180:	//North (+1/2 , Range) Rot = 180
			move.x = 0;
			move.y = -100;
			break;

		case 270:	//West	(Range, -1/2) Rot = 270
			move.x = 100;
			move.y = 0;
			break;

		}
		Vector3 movement = new Vector3(move.x, 0.0f, move.y);
		rb.AddForce(movement * speed);
    }

    // Update is called once per frame
    void Update()
    {
		//If the ghost gets too far from the maze, despawn
        if ( (Mathf.Abs(transform.position.x) > despawn) || (Mathf.Abs(transform.position.z) > despawn) ) {
			Destroy(gameObject);
		}
    }
}
