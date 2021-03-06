﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Mirror;

public class PlayerController : NetworkBehaviour
{
    public float speed;
    public int winCondition;
    public int jump;
    public Text countText;
    public Text winText;
    public GameObject myCam;


    private Rigidbody rb;
 
    private int count;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        countText.text = "Pisteet: " + count.ToString();
        winText.text = "";

    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        if (!isLocalPlayer)
        {
            // exit from update if this is not the local player
            return;
        }

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.AddForce(movement * speed);
        if (Input.GetKeyDown("space"))
        {
            Vector3 up = new Vector3(0.0f, 200.0f, 0.0f);
            GetComponent<Rigidbody>().AddForce(up * jump);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            count++;
            countText.text = "Pisteet: " + count.ToString();
            if (count >= winCondition)
            {
                winText.text = "VOITIT PELIN";
            }
        }
    }
}
