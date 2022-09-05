using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed;
    public float lifeTime;

    public Vector2 velocity = new Vector2(0.0f, 0.0f);
    public GameObject cowboy;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestroyProjectile", lifeTime);
    }

    // Update is called once per frame
    void Update()
    {
        //new code
            Vector2 currentPosition = new Vector2(transform.position.x, transform.position.y);
        Vector2 newPosition = currentPosition + velocity * Time.deltaTime;

        Debug.DrawLine(currentPosition, newPosition, Color.red);

        RaycastHit2D[] hits = Physics2D.LinecastAll(currentPosition, newPosition);

        foreach(RaycastHit2D hit in hits)
        {
            GameObject other = hit.collider.gameObject;
            if(other != cowboy)
            {
                FindObjectOfType<AudioManager>().Play("Skeleton Death");
                Destroy(gameObject);
                if (other != null)  // Prevents spamming the log with null reference exceptions
                    Debug.Log(this + " Hit " + other);  // Message saying what this bullet hit
                Destroy(other);
            }
        }

        transform.position = newPosition;
        //end of new code

        transform.Translate(Vector2.right * speed * Time.deltaTime);//speed of bullet
    }

    void DestroyProjectile(){
        Object.Destroy(gameObject);
    }
    

}
