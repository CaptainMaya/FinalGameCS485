using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySmall_Controller : MonoBehaviour
{

	Rigidbody rb;
	Vector3 movement;

    // Start is called before the first frame update
    void Start()
    {
	rb = transform.GetComponent<Rigidbody>();
	transform.Rotate(0, 180, 0, Space.Self);
        transform.position = new Vector3(Random.Range(-50,50), Random.Range(-1, 1), 70);

	movement = new Vector3(0f, 0f, -10f);

	rb.velocity = movement;
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject,10);
    }
}
