using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArenaController : MonoBehaviour
{
	public GameObject player;
	public GameObject arena;

	[Header("Inscribed")]
	public GameObject pipPrefab;
	public GameObject ghostPrefab;
	public GameObject ghostTrailPrefab;
	
	public float pipDropDelay = 1f;
	public float ghostDelay = 1f;
	public float arenaX = 30f;
	public float arenaY = 20f;
	public int levelNum = 0;
	public int offset = 0;

	[Header("Dynamic")]
	public bool active = true;
	public bool resetTrig = false;

	// Start is called before the first frame update
	void Start()
    {
		//Start Dropping Pips
		Invoke("DropPip", 3f);
		Invoke("SpawnGhost", 3f);
		if (levelNum == 0) {
			offset = 0;
		}
		if (levelNum == 1) {
			offset = 60;
		}
		if (levelNum == 2) {
			offset = 120;
		}

		//Correct Trigger Zone
		Vector3 box = Vector3.one;
		box.x = arenaX;
		box.y = 20;
		box.z = arenaY;
		gameObject.GetComponent<BoxCollider>().size = box;

	}

    // Update is called once per frame
    void Update()
    {
		// If player is not in trigger zone, stop dropping pips and spawning ghosts
        if (	player.transform.position.x > (arenaX / 2) + offset || player.transform.position.x < -(arenaX / 2) + offset  ||
				player.transform.position.z > (arenaY / 2)  || player.transform.position.z < -(arenaY / 2)
			)	{
					active = false;
					resetTrig = true;
				} else {
					active = true;
					if (resetTrig == true) {
						Invoke("DropPip", pipDropDelay);
						Invoke("SpawnGhost", ghostDelay);
						resetTrig = false;
					}
				}
    }

	void DropPip()
	{
		if (active) {
			GameObject pip;
			Vector3 pos = new Vector3();
				pos.z = transform.position.z + Random.Range(-(arenaY/2), (arenaY/2));
				pos.x = transform.position.x + Random.Range(-(arenaX/2), (arenaX/2));
				pos.y = 10;
			pip = Instantiate<GameObject>(pipPrefab);
				pip.transform.position = pos;
			Invoke("DropPip", pipDropDelay);
		}
	}

	void SpawnGhost()
	{
		if (active) {
			GameObject ghost;
			int side = Random.Range(0, 4);

			Vector3 pos = new Vector3();
			int rot = 0;
		
			pos.y = 1;

			switch (side) {

			case 0:	//North (+1/2 , Range) Rot = 180
				pos.z = transform.position.z + (arenaY / 2) + 5;
				pos.x = transform.position.x + Random.Range(-(arenaX / 2), (arenaX / 2));
				rot = 180;
				break;

			case 1: //East	(Range, +1/2) Rot = 90
				pos.z = transform.position.z + Random.Range(-(arenaY / 2), (arenaY / 2));
				pos.x = transform.position.x +  (arenaX / 2) + 5;
				rot = 90;
				break;

			case 2:	//South (-1/2 , Range) Rot = 0
				pos.z = transform.position.z + -(arenaY / 2) - 5;
				pos.x = transform.position.x + Random.Range(-(arenaX / 2), (arenaX / 2));
				rot = 0;
				break;

			case 3:	//West	(Range, -1/2) Rot = 270
				pos.z = transform.position.z + Random.Range(-(arenaY / 2), (arenaY / 2));
				pos.x = transform.position.x + -(arenaX / 2) - 5;
				rot = 270;
				break;

			}
		
			ghost = Instantiate<GameObject>(ghostPrefab);
			ghost.GetComponent<Ghost>().despawn += offset;
			Instantiate<GameObject>(ghostTrailPrefab, ghost.transform);
			ghost.transform.position = pos;
			ghost.transform.Rotate(0,0,rot);
			ghost.GetComponent<Ghost>().rot = rot;
			Invoke("SpawnGhost", ghostDelay);
		}
	}
}
