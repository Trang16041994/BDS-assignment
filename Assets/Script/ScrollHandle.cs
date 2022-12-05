using UnityEngine;
using UnityEngine.UI;
using System.Net;
using System;
using System.IO;

public class ScrollHandle : MonoBehaviour
{

    // Start is called before the first frame update
    ScrollRect scrollRect;
    GameObject tempObject;
    bool onspawn;
    int countSpawn;
    public Transform tfParent;
    void Start()
    {

        countSpawn = 0;
        //UnityEngine.Events.UnityAction<Vector2>
        scrollRect = GetComponent<ScrollRect>();
        //sourceImage = GetComponent<Image>();
        //Image layanh = GetComponent<Image>();
        //layanh.sprite.

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
        if(tempObject == null)
        {
            //Assets/Resources/Images/headImages/     Element
            tempObject = Resources.Load("Element") as GameObject;
        }

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

                GameObject abc = Instantiate(tempObject, tfParent) as GameObject;
                abc.GetComponent<ElementManager>().SetId(countSpawn * 20 + i);
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
    /*
    private ImageJson getImage(int id)
    {
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(String.Format("https://jsonplaceholder.typicode.com/photos/{0}", id));
        HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        StreamReader reader = new StreamReader(response.GetResponseStream());
        string jsonResponse = reader.ReadToEnd();
        ImageJson image = JsonUtility.FromJson<ImageJson>(jsonResponse);
        return image;
    }
    */
 
}
