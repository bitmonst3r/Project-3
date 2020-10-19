using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//technique for making sure there isn't a null reference during runtime if you are going to use get component
[RequireComponent(typeof(Rigidbody2D))]
public class Bullet : MonoBehaviour
{
    private Rigidbody2D myRigidbody2D;
    public float speed = 5;

    // Start is called before the first frame update
    void Start()
    {
        myRigidbody2D = GetComponent<Rigidbody2D>();
        Fire();
    }

    // Update is called once per frame
    private void Fire()
    {
      myRigidbody2D.velocity = Vector2.up * speed; 
      Debug.Log("Wwweeeeee");
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // When collition is detected with collider add to score
        if (collision.gameObject.name == "Enemy1(Clone)")
        {
            Destroy(collision.gameObject);
            Player.score += 10;
        }
        if (collision.gameObject.name == "Enemy2(Clone)")
        {
            Destroy(collision.gameObject);
            Player.score += 20;
        }
        if (collision.gameObject.name == "Enemy3(Clone)")
        {
            Destroy(collision.gameObject);
            Player.score += 30;
        }
        if (collision.gameObject.name == "Enemy4(Clone)")
        {
            Destroy(collision.gameObject);
            Player.score = Player.score + 40;

        }
    }
}

