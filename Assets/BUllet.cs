using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BUllet : MonoBehaviour
{
    public float destroy;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.forward * -2;
        destroy += Time.deltaTime;
        if (destroy == 20)
        {
            Destroy(this.gameObject);
        }
    }
    private void OnCollisionStay(Collision other)
    {
        if (other.gameObject.tag == "Meteo")
        {
            Destroy(other.gameObject);
        }
    }
}
