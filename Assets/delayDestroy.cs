using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class delayDestroy : MonoBehaviour {
	float SecondsUntilDestroy = 7f;
    float startTime;
    // Use this for initialization
    void Start () {
        startTime = Time.time;
    }
    
    // Update is called once per frame
    void Update () {
        if (Time.time - startTime >= SecondsUntilDestroy) {
            Destroy(this.gameObject);
        }
    }
}
