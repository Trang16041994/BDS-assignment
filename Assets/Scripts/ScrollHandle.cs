using UnityEngine;
using UnityEngine.UI;
using System.Net;
using System;
using System.IO;
using APIHandler;

public class ScrollHandle : MonoBehaviour
{
    // Start is called before the first frame update
    private Image[] listImage;
    private JsonImageList listJsonImage;
    ScrollRect scrollRect;
    GameObject tempObject;
    bool onspawn;
    int countSpawn;
    public Transform tfParent;
    void Start()
    {
        listJsonImage = Utility.fetchJsonImage();
        countSpawn = 0;
        //UnityEngine.Events.UnityAction<Vector2>
        scrollRect = GetComponent<ScrollRect>();
        //sourceImage = GetComponent<Image>();
        //Image layanh = GetComponent<Image>();
        //layanh.sprite.
        tempObject = Resources.Load("Element") as GameObject;
        spawnElement();

        scrollRect.onValueChanged.AddListener(
            
            (vectorValue) =>
            {
                if(vectorValue != null)
                {
                    if(!onspawn && vectorValue.y <= 0.02f)
                    {
                        //onspawn = true;
                        spawnElement();
                    }
                }
            }
        );
    }
    void spawnElement()
    {
        if (!onspawn)
        {
            onspawn = true;
            
            for (int i = 1; i <= 20; i++)
            {
                int jsonObjectIndex = countSpawn * 20 + i;          
                GameObject abc = Instantiate(tempObject, tfParent) as GameObject;
                ElementManager element = abc.GetComponent<ElementManager>();
                element.setId(listJsonImage.listImages[jsonObjectIndex].id);
                element.setText(listJsonImage.listImages[jsonObjectIndex].title);
                Image image = element.getImage();
                image = Utility.DownloadImage(listJsonImage, image, jsonObjectIndex);
                element.setImage(image);
                if (jsonObjectIndex >= listJsonImage.listImages.Count)
                    break; // No more json image left to load into UI
            }
            countSpawn += 1;
        }
        onspawn = false;
    }
}
