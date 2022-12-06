using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Testscript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //string url = "https://t3.gstatic.com/licensed-image?q=tbn:ANd9GcRlex2yeMomsbkm0qzpHjtPf8j9QLCDPLZ_brREwaQIrpsnwot3sOfn8Qr3ujA92cho";
        string url = "https://via.placeholder.com/600/24f355";
        string backupUrl = "https://picsum.photos/200";
        bool isError = false;
        Image image = GetComponent<Image>();
        Davinci.ClearCache(backupUrl);
        Davinci.get().load(url).into(image
                ).withErrorAction((error) => {
                    isError = true;
                }).start();
        if (image.sprite == null)
            isError = true;
        Debug.Log(isError);
        if (isError)
        {
            Davinci.get().load(backupUrl).into(GetComponent<Image>()).start();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
