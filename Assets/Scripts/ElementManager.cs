using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ElementManager : MonoBehaviour
{
    // Start is called before the first frame update
    public Image m_image;
    public Text m_text;
    int id;

    public void setText(string text)
    {
        m_text.text = text;
    }
    public void setImage(Image image){
        m_image = image;
    }
    public Image getImage()
    {
        return m_image;
    }
    public void setId(int newid)
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
        GetComponent<HorizontalLayoutGroup>().reverseArrangement = (id % 2 == 0);
        //m_image.transform.SetSiblingIndex(idToGetData % 2);
        //
        //DataManager.GetInstace().GetDataFromJsonPlaceHolder(idToGetData);
    }
}
