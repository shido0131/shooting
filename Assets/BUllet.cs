﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BUllet : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.forward * -2;
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Meteo")
        {
            Destroy(other.gameObject);
        }
    }
}
