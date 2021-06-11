using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class player : MonoBehaviour
{
    public static GameObject Player;
    float X;
    float Y;
    Vector3 VZ;
    float RZ;
    public Slider slider;
    float Scores;
    float RemainingTimes;
    float RX;
    float Rundom;
    public Text Reat;
    public AudioSource shot;
    public AudioSource GameOver;
    public Text RemainingTime;
    public Text Score;
    public Text T1;
    public Text T2;
    public Text T3;
    public GameObject Bullet;
    public GameObject particle;
    public GameObject Camera;
    //public GameObject ClickHere;
    private Transform camera_transform;
    // Start is called before the first frame update
    void Start()
    {
        camera_transform = Camera.GetComponent<Transform>();
        Reat.gameObject.SetActive(false);
        slider.value = 20;
        RemainingTimes = 3;
    }
    public void ScorePlus()
    {
        Rundom = Random.Range(1, 5);
        Scores += Rundom;
    }
    public void Initialize()
    {

    }
    void Update()
    {
        if (RemainingTimes > 0)
        {
            //camera_transform.position = transform.position;
            X = transform.position.x;
            Y = transform.position.y;
            RX = transform.rotation.x;
            RZ = transform.rotation.z;
            RemainingTimes -= Time.deltaTime;
            RemainingTime.text = "RemainingTime." + RemainingTimes.ToString("f2");
            Score.text = "Score." + Scores.ToString("f0");

            if (Input.GetKey(KeyCode.UpArrow))
            {
                if (Y < 20)
                {
                    transform.position += Vector3.up * 0.5f;
                }
            }
            else if (Input.GetKey(KeyCode.DownArrow))
            {
                if (Y > -20)
                {
                    transform.position += Vector3.up * -0.5f;
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
                    transform.position += Vector3.right * 0.5f;
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
                    transform.position += Vector3.right * -0.5f;
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
        }
        else if (RemainingTimes < 0)
        {
            T1.gameObject.SetActive(false);
            T2.gameObject.SetActive(false);
            T3.gameObject.SetActive(false);
            Reat.gameObject.SetActive(true);
            if (Scores >= 20)
            {
                Text Bule =Reat.GetComponent<Text>();
                Bule.color=new Color(0f,0f,1f,1f);
                Reat.text = "Reat.S";
            }
            else
                if (Scores >= 15)
            {
                Text Yerow =Reat.GetComponent<Text>();
                Yerow.color=new Color(1f,1f,0f,1f);
                Reat.text = "Reat.A";
            }
            else
                if (Scores >= 10)
            {
                Text Orange =Reat.GetComponent<Text>();
                Orange.color=new Color(1f,0.5f,0f,1f);
                Reat.text = "Reat.B";
            }
            else
                if (Scores >= 5)
            {
                Text Green =Reat.GetComponent<Text>();
                Green.color=new Color(0f,1f,0f,1f);
                Reat.text = "Reat.C";
            }
            else
            {
                Text Brown =Reat.GetComponent<Text>();
                Brown.color=new Color(0.5f,0.2f,0f,1f);
                Reat.text = "Reat.E";
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
        if (slider.value <= 0)
        {
            this.gameObject.SetActive(false);
            GameObject Particle;
            Particle = GameObject.Instantiate(particle);
            Particle.transform.position = transform.position;
            GameOver.PlayOneShot(GameOver.clip);
        }

    }
}
