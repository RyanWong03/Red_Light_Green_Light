using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class animationStateController : MonoBehaviour
{
    Animator animator;
    int isWalkingHash;
    int isRunningHash;
    int isDyingHash;
    public float movementSpeed = 5.0f;
    public DollMovement doll;
    public float wait_time = 4.0f;
    public bool playerDead = false;
    public bool isWalking;
    public bool isRunning;
    public bool player_won = false;

    // Start is called before the first frame update
    void Start()
    {
        doll = FindObjectOfType<DollMovement>();
        animator = GetComponent<Animator>();
        isWalkingHash = Animator.StringToHash("isWalking");
        isRunningHash = Animator.StringToHash("isRunning");
        //isDyingHash = Animator.StringToHash("isDying");
    }

    // Update is called once per frame
    void Update()
    {
        //bool isRunning = animator.GetBool(isRunningHash);
        //bool isWalking = animator.GetBool(isWalkingHash);
        bool forwardPressed = Input.GetKey(KeyCode.W);
        bool backwardPressed = Input.GetKey(KeyCode.S);
        bool leftPressed = Input.GetKey(KeyCode.A);
        bool rightPressed = Input.GetKey(KeyCode.D);
        bool runPressed = Input.GetKey(KeyCode.LeftShift);

        if(playerDead == false)
        {
            if(wait_time >= 0)
            {
                wait_time -= Time.deltaTime;
                return;
            } 
            else
            {
                if(Input.GetKey(KeyCode.W))
                {
                    animator.SetBool(isWalkingHash, true);
                    isWalking = true;
                    movementSpeed = 2.0f;
                    transform.position += transform.forward * Time.deltaTime * movementSpeed;
                }

                if(isWalking && !forwardPressed)
                {
                    animator.SetBool(isWalkingHash, false);
                    isWalking = false;
                }
                
                if(Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.LeftShift))
                {
                    animator.SetBool(isRunningHash, true);
                    isRunning = true;
                    movementSpeed = 4.0f;
                    transform.position += transform.forward * Time.deltaTime * movementSpeed;
                }

                if(isRunning && (!forwardPressed || !runPressed))
                {
                    animator.SetBool(isRunningHash, false);
                    isRunning = false;
                }

                if(transform.position.z > 89)
                {
                    player_won = true;
                    Debug.Log("Player won");
                }
            }
        }
        
        if(Input.GetKey(KeyCode.W) && !doll.looking_back()) 
        {
            //animator.SetBool("isDying", true);
            //movementSpeed = 0.0f;
            //FindObjectOfType<AudioManager>().Play("PlayerDeath");
            //Invoke("reloadGame", 6f);
            //playerDead = true;
        }

        if(playerDead == true)
        {
            Time.timeScale = 0.5f;
        } 
    }

    public void reloadGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1.0f;
        movementSpeed = 2.0f;
        playerDead = false;
    }

    public bool isMoving()
    {
        return movementSpeed >= 0.1f;
    }

    public bool dead_player()
    {
        return playerDead;
    }

    public bool playerwin()
    {
        return player_won;
    }
}