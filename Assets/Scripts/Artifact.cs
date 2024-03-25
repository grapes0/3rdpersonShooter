using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Artifact : MonoBehaviour
{
    public float health;
    public GameObject artifactObject;

    public void TakeDamage(float damage)
    {
        health -= damage;
        if(health <= 0)
        {
            Destroy(artifactObject);
            Debug.Log("Artifact destroyed! game over");
        }
    }
}
