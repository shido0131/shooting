using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class player : MonoBehaviour
{

    int maxHp;
    int currentHp;
    public Slider slider;
    float ScoreS;
    float RemainingTimeS;
    public AudioSource shot;
    public AudioSource GameOver;
    public Text RemainingTime;
    public Text Score;
    public GameObject Bullet;
    public GameObject particle;
    // Start is called before the first frame update
    void Start()
    {
        slider.value = 20;
        currentHp = maxHp;
        //Debug.Log("Start currentHp : " + currentHp);
        shot = GetComponent<AudioSource>();
        GameOver = GetComponent<AudioSource>();
        RemainingTimeS = 100;
    }

    // Update is called once per frame
    void Update()
    {

        RemainingTimeS -= Time.deltaTime;
        RemainingTime.text = "RemainingTime." + RemainingTimeS.ToString("f2");
        Score.text = "Score." + ScoreS.ToString("f0");
        
        if (Input.GetKeyDown(KeyCode.W))
        {
            transform.position += transform.forward * 1;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            shot.PlayOneShot(shot.clip);
            GameObject bullet;
            bullet = GameObject.Instantiate(Bullet);
            bullet.transform.position = transform.position;
        }
    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Meteo")
        {
            int damage = Random.Range(1, 5);
            //Debug.Log("damage : " + damage);
            currentHp = currentHp - damage;
            //Debug.Log("After currentHp : " + currentHp);
            slider.value = (float)currentHp / (float)maxHp; ;
            //Debug.Log("slider.value : " + slider.value);
        }

    }
}
