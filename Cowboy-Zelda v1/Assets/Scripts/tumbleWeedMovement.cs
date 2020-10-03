using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public class tumbleWeedMovement : MonoBehaviour
{
    public float speed;

    public bool MoveRight;

    // Update is called once per frame
    void Update()
    {
        // checks if moveright bol is True, if so, the enemy will begin moving right cycle
        if (MoveRight)
        {
            transform.Translate(2 * Time.deltaTime * speed, 0, 0);
            transform.localScale = new Vector2(2, 2);                //     this code could be used to flip the sprite in appropriate direction, if needed
        }
        else // else if moveright is False, enemy will begin moving left cycle
        {
            transform.Translate(-2 * Time.deltaTime * speed, 0, 0);
            transform.localScale = new Vector2(-2, 2);              // see above
        }
    }
    void OnTriggerEnter2D(Collider2D trig)   // This requires hidden turntriggers (look in my sample scene to see how they should be placed, allows patrol of an area
    {
        if (trig.gameObject.CompareTag("delete"))   // if the trigger it hits has tag delete, carries out following process
        {
            gameObject.SetActive(false);            // once the tumbleweed has went past the whole screen, hits trigger after the end of the screen and deletes it
        }
    }
}
