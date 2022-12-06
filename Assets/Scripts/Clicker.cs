using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clicker : MonoBehaviour
{
    [SerializeField] Animator anm;
    //player can click model for trigger animation
    public void ClickTrigger()
    {
        anm.SetTrigger("Hello");
    }
}
