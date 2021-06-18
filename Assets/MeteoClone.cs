using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteoClone : MonoBehaviour
{
    float random;
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
        if (time > 0.5)
        {
            random=Random.Range(1, 2);
            if (random == 1)
            {
                GameObject meteos;
                meteos = GameObject.Instantiate(meteo);
                meteos.transform.position = transform.position;
                time = 0;
            }
            else if (random == 2)
            {
                GameObject IronBeams;
                IronBeams = GameObject.Instantiate(IronBeam);
                IronBeams.transform.position = transform.position;
                time = 0;
            }
        }
    }
}
