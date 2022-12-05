using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ElementManager : MonoBehaviour
{
    // Start is called before the first frame update
    public Image m_image;
    public Text text;
    int id;

    public void SetId(int newid)
    {
        id = newid;
        fillData(newid);
    }


    void Start()
    {

    }

    public void fillData(int idToGetData)
    {
        // quy tac: neu id chan thif anh ben phai, neu id le thi anh ben trai
        //GetComponent<HorizontalLayoutGroup>().reverseArrangement = (id % 2 == 0);
        m_image.transform.SetSiblingIndex(idToGetData % 2);
        //
        DataManager.GetInstace().GetDataFromJsonPlaceHolder(idToGetData);
    }
}
