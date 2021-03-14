using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
[System.Serializable]

public class QuestionWidget
{
    public Text questionText;
    public List<Button> buttons = new List<Button>(4);
}

public class QuestionPool : MonoBehaviour
{
    public List<Question> sorular;


    public QuestionWidget qw;

    public int r;

    public AudioClip trueSound;
    public AudioClip falseSound;

    public AudioSource au;

    public int trueCounter = 0;
    public int falseCounter = 0;

    [Range(0,15)] public int questionCount = 5;
    void Start()
    {
        au = GetComponent<AudioSource>();
        loadQuestionsOnList(questionCount);
        setQuestion();
    }


    public List<Question> selectedQuestions;
    //selects a certain number of questions from the list
    public void loadQuestionsOnList(int loadQuestionCount) {

        List<int> randQuestionIndex = new List<int>();
        System.Random randomm = new System.Random();
        
        while(selectedQuestions.Count -1 < loadQuestionCount)
        {
            int randInd = randomm.Next(0, sorular.Count - 1);
            if (!randQuestionIndex.Contains(randInd))
            {
                randQuestionIndex.Add(randInd);
                selectedQuestions.Add(sorular[randInd]);
            }
        }
    }

    public void setQuestion()
    {
        
        List<Button> btns = qw.buttons;
        System.Random randomm = new System.Random();
        r = randomm.Next(0,selectedQuestions.Count-1);
        
        qw.questionText.text = selectedQuestions[r].soru;
        for (int i = 0; i < btns.Count; i++)
        {
            btns[i].GetComponentInChildren<Text>().text = selectedQuestions[r].siklar[i];
        }
    }

    public void check(Button t)
    {
        if( selectedQuestions.Count > 1)
        {
            bool control = selectedQuestions[r].checkQuestionAnswer(t);
            if (control)
            {
                au.clip = trueSound;
                au.Play();
                selectedQuestions.Remove(selectedQuestions[r]);
                setQuestion();
                trueCounter++;
            }
            else
            {
                au.clip = falseSound;
                au.Play();
                selectedQuestions.Remove(selectedQuestions[r]);
                setQuestion();
                falseCounter++;
            }
        }
        else
        {
            showFinishScreen();
        }
    }

    public GameObject questionWidgetObj;
    public GameObject finishScreen;
    public Text falseText;
    public Text trueText;


    void setScore(int tCount, int fCount)
    {
        falseText.text = fCount.ToString() + " Yanlış";
        trueText.text = tCount.ToString() + " Doğru";
    }

    void showFinishScreen()
    {
        setScore(trueCounter,falseCounter);

        questionWidgetObj.SetActive(false);
        finishScreen.SetActive(true);
    }
    
    public void RestrartQuiz()
    {
        SceneManager.LoadScene("Quiz");
    }

    public void ReturnMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
