using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GoTime : MonoBehaviour
{

	public TextMeshProUGUI goGO;
	public GameController GC;

    // Start is called before the first frame update
    void Start()
    {
		goGO.text = "";
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (GC.areaUnlock) {
			goGO.text = "GO! >";
		} else {
			goGO.text = "";
		}
    }
}