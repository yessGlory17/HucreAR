using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TagsVisible : MonoBehaviour
{
    public GameObject ARCAMERA;
    public List<TagsAR> etiketler = new List<TagsAR>();
    public List<Transform> CanvasPositions = new List<Transform>();
    public bool allTagsİsVisible = false;

    //Burada bütün etiketler gösterilip gizlenir.
    public void TumEtiketleriGizle()
    {
        for (int i = 0; i < etiketler.Count; i++)
        {
            etiketler[i].Goster();
        }

        if(allTagsİsVisible)
            allTagsİsVisible = false;
        else
            allTagsİsVisible = true;
    }


    private void FixedUpdate()
    {
        if(allTagsİsVisible)
            CalculateRotation(etiketler);

        //if(allTagsİsVisible)
        //    TurnTags(etiketler);
    }

    public void TurnTags(List<TagsAR> liste)
    {
        foreach (var item in liste)
        {
            Vector3 targetPosition = new Vector3(ARCAMERA.transform.position.x,
            item.TagCanvas.transform.position.y,
            ARCAMERA.transform.position.z);
            item.TagCanvas.transform.LookAt(targetPosition);
        }
    }

    void CalculateRotation(List<TagsAR> tagsList)
    {
        foreach (var item in tagsList)
        {
            Vector3 normalizeArCamera = new Vector3(ARCAMERA.transform.position.x, item.TagCanvas.transform.position.y, ARCAMERA.transform.position.z);
            Vector3 rotasyonFarki = normalizeArCamera - item.TagCanvas.transform.position;
            rotasyonFarki = new Vector3(normalizeArCamera.x*-1f, normalizeArCamera.y * -1f, normalizeArCamera.z*-1f);
            RotateTag(rotasyonFarki,item);
        }
    }

    void RotateTag(Vector3 fark, TagsAR item)
    {
        item.TagCanvas.transform.rotation = Quaternion.LookRotation(fark, Vector3.up);
    }
}
