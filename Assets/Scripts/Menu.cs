using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Menu : MonoBehaviour
{
    public Animator anim;
    public GameObject LoadCanvas;
    public void LoadAnimalCell()
    {
        SceneManager.LoadScene("SampleScene");
    }


    public void LoadAnimalCellButtonFunc()
    {
           StartCoroutine(loadAnimation());
    }


    public void LoadPlantCell()
    {
        SceneManager.LoadScene("PlantCell");
    }


    public void LoadQuiz()
    {
        SceneManager.LoadScene("Quiz");
    }

    IEnumerator loadAnimation()
    {
        LoadCanvas.SetActive(true);
        anim.SetBool("LoadSceneAnim",true);

        yield return new WaitForSeconds(2f);

        LoadAnimalCell();
    }
}
