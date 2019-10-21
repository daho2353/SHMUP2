using System.Collections;           // Required for Arrays & other Collections

using System.Collections.Generic;   // Required to use Lists or Dictionaries

using UnityEngine;                  // Required for Unity

using UnityEngine.SceneManagement;  // For loading & reloading of scenes



public class Main : MonoBehaviour
{

    static public Main S;                                // A singleton for Main



    [Header("Set in Inspector")]

    public GameObject[] prefabEnemies;              // Array of Enemy prefabs

    public float enemySpawnPerSecond = 0.5f; // # Enemies/second

    public float enemyDefaultPadding = 1.5f; // Padding for position

    public float boundsX = 485;

    public float boundsY = 425;

    public float timer = 30;

    public int level = 0;

    private bool isCrab = false;


    void Awake()
    {

        S = this;

        // Invoke SpawnEnemy() once (in 2 seconds, based on default values)

        Invoke("SpawnEnemy", 1f / enemySpawnPerSecond);                      // a

    }

    void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            NextLevel();

        }
    }


    public void SpawnEnemy()
    {

        // Pick a random Enemy prefab to instantiate

        int ndx = Random.Range(0, prefabEnemies.Length);                     

        GameObject go = Instantiate<GameObject>(prefabEnemies[ndx]);

        print(go.name);
        if(go.name == "Pirahna(Clone)")
        {
            isCrab = true;
        }
        else
        {
            isCrab = false;
        }


        // Set the initial position for the spawned Enemy                    

        if(isCrab == true)
        {
            Vector3 posCrab = Vector3.zero;

            float yMin = -375;
            float yMax = boundsY;
            posCrab.x = boundsX;
            posCrab.y = Random.Range(yMin, yMax);
            posCrab.z = 730;
            go.transform.position = posCrab;
        }
        else
        {
            print("not pirahna");
            Vector3 pos = Vector3.zero;

            float xMin = -boundsX;

            float xMax = boundsX;

            pos.x = Random.Range(xMin, xMax);

            pos.y = boundsY;

            pos.z = 730;

            go.transform.position = pos;
        }

        // Invoke SpawnEnemy() again

        Invoke("SpawnEnemy", 1f / enemySpawnPerSecond);                      

    }
    public void DelayedRestart(float delay)
    {

        // Invoke the Restart() method in delay seconds

        Invoke("Restart", delay);

    }



    public void Restart()
    {

        // Reload _Scene_0 to restart the game

        SceneManager.LoadScene("scene0");
        
    }

    public void NextLevel()
    {
        level++;
        if (level == 1)
        {
            SceneManager.LoadScene("scene1");
        }
        /*
        else if (level == 2)
        {
            SceneManager.LoadScene("scene2");
        }
        else if (level == 3)
        {
            SceneManager.LoadScene("scene3");
        }
        else if (level == 4)
        {
            SceneManager.LoadScene("scene4");
        }
        else
        {
            SceneManager.LoadScene("scene5");
        }
        */
    }

}