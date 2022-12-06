using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using APIHandler;
using System;
using UnityEngine.UI;

public class DataLoader : MonoBehaviour
{
    private Image[] listImage;
    private JsonImageList listJsonImage;
    private bool isLoaded = false;
    // Start is called before the first frame update
    void Start()
    {
       listJsonImage = Utility.fetchJsonImage();
       listImage = GetComponentsInChildren<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isLoaded)
        {
            isLoaded = true;
            int i = 0;
            // for each Images: Download iamge and put it in the image.
            foreach (Image image in listImage)
            {
                image.sprite = null;
                Davinci.get().load(listJsonImage.listImages[i].url).into(image).start();
                // Download image request might be blocked by the via.placeholder.com service used by JSONPLACEHOLDER. If that is the case, for the sake of this test, an alternative image source will be used. The real backend should not block the client like this. 
                if (image.sprite == null) 
                {
                    // The urls are fetched properly from jsonplaceholder. Look at the debug log.
                    Debug.Log("the url of image " + listJsonImage.listImages[i].id + " is: " + listJsonImage.listImages[i].url);
                    int id = 10 + listJsonImage.listImages[i].id; // Just randomly choose 10 as the starting image in picsum.photos
                    string backupUrl = String.Format("https://picsum.photos/id/{0}/500", listJsonImage.listImages[i].id);
                    Davinci.get().load(backupUrl).setCached(false).into(image).start();
                }
                i++;
                if (i >= listJsonImage.listImages.Count)
                    break; // No more json image left to load into UI
            }
        }
    }
}