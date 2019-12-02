using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class FirstStage : MonoBehaviour
{
 public Boss_Controller boss;
	  public EnemyBig_Controller enemyBig;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    	Debug.Log("Mini Killed"+EnemyBig_Controller.Global.killCount);
    	if(EnemyBig_Controller.Global.killCount == 1)
    	{
    		Debug.Log("works...");
    		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 4);

    	}

        
    }
}
