using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagers : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void Page1(int index)
    {
        SceneManager.LoadScene(index);
    }

}
