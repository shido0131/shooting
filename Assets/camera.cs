using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{
    public GameObject player;
    private Transform Player_transform;
    private Vector3 posi;
    // Start is called before the first frame update
    void Start()
    {
        Player_transform = player.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        posi = Player_transform.position;
        transform.position = new Vector3(posi.x ,posi.y+1f, posi.z + 2f);
    }
    
}