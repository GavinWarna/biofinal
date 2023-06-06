using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
 using UnityEngine.SceneManagement;
public class AnswerScript : MonoBehaviour
{
    public bool isCorrect = false;
    public quizManage quizManager;
    public GameObject f;
    public TextMeshProUGUI fsc;
    public GameObject mainPlane;
   
    public void Answer()
    {
        if (isCorrect)
        {
            Debug.Log("Correct Answer");
            quizManager.correct();
        }
        else {
            f.SetActive(true);
            mainPlane.GetComponent<planeMovement>().question = true;
            fsc.SetText("Your score was \n"+mainPlane.GetComponent<planeMovement>().score.ToString());
        }
    }
}
