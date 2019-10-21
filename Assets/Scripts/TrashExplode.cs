using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashExplode : MonoBehaviour
{
    private int health = 1;
    public GameObject bottle;
    private float projectileSpeed = 400;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        health--;
        if (health == 0)
        {
            GameObject projN = Instantiate<GameObject>(bottle);

            GameObject projE = Instantiate<GameObject>(bottle);

            GameObject projS = Instantiate <GameObject>(bottle);

            GameObject projW = Instantiate<GameObject>(bottle);

            projN.transform.position = transform.position;
            projE.transform.position = transform.position;
            projS.transform.position = transform.position;
            projW.transform.position = transform.position;

            Rigidbody rigidN = projN.GetComponent<Rigidbody>();
            Rigidbody rigidE = projE.GetComponent<Rigidbody>();
            Rigidbody rigidS = projS.GetComponent<Rigidbody>();
            Rigidbody rigidW = projW.GetComponent<Rigidbody>();

            rigidN.velocity = Vector3.up * projectileSpeed;
            rigidE.velocity = Vector3.right * projectileSpeed;
            rigidS.velocity = Vector3.down * projectileSpeed;
            rigidW.velocity = Vector3.left * projectileSpeed;

        }
    }
}
