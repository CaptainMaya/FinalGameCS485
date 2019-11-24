using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Brute_Stats
{
    public float damage;
    public float health;
}

public class EnemyBrute_Controller : MonoBehaviour
{

	Rigidbody rb;
	public Brute_Stats stats;
	Vector3 movement;

	public GameObject bullet;
	public GameObject explosion;

	Quaternion r1, r2, r3, r4, r5;

    // Start is called before the first frame update
    void Start()
    {
	rb = transform.GetComponent<Rigidbody>();

	movement = new Vector3(0f, 0f, -10f);

	r1 = Quaternion.Euler(0, 210, 0);
	r2 = Quaternion.Euler(0, 195, 0);
	r3 = Quaternion.Euler(0, 180, 0);
	r4 = Quaternion.Euler(0, 165, 0);
	r5 = Quaternion.Euler(0, 150, 0);

	rb.velocity = movement;
	InvokeRepeating("doubleShot", 5.0f, 2.0f);
        Destroy(gameObject,10);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


	public IEnumerator fireNarrow(float waitTime)
	{
		yield return new WaitForSeconds(waitTime);

		Instantiate(bullet, new Vector3(transform.position.x - 2f, transform.position.y, transform.position.z - 2f), r2);
		Instantiate(bullet, new Vector3(transform.position.x, transform.position.y, transform.position.z - 3f), r3);
		Instantiate(bullet, new Vector3(transform.position.x + 2f, transform.position.y, transform.position.z - 2f), r4);
	}

	public IEnumerator fireBroad(float waitTime)
	{
		yield return new WaitForSeconds(waitTime);

		Instantiate(bullet, new Vector3(transform.position.x - 2f, transform.position.y, transform.position.z - 2f), r1);
		Instantiate(bullet, new Vector3(transform.position.x, transform.position.y, transform.position.z - 3f), r3);
		Instantiate(bullet, new Vector3(transform.position.x + 2f, transform.position.y, transform.position.z - 2f), r5);
	}


	void doubleShot()
	{
		StartCoroutine(fireNarrow(0.1f));
		StartCoroutine(fireBroad(0.3f));
		//StartCoroutine(fireNarrow(0.3f));
	}


    public void OnCollisionEnter(Collision collision)
    {
	Instantiate(explosion, transform.position, Quaternion.identity);
	Destroy(gameObject);
    }

}