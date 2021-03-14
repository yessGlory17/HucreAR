using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadSceneAnimationController : MonoBehaviour
{
    public GameObject LoadSceneCanvas;

    public GameObject LoadSceneCanvas2;
    public void CloseLoadScreen()
    {
        LoadSceneCanvas.SetActive(false);
    }


}
