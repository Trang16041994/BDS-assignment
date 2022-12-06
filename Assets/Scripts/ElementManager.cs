using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ElementManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Image m_image;
    [SerializeField] Text m_text;
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
        fillData();
    }

    public void fillData()
    {
        GetComponent<HorizontalLayoutGroup>().reverseArrangement = (id % 2 == 0);
        //other way: m_image.transform.SetSiblingIndex(idToGetData % 2);
    }
}
