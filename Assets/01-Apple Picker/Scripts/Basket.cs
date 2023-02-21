using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basket : MonoBehaviour
{
    public ScoreCounter scoreCounter;
    public AppleTree theTree;

    // Start is called before the first frame update
    void Start()
    {
        GameObject scoreGO = GameObject.Find("ScoreCounter");
        scoreCounter = scoreGO.GetComponent<ScoreCounter>();
        GameObject treeGO = GameObject.Find("AppleTree");
        theTree = treeGO.GetComponent<AppleTree>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos2D = Input.mousePosition;
        mousePos2D.z = -Camera.main.transform.position.z;
        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);
        Vector3 pos = this.transform.position;
        pos.x = mousePos3D.x;
        this.transform.position = pos;
    }

    void OnCollisionEnter(Collision coll)
    {
        GameObject collidedWith = coll.gameObject;
        if (collidedWith.CompareTag("Apple")) {
            Destroy(collidedWith);
            if (collidedWith.GetComponent<Apple>().points == -27) {
                scoreCounter.score = scoreCounter.score - (scoreCounter.score / 2);
            } else if (collidedWith.GetComponent<Apple>().points == 500) {
                scoreCounter.score += (collidedWith.GetComponent<Apple>().points * ( 1 + (Mathf.RoundToInt(scoreCounter.score / 10000))));
            } else {
                scoreCounter.score += collidedWith.GetComponent<Apple>().points;
            }
            HighScore.TRY_SET_HIGH_SCORE(scoreCounter.score);
            // Speed up tree as score increases, tree gets 1 point faster for every 1000 points
            theTree.speed = 12 +  Mathf.RoundToInt( scoreCounter.score / 1000);
            theTree.poisonChance = 0.05f + ( 0.03f * (Mathf.RoundToInt(scoreCounter.score / 1000)));
            theTree.goldenChance = 0.1f + (0.1f * (Mathf.RoundToInt(scoreCounter.score / 10000)));
            theTree.appleDropDelay = 1f - (0.05f * Mathf.RoundToInt(scoreCounter.score / 100000));
        }
    }
}
