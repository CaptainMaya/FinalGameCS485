using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBig_Controller : MonoBehaviour
{
	Rigidbody rb;
	Vector3 movement;

    // Start is called before the first frame update
    void Start()
    {
        rb = transform.GetComponent<Rigidbody>();

	transform.Rotate(0, 180, 0, Space.Self);
	transform.position = new Vector3(0, 4, 40);

	movement = new Vector3(10f, 0f, 0f);

	rb.velocity = movement;
    }

    // Update is called once per frame
    void Update()
    {
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
}