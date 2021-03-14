using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Question
{
    public string soru;
    public List<string> siklar;
    public string cevap;

    public bool checkQuestionAnswer(Button kCevap)
    {
        if(kCevap.GetComponentInChildren<Text>().text != cevap)
            return false;
        else
            return true;
    }
}
