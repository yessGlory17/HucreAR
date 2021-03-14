using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Organel
{
    public string Etiket;
    public GameObject OrganelModel;
    public List<string> OrganelBilgi = new List<string>();
    public Material DefaultMaterial;
    //Alt Bolumleri Al
    public List<OrganelAltBolum> AltBolumler = new List<OrganelAltBolum>();

    //Organel Bilgi Canvası eklenecek.

    public bool isOutline = false;


    [Range(0f,5f)] public float OutlineWidth;
    //Kendini ve alt bolumlerini outline ekleyecek. 
    public void SetOutline(Shader Outline)
    {
        if (!isOutline)
        {
            OrganelModel.GetComponent<Renderer>().material.SetFloat("_ASEOutlineWidth",OutlineWidth);
            OrganelModel.GetComponent<Renderer>().material.shader = Outline;
            OrganelModel.GetComponent<Renderer>().material.SetColor("_TestColor",DefaultMaterial.color);
            isOutline = true;
        }
        else
        {
            RemoveOutline();
        }
            
    }

    //Outline'ı Siler
    public void RemoveOutline()
    {
        OrganelModel.GetComponent<Renderer>().material = DefaultMaterial;
        isOutline = false;
    }
}
