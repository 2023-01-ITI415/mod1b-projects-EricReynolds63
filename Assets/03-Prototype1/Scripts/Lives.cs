using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Lives : MonoBehaviour
{

	public TextMeshProUGUI livesGO;
	public GameController GC;

    // Start is called before the first frame update
    void Start()
    {
		livesGO.text = "O O O";
    }

    // Update is called once per frame
    void Update()
    {
        setScore();
    }

	void setScore() {
		if (GC.lives == 3) {
			livesGO.text = "O O O";
		}
		if (GC.lives == 2) {
			livesGO.text = "O O";
		}
		if (GC.lives == 1) {
			livesGO.text = "O";
		}
		if (GC.lives == 0) {
			livesGO.text = "";
		}
		
	}

}
