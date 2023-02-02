using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour
{
    [Header("Inscribed")]
    public GameObject applePrefab;
    public float speed = 1f;
    public float leftAndRightEdge = 10f;    //Distance to turn around
    public float changeDirChance = 0.1f;
    public float appleDropDelay = 1f;

    // Start is called before the first frame update
    void Start()
    {
        //Start Dropping Apples   
    }

    // Update is called once per frame
    void Update()
    {
        //Basic Movement
            Vector3 pos = transform.position;
            pos.x += speed * Time.deltaTime;
            transform.position = pos;
        //Change Direction
        if (pos.x < -leftAndRightEdge){
            speed = Mathf.Abs(speed);
        } else if (pos.x > leftAndRightEdge){
            speed = -Mathf.Abs(speed);
        }
    }

    private void FixedUpdate()
    {
        if (Random.value < changeDirChance){
            speed *= -1;
        }
    }
}
