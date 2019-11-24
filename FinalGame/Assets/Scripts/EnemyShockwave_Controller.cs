using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Shockwave_Stats
{
    public float damage;
    public float health;
}

public class EnemyShockwave_Controller : MonoBehaviour
{

	Rigidbody rb;
	public Brute_Stats stats;
	Vector3 movement;

	public GameObject bullet;
	public GameObject explosion;


    // Start is called before the first frame update
    void Start()
    {
	rb = transform.GetComponent<Rigidbody>();

	movement = new Vector3(0f, 0f, -10f);

	rb.velocity = movement;
	InvokeRepeating("mainCannon", 3.0f, 3.0f);
        Destroy(gameObject,10);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	void mainCannon()
	{
		//shockwaveShot(Random.Range(1.0f, 4.0f));
		Instantiate(bullet, new Vector3(transform.position.x, transform.position.y, transform.position.z - 13f), Quaternion.Euler(0, 180, 0));
	}


    public void OnCollisionEnter(Collision collision)
    {
	Instantiate(explosion, transform.position, Quaternion.identity);
	Destroy(gameObject);
    }


}
