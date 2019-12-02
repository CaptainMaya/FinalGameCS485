using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Small_Stats
{
    public float maxHealth = 5;
    public float currentHealth = 5;
    public float damage = 5;
}



public class EnemySmall_Controller : MonoBehaviour
{
    public float damage = 5f;
	Rigidbody rb;
    public GameObject explosionPrefab;
    public Small_Stats stats;
	Vector3 movement;

    // Start is called before the first frame update
    void Start()
    {
    //public Small_Stats stats;
    stats.currentHealth = stats.maxHealth;
	rb = transform.GetComponent<Rigidbody>();
	transform.Rotate(0, 180, 0, Space.Self);

        transform.position = new Vector3(Random.Range(-70,70), Random.Range(-1, 1), 90);

	movement = new Vector3(0f, 0f, -10f);

	rb.velocity = movement;
    }

    // Update is called once per frame
    void Update()
    {
        if (stats.currentHealth <= 0)
        {
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }

        //Destroy(gameObject,10);
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
