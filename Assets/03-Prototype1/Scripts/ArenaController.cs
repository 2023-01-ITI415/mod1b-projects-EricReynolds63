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

	// Start is called before the first frame update
	void Start()
    {
		//Start Dropping Pips
		Invoke("DropPip", 3f);
		Invoke("SpawnGhost", 3f);
	}

    // Update is called once per frame
    void Update()
    {
        
    }

	void DropPip()
	{
		GameObject pip;
		Vector3 pos = new Vector3();
			pos.z = transform.position.z + Random.Range(-(arenaY/2), (arenaY/2));
			pos.x = transform.position.x + Random.Range(-(arenaX/2), (arenaX/2));
			pos.y = 10;
		pip = Instantiate<GameObject>(pipPrefab);
			pip.transform.position = pos;
		Invoke("DropPip", pipDropDelay);
	}

	void SpawnGhost()
	{
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
		Instantiate<GameObject>(ghostTrailPrefab, ghost.transform);
		ghost.transform.position = pos;
		ghost.transform.Rotate(0,0,rot);
		ghost.GetComponent<Ghost>().rot = rot;
		Invoke("SpawnGhost", ghostDelay);
	}
}
