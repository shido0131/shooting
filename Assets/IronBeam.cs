using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IronBeam : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
        float x = Random.Range(-20.0f, 20.0f);
        float y = Random.Range(-20.0f, 20.0f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.forward * 1;
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            Destroy(other.gameObject);
        }
    }
}
