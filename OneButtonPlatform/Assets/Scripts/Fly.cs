using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fly : MonoBehaviour
{
    public Rigidbody2D rb;
    public float moveSpeed;
    public float moveRange;

    public Animator ani;

    public GameObject coin;
    public SpriteRenderer sprRenderer;

    private bool isDead = false;

    // Update is called once per frame
    void Update()
    {
        Move();   
    }

    private void Move()
    {
        if (rb.position.x < moveRange && !isDead)
        {
            rb.MovePosition(rb.position + new Vector2(4, 0) * moveSpeed * Time.fixedDeltaTime);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Lava")
        {
            Destroy(gameObject);
        }
        if(collision.gameObject.tag == "Wall")
        {
            sprRenderer.flipX = !sprRenderer.flipX;
            moveSpeed *= -1f;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Sword")
        {
            Debug.Log(isDead);
            isDead = true;
            ani.SetTrigger("death");
            StartCoroutine("Death");
        }
    }

    private IEnumerator Death()
    {
        Destroy(gameObject, 0.37f);
        yield return new WaitForSeconds(0.36f);
        Instantiate(coin, transform.position, Quaternion.identity);
    }
}
