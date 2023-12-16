using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameControl : MonoBehaviour{
    
    public static GameControl instance;
    public GameObject gameOverText;
    public TextMeshProUGUI ScoreText;
  
    public float scrollspeed = -1.5f;
    public bool gameOver = false;

    private int score = 0;

    AudioSource audioSource;
    public AudioClip scoreSound;


    // Use this for initialization 
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Awake()
    {
        if (instance == null) 
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update() 
    {
        if (gameOver == true && Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

    }

    public void BirdScored()
    {
if (gameOver)
        {
            return;
        }
        score++;
        ScoreText.text = "Score: " + score.ToString();
        PlaySound(scoreSound);
    }





    public void BirdDied()
    {
        gameOverText.SetActive (true);
        gameOver = true;
    }
    public void PlaySound(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }







}





