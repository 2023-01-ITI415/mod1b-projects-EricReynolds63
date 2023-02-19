using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
	static private GameController master;

	public GameObject player;
	public List<GameObject> allPips = new List<GameObject>();
	public List<GameObject> allGhosts = new List<GameObject>();

	[Header("Inscribed")]
	public int maxLives = 3;

	[Header("Dynamic")]
	public int lives = 0;
	public int score = 0;

	// Start is called before the first frame update
	void Start()
    {
		master = this;
        lives = maxLives;
    }

    // Update is called once per frame
    void Update()
    {
		// If player has fallen off the map or touched a ghost, reset
        if ( (player.transform.position.y < -5) || (player.GetComponent<PlayerController>().dead) ) {
			arenaReset();
		}
    }

	void arenaReset() {
		if (lives > 1) {
			//Remove a life
			lives -= 1;
			Debug.Log("Lost a life, " + lives + " remain.");
			//Put player back
			Vector3 origin = Vector3.zero;
			origin.y = 1;
			player.GetComponent<PlayerController>().dead = false;
			player.transform.position = origin;
			//Remove pips
			foreach (GameObject pip in allPips) {
				Destroy(pip);
			}
			//Remove ghosts
			foreach (GameObject ghost in allGhosts) {
				Destroy(ghost);
			}
		} else {
			gameReset();
		}
		
	}

	void gameReset() {
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}

	//Allows other objects to help keep track of pips
	static public void addPip(GameObject pip) {
		master.allPips.Add(pip);
	}

	//Allows other objects to remove of pips from list
	static public void cullPip(GameObject pip) {
		master.allPips.Remove(pip);
	}

	//Allows other objects to help keep track of ghosts
	static public void addGhost(GameObject ghost) {
		master.allGhosts.Add(ghost);
	}

	//Allows other objects to remove of pips from list
	static public void cullGhost(GameObject ghost) {
		master.allGhosts.Remove(ghost);
	}

	//Allows other objects to get points for pips
	static public void eatPip(GameObject pip, int value) {
		//increment score
		master.score += value;
		//delete pip
		cullPip(pip);
		Destroy(pip);
	}
}
