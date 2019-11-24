using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBrute_Controller : MonoBehaviour
{

    public float BulletSpeed;
    public float damage;

	public GameObject explosion;


    // Start is called before the first frame update
    void Start()
    {
    	transform.GetComponent<Rigidbody>().velocity = transform.forward * BulletSpeed;
        Destroy(gameObject, 10);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
	Instantiate(explosion, transform.position, Quaternion.identity);
	Destroy(gameObject);
    }

}
