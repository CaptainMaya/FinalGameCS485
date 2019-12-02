using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Asteroid_Stats
{
    public float maxHealth;
    public float currentHealth;
    public float damage;

}



public class Asteroid_Controller : MonoBehaviour
{
	public Asteroid_Stats stats;

    private Quaternion randomRotation;

    public GameObject explosionPrefab;


    private void Start()
    {
        stats.currentHealth = stats.maxHealth;

        randomRotation = Random.rotation;
    }

    private void Update()
    {
        transform.Rotate(randomRotation.eulerAngles * 0.1f * Time.deltaTime);

        if (stats.currentHealth <= 0)
        {
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            stats.currentHealth -= collision.transform.GetComponent<Bullet_Controller>().damage;
            Destroy(collision.gameObject);
        }
     

    }
}