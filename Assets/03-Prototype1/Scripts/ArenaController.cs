using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArenaController : MonoBehaviour
{
	public GameObject player;
	public GameObject arena;

	[Header("Inscribed")]
	public GameObject pipPrefab;
	public float pipDropDelay = 1f;
	public int arenaX = 30;
	public int arenaY = 20;

	// Start is called before the first frame update
	void Start()
    {
		//Start Dropping Pips
		Invoke("DropPip", 5f);
	}

    // Update is called once per frame
    void Update()
    {
        
    }

	void DropPip()
	{
		GameObject pip;
		Vector3 pos = new Vector3();
			pos.z = transform.position.z + Random.Range(-10.0f, 10.0f);
			pos.x = transform.position.x + Random.Range(-15.0f, 15.0f);
			pos.y = 10;
		pip = Instantiate<GameObject>(pipPrefab);
			pip.transform.position = pos;
		Invoke("DropPip", pipDropDelay);
	}
}
