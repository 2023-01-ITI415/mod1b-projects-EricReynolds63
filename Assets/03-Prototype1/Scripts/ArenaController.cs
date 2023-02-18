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
		Vector3 pos = new Vector3();
		pos.z = transform.position.z + Random.Range(-(arenaY / 2), (arenaY / 2));
		pos.x = transform.position.x + Random.Range(-(arenaX / 2), (arenaX / 2));
		pos.y = 1;
		ghost = Instantiate<GameObject>(ghostPrefab);
		ghost.transform.position = pos;
		Invoke("SpawnGhost", ghostDelay);
	}
}
