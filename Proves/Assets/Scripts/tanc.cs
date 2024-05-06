using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Tanc : MonoBehaviour
{
    public float speedMovement;
    public float rotationSpeed;
    public int lives;
    private Rigidbody2D rb;
    private GameObject tocat;

    // Start is called before the first frame update
    void Start()
    {
        this.lives = 3;
        tocat = GameObject.Find("Tocat");
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        movement();
        if(lives < 1)
        {
            SceneManager.LoadScene("Mort");
        }
    }

    private void movement()
    {
        if(Input.GetKey(KeyCode.A))
        {
            this.transform.Rotate(0, 0, (rotationSpeed/10));
        }
        else if (Input.GetKey(KeyCode.D))
        {
            this.transform.Rotate(0, 0, -(rotationSpeed/10));
        }
        else
        {
            this.transform.Rotate(0, 0, 0);
            rb.angularVelocity = 0;
        }

        if (Input.GetKey(KeyCode.W)) 
        {
            rb.velocity = this.transform.up * speedMovement;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            rb.velocity = this.transform.up * -speedMovement;
        }
        else
        {
            rb.velocity = new Vector2(0, 0);
            this.transform.Rotate(0, 0, 0);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Paret")
            rb.velocity = new Vector2(0, 0);
        if (collision.transform.tag == "Obstacles")
            rb.velocity = new Vector2(0, 0);
        if (collision.transform.tag == "Bala")
        {
            lives--;
            print("aaa");
            tocat.GetComponent<AudioSource>().Play();
        }
    }

    internal int getVides()
    {
        return lives;
    }
}
