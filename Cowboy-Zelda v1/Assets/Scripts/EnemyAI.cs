using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public float speed;
    public float lineOfSite;
    private Transform player;

    public Transform moveSpot;
    private float waitTime;
    public float startWaitTime;
    public float minX;
    public float maxX;
    public float minY;
    public float maxY;

    public GameObject cowboy;


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        waitTime = startWaitTime;
        moveSpot.position = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
    }

    void Update()
    {
        float distanceFromPlayer = Vector2.Distance(player.position, transform.position);
        if(distanceFromPlayer < lineOfSite)
        {
            FindObjectOfType<AudioManager>().Play("Bird Screech");
            transform.position = Vector2.MoveTowards(this.transform.position, player.position, speed * Time.deltaTime);
        }
        else//roaming
        {
            transform.position = Vector2.MoveTowards(transform.position, moveSpot.position, speed*Time.deltaTime);

            if(Vector2.Distance(transform.position, moveSpot.position) < 0.2f)
            {
                if(waitTime <= 0)
                {
                    moveSpot.position = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
                    waitTime = startWaitTime;
                }
                else
                {
                    waitTime -= Time.deltaTime;
                }
            }
        }

        if(distanceFromPlayer <= 0.1)
        {
            Debug.Log("you dead");
            Destroy(gameObject);
            Destroy(cowboy);
            FindObjectOfType<AudioManager>().Play("Cowboy Death");
            FindObjectOfType<GameManager>().EndGame();
        }

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, lineOfSite);
    }
}
