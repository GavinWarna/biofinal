using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class planeMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody2D rb;
    public Transform tf; 
    public Transform tfTwo;
    public Transform me;
    public float planeSpeed = 1f;
    public int inFront = 0;
    public int score = 0;
    public TextMeshProUGUI tp;
    public TextMeshProUGUI sc;
    public TextMeshProUGUI fsc;
    public bool question = false;
    public string[] answers = {"answerOne", "answerTwo", "answerThree", "answerFour"};
    public GameObject a;
    public GameObject b;
    public GameObject c;
    public GameObject d;
    public GameObject e;
    public GameObject f;

    public float timePassed = 0f;
    void Start()
    {
        hideQuestions();
       
       // askQuestion("test Question", answers);
    }

    // Update is called once per frame
    void Update()
    {
    
        if (!question) {
            Time. timeScale = 1;
            tp.SetText(Mathf.FloorToInt(planeSpeed).ToString());
             if (Input.GetKey(KeyCode.UpArrow)) {
                me.Translate(new Vector3(0, 5, 0)  * Time.deltaTime);
    
            }
            if (Input.GetKey(KeyCode.DownArrow)) {
                me.Translate(new Vector3(0, -5, 0)  * Time.deltaTime);
            }
            /*if (planeSpeed > 100) {
                if (Input.GetKey(KeyCode.LeftArrow)) {
                    planeSpeed --;
                }
            }
            if (planeSpeed < 1000) {
                if (Input.GetKey(KeyCode.RightArrow)) {
                    planeSpeed ++;
                }
            }*/
            tf.Translate(new Vector3(-.1f*planeSpeed, 0, 0)  * Time.deltaTime);
            tfTwo.Translate(new Vector3(-.1f*planeSpeed, 0, 0)  * Time.deltaTime);
    
            if (inFront == 0) {
                tf.Translate(new Vector3(-.1f*planeSpeed, 0, 0)  * Time.deltaTime);
                tfTwo.position = new Vector3(tf.position.x+25.5f, 0, 0);
            }
            if (inFront == 1) {
                tfTwo.Translate(new Vector3(-.1f*planeSpeed, 0, 0)  * Time.deltaTime);
                tf.position = new Vector3(tfTwo.position.x+25.5f, 0, 0);
            }
            if (tf.position.x<=-25) {
                inFront = 1;
            
            }
            if (tfTwo.position.x<=-25) {
                inFront = 0;
            
            }
            score += Mathf.FloorToInt(planeSpeed/100f);
            //Debug.Log(score.ToString());
            sc.SetText(Mathf.FloorToInt(score).ToString());
            timePassed += Time.deltaTime;
            if(timePassed > 10f)
            {
                timePassed = 0f;
                //rb.useGravity = false;
                rb.velocity = new Vector3(0, 0, 0);
                showQuestions();
            }
            if (planeSpeed<=1000) {
            planeSpeed+= Time.deltaTime*10;
        }
        }
        else {
            Time.timeScale = 0;
        }

    
    }
    public void showQuestions() {
        a.SetActive(true);
        b.SetActive(true);
        c.SetActive(true);
        d.SetActive(true);
        e.SetActive(true); 
 
        question = true;
    }
    public void hideQuestions() {
        a.SetActive(false);
        b.SetActive(false);
        c.SetActive(false);
        d.SetActive(false);
        e.SetActive(false); 
        question = false;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //hideQuestions();
        if (collision.gameObject.name == "edgeOne" ) {
            me.position = new Vector2(-7.12f, -3.85f);
        }
        else if (collision.gameObject.name == "edgeTwo") {
            me.position = new Vector2(-7.12f, 3.85f);
        }
        else {
            
 
            f.SetActive(true);
            question = true;
            fsc.SetText("Your score was \n"+score.ToString());

        }
        //SceneManager.LoadScene("Lose");

    }

}
