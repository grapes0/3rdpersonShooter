using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballCaster : MonoBehaviour
{
    public Fireball Fireball;
    public Transform FireballSource;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(Fireball, FireballSource.transform.position, FireballSource.transform.rotation);

        }
    }
}
