using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class cactusBall_script : MonoBehaviour
{
    public float speed;

    public bool MoveRight;

    private float timebtwnShots;
    public float startTimebtwnShots;
    public GameObject spike;

    void Start()
    {
        timebtwnShots = startTimebtwnShots;
    }

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

        if (timebtwnShots <= 0)
        {
            Instantiate(spike, new Vector3(0, 1, 0), Quaternion.identity);
            Instantiate(spike, new Vector3(0, -1, 0), Quaternion.identity);
            Instantiate(spike, new Vector3(1, 0, 0), Quaternion.identity);
            Instantiate(spike, new Vector3(-1, 1, 0), Quaternion.identity);
            timebtwnShots = startTimebtwnShots;
        }
        else
        {
            timebtwnShots -= Time.deltaTime;
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
