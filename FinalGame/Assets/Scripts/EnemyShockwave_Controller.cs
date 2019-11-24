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
	InvokeRepeating("fire", 3.0f, 3.0f);
        Destroy(gameObject,10);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


	public IEnumerator fire(float waitTime)
	{
		yield return new WaitForSeconds(waitTime);

		Instantiate(bullet, new Vector3(transform.position.x - 1f, transform.position.y, transform.position.z - 10f), new Quaternion(0, 0, 0, 0));
	}


    public void OnCollisionEnter(Collision collision)
    {
	Instantiate(explosion, transform.position, Quaternion.identity);
	Destroy(gameObject);
    }


}
