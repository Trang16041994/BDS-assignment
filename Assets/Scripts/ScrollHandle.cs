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
            // Resource.load de load prefab
            // instatiate(parent chinh la content)
            // so luong la 20
            // vi tri nay count dang = 0 trong lan spawn dau tien
            for (int i = 1; i <= 20; i++)
            {
                // so thu tu 1 -> 20
                // so thu tu 21 ->40
                // (count)*20 + i
                //listJsonImage
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
               
                Debug.Log(countSpawn * 20 + i);
                // lay component cua anc
                // gan id cho abc
                // count = 1
                // count =2
                // = 20*(count - 1) + i
                    
            }
            countSpawn += 1;
        }
        onspawn = false;
    }
}
