using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{

	public TextMeshProUGUI scoreGO;
	public GameController GC;

    // Start is called before the first frame update
    void Start()
    {
		scoreGO.text = "0";
    }

    // Update is called once per frame
    void Update()
    {
        setScore();
    }

	void setScore() {
		scoreGO.text = GC.score.ToString();
	}

}
