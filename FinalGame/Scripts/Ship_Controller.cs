using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


[System.Serializable]

public class Ship_Stats
{
    public float maxHealth;
    public float currentHealth;
}

public class Ship_Controller : MonoBehaviour
{
    Rigidbody rb;

    public Ship_Stats stats;

    public GameObject bullet;
    public Transform[] firePoints = new Transform[2];
    public float fireRate;
    private float nextFire;

    public GameObject explosionPrefab;


    public float moveSpeed;
    public float tiltAngle;



    private void Start()
    {
        rb = transform.GetComponent<Rigidbody>(); //gets the outter shell of the ship
        stats.currentHealth = stats.maxHealth;
        nextFire = 2f / fireRate; //how fast the bullets will be fired
        //nextFire += 1 / fireRate;

    }

    private void Update()
    {



        if (stats.currentHealth <= 0)
        {
        	Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            //yield WaitForSeconds(4);
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 3);
            SceneManager.LoadScene("GameOver");
            Destroy(gameObject);
            


        }
    }

    private void FixedUpdate()
    {
        float moveLR = Input.GetAxis("Horizontal"); //move left to right
        float moveFB = Input.GetAxis("Vertical"); //move front and forward

        Vector3 movement = new Vector3(moveLR, 0, moveFB);
        rb.velocity = movement * moveSpeed;

        rb.rotation = Quaternion.Euler(Vector3.forward * moveLR * -tiltAngle);

        bool fireButton = Input.GetButton("Fire1");

        Collider[] shipColliders = transform.GetComponentsInChildren<Collider>();

        if(fireButton)
        {
            nextFire -= Time.fixedDeltaTime;
            if(nextFire <= 0)
            {
                for (int i = 0; i < 2; i++)
                {
                    GameObject bulletClone = Instantiate(bullet, firePoints[i].position, Quaternion.identity);

                    for(int x = 0; x < shipColliders.Length; x++)
                    {
                    	Physics.IgnoreCollision(bulletClone.transform.GetComponent<Collider>(), shipColliders[x]);

                    }


                }
               nextFire += 2f / fireRate;

            }

        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ast")
        {
            stats.currentHealth -= collision.transform.GetComponent<Asteroid_Controller>().stats.damage;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "Spawner")
        {
            stats.currentHealth -= collision.transform.GetComponent<EnemyBig_Controller>().stats.damage;
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "Bullet")
        {
            stats.currentHealth -= collision.transform.GetComponent<Bullet_Controller>().damage;
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "LittleOne")
        {
            stats.currentHealth -= collision.transform.GetComponent<EnemySmall_Controller>().stats.damage;
            Destroy(collision.gameObject);
        }

    }
}


