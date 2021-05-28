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
    public Slider slider;
    float Scores;
    float RemainingTimes;
    float RX;
    public AudioSource shot;
    public AudioSource GameOver;
    public Text RemainingTime;
    public Text Score;
    public Image GameClearImage;
    public Image GameOverImage;
    public GameObject Bullet;
    public GameObject particle;
    public GameObject Camera;
    public GameObject GameStart;
    private Transform camera_transform;
    // Start is called before the first frame update
    void Start()
    {
        //this.gameObject.SetActive(false);
        camera_transform = Camera.GetComponent<Transform>();
        GameClearImage.gameObject.SetActive(false);
        GameOverImage.gameObject.SetActive(false);
        slider.value = 20;
        RemainingTimes = 30;
    }
    public void Initialize()
    {
        /*GameClearImage.gameObject.SetActive(false);
        GameOverImage.gameObject.SetActive(false);
        slider.value = 20;
        RemainingTimes = 30;*/
    }
    void Update()
    {
        if (RemainingTimes > 0)
        {
            //camera_transform.position = transform.position;
            X = transform.position.x;
            Z = transform.position.z;
            RX = transform.rotation.x;
            RZ = transform.rotation.z;
            RemainingTimes -= Time.deltaTime;
            RemainingTime.text = "RemainingTime." + RemainingTimes.ToString("f2");
            Score.text = "Score." + Scores.ToString("f0");

            if (Input.GetKey(KeyCode.UpArrow))
            {
                if (Z > -20)
                {
                    transform.position += Vector3.forward * -0.25f;
                }
                if (RX < -0.1)
                {
                    transform.Rotate(-1f, 0f, 0f);
                }
            }
            else if (Input.GetKey(KeyCode.DownArrow))
            {
                if (Z < 20)
                {
                    transform.position += Vector3.forward * 0.25f;
                }
                if (RX < 0.1)
                {
                    transform.Rotate(1f, 0f, 0f);
                }
            }
            else
            {
                if (RX < 0.008)
                {
                    transform.Rotate(0f, 0f, -1f);
                }
                else if (RX < -0.008)
                {
                    transform.Rotate(0f, 0f, 1f);
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
                    transform.position += Vector3.right * 0.25f;
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
                    transform.position += Vector3.right * -0.25f;
                }
            }
            else
            {
                if (RZ > 0.008f)
                {
                    transform.Rotate(0f, 0f, -1f);
                }
                else if (RZ < -0.008f)
                {
                    transform.Rotate(0f, 0f, 1f);
                }
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                GameObject bullet;
                bullet = GameObject.Instantiate(Bullet);
                VZ = transform.position;
                VZ.z -= 2;
                bullet.transform.position = VZ;

            }

            if (slider.value <= 0)
            {
                this.gameObject.SetActive(false);
                GameObject Particle;
                Particle = GameObject.Instantiate(particle);
                Particle.transform.position = transform.position;
                GameOver.PlayOneShot(GameOver.clip);
                GameOverImage.enabled = true;
            }
        }
        else if (RemainingTimes < 0)
        {
            this.gameObject.SetActive(false);
            if (Scores > 50)
            {
                GameClearImage.gameObject.SetActive(true);
                GameStart.gameObject.SetActive(true);
            }
            else if (Scores <= 50)
            {
                GameOverImage.gameObject.SetActive(true);
                GameStart.gameObject.SetActive(true);
                GameOver.PlayOneShot(GameOver.clip);
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
