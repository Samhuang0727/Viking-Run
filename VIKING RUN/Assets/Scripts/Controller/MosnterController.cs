using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class MosnterController : MonoBehaviour
{
    public Vector3 MovingDirection = new Vector3(0, 0, -1);
    public float JumpingForce;


    [SerializeField] float MovingSpeed = 10f;
    Rigidbody rb;
    bool Onground = true;

   

    private void OnCollisionEnter(Collision collision)
    {
        Onground = true;
        

        if(collision.transform.name=="viking")
        {
            Invoke("Gameover", 1);            
        }
    }

    private void Gameover()
    {
        SceneManager.LoadScene(3);
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();      
    }
    // Update is called once per frame
    void Update()
    {
        Invoke("Move", 3);
       
       if(Input.GetKeyDown(KeyCode.A))
        {
            Invoke("turnleft", (float)0.5);
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            Invoke("turnright", (float)0.5);
        }


        //jump
        if (Onground & Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(JumpingForce * Vector3.up);
            Onground = false;
        }

       
    }

    private void Move()
    {
        transform.localPosition += MovingSpeed * Time.deltaTime * transform.forward;
    }


    private void turnleft()
    {
        transform.Rotate(0, -90, 0);
    }

    private void turnright()
    {
        transform.Rotate(0, 90, 0);
    }

}
