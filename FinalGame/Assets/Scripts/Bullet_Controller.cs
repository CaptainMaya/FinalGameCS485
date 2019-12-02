using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class Bullet_Controller : MonoBehaviour
{
    // Start is called before the first frame update
    public float BulletSpeed;

    public float damage;

    private void Start()
    {
    	transform.GetComponent<Rigidbody>().velocity = transform.forward * BulletSpeed;



    }

    private void Update()
    {
    	Destroy(gameObject,10);
    }

    private void OnCollisionEnter(Collision collision)
    {
    	if (collision.gameObject.tag == "Ast")
    	{
    		collision.transform.GetComponent<Asteroid_Controller>().stats.currentHealth -= damage;
    		//Destroy(gameObject);

    	}

        if (collision.gameObject.tag == "Spawner")
        {
            collision.transform.GetComponent<EnemyBig_Controller>().stats.currentHealth -= damage;
           // Destroy(gameObject);

        }

        if (collision.gameObject.tag == "LittleOne")
        {
            collision.transform.GetComponent<EnemySmall_Controller>().stats.currentHealth -= damage;
            //Destroy(gameObject);

        }

        if (collision.gameObject.tag == "Player")
        {
            collision.transform.GetComponent<Ship_Controller>().stats.currentHealth -= damage;
            //Destroy(gameObject);

        }

        if (collision.gameObject.tag == "NewBoss")
        {
            collision.transform.GetComponent<MediumStage>().stats.currentHealth -= damage;
            //Destroy(gameObject);

        }

        else if (collision.gameObject.tag == "Boss")
        {
            collision.transform.GetComponent<Boss_Controller>().stats.currentHealth -= damage;
            //Destroy(gameObject);
        }


    }
}
