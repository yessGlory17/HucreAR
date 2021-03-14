using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[System.Serializable]

//Bu sınıfın amacı organellerin etiketlerinin bilgilerini taşımaktır.
public class TagsAR 
{
    public GameObject TagCanvas;
    public string TagName;
    public TextMeshProUGUI TagText;
    bool isVisible = false;

    //Göster Gizle Fonksiyonu

    //Bu fonksiyon kendi elemanı olan TagCanvas'ı gösterip gizler.
    public void Goster()
    {
        TagCanvas.SetActive(!isVisible);
        isVisible = !isVisible;
    }
}
