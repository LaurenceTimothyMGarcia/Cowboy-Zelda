using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VultureEnemyMove : MonoBehaviour
{
    public Transform target; //select the player
    public float AggroRadius; //how close player has to get to aggro
    public float FlySpeed; //how fast enemy flies to player when first aggro'd, and how fast it dives
    public float FollowDistance; //how far away enemy circles around player
    public float MinCircleTime; //minimum time enemy will circle around the player
    public float MaxCircleTime; //maximum time enemy will circle around the player
    public float CircleFreq; //How many times the enemy will circle per second
    public float DiveChargeTime; //how long the enemy waits between pausing and diving
    public float DiveLength; //how far enemy dives while attacking

    enum AIMode //for readability purposes
    {
        SENTRY,
        FLIGHT_START,
        LOCK_ON,
        CIRCLE_START,
        CIRCLE,
        DIVE_START,
        DIVE_CHARGE,
        DIVE
    }

    AIMode currentMode = AIMode.SENTRY;
    Rigidbody2D rb;
    float followTime;
    float currentAngle;
    float chargeTimer;
    float distanceTraveled;
    Vector2 diveStartPoint;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    
    void FixedUpdate()
    {
        switch (currentMode) {
            case AIMode.SENTRY:
                SentryMode();
                break;
            case AIMode.FLIGHT_START:
                FlightStartMode();
                break;
            case AIMode.LOCK_ON:
                LockOnMode();
                break;
            case AIMode.CIRCLE_START:
                CircleStartMode();
                break;
            case AIMode.CIRCLE:
                CircleMode();
                break;
            case AIMode.DIVE_START:
                DiveStartMode();
                break;
            case AIMode.DIVE_CHARGE:
                DiveChargeMode();
                break;
            case AIMode.DIVE:
                DiveMode();
                break;
        }
    }
    void SentryMode() //do nothing, but if player enters aggro range, start attacking
    {
        if (Vector2.Distance(transform.position, target.position) <= AggroRadius)
        {
            currentMode = AIMode.FLIGHT_START;
        }
    }
    void FlightStartMode() //determine how long enemy will circle around player, maybe play a noise, then lock on
    {
        followTime = Random.Range(MinCircleTime,MaxCircleTime);
        currentMode = AIMode.LOCK_ON;
    }

    void LockOnMode() //While farther than circling distance from the player, dash straight towards the player
    {
        if (Vector2.Distance(transform.position, target.position) >= FollowDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, FlySpeed);
        }
        else
        {
            currentMode = AIMode.CIRCLE_START;
        }
    }

    void CircleStartMode() //get current angle between player and enemy, for use while circling
    {
        currentAngle = Vector2.Angle(target.position, transform.position) * Mathf.Deg2Rad; //get it in Radians
        currentMode = AIMode.CIRCLE;
    }

    void CircleMode()
    {
        if (followTime > 0) 
        {
            followTime -= Time.deltaTime;
            currentAngle += Mathf.PI / 100;
            transform.position = new Vector2(target.position.x + FollowDistance * Mathf.Cos(currentAngle), target.position.y + FollowDistance * Mathf.Sin(currentAngle));
        }
        else
        {
            currentMode = AIMode.DIVE_START;
        }
    }
    void DiveStartMode()
    {
        currentAngle = Vector2.SignedAngle(target.position, transform.position) * Mathf.Deg2Rad;
        distanceTraveled = 0;
        diveStartPoint = transform.position;
        chargeTimer = DiveChargeTime;
        currentMode = AIMode.DIVE_CHARGE;
    }

    void DiveChargeMode()
    {
        if (chargeTimer > 0)
        {
            chargeTimer -= Time.deltaTime;
        }
        else
        {
            currentMode = AIMode.DIVE;
        }
    }
    void DiveMode()
    {
        if (distanceTraveled < DiveLength)
        {
            distanceTraveled = Vector2.Distance(diveStartPoint, transform.position);
            rb.velocity = new Vector2(FlySpeed * Mathf.Cos(currentAngle), FlySpeed * Mathf.Sin(currentAngle));
        }
        else
        {
            rb.velocity = Vector2.zero;
            currentMode = AIMode.SENTRY;    
        }
    }
}
