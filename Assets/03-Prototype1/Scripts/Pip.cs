using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pip : MonoBehaviour
{
	[Header("Inscribed")]
	public float decay = 7f;
	public int value = 100;

    // Start is called before the first frame update
    void Start()
    {
		GameController.addPip(gameObject);
		//Decay after time
		Invoke("Decay", decay);
	}

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -5) {
			GameController.cullPip(gameObject);
			Destroy(gameObject);
		}
    }

	void Decay()
	{
		GameController.cullPip(gameObject);
		Destroy(gameObject);
	}
}
