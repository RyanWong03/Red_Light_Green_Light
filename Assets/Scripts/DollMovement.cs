using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
using UnityEngine.EventSystems;

public class DollMovement : MonoBehaviour
{
    public animationStateController state;
    public bool is_looking_back;
    public float waitTime = 3f;
    public bool doll_moving = true;
    
    void Start()
    {
        state = FindObjectOfType<animationStateController>();
        Invoke("start_doll", 4f);
        if(state.dead_player() || state.playerwin()) doll_moving = false;
    }

    void start_doll()
    {
        if(doll_moving) StartCoroutine(update());
    }

    IEnumerator update()
    {
        transform.Rotate(0.0f, 180.0f, 0.0f, Space.Self); //makes doll face backwards
        is_looking_back = true;
        yield return new WaitForSeconds(Random.Range(1,2));
        transform.Rotate(0.0f, 180.0f, 0.0f, Space.Self);
        is_looking_back = false;
        yield return new WaitForSeconds(Random.Range(1,2));

        Start();
    }

    void doll_rotate()
    {
        transform.Rotate(0.0f, 180.0f, 0.0f, Space.Self);
        Invoke("doll_rotate", waitTime);
    }

    public bool looking_back()
    {
        return is_looking_back;
    }
}
