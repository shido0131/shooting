using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IronBeam : MonoBehaviour
{
    float X;
    float Y;
    float destroy;
    // Start is called before the first frame update
    void Start()
    {
        X = Random.Range(-20.0f, 20.0f);
        Y= Random.Range(-20.0f, 20.0f);
        transform.position += Vector3.right * X;
        transform.position += Vector3.up * Y;
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.forward * 1;
        destroy += Time.deltaTime;
        if (destroy >10)
        {
            Destroy(this.gameObject);
        }
    }
    private void OnCollisionStay(Collision other)
    {

    }
}
