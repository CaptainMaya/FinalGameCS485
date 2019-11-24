using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletShockwave_Controller : MonoBehaviour
{

    public float BulletSpeed;
    public float damage;

	public GameObject explosion;
	public GameObject shrapnel;

	float shrapnelRadius;
	int shrapnelCount;
	float shrapnelAngle;

	float lifespan;


    // Start is called before the first frame update
    void Start()
    {
    	transform.GetComponent<Rigidbody>().velocity = transform.forward * BulletSpeed;

	shrapnelRadius = 2.1f;
	shrapnelCount = 12;
	shrapnelAngle = 360 / shrapnelCount;

	lifespan = Random.Range(2.0f, 5.0f);
	timeDelay(lifespan);

        Destroy(gameObject, 10);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	private void Shrapnel()
	{
		float angle, xPos, zPos;
		Vector3 pos;

		for (int i = 0; i < shrapnelCount; i++)
		{
		angle = (shrapnelAngle / 2) + (shrapnelAngle * i);
		xPos = (shrapnelRadius * Mathf.Sin(angle * Mathf.PI / 180));
		zPos = (shrapnelRadius * Mathf.Cos(angle * Mathf.PI / 180));
		pos = new Vector3(transform.position.x + xPos, transform.position.y, transform.position.z + zPos);

		Instantiate(shrapnel, pos, Quaternion.Euler(0, angle, 0));
		}


	Instantiate(explosion, transform.position, Quaternion.identity);
	Destroy(gameObject);
	}


    private void OnCollisionEnter(Collision collision)
    {
	Shrapnel();
    }


	public IEnumerator timeDelay(float lifespan)
	{
		yield return new WaitForSeconds(lifespan);
		Shrapnel();
	}


}