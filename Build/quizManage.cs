using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class quizManage : MonoBehaviour
{
    public List<questionsAndAnswers> QnA;
    public List<questionsAndAnswers> newQnA;
    public GameObject[] options;
    public int currentQuestion;
    public GameObject plane;
    public TextMeshProUGUI QuestionTxt;
    public TextMeshProUGUI optionOne;
    public TextMeshProUGUI optionTwo;
    public TextMeshProUGUI optionThree;
    public TextMeshProUGUI optionFour;
    private void Start()
    {
        generateQuestion();
        newQnA = QnA;
    }
    
    public void correct() {
        generateQuestion();
        plane.GetComponent<planeMovement>().hideQuestions();
    }
    void SetAnswers()
    {
        for (int i=0; i<4; i++) {
            options[i].GetComponent<AnswerScript>().isCorrect = false;
            if (QnA[currentQuestion].CorrectAnswer == i+1)
            {
                options[i].GetComponent<AnswerScript>().isCorrect = true;
            }
        }
        optionFour.SetText(QnA[currentQuestion].Answers[3]);
        optionThree.SetText(QnA[currentQuestion].Answers[2]);
        optionTwo.SetText(QnA[currentQuestion].Answers[1]);
        optionOne.SetText (QnA[currentQuestion].Answers[0]);

        
    }
    void generateQuestion()
    {
        currentQuestion = Random.Range(0, QnA.Count);

        QuestionTxt.SetText(QnA[currentQuestion].Question);
        SetAnswers();
        if (QnA.Count > 1) {
            QnA.RemoveAt(currentQuestion);
        }
        else {
            QnA = newQnA;
        }
    }
}
