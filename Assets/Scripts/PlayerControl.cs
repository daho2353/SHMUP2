using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour
{
    public float manateeSpeed = 10f;
    public KeyCode moveUpKey, moveDownKey, moveRightKey, moveLeftKey;
    public float bounds = 500;
    public int health;
    private GameObject lastTriggerGo = null;
    public float gameRestartDelay = 2f;
    public GameObject projectilePrefab;
    private bool canShoot = true;
    public float projectileSpeed = 400;
    public float projectileTimer = 0.75f; //.25 second delay on projectile
    // Start is called before the first frame update
    void Start()
    {
        health = 3;
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;
        if(sceneName == "scene0")
        {
            canShoot = false;
        }
        else
        {
            canShoot = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        projectileTimer += Time.deltaTime;
        if (Input.GetKey(moveUpKey) && transform.position.y < (bounds + 25))
        {
            //move paddle up
            Vector3 currPos = transform.position;
            Vector3 newPos = new Vector3(currPos.x, currPos.y + manateeSpeed * Time.deltaTime, currPos.z);
            transform.position = newPos;
        }

        if (Input.GetKey(moveDownKey) && transform.position.y > -bounds)
        {
            //move paddle down
            Vector3 currPos = transform.position;
            Vector3 newPos = new Vector3(currPos.x, currPos.y - manateeSpeed * Time.deltaTime, currPos.z);
            transform.position = newPos;
        }

        if (Input.GetKey(moveRightKey) && transform.position.x < (bounds+100))
        {
            Vector3 currPos = transform.position;
            Vector3 newPos = new Vector3(currPos.x + manateeSpeed * Time.deltaTime, currPos.y, currPos.z);
            transform.position = newPos;
        }

        if (Input.GetKey(moveLeftKey) && transform.position.x > (-bounds-100))
        {
            Vector3 currPos = transform.position;
            Vector3 newPos = new Vector3(currPos.x - manateeSpeed * Time.deltaTime, currPos.y, currPos.z);
            transform.position = newPos;
        }

        if (Input.GetKeyDown(KeyCode.Space) && projectileTimer  >= 2 && canShoot == true)
        {                           // a
            projectileTimer = 0.75f;
            TempFire();

        }
    }

    void TempFire()
    {                                                        // b

        GameObject projGO = Instantiate<GameObject>(projectilePrefab);

        projGO.transform.position = transform.position;

        Rigidbody rigidB = projGO.GetComponent<Rigidbody>();

        rigidB.velocity = Vector3.right * projectileSpeed;

    }

    void OnTriggerEnter(Collider other)
    {

        Transform rootT = other.gameObject.transform.root;

        GameObject go = rootT.gameObject;

        //print("Triggered: "+go.name);                                      // b

        // Make sure it's not the same triggering go as last time

        if (go == lastTriggerGo)
        {                                           // c

            return;

        }

        lastTriggerGo = go;                                                  // d



        if (go.tag == "Enemy")
        {  // If the shield was triggered by an enemy
            health--;
            if(health == 0)
            {
                Destroy(this.gameObject);
                Main.S.DelayedRestart(gameRestartDelay);
            }
            Destroy(go);          // … and Destroy the enemy                 // e

        }
        else
        {

            print("Triggered by non-Enemy: " + go.name);                       // f

        }

    }
}
