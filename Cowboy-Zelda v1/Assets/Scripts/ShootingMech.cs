using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShootingMech : MonoBehaviour
{
    private Rigidbody2D rb;

    public float offset;
    public float bulletCount;

    public int maxAmmo = 3;
    private int currentAmmo;
    public float reloadTime = 2f;
    private bool isReloading = false;
    public Text ammoDisplay;

    public GameObject bulletPrefab;
    public Transform shotPoint;

    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        currentAmmo = maxAmmo;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        ammoDisplay.text = currentAmmo.ToString();

        Vector3 movement = new Vector3(Input.GetAxis("Horizontal")*2, Input.GetAxis("Vertical")*2, 0.0f);//moves character

        //animation of sprites
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Magnitude", movement.magnitude);

        transform.position = transform.position + movement * Time.deltaTime;

        if (isReloading)
        {
            return;
        }

        if (currentAmmo <= 0)
        {
            StartCoroutine(Reload());
            return;
        }

        if (Input.GetMouseButtonDown(0)){//button press to shoot
            GameObject projectile = Instantiate(bulletPrefab, shotPoint.position, Quaternion.FromToRotation(new Vector3(1, 0, 0), movement));
            Projectile projectileScript = projectile.GetComponent<Projectile>();
            projectileScript.cowboy = gameObject;
            currentAmmo--;
        }

    }

    void OnDestroy()
    {
        FindObjectOfType<AudioManager>().Play("Cowboy Death");
        FindObjectOfType<GameManager>().EndGame();
    }

    IEnumerator Reload()
    {
        isReloading = true;
        Debug.Log("Reloading...");

        yield return new WaitForSeconds(reloadTime);

        currentAmmo = maxAmmo;
        isReloading = false;
    }

}
