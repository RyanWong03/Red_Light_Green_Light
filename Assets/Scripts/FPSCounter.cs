using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FPSCounter : MonoBehaviour
{
    //public int fps;
    public Text fpsText;
    public PauseMenu pause;

    void Start()
    {
        pause = FindObjectOfType<PauseMenu>();
    }

    void Update()
    {
        /*float current = 0;
        current = (int)(1f / Time.unscaledDeltaTime);
        fps = (int)current;
        fpsText.text = fps.ToString();*/

        float fps = 1 / Time.unscaledDeltaTime;
        fpsText.text = "" + (int)fps;

        //if(pause.paused()) fpsText.text = ""
    }
}
