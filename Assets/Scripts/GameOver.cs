using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public animationStateController state;

    void Start()
    {
        state = FindObjectOfType<animationStateController>();
    }

    void Update()
    {
        if(state.dead_player())
        {
            //StartCoroutine(FadeTextToFullAlpha(1f, GetComponent<Text>()));
            GetComponent<Text>().text = "GAME OVER";
        }
        if(state.playerwin())
        {
            GetComponent<Text>().text = "YOU WIN";
        }
    }

    public IEnumerator FadeTextToFullAlpha(float t, Text i)
    {
        i.color = new Color(i.color.r, i.color.g, i.color.b, 0);
        i.text = "Game Over";
        while(i.color.a < 1.0f)
        {
            i.color = new Color(i.color.r, i.color.g, i.color.b, i.color.a + (Time.deltaTime / t));
            yield return null;
        }
    }

    public IEnumerator FadeTextToZeroAlpha(float t, Text i)
    {
        i.color = new Color(i.color.r, i.color.g, i.color.b, 1);
        while (i.color.a > 0.0f)
        {
            i.color = new Color(i.color.r, i.color.g, i.color.b, i.color.a - (Time.deltaTime / t));
            yield return null;
        }
    }
}
