using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GM : MonoBehaviour
{
    public int lives = 3;
    public int bricks = 28;
    public float resetDelay = 1f;
    public Text livestext;
    public GameObject gameover;
    public GameObject youwon;
    public GameObject bricksprefab;
    public GameObject paddle;
    public GameObject deathparticles;
    public static GM instance = null;

    private GameObject clonepaddle; 

    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
        Setup();
    }

    public void Setup()
    {
        clonepaddle = Instantiate(paddle, transform.position, Quaternion.identity) as GameObject;
        Instantiate(bricksprefab, transform.position, Quaternion.identity);
    }

    void CheckGameover()
    {
        if (bricks < 1)
        {
            youwon.SetActive(true);
            Time.timeScale = .23f;
            Invoke("Reset", resetDelay);
        }

        if (lives < 1)
        {
            gameover.SetActive(true);
            Time.timeScale = .25f;
            Invoke("Reset", resetDelay);
        }

    }

    [System.Obsolete]
    void Reset()
    {
        Time.timeScale = 1f;
        Application.LoadLevel(Application.loadedLevel);
    }

    // Update is called once per frame
    public void loselife()
    {
        lives--;
        livestext.text = "Lives: " + lives;
        Instantiate(deathparticles, clonepaddle.transform.position, Quaternion.identity);
        Destroy(clonepaddle);
        Invoke("Setuppaddle", resetDelay);
        CheckGameover();
    }

    void Setuppaddle()
    {
        clonepaddle = Instantiate(paddle, transform.position, Quaternion.identity) as GameObject;
    }

    public void DestroyBrick()
    {
        bricks--;
        CheckGameover();
    }
}
