using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using System.Boolean;


public class Enemy_Creator : MonoBehaviour
{

<<<<<<< HEAD
    public GameObject bigEnemy;
    public GameObject AlienFighter;
	public GameObject smallEnemy;
    //public float damage;
=======

	public GameObject Drone;
	public GameObject Brute;
	public GameObject Shockwave;
	public float damage;
>>>>>>> master

	bool bossBattle;
	float waveCode;

    // Start is called before the first frame update
    void Start()
    {
	bossBattle = false;
        //InvokeRepeating("spawnEnemyWaveSmall", 2.0f, 5.0f);
        //InvokeRepeating("spawnEnemyWaveDrone", 2.0f, 5.0f);
	//spawnEnemyBig();
	InvokeRepeating("spawnWave", 0.0f, 5.0f);
    }

    // Update is called once per frame
    void Update()
    {

        //spawnEnemyWaveSmall();

    }

	void spawnWave()
	{
<<<<<<< HEAD
		//Instantiate(bigEnemy);
=======

		while(!bossBattle)
		{
			waveCode = Random.Range(0.0f, 10.0f);

			//30% chance of drone wave
			if (waveCode < 3.0f)
			{
				spawnEnemyWaveDrone();
			}
			//30% chance of brutes
			else if (waveCode < 6.0f)
			{
				spawnEnemyWaveBrute();
			}
			//20% chance of Shockwave
			else if (waveCode < 8.0f)
			{
				spawnEnemyWaveShockwave();
			}
			//20% chance of everything
			else
			{
				spawnEnemyWaveDrone();
				spawnEnemyWaveBrute();
				spawnEnemyWaveShockwave();
			}
		}
>>>>>>> master
	}


	public IEnumerator spawnEnemyDrone(float waitTime)
	{
		yield return new WaitForSeconds(waitTime);
<<<<<<< HEAD
		Instantiate(smallEnemy);
        Instantiate(AlienFighter);

    }
=======
		Instantiate(Drone, new Vector3(Random.Range(-50, 50), 0, 70), new Quaternion(0, 180, 0, 0));
	}
>>>>>>> master

	public IEnumerator spawnEnemyBrute(float waitTime)
	{
		yield return new WaitForSeconds(waitTime);
		Instantiate(Brute, new Vector3(Random.Range(-50, 50), 0, 70), new Quaternion(0, 180, 0, 0));
	}

	public IEnumerator spawnEnemyShockwave(float waitTime)
	{
		yield return new WaitForSeconds(waitTime);
		Instantiate(Brute, new Vector3(Random.Range(-50, 50), 0, 70), new Quaternion(0, 180, 0, 0));
	}




	void spawnEnemyWaveDrone()
	{
		StartCoroutine(spawnEnemyDrone(0.5f));
		StartCoroutine(spawnEnemyDrone(1.0f));
		StartCoroutine(spawnEnemyDrone(1.5f));
		StartCoroutine(spawnEnemyDrone(2.0f));
		StartCoroutine(spawnEnemyDrone(2.5f));
	}


	void spawnEnemyWaveBrute()
	{
		StartCoroutine(spawnEnemyBrute(1.0f));
		StartCoroutine(spawnEnemyBrute(2.5f));
	}


	void spawnEnemyWaveShockwave()
	{
<<<<<<< HEAD

            StartCoroutine(spawnEnemySmall(0.5f));
            StartCoroutine(spawnEnemySmall(1.0f));
            StartCoroutine(spawnEnemySmall(1.5f));
            StartCoroutine(spawnEnemySmall(2.0f));
            StartCoroutine(spawnEnemySmall(2.5f));

    }

  
=======
		StartCoroutine(spawnEnemyShockwave(0.5f));
		StartCoroutine(spawnEnemyShockwave(4.5f));
	}
>>>>>>> master
}
