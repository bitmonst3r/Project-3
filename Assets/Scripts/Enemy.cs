using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    float timer = 0;
    float timeToMove = 0.5f;
    int numOfMovements = 0;
    float speed = 0.25f;

    public GameObject enemy;
    public GameObject enemyBullet;
    public GameObject shot;
    private Animator enemyAnimator;
    public AudioClip enemyshootClip;

    // Start is called before the first frame update
    void Start()
    {
        enemyAnimator = GetComponent<Animator>();
    }
    void Update()
    {
        // Move down after 14 movements one direction
        if (numOfMovements == 14)
        {
            transform.Translate(new Vector3(0, -.8f, 0));
            numOfMovements = -1;
            speed = -speed;
            timer = 0;
        }

        // Move sideways on timed onterval
        timer += Time.deltaTime;
        if(timer > timeToMove && numOfMovements < 14)
        {
            transform.Translate(new Vector3(speed, 0, 0));
            timer = 0;
            numOfMovements++;
        }

        fireEnemy();
    }

    void fireEnemy()
    {
        if(Random.Range(0f, 500f) < 1)
        {
            // Activates EnemyShoot Animation
            enemyAnimator.SetTrigger("EnemyShoot");

            // Plays shot sound
            AudioSource audio = GetComponent<AudioSource>();
            audio.clip = enemyshootClip;
            audio.Play();

            // We instantiate a new copy of the bullet prefab
            GameObject shot = Instantiate(enemyBullet, new Vector3(enemy.transform.position.x, enemy.transform.position.y - 0.4f, 0), enemy.transform.rotation);

            // Shot is destroyed in 3 sec
            Destroy(shot, 3f);
        }
    }
}
