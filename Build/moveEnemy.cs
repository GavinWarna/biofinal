using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveEnemy : MonoBehaviour
{
    public Transform em;
    public GameObject mainPlane;
    public float enemySpeed;
    // Start is called before the first frame update
    void Start()
    {
        enemySpeed=-10f;
    }

    // Update is called once per frame
    void Update()
    {
        //enemySpeed = mainPlane.GetComponent<planeMovement>().planeSpeed*Random.Range(-.01f, -.05f);
        em.Translate(new Vector3(enemySpeed, 0, 0)  * Time.deltaTime);
        if (em.position.x<=-10) {
            em.position = new Vector3(Random.Range(10f,15f), Random.Range(3.55f,-3.55f), -1);
            enemySpeed = mainPlane.GetComponent<planeMovement>().planeSpeed*Random.Range(-.01f, -.05f);
        }
    }
}
