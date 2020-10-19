using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public GameObject bullet;
    public Transform shottingOffset;
    public AudioClip shootClip;
    public AudioClip ohohClip;
    private Animator playerAnimator;
    float duration = 1f;
    float moveSpeed = 10;

    // Player score 
    public static float score = 0;
    public static float highScore = 0;
    [SerializeField]public Text scoreText;
    [SerializeField]public Text highScoreText;

    void Start()
    {
        playerAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // Score text format
        scoreText.text = "00" + score;
        highScoreText.text = "00" + highScore;
        if (score > 99)
        {
            scoreText.text = "0" + score;
        }
        if (highScore > 99)
        {
            highScoreText.text = "0" + highScore;
        }

        // Checks for input, if its space bar
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Activates player shoot animation
            playerAnimator.SetTrigger("Shoot");

            // Plays shooting clip
            AudioSource audio = GetComponent<AudioSource>();
            audio.clip = shootClip;
            audio.Play();

            // We instantiate a new copy of the bullet prefab
            GameObject shot = Instantiate(bullet, shottingOffset.position, Quaternion.identity);
            Debug.Log("Bang!");
        
            // Shot is destroyed in 3 sec
            Destroy(shot, 3f);
        }

        // Moves player left and right due to axis & transform 
        float horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(new Vector3(horizontalInput, 0, 0) * moveSpeed * Time.deltaTime);     
    }

    IEnumerator OnCollisionEnter2D(Collision2D collision)
    {
     
        // Activates Death animation
        playerAnimator.SetTrigger("Death");
        Destroy(collision.gameObject);

        // Plays death sound
        AudioSource audio1 = GetComponent<AudioSource>();
        audio1.clip = ohohClip;
        audio1.Play();

        // Wait x amount of seconds
        yield return new WaitForSeconds(duration);
        Destroy(GameObject.FindWithTag("Player"));
    }
}
