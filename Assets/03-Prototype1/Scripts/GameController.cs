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
	//public GameObject arenaOnePrefab;
	public GameObject arenaControllerPrefab;
	public GameObject arenaTwoPrefab;
	public GameObject arenaThreePrefab;

	[Header("Inscribed")]
	public int maxLives = 3;
	public float bumpSpeed = 3.5f;
	public bool bumpCD = true;

	[Header("Dynamic")]
	public int lives = 0;
	public int score = 0;
	public bool areaUnlock = false;
	public bool winner = false;

	//Level Control
	private bool areaOneUnlocked = false;
	private bool areaTwoUnlocked = false;
	//private bool areaThreeUnlocked = false;

	// Start is called before the first frame update
	void Start()
    {
		master = this;
        lives = maxLives;
		Invoke("bumpRefresh", 3f);
    }

    // Update is called once per frame
    void Update()
    {
		// No more ghosts if the game is over
		if (winner == true) {
			foreach (GameObject ghost in allGhosts) {
				Destroy(ghost);
			}
			allGhosts.Clear();
		}
		// If player has fallen off the map or touched a ghost, reset
        if ( (player.transform.position.y < -5) || (player.GetComponent<PlayerController>().dead) ) {
			arenaReset();
		}

		// NEXT AREA SPAWN SCRIPT
		if ( score >= 100 && areaOneUnlocked == false ) {
			areaOneUnlocked = true;
			goTime();
			Vector3 LevTwo = Vector3.zero;
			LevTwo.x = 60;
			GameObject areaTwo = Instantiate<GameObject>(arenaTwoPrefab);
				GameObject ACTwo = Instantiate<GameObject>(arenaControllerPrefab);
				ArenaController ACT = ACTwo.GetComponent<ArenaController>();
				//ACT.ghostDelay = 0.75f;
				ACT.levelNum = 1;
				ACT.player = player;
				ACT.arena = areaTwo;
				ACT.arenaX = 40;
				ACT.active = true;
				ACT.pipDropDelay = 0.8f;
				ACT.ghostDelay = 0.8f;
			areaTwo.transform.position = LevTwo;
				LevTwo.y = 15;
				ACTwo.transform.position = LevTwo;
			Invoke("resetGoTime", 20f);
		}
		if ( score >= 500 && areaTwoUnlocked == false ) {
			areaTwoUnlocked = true;
			goTime();
			Vector3 LevThree = Vector3.zero;
			LevThree.x = 120;
			GameObject areaThree = Instantiate<GameObject>(arenaThreePrefab);
				GameObject ACThree = Instantiate<GameObject>(arenaControllerPrefab);
				ArenaController ACT = ACThree.GetComponent<ArenaController>();
				//ACT.ghostDelay = 0.75f;
				ACT.levelNum = 2;
				ACT.player = player;
				ACT.arena = areaThree;
				ACT.arenaX = 40;
				ACT.active = true;
				ACT.pipDropDelay = 0.5f;
				ACT.ghostDelay = 0.3f;
			areaThree.transform.position = LevThree;
				LevThree.y = 15;
				ACThree.transform.position = LevThree;
			Invoke("resetGoTime", 20f);
		}
		if ( score >= 2000) { //&& areaThreeUnlocked == false ) {
			//areaThreeUnlocked = true;
			//goTime();
			//Invoke("resetGoTime", 20f);
			winner = true;
		}

    }

	void goTime() {
		areaUnlock = true;
	}

	void resetGoTime() {
		areaUnlock = false;
	}

	// BUMP/SHAKE METHOD
	public static void bump(GameObject player) {
		if (master.bumpCD == false) {
			Vector3 bump = Vector3.zero;
			bump.x = Random.Range(-50, 50);
			bump.y = 100 * master.bumpSpeed;
			bump.z = Random.Range(-50, 50);
			player.GetComponent<Rigidbody>().AddForce(bump);
			foreach (GameObject pip in master.allPips) {
				pip.GetComponent<Rigidbody>().AddForce(bump);
			}
			master.bumpCD = true;
			master.Invoke("bumpRefresh", 3f);
		}
	}

	void bumpRefresh() {
		bumpCD = false;
	}

	void arenaReset() {
		if (lives > 1) {
			//Remove a life
			lives -= 1;
			//Put player back
			Vector3 origin = Vector3.zero;
			origin.y = 1;
				//Account for which level
				if (areaOneUnlocked) { origin.x = 60; origin.y += 2; }
				if (areaTwoUnlocked) { origin.x = 120; origin.y += 1; }
			player.GetComponent<PlayerController>().dead = false;
			player.transform.position = origin;
			//Remove pips
			foreach (GameObject pip in allPips) {
				Destroy(pip);
			}
			allPips.Clear();
			//Remove ghosts
			foreach (GameObject ghost in allGhosts) {
				Destroy(ghost);
			}
			allGhosts.Clear();
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
