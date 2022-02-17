using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartButton : MonoBehaviour
{
    public void Start()
    {
        //state = FindObjectOfType<animationStateController>();
    }

    public void showButton(GameObject obj)
    {
        obj.SetActive(true);
    }

    public void HideButton(GameObject obj)
    {
        obj.SetActive(false);
    }
}
