using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;


[System.Serializable]



public class Boss_Stats
{
    public float maxHealth;
    public float currentHealth;
    public string nextAbility;
    public float abilityTimer; //counter
    public float abilityTime; //fixed time between abilities
    //public float pulseDistance; //length pulse beam extends out
    public float shockDistance; //radius shock wave extends out
    public float shockDamage;
}

public class Boss_Controller : MonoBehaviour
{
    public float bulletTimer;
    public float waitingTimer;
    public Boss_Stats stats;
    public Transform Player;
    public GameObject explosionPrefab;
    public GameObject shockPrefab;
    public GameObject pulsePrefab;
    public GameObject bullet;
    public Transform[] firePoints = new Transform[2];
    public float fireRate;
    private float nextFire;
    int MoveSpeed = 5;
   // int MaxDist = 10;
    int MinDist = 5;

public class Global 
 {
     public static int bossKill = 0;
 }

    void Start()
    {
        stats.currentHealth = stats.maxHealth = 500f;
        stats.shockDistance = 5f;
        stats.shockDamage = 30f;
        //stats.pulseDistance = 20f;
        stats.nextAbility = "pulsebeam";
        stats.abilityTimer = 0f;
        stats.abilityTime = 5f;
        waitingTimer = 2f;
        bulletTimer = 0f;
    }

    
    void Update()
    {
        stats.abilityTimer += Time.deltaTime;
        bulletTimer += Time.deltaTime;
        Collider[] bossColliders = transform.GetComponentsInChildren<Collider>();
        transform.LookAt(Player);

        if (stats.currentHealth <= 0)
        {
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 3);
            Destroy(gameObject);
            Global.bossKill = Global.bossKill + 1;
            
            //Debug.Log("Boss Kills"+Global.bossKill);

        }

        if (stats.abilityTimer >= stats.abilityTime)
        {
            if (stats.nextAbility == "pulsebeam")
            {
                Instantiate(pulsePrefab, transform.position, Quaternion.identity);
                stats.abilityTimer = 0f;
                stats.nextAbility = "shockwave";
            }
            else if (stats.nextAbility == "shockwave")
            {
                Instantiate(shockPrefab, transform.position, Quaternion.identity);
                if (Vector3.Distance(transform.position, Player.position) <= stats.shockDistance)
                {
                    transform.GetComponent<Ship_Controller>().stats.currentHealth -= stats.shockDamage;
                }
                stats.abilityTimer = 0f;
                stats.nextAbility = "pulsebeam";




            }

        }

        if (Vector3.Distance(transform.position, Player.position) >= MinDist)
        {
            transform.position += transform.forward * MoveSpeed * Time.deltaTime;
        }

        if (bulletTimer >= waitingTimer)
        {
            //GameObject bulletClone = Instantiate(bullet, transform.position, Quaternion.identity);
            GameObject bulletClone = Instantiate(bullet, transform.position, transform.rotation);
            bulletClone.transform.TransformDirection(new Vector3(0, 0, MoveSpeed));
            bulletTimer = 0f;
        }

        //if (stats.currentHealth <= 0)
        //{
            //Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 3);
            //Destroy(gameObject);
        //}
    }
}