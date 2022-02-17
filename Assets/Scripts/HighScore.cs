/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class HighScore : MonoBehaviour
{
    public Timer time;
    public animationStateController state;

    // Start is called before the first frame update
    void Start()
    {
        time = FindObjectOfType<Timer>();
        state = FindObjectOfType<animationStateController>();
        CreateText();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CreateText()
    {
        string path = Application.dataPath + "/HighScores.txt";
        /*if(!File.Exists(path))
        {
            File.WriteAllText(path, "Login Log \n\n");
        }
        string content = "Login date: " + System.DateTime.Now + "\n";
        //string high_score = 
        if(state.playerwin() || state.dead_player()) 
        {
            //Time.timeScale = 0f;
            Debug.Log("dead");
            string high_score = "test";
            File.AppendAllText(path, high_score);
        }
        //File.AppendAllText(path, content);
    }
}
*/