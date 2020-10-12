using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingMech : MonoBehaviour
{
    public GameObject crossHair;
    public GameObject bulletPrefab;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"),0.0f);

        

        MoveCrossHair();

        transform.position = transform.position + movement * Time.deltaTime;

    }

    private void MoveCrossHair(){
        Vector3 aim = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"),0.0f);
        aim.Normalize();
    }
}
