using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Victory : MonoBehaviour
{

	public TextMeshProUGUI vGO;
	public GameController GC;

    // Start is called before the first frame update
    void Start()
    {
		vGO.text = "";
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (GC.winner) {
			vGO.text = "You are the greatest to ever do it.";
			GC.bumpCD = false;
		} else {
			vGO.text = "";
		}
    }
}