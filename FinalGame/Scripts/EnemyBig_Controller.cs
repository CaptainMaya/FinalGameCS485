using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


[System.Serializable]
public class EnemyBig_Stats
{
    public float maxHealth;
    public float currentHealth;
    public float damage;
}



public class EnemyBig_Controller : MonoBehaviour
{
    public GameObject explosionPrefab;

   

    public EnemyBig_Stats stats;
    Rigidbody rb;
	Vector3 movement;

    public class Global 
    {
     public static int killCount = 0;
     public static int killedCount = 0;

    }

    // Start is called before the first frame update
    void Start()
    {
        stats.currentHealth = stats.maxHealth;

        rb = transform.GetComponent<Rigidbody>();

	    transform.Rotate(0, 180, 0, Space.Self);
	    transform.position = new Vector3(0, 0, 40);

	    movement = new Vector3(10f, 0f, 0f);
        rb.velocity = movement;
    }


    // Update is called once per frame
    void Update()
    {
        if (stats.currentHealth <= 0)
        {
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
            Global.killCount = Global.killCount + 1;
            Global.killedCount = Global.killedCount + 1;

            Debug.Log("Big Enemy"+Global.killCount);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 3);


        }

        if (transform.position.x < -60)

	    {
		    movement.x = 10f;
		    rb.velocity = movement;
	    }
	    else if (transform.position.x > 60)
	    {
		    movement.x = -10f;
		    rb.velocity = movement;
	    }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            stats.currentHealth -= collision.transform.GetComponent<Bullet_Controller>().damage;
            Destroy(collision.gameObject);
        }


    }
}