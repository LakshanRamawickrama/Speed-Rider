using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Player_Movement : MonoBehaviour
{
    public Transform transform1;
    public float speed = 5f;
    public float rotationSpeed = 5f;

    public Score_Manager scoreValue;

    public GameObject gameOverPanel;

    public Audio_Manager am;

    bool currentPlatformAndroid = false;
    Rigidbody2D rb;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

         #if UNITY_ANDROID 

                currentPlatformAndroid = true;

         #else

                currentPlatformAndroid = false;

        #endif 

    
    }



    // Start is called before the first frame update
    void Start()
    {
        gameOverPanel .SetActive(false);
        Time.timeScale = 1;

        am.carSound .Play ();
    }

    // Update is called once per frame
    void Update()
    {

        if (currentPlatformAndroid == true)
        {
            AccelerometerMove();
        }
        else
        {

            if (Input.GetKey(KeyCode.RightArrow))
            {
                transform1.position += new Vector3(speed * Time.deltaTime, 0, 0);
                transform1.rotation = Quaternion.Lerp(transform1.rotation, Quaternion.Euler(0, 0, -47), rotationSpeed * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                transform1.position -= new Vector3(speed * Time.deltaTime, 0, 0);
                transform1.rotation = Quaternion.Lerp(transform1.rotation, Quaternion.Euler(0, 0, 47), rotationSpeed * Time.deltaTime);
            }
        }

       if(transform1 .rotation .z !=90)
        {
            transform1 .rotation = Quaternion .Lerp(transform1 .rotation , Quaternion.Euler(0, 0,0),10f*Time .deltaTime);
        }
    
    

        if(transform .position .x <-8.1f)
        {
            transform1.position = new Vector3(-8.1f, transform1.position.y, transform.position.z);
        }

        if (transform.position.x > 8.2f)
        {
            transform1.position = new Vector3(8.2f, transform1.position.y, transform1.position.z);
        }
    }

    void AccelerometerMove()
    {
        float x = Input .acceleration .x;
        if (x < -2.1f)
        {
            MoveLeft();
        }
        else if (x >2.1f)
        {
            MoveRight();
        }
        else 
            SetVelocityZero();
      
    }

    public void MoveLeft()
    {
        rb.velocity = new Vector2(-speed, 0); 
    }

    public void MoveRight()
    {
        rb.velocity = new Vector2 (speed, 0);
    }

    public void SetVelocityZero()
    { 
        rb.velocity = Vector2.zero;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision .gameObject.tag == "Cars")
        {
            Time.timeScale = 0;
            gameOverPanel.SetActive(true);
            am.carSound .Stop();
        }

        if (collision .gameObject.tag == "Coins")
        {
            Audio_Manager.instance.coinSource.PlayOneShot(Audio_Manager.instance.coinSound);
            scoreValue.score += 10; 
            Destroy (collision .gameObject);
           
            
        }
    }

}
