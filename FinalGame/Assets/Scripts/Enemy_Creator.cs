using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Creator : MonoBehaviour
{

	public GameObject bigEnemy;
	public GameObject smallEnemy;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("spawnEnemyWaveSmall", 2.0f, 5.0f);
	spawnEnemyBig();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	void spawnEnemyBig()
	{
		Instantiate(bigEnemy);
	}

	public IEnumerator spawnEnemySmall(float waitTime)
	{
		yield return new WaitForSeconds(waitTime);
		Instantiate(smallEnemy);
	}

	void spawnEnemyWaveBig()
	{
	}

	void spawnEnemyWaveSmall()
	{
		StartCoroutine(spawnEnemySmall(0.5f));
		StartCoroutine(spawnEnemySmall(1.0f));
		StartCoroutine(spawnEnemySmall(1.5f));
		StartCoroutine(spawnEnemySmall(2.0f));
		StartCoroutine(spawnEnemySmall(2.5f));
	}
}
