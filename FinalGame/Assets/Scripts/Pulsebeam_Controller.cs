using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pulsebeam_Stats
{
    public float pulseDistance; //pulse beam distance
    public float pulseSpeed;
    public float damage;
}

public class Pulsebeam_Controller : MonoBehaviour
{
    public Pulsebeam_Stats stats;
    public ParticleSystem ps;
    public Transform Player;
    public Vector3 lastPosition;
    public float distanceTraveled;

    // Start is called before the first frame update
    void Start()
    {
        //ps = transform.GetComponent<ParticleSystem>();
        lastPosition = transform.position;
        stats.pulseSpeed = 1f;
        distanceTraveled = 0f;
        stats.pulseDistance = 10f;
        stats.damage = 1000f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(Player);
        distanceTraveled += Vector3.Distance(transform.position, lastPosition);
        lastPosition = transform.position;
        transform.position += transform.forward * stats.pulseSpeed * Time.deltaTime;

        if (distanceTraveled >= stats.pulseDistance)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.transform.GetComponent<Ship_Controller>().stats.currentHealth -= stats.damage;
            Destroy(gameObject);
        }

        //if (!ps.IsAlive())
        //{
          //  Destroy(gameObject);
        //}
    }
}
