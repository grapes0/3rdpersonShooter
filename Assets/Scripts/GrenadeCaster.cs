using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeCaster : MonoBehaviour
{
    public Rigidbody grenade;
    public Transform grenadeSource;
    public float force = 10;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            var grenadeProj = Instantiate(grenade);
            grenadeProj.transform.position = grenadeSource.position;
            grenadeProj.GetComponent<Rigidbody>().AddForce(grenadeSource.forward * force);
        }
    }
}
