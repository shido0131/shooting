using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class player : MonoBehaviour
{
    float ScoreS;
    float RemainingTimeS;
    public AudioSource shot;
    public Text RemainingTime;
    public Text Score;
    public GameObject Bullet;
    // Start is called before the first frame update
    void Start()
    {
        shot = GetComponent<AudioSource>();
        RemainingTimeS = 100;
    }

    // Update is called once per frame
    void Update()
    {
        RemainingTimeS -= Time.deltaTime;
        RemainingTime.text = "RemainingTime." + RemainingTimeS.ToString("f2");
        Score.text = "Score." + ScoreS.ToString("f0");
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += transform.forward * 1;
        }
        if (Input.GetKey(KeyCode.Space))
        {
            shot.PlayOneShot(shot.clip);
            GameObject bullet;
            bullet = GameObject.Instantiate(Bullet);
            bullet.transform.position = transform.position;
        }
    }
}
