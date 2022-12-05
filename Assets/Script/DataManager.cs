using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager
{
    static DataManager instance;
    public List<DataFromJsonxxx> dataFromJsonxxxes = new List<DataFromJsonxxx>();

    Dictionary<int, DataFromJsonxxx> dicData = new Dictionary<int, DataFromJsonxxx>();


    public static DataManager GetInstace()
    {
        if(instance == null)
        {
            instance = new DataManager();
        }
        return instance;
    }
    DataManager()
    {
        InitData();
    }
    void InitData()
    {
        GetAllData();
    }
    void GetAllData()
    {
        // chay vong for
        // dua data vao dic
    }
    public DataFromJsonxxx GetDataXXX(int id)
    {
        if (!dicData.ContainsKey(id))
        {
            GetDataFromJsonPlaceHolder(id);
        }
        return dicData[id];
    }

    public void GetDataFromJsonPlaceHolder(int id)
    {
        //DataFromJsonxxx res = new DataFromJsonxxx();
        dicData.Add(id, DataFromJsonxxx.ConvertDataFromJsonPlaceHolder());
    }
}

public class DataFromJsonxxx
{
    public int id;
    public string textDes;
    public string imageLink; // resouces/images/nameofimages
    public static DataFromJsonxxx ConvertDataFromJsonPlaceHolder()// nguyen cuc data vao day)
    {
        DataFromJsonxxx res = new DataFromJsonxxx();




        return res;
    }
}




