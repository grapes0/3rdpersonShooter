using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float health = 100;
    public RectTransform healthRectTransform;
    public GameObject gameplayUI;
    public GameObject gameOverScreen;

    private float _maxHealth;
    // Start is called before the first frame update
    void Start()
    {
        _maxHealth = health;
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        if(health <= 0)
        {
            PlayerDeath();
        }
        DrawHealthBar();
    }

    private void DrawHealthBar()
    {
        healthRectTransform.anchorMax = new Vector2(health / _maxHealth, 1);
    }
    private void PlayerDeath()
    {
        gameplayUI.SetActive(false);
        gameOverScreen.SetActive(true);
        GetComponent<PlayerController>().enabled = false;
        GetComponent<FireballCaster>().enabled = false;
        GetComponent<CameraRotation>().enabled = false;
    }
}
