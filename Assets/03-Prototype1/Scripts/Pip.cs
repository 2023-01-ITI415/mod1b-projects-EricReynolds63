using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pip : MonoBehaviour
{
	[Header("Inscribed")]
	public float decay = 7f;

    // Start is called before the first frame update
    void Start()
    {
		//Decay after time
		Invoke("Decay", decay);
	}

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -5) {
			Destroy(gameObject);
		}
    }

	void Decay()
	{
		Destroy(gameObject);
	}
}
