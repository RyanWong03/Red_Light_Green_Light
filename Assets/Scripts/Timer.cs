using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class Timer : MonoBehaviour
{

    public Text timer;
    public float time;
    float msec;
    float sec;
    float min;
    public animationStateController state;
    public float win_time = 0.01f;

    private void Start()
    {
        state = FindObjectOfType<animationStateController>();
        Invoke("start_timer",4f);
    }

    void start_timer()
    {
        if(!state.playerwin())
        {   
            StartCoroutine("StopWatch");
        }
        //Create_Text();
    }

    IEnumerator StopWatch()
    {
        while(true)
        {
            time += Time.deltaTime;
            msec = (int)((time - (int)time) * 100);
            sec = (int)(time % 60);
            min = (int)(time / 60 % 60);

            timer.text = string.Format("{0:00}:{1:00}:{2:00}",min,sec,msec);
            if(state.dead_player()) clear_timer();
            if(state.playerwin()) 
            {
                if(win_time > 0)
                {
                    Time.timeScale = 0f;
                    win_time -= Time.deltaTime;
                    Create_Text();
                    //return;
                }
                else if(win_time <= 0)
                {
                    Time.timeScale = 1.0f;
                }
                //Time.timeScale = 0f;
                //Debug.Log(timer.text);
            }
            yield return null;
        }
    }

    public void clear_timer()
    {
        timer.text = ("00:00:00");
    }

    public void change_color()
    {
        timer.color = Color.yellow;
    }

    void Create_Text()
    {
        string path = Application.dataPath + "/High_Scores.txt";
        /*if(!File.Exists(path))
        {
            File.WriteAllText(path, "Login Log \n\n");
        }*/
        string content = "Login date: " + System.DateTime.Now + "\n";
        //string high_score = 
        if(state.playerwin() || state.dead_player()) 
        {
            //Time.timeScale = 0f;
            Debug.Log("dead");
            string high_score = "test";
            File.WriteAllText(path, high_score);
        }
        //File.AppendAllText(path, content);
        Debug.Log("hello");
    }
}
