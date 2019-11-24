using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Drone_Stats
{
    public float damage;
}



public class EnemyDrone_Controller : MonoBehaviour
{

	Rigidbody rb;
    public Small_Stats stats;
	Vector3 movement;

    //public Ship_Stats stats;

    public GameObject bullet;
    public GameObject explosion;



    // Start is called before the first frame update
    void Start()
    {
    //public Small_Stats stats;
	rb = transform.GetComponent<Rigidbody>();
	//transform.Rotate(0, 180, 0, Space.Self);
        //transform.position = new Vector3(Random.Range(-50,50), Random.Range(-1, 1), 70);

	movement = new Vector3(0f, 0f, -10f);

	rb.velocity = movement;
	InvokeRepeating("tripleShot", 2.0f, 5.0f);
        Destroy(gameObject,10);
    }

    // Update is called once per frame
    void Update()
    {
    }


	public IEnumerator fire(float waitTime)
	{
		yield return new WaitForSeconds(waitTime);
		Instantiate(bullet, new Vector3(transform.position.x, transform.position.y, transform.position.z - 2), new Quaternion(0, 0, 0, 0));
	}

	void tripleShot()
	{
		StartCoroutine(fire(0.3f));
		StartCoroutine(fire(0.6f));
		StartCoroutine(fire(0.9f));
	}



    public void OnCollisionEnter(Collision collision)
    {
	Instantiate(explosion, transform.position, Quaternion.identity);
	Destroy(gameObject);
    }



}