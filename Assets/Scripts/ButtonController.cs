using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ButtonController : MonoBehaviour
{
    public GameObject InfoPanel;
    public AudioSource BlobTouchEffect;

    public TouchController TouchController;
    
    public GameObject İleriButton;
    public GameObject GeriButton;

    int index = 0;

    public OrganelManager organelMan;
    

    public GameObject SceneLoaderScreen2;
    

    public void ClosePanel()
    {
        //InfoPanel.SetActive(false);

        //Burada Close Animation Calıştırılacak

        Animator animator = InfoPanel.GetComponent<Animator>();
        bool isOpen = animator.GetBool("isOpen");
        if(animator != null)
        {
            animator.SetBool("isOpen",false);
            BlobTouchEffect.Play();
            TouchController.isActive = false;
            Debug.LogError("Basıldı Animator Var!");
        }

        Debug.LogError("Basıldı Animator Yok!");

        //Kapatılıncı Hepsinin Outlinenını Sil

        foreach (var item in organelMan.Organeller)
        {
            item.RemoveOutline();
        }

    }

    public void ForwardInfo()
    {
        
        Organel organel = TouchController.GetFindedOrganel();

        if (index < organel.OrganelBilgi.Count - 1)
        {
            
            index++;

            TouchController.InfoText.text = organel.OrganelBilgi[index];
        }
        else
        {
            İleriButton.SetActive(false);
            GeriButton.SetActive(true);
        }
    }

    public void BackInfo()
    {
        Organel organel = TouchController.GetFindedOrganel();

        if(index > 0)
        {
            //Debug.LogError("BİLGİ SONUCU => " + organel.OrganelBilgi[index--]);

            index--;

            TouchController.InfoText.text = organel.OrganelBilgi[index];
        }
        else
        {
            GeriButton.SetActive(false);
            İleriButton.SetActive(true);
        }


    }



    public void BackMenu()
    {
        StartCoroutine(loadingMenu());
    }
    public void Menu()
    {
        SceneManager.LoadScene("Menu");
    }


    IEnumerator loadingMenu()
    {
        SceneLoaderScreen2.SetActive(true);
        GameObject.FindGameObjectWithTag("SceneLoaderScreen2Anim").GetComponent<Animator>().SetBool("GoMenu",true);

        yield return new WaitForSeconds(2f);

        Menu();
    }
    
}
