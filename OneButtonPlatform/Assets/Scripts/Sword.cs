using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    public PlayerMovement player;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Fly")
        {
            FindObjectOfType<AudioManager>().Play("swordHit");
            player.canJump = true;
        }
    }
}
