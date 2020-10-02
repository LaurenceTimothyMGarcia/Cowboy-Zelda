using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveTest : MonoBehaviour
{
    Rigidbody2D body;
    Transform direction;
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        direction = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("w"))
        {
            transform.Translate(0, 1, 0);
        }
        else if (Input.GetKeyDown("a"))
        {
            transform.Translate(-1, 0, 0);
        }
        else if (Input.GetKeyDown("s"))
        {
            transform.Translate(0, -1, 0);
        }
        else if (Input.GetKeyDown("d"))
        {
            transform.Translate(1, 0, 0);
        }
    }
}
