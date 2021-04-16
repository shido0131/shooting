using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class player : MonoBehaviour
{
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
            GameObject bullet;
            bullet = GameObject.Instantiate(Bullet);
            bullet.transform.position = transform.position;

        }
        if (slider.value == 0)
        {
            Destroy(this.gameObject);
            GameObject Particle;
            Particle = GameObject.Instantiate(particle);
            Particle.transform.position = transform.position;
            GameOver.PlayOneShot(GameOver.clip);
        }
    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Meteo")
        {
            int damage = Random.Range(1, 5);
            slider.value -= damage;
            Debug.Log("Damege");
            Destroy(collision.gameObject);
            shot.PlayOneShot(shot.clip);
        }

    }
}
