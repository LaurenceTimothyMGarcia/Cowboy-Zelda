using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingMech : MonoBehaviour
{
    public float offset;

    public GameObject bulletPrefab;
    public Transform shotPoint;

    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0.0f);//moves character

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Magnitude", movement.magnitude);

        transform.position = transform.position + movement * Time.deltaTime;

        //Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;//makes bullet follow mouse
        //float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        //transform.rotation = Quaternion.Euler(0f,0f,rotZ + offset);



        /*if(Input.GetAxis("Horizontal") != 0){
            if(Input.GetAxis("Horizontal") > 0){
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }   else{
            transform.rotation = Quaternion.Euler(0, -180, 0);
            }
        }   else if(Input.GetAxis("Vertical") != 0){
                if(Input.GetAxis("Vertical") >= 0){
                    transform.rotation = Quaternion.Euler(0, 0, 0);
                }   else{
                    transform.rotation = Quaternion.Euler(-180, 0, 0);
                }
        }*/

        if (Input.GetMouseButtonDown(0)){//button press to shoot
            Instantiate(bulletPrefab, shotPoint.position, Quaternion.FromToRotation(new Vector3(1, 0, 0), movement));
        }

    }

}
