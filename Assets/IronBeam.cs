using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IronBeam : MonoBehaviour
{
    public float destroy;
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
        destroy += Time.deltaTime;
        if (destroy == 20)
        {
            Destroy(this.gameObject);
        }
    }
    private void OnCollisionStay(Collision other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            Destroy(other.gameObject);
            Debug.Log("delete");
        }
        if (other.gameObject.tag == "Player")
        {
            //Destroy(other.gameObject);
            //Debug.Log("delete");
        }
    }
}
