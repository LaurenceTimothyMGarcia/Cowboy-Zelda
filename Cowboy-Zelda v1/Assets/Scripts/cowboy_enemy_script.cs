using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public class cowboy_enemy_script : MonoBehaviour
{
    public float speed;
    public float movementTimer;

    public bool MoveRight;

    public Animator animator;

    private Transform target;

    void Start()
    {
        Invoke("ChangeDirection", movementTimer);
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 movement = new Vector3(x, y, 0.0f);

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Magnitude", movement.magnitude);

        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);



        // checks if moveright bol is True, if so, the enemy will begin moving right cycle
        /*if (MoveRight)
        {
            transform.Translate(2 * Time.deltaTime * speed, 0, 0);
            // transform.localScale = new Vector2(2, 2);             this code could be used to flip the sprite in appropriate direction, if needed
        }
        else // else if moveright is False, enemy will begin moving left cycle
        {
            transform.Translate(-2 * Time.deltaTime * speed, 0, 0);
            // transform.localScale = new Vector2(-2, 2);            see above
        }*/



    }
    void OnTriggerEnter2D(Collider2D trig)   // This requires hidden turntriggers (look in my sample scene to see how they should be placed, allows patrol of an area
    {
        if(trig.gameObject.CompareTag("turntrigger"))   // if the trigger it hits has tag turntrigger, carries out following process
        {
            if (MoveRight)                              // has the sprite start moving the other way
            {
                MoveRight = false;
            }
            else
            {
                MoveRight = true;
            }
        }
    }
}
