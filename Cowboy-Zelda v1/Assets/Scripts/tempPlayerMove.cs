using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tempPlayerMove : MonoBehaviour
{
    public float moveSpeed;
    float x;
    float y;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        x = Input.GetAxisRaw("Horizontal");
        y = Input.GetAxisRaw("Vertical");
        rb.velocity = new Vector2(moveSpeed * x, moveSpeed * y);
    }
}
