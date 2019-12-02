using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shockwave_Stats
{
    public float shockDistance; //radius of shockwave distance
    public float damage;
    public float shockSpeed;
}

public class Shockwave_Controller : MonoBehaviour
{
    public Shockwave_Stats stats;
    public ParticleSystem ps;

    // Start is called before the first frame update
    void Start()
    {
        ps = transform.GetComponent<ParticleSystem>();
        transform.GetComponent<Rigidbody>().velocity = transform.forward * stats.shockSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        if (!ps.IsAlive())
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.transform.GetComponent<Ship_Controller>().stats.currentHealth -= stats.damage;
        }

        if (!ps.IsAlive())
        {
            Destroy(gameObject);
        }
    }
}
