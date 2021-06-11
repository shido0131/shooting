using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStrat : MonoBehaviour
{
    public GameObject Player;
    // Start is called before the first frame update
    void Start()
    {

    }
    public void setinitialize()
    {

        Debug.Log("click");
        Player.SetActive(true);
        //this.gameObject.SetActive(false);
        Player.GetComponent<player>().Initialize();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
