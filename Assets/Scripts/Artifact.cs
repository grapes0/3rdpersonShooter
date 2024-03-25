using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Artifact : MonoBehaviour
{
    public float health;
    public GameObject artifactObject;
    public UnityEvent onDestroy;

    public void TakeDamage(float damage)
    {
        health -= damage;
        if(health <= 0)
        {
            Destroy(artifactObject);
            onDestroy.Invoke();
        }
    }
}
