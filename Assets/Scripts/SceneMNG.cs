using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMNG : MonoBehaviour
{
    // Start is called before the first frame update
    
    public void Page1(int index)
    {
        SceneManager.LoadScene(index);
    }
}
