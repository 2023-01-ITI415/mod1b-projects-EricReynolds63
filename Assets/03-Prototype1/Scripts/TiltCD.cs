using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TiltCD : MonoBehaviour
{

	public TextMeshProUGUI tiltGO;
	public GameController GC;

    // Start is called before the first frame update
    void Start()
    {
		tiltGO.text = "";
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (GC.bumpCD) {
			tiltGO.text = "! TILT !";
		} else {
			tiltGO.text = "";
		}
    }
}
