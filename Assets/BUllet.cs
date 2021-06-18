using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BUllet : MonoBehaviour
{
    public GameObject Player;
    public AudioSource shot;
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
        if (destroy == 5)
        {
            Destroy(this.gameObject);
        }
    }
    private void OnCollisionStay(Collision other)
    {
        if (other.gameObject.tag == "Meteo")
        {
            Player.GetComponent<PlayS>().ScorePlus;
               shot.PlayOneShot(shot.clip);
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
    }
}
