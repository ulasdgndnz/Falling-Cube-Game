using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBounds : MonoBehaviour
{
    public float minX = -2.6f, maxX = 2.6f, minY = -7.6f;
    private bool outOfBounds;

    // Update is called once per frame
    void Update()
    {
        checkBounds();
    }

    private void checkBounds()
    {
        Vector2 temp = transform.position;

        if (temp.x > maxX)
        {
            temp.x = maxX;    
        }
        if (temp.x < minX)
        {
            temp.x = minX;
        }

        transform.position = temp;
        if (temp.y <= minY)
        {
            if (!outOfBounds)
            {
                outOfBounds = true;
            }
        }

        if (outOfBounds)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("Gameplay");
        }
        
    }

    void OnTriggerEnter2D(Collider2D target) {

        if(target.tag == "TopSpike") {

            transform.position = new Vector2(1000f, 1000f);
            SoundManager.instance.DeathSound();
            UnityEngine.SceneManagement.SceneManager.LoadScene("Gameplay");
    
        }

    }
}
