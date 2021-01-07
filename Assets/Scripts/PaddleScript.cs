using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleScript : MonoBehaviour
{
    public float speed;
    public float boundaryLengthL;
    public float boundaryLengthR;
    public GameManager gm;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gm.lastLife)
            return;
        float pos = Input.GetAxis("Horizontal");
        transform.Translate(Vector2.right * Time.deltaTime * speed * pos);
        if (transform.position.x < boundaryLengthL)
            transform.position = new Vector2(boundaryLengthL, transform.position.y);
        if (transform.position.x > boundaryLengthR)
            transform.position = new Vector2(boundaryLengthR, transform.position.y);
    }
}
