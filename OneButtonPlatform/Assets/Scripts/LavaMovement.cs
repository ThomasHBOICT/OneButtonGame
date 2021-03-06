﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaMovement : MonoBehaviour
{
    public bool ignorePlayer = false;
    public float lavaOffset;

    public float lavaSpeed;
    public float lavaSpeedAcceleration;
    public UIController ui;
    public Transform player;
    public FloatValue playerHeight;

    public bool constantRise;
    
    // Start is called before the first frame update
    void Start()
    {
        playerHeight.@float = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (constantRise)
        {
            ConstantRise();
        }
        else
        {
            RiseWithPlayer();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player" && !ignorePlayer)
        {
            FindObjectOfType<AudioManager>().Play("death");
            Time.timeScale = 0;
            ui.OpenDeathScreen();
        }
    }

    private void ConstantRise()
    {
        lavaSpeedAcceleration += Time.deltaTime /200;
        transform.Translate(Vector2.up * Time.deltaTime * (lavaSpeed + lavaSpeedAcceleration));
    }

    private void RiseWithPlayer()
    {
        if (player.position.y > playerHeight.@float)
        {
            playerHeight.@float = player.position.y;
            transform.position = new Vector2(0, playerHeight.@float - lavaOffset);
        }
    }
}
