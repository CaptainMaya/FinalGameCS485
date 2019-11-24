using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Creator_Stats
{
    public float maxHealth;
    public float currentHealth;

    public float damage;
}

public class Enemy_Creator : MonoBehaviour
{

	public GameObject enemyDrone;
	public GameObject enemyBrute;
	public GameObject enemyShockwave;
	public float damage;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("spawnWaveDrone", 2.0f, 5.0f);
        InvokeRepeating("spawnWaveBrute", 2.0f, 5.0f);
        InvokeRepeating("spawnWaveShockwave", 5.0f, 6.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


	public IEnumerator spawnEnemyDrone(float waitTime)
	{
		yield return new WaitForSeconds(waitTime);
		//Instantiate(enemyDrone);
		Instantiate(enemyDrone, new Vector3(Random.Range(-50, 50), 0, 70), new Quaternion(0, 180, 0, 0));
	}

	public IEnumerator spawnEnemyBrute(float waitTime)
	{
		yield return new WaitForSeconds(waitTime);
		//Instantiate(enemyBrute);
		Instantiate(enemyBrute, new Vector3(Random.Range(-50, 50), 0, 70), new Quaternion(0, 180, 0, 0));
	}

	public IEnumerator spawnEnemyShockwave(float waitTime)
	{
		yield return new WaitForSeconds(waitTime);
		//Instantiate(enemyShockwave);
		Instantiate(enemyShockwave, new Vector3(Random.Range(-50, 50), 0, 70), new Quaternion(0, 180, 0, 0));
	}



	void spawnWaveDrone()
	{
		StartCoroutine(spawnEnemyDrone(0.5f));
		StartCoroutine(spawnEnemyDrone(1.0f));
		StartCoroutine(spawnEnemyDrone(1.5f));
		StartCoroutine(spawnEnemyDrone(2.0f));
		StartCoroutine(spawnEnemyDrone(2.5f));
	}

	void spawnWaveBrute()
	{
		StartCoroutine(spawnEnemyBrute(1.5f));
		StartCoroutine(spawnEnemyBrute(3.0f));
	}

	void spawnWaveShockwave()
	{
		StartCoroutine(spawnEnemyShockwave(Random.Range(1.0f, 4.0f)));
	}
}
