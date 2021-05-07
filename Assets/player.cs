using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class player : MonoBehaviour
{
    float X;
    float Z;
    Vector3 VZ;
    float RZ;
    float RMX;
    public Slider slider;
    float ScoreS;
    float RemainingTimeS;
    public AudioSource shot;
    public AudioSource GameOver;
    public Text RemainingTime;
    public Text Score;
    public Image GameClearImage;
    public Image GameOverImage;
    public GameObject Bullet;
    public GameObject particle;
    // Start is called before the first frame update
    void Start()
    {
        GameClearImage.enabled = false;
        GameOverImage.enabled = false;
        slider.value = 20;
        //Debug.Log("Start currentHp : " + currentHp);
        shot = GetComponent<AudioSource>();
        GameOver = GetComponent<AudioSource>();
        RemainingTimeS = 50;
    }
    void Update()
    {
        if (RemainingTimeS > 0)
        {
            X = transform.position.x;
            Z = transform.position.z;
            RZ = transform.rotation.z;
            Debug.Log(RZ);
            RemainingTimeS -= Time.deltaTime;
            RemainingTime.text = "RemainingTime." + RemainingTimeS.ToString("f2");
            Score.text = "Score." + ScoreS.ToString("f0");

            if (Input.GetKey(KeyCode.UpArrow))
            {
                if (Z > -20)
                {
                    transform.position += Vector3.forward * -1;
                }
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                if (Z < 20)
                {
                    transform.position += Vector3.forward * 1;
                }
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                if (RZ < 0.2)
                {
                    transform.Rotate(0f, 0f, 1f);
                }
                if (X < 20)
                {
                    transform.position += Vector3.right * 1;
                }
            }
            else if (Input.GetKey(KeyCode.LeftArrow))
            {
                if (RZ > -0.2)
                {
                    transform.Rotate(0f, 0f, -1f);
                }
                if (X > -20)
                {
                    transform.position += Vector3.right * -2;
                }
            }
            else
            {
                if (RZ > 0.008)
                {
                    transform.Rotate(0f, 0f, -1f);
                }
                else if (RZ < -0.008)
                {
                    transform.Rotate(0f, 0f, 1f);
                }
            }
            if (Input.GetKey(KeyCode.Space))
            {
                GameObject bullet;
                bullet = GameObject.Instantiate(Bullet);
                VZ = transform.position;
                VZ.z -= 2;
                bullet.transform.position = VZ;

            }
            if (slider.value == 0)
            {
                Destroy(this.gameObject);
                GameObject Particle;
                Particle = GameObject.Instantiate(particle);
                Particle.transform.position = transform.position;
                GameOver.PlayOneShot(GameOver.clip);
            }
        }else if (RemainingTimeS==0)
        {
            Destroy(this.gameObject);
            if (ScoreS >= 50)
            {
                GameClearImage.enabled = true;
            }
            else if (ScoreS < 50)
            {
                GameOverImage.enabled = true;
            }
        }
    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            int damage = Random.Range(5, 10);
            slider.value -= damage;
            Debug.Log("Damege");
            Destroy(collision.gameObject);
            shot.PlayOneShot(shot.clip);
        }
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
