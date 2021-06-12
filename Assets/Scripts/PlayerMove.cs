using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour
{
    [Header("Movement")]
    public float timeToMove = 0.3f;
    bool isMoving;
    Vector3 origPos, targetPos;

    [Header("Player Reference")]
    public GameObject playerDead;
    public GameObject player;

    Animator anim;   
    
    void Start()
    {
        anim = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        PlayerControls();
        AnimationContol();
        QuitGame();        
    }

    void PlayerControls()
    {
        if (Input.GetKeyDown(KeyCode.W) && !isMoving)
        {
            StartCoroutine(MovePlayer(Vector3.forward));
            transform.eulerAngles = new Vector3(0, 0, 0);
        }

        else if (Input.GetKeyDown(KeyCode.A) && !isMoving)
        {
            StartCoroutine(MovePlayer(Vector3.left));
            transform.eulerAngles = new Vector3(0, -90, 0);
        }

        else if (Input.GetKeyDown(KeyCode.S) && !isMoving)
        {
            StartCoroutine(MovePlayer(Vector3.back));
            transform.eulerAngles = new Vector3(0, 180, 0);
        }


        else if (Input.GetKeyDown(KeyCode.D) && !isMoving)
        {
            StartCoroutine(MovePlayer(Vector3.right));
            transform.eulerAngles = new Vector3(0, 90, 0);
        }
    }
    
    //move player 1 unit
    IEnumerator MovePlayer(Vector3 direction)
    {
        isMoving = true;

        float elapsedTime = 0;

        origPos = transform.position;
        targetPos = origPos + direction;

        while(elapsedTime < timeToMove)
        {
            transform.position = Vector3.Lerp(origPos, targetPos, (elapsedTime / timeToMove));
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = targetPos;

        isMoving = false;
    }

    //jump animation
    void AnimationContol()
    {
        if(isMoving)
        {
            anim.SetBool("JumpBool", true);
        }
        else
        {
            anim.SetBool("JumpBool", false);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        //steps count
        if(other.CompareTag("StepTrigger"))
        {
            LevelManager.levelManager.SetSteps();
            Destroy(other.gameObject);       
        }
           
        //if hits a obstacle
        if(other.CompareTag("Obstacle"))
        {
            GameOver();
            LevelManager.levelManager.GameOver();
        }

        //death on water
        if(other.CompareTag("Water"))
        {
            GameOver();
        }
    }
    
    void OnCollisionEnter(Collision collision)
    {
        //if hit obstacle
        if(collision.gameObject.CompareTag("Obstacle"))
        {
            GameOver();
        }
    }

    void GameOver()
    {
        Instantiate(playerDead, transform.position, transform.rotation);
        gameObject.SetActive(false);
        LevelManager.levelManager.GameOver();
    }

    void QuitGame()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}