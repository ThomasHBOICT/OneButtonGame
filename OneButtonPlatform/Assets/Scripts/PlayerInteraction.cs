using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    [HideInInspector]
    public PlayerMovement playermove;
    public GameObject sword;
    public float hitTime;
    public float hitCooldown;

    public FloatValue coins;

    private bool isHitting = false;
    // Start is called before the first frame update
    void Start()
    {
        playermove = GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        Hit();
        Debug.Log("Can jump: "+playermove.canJump);
        Debug.Log("IS hitting: " + isHitting);
    }

    private void Hit()
    {
        if (playermove.canJump == false && isHitting == false)
        {
            if (Input.anyKeyDown || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began))
            {
                Debug.Log("sword slash");
                FindObjectOfType<AudioManager>().Play("swordSlash");
                StartCoroutine("HitNum");
            }
        }
    }

    private IEnumerator HitNum()
    {
        isHitting = true;
        sword.SetActive(true);
        yield return new WaitForSeconds(hitTime);
        sword.SetActive(false);
        yield return new WaitForSeconds(hitCooldown);
        isHitting = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Fly")
        {
            Debug.Log("Player is hit");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Coin")
        {
            coins.@float += 1;
        }
    }
}
