using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class deployEnemyPlanes : MonoBehaviour
{

    public GameObject enemyPrefab;
    public GameObject mainPlane;
    private int difficulty;
    // Start is called before the first frame update
    void Update()
    {
        difficulty = Mathf.CeilToInt(mainPlane.GetComponent<planeMovement>().score/10000);
        if (GameObject.FindGameObjectsWithTag("Enemy").Length < difficulty) {
            spawnEnemy();

        }
        print(GameObject.FindGameObjectsWithTag("Enemy").Length);
    }
    private void spawnEnemy() 
    {
        GameObject enemy = Instantiate(enemyPrefab) as GameObject;
        
    }



}
