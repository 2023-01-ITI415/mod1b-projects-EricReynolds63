using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : MonoBehaviour
{
    public static float bottomY = -20f;
    public int points = 100;

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < bottomY) {
            Destroy(this.gameObject);
            if (points != -27) {
                ApplePicker apScript = Camera.main.GetComponent<ApplePicker>();
                apScript.AppleMissed();
            }
        }
    }
}
