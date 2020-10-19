using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (Player.score > Player.highScore)
            {
                Player.highScore = Player.score;

            }
            Player.score = 0;
            Time.timeScale = 1;

            SceneManager.LoadScene("DemoScene");

        }
    }
}
