using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayHealth : MonoBehaviour
{
    Text Health;
    private int health = 0;
    // Start is called before the first frame update
    void Start()
    {
        Health = GetComponent<Text>();
        Health.text = "Health: " + health;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
