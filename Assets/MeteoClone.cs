using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteoClone : MonoBehaviour
{
    float time;
    public GameObject IronBeam;
    public GameObject meteo;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time > 1.0)
        {
            GameObject meteos;
            meteos = GameObject.Instantiate(meteo);
            meteos.transform.position = transform.position;
            time = 0;
        }
    }
}
