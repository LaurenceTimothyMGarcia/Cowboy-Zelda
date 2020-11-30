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
                Debug.Log(hit.collider.gameObject);
                Destroy(hit.collider.gameObject);
            }
        }

        transform.position = newPosition;
        //end of new code

        transform.Translate(Vector2.right * speed * Time.deltaTime);//speed of bullet

        /*foreach(GameObject enemy in GameObject.FindGameObjectsWithTag("Enemy"))
        {//projectile collision
            float selfx = transform.position.x;
            float selfy = transform.position.y;
            float enemyx = enemy.transform.position.x;
            float enemyy = enemy.transform.position.y;
            BoxCollider2D enemyBox = enemy.GetComponent(typeof(BoxCollider2D)) as BoxCollider2D;
            float enemyw = enemyBox.size.x;
            float enemyh = enemyBox.size.y;

            if(selfx>enemyx &&
                selfx<enemyx+enemyw &&
                selfy>enemyy &&
                selfy<enemyy+enemyh
                )
            {
                FindObjectOfType<AudioManager>().Play("Skeleton Death");

                Object.Destroy(enemy);
                DestroyProjectile();
            }
        }*/
    }

    void DestroyProjectile(){
        Object.Destroy(gameObject);
    }
    

}
