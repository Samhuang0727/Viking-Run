using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterChasing : MonoBehaviour
{
    Transform Viking;
    Transform Monster;
    Vector3 MonsterLocationUpdate;
    Vector3 VikingLoationUpdate;


    Vector3 NewVector1 = new Vector3(0, 0, -5);
    Vector3 NewVector2 = new Vector3(-5, 0, 0);
    Vector3 NewVector3 = new Vector3(0, 0, 5);
    Vector3 NewVector4 = new Vector3(5, 0, 0);

    public VikingController vikingController;
    public RoadSpawner roadspawner;

    // Start is called before the first frame update
    void Start()
    {
        Viking = gameObject.transform.Find("Viking");
        Monster = gameObject.transform.Find("Monster");     
    }

    // Update is called once per frame
    void Update()
    {
        MonsterLocationUpdate = Monster.transform.position;      
        VikingLoationUpdate = Viking.transform.position;
        Vector3 Distance = MonsterLocationUpdate - VikingLoationUpdate;


        if (Distance.magnitude >= 10)
        {
            if (Viking.transform.forward == Vector3.forward)
            {
                Monster.position = Viking.transform.position + NewVector1;
            }
            else if (Viking.transform.forward == Vector3.right)
            {
                Monster.position = Viking.transform.position + NewVector2;
            }
            else if (Viking.transform.forward == Vector3.back)
            {
                Monster.position = Viking.transform.position + NewVector3;
            }
            else if (Viking.transform.forward == Vector3.left)
            {
                Monster.position = Viking.transform.position + NewVector4;
            }
        }
    }
}
