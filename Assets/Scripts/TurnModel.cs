using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnModel : MonoBehaviour
{
    public TouchController touchController;
    bool isTurnActive = false;
    GameObject ActiveModel;
    
    public void ActivatedTurnModel()
    {
        //Aktif Modeli bul.
        //Değişkeni true yap.
        ActiveModel = GameObject.FindGameObjectWithTag("ActiveModel");
        isTurnActive = !isTurnActive;
    }

    public void TurnActiveModel()
    {
        //Döndürme Fonksiyonu
        if (!touchController.isActive)
        {
            Vector3 rotateVectors = new Vector3(0, 0.5f, 0);
            ActiveModel.transform.Rotate(rotateVectors);
        }
    }

    private void FixedUpdate()
    {
        if (isTurnActive)
        {
            TurnActiveModel();
        }
    }
   
}
