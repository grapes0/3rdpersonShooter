using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour
{
    public float delay;
    public GameObject objectToDestroy;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestroyObj", delay);
    }

    private void DestroyObj()
    {
        if (objectToDestroy == null)
        {
            Destroy(gameObject);
        }
        else
        {
            Destroy(objectToDestroy);
        }
    }

}
