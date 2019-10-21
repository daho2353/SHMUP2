using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwimmingEnemy : MonoBehaviour
{

    [Header("Set in Inspector: Enemy")]

    public float speed = 10f;      // The speed in m/s

    public float fireRate = 0.3f;  // Seconds/shot (Unused)

    public int health = 1;

    private float bounds = 475;

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
        
        if (transform.position.x < -bounds)
        {
            Destroy(gameObject);
        }

    }



    public virtual void Move()
    {                                             // b

        Vector3 tempPos = pos;

        tempPos.x -= speed * Time.deltaTime;

        pos = tempPos;
    }

    void OnTriggerEnter(Collider coll)
    {

        GameObject otherGO = coll.gameObject;                                  // a

        if (otherGO.tag == "ProjectileHero")
        {                               // b

            Destroy(otherGO);        // Destroy the Projectile

            if (health <= 1)
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

