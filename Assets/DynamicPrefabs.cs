using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DynamicPrefabs : MonoBehaviour {
	public GameObject fire;
    public GameObject items;
    float timeElapsed = 0;
    public float ItemCycle = 3f;
    bool ItemPowerup = true;
    void Update () {
        timeElapsed += Time.deltaTime;
        if(timeElapsed > ItemCycle)
        {
            GameObject temp;
            if(ItemPowerup)
            {
                temp = (GameObject)Instantiate(items);
                Vector3 pos = temp.transform.position;
                temp.transform.position = new Vector3(pos.x, pos.y, pos.z);
            }
            else
            {
                temp = (GameObject)Instantiate(fire);
                Vector3 pos = temp.transform.position;
                temp.transform.position = new Vector3(Random.Range(-2, 2), pos.y, pos.z);
            }
            timeElapsed -= ItemCycle;
            ItemPowerup = !ItemPowerup;
        }
    }
}
