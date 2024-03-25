using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float health = 100;
    public float maxHealth = 100;
    public AudioSource hurtSound;
    public void TakeDamage(float damage)
    {
        hurtSound.Play();
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
