using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStrat : MonoBehaviour
{
    //public string player = "RemainingTimes";
    public GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.SetActive(false);
        Player.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
