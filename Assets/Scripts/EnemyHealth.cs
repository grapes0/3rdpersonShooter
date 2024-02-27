using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float health = 100;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void DealDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
   
    // Update is called once per frame
    void Update()
    {
        
    }
}
