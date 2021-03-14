using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TagButtonChange : MonoBehaviour
{
    public TagsVisible Etiketler;
    public Button EtiketButton;

    public Sprite EtiketKapatIcon;
    public Sprite EtiketGosterIcon;
    private void FixedUpdate()
    {
        if (Etiketler.allTagsİsVisible)
        {
            if(EtiketButton.GetComponent<Image>().sprite != EtiketKapatIcon)
                EtiketButton.GetComponent<Image>().sprite = EtiketKapatIcon;
        }
        else
        {
            if(EtiketButton.GetComponent<Image>().sprite != EtiketGosterIcon)
                EtiketButton.GetComponent<Image>().sprite = EtiketGosterIcon;
        }   
    }
}
