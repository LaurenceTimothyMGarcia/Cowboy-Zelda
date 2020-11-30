using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed;
    public float lifeTime;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestroyProjectile", lifeTime);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);//speed of bullet

        foreach(GameObject enemy in GameObject.FindGameObjectsWithTag("Enemy"))
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
                //DestroyProjectile();
            }
        }
    }

    void DestroyProjectile(){
        Object.Destroy(gameObject);
    }
    

}
