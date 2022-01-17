using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformScript : MonoBehaviour
{

    public float moveSpeed = 2f;
    public float boundY = 6f;

    [SerializeField] private float multiple = 1f;

    public bool movingplatformLeft, movingplatformRight, isBreakable, isSpkie, isPlatform;

    private Animator anim;
    
    
    // Start is called before the first frame update
    void Awake()
    {
        anim = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        Vector2 temp = transform.position;
        temp.y += moveSpeed * Time.deltaTime * multiple;
        transform.position = temp;

        if (temp.y >= boundY)
        {
            gameObject.SetActive(false);
        }
    }

    void BreakableDeactivate()
    {
        Invoke("DeactivateGameObject", 0.3f);
    }

    void DeactivateGameObject()
    {
        SoundManager.instance.IceBreakSound();
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider target)
    {
        if (target.tag == "Player")
        {
            if (isSpkie)
            {
                target.transform.position = new Vector2(1000f, 1000f);
                SoundManager.instance.GameOverSound();
                //GameManager.instance.RestartGame();
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D target)
    {
        if (target.gameObject.tag == "Player")
        {
            if (isBreakable)
            {
                SoundManager.instance.LandSound();
                anim.Play("Break");
            }

            if (isPlatform)
            {
                SoundManager.instance.LandSound();
            }
        }
    }

    private void OnCollisionStay2D(Collision2D target)
    {
        float direction = 1;
        if (target.gameObject.tag == "Player")
        {
            if (movingplatformLeft)
            {
                target.gameObject.GetComponent<PlayerMovement>().PlatformMove(-direction);
            }

            if (movingplatformRight)
            {
                target.gameObject.GetComponent<PlayerMovement>().PlatformMove(direction);
            }
        }
    }
}



























