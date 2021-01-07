using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    public Rigidbody2D rb;
    public float force;
    public bool Play;
    public Transform bsp;
    public GameManager gm;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gm.lastLife)
            return;
        if (!Play)
            transform.position = bsp.position;
        if (Input.GetKeyDown(KeyCode.Space) && !Play)
        {
            rb.AddForce(Vector2.up * force);
            Play = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bottom"))
        {
            rb.velocity = Vector2.zero;
            Play = false;
            gm.UpdateLives();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Brick"))
        {
            Debug.Log("Hit");
            Destroy(collision.gameObject);
            gm.UpdateScore(collision.gameObject.GetComponent<BrickScript>().points);
            gm.UpdateBricks();
        }
    }
}
