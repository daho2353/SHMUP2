using System.Collections;          // Required for Arrays & other Collections

using System.Collections.Generic;  // Required for Lists and Dictionaries

using UnityEngine;                 // Required for Unity



public class FallingEnemy : MonoBehaviour
{

    [Header("Set in Inspector: Enemy")]

    public float speed = 10f;      // The speed in m/s

    public float fireRate = 0.3f;  // Seconds/shot (Unused)

    public int health = 1;

    private float rotationsPerMin = 10f;

    private float bounds = 425;

    public GameObject enemy;
    // This is a Property: A method that acts like a field

    public Vector3 pos
    {                                                     // a


        get
        {

            return (this.transform.position);

        }

        set
        {

            this.transform.position = value;
            

        }

    }


    void Update()
    {
        Move();
        transform.Rotate(0, 0, 5 * rotationsPerMin * Time.deltaTime);
        if(transform.position.y < -bounds)
        {
            Destroy(gameObject);
        }
    }



    public virtual void Move()
    {                                             // b

        Vector3 tempPos = pos;
        
        tempPos.y -= speed * Time.deltaTime;
        
        pos = tempPos;

    }

    void OnTriggerEnter(Collider coll)
    {

        GameObject otherGO = coll.gameObject;                                  // a

        if (otherGO.tag == "ProjectileHero")
        {                               // b
           
            Destroy(otherGO);        // Destroy the Projectile

            if(health <= 1)
            {
                Destroy(gameObject);     // Destroy this Enemy GameObject
                print("destroyed with" + health + "health");
            }

            health--;
            print(health);
            

        }
        else
        {

            print("Enemy hit by non-ProjectileHero: " + otherGO.name);     // c

        }

    }

}
