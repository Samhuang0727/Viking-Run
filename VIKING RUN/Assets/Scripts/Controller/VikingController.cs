using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Animator))]
public class VikingController : MonoBehaviour
{
    public Vector3 MovingDirection=new Vector3(0,0,-1);
    public float JumpingForce;
    public SpawnManager spawnmanager;
    public int CoinNum=0;
    
    [SerializeField]float MovingSpeed = 10f;
    [SerializeField] Text CoinButtonText;


    Rigidbody rb;
    Animator animator;
    bool Onground = true;
    bool Run=false;

    public float leftZ;
    public float rightZ;
    public float rightX;
    public float leftX;
    public float negrightX;
    public float negleftX;
    public float negrightZ;
    public float negleftZ;

    //During collision viking is on ground
    private void OnCollisionEnter(Collision collision)
    {
        Onground = true;   
        
        if(collision.transform.tag=="Respawn")
        {
            collision.gameObject.SetActive(false);
            CoinNum++;
        }
    }

 
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        CoinButtonText = GameObject.Find("CoinButtonText").GetComponent<Text>();    
    }

   
    private void OnTriggerEnter(Collider other)
    {
        spawnmanager.SpawnTriggerEnter();
    }

    private void Move()
    {
        transform.localPosition += MovingSpeed * Time.deltaTime * transform.forward;
        Run = true;
        animator.SetBool("run", Run);
    }

    private void GameOver()
    {
        CoinButtonText.text= CoinNum.ToString("0");
        SceneManager.LoadScene(3);
    }

    // Update is called once per frame
    void Update()
    {  
        Invoke("Move", 3);
        CoinButtonText.text = CoinNum.ToString("0");

       
        //Move
        if (transform.position.y<=-20)
        {        
            Invoke("GameOver", 2);
        }
  

        //rotation
        if (Input.GetKeyDown(KeyCode.A))
        {        
            transform.Rotate(0, -90, 0);
            if (transform.forward == Vector3.right)
            {
                leftX = transform.position.z;
                Debug.Log(leftX);
            }
            else if (transform.forward == Vector3.forward)
            {
                leftZ = transform.position.x;
            }
            else if(transform.forward == Vector3.left)
            {
                negleftX = transform.position.z;
            }
            else if (transform.forward == Vector3.back)
            {
                negleftZ = transform.position.x;
            }
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            transform.Rotate(0, 90, 0);
            if (transform.forward == Vector3.right)//轉了之後往+x方向移動
            {
                rightX = transform.position.z;
                Debug.Log(rightX);
            }
            else if (transform.forward == Vector3.back)
            {
                negrightZ = transform.position.x;
            }
            else if (transform.forward == Vector3.left)
            {
                negrightX = transform.position.z;
            }
            else if (transform.forward == Vector3.forward)
            {
                negrightZ = transform.position.x;
            }
        }

        //jump
        if (Onground & Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(JumpingForce * Vector3.up);
            Onground = false;          
        }
    }

}
