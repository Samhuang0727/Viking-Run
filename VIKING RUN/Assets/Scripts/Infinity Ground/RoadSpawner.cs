using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadSpawner : MonoBehaviour
{
    public List<Transform> Roads;//Roads的list
    public List<Transform> RoadsType;

    List<Transform> RoadToDestroy=new List<Transform>();
    private int prefab0 = 8;
    private int hole_prefab0 = 23;
    private int hole_hole = 38;
    public  int currentdirection=1;
    private int RoadXLocation = 0;
    private int RoadZLocation = 125;
    private int CoinXLocation;
    private int CoinZLocation;
    private int RotateDegree;
    private int i = 0;

    private int lastswhcihprefab=0;

    Transform This;
    Transform NewTransform;
    Transform LastPrefab;
    Transform DeleteTransform;
    Transform ProduceTransform;

    Transform Coin;
    Transform NewCoin;



    // Start is called before the first frame update
    void Start()
    {
        Coin = gameObject.transform.Find("Coin");
        NewCoin = Coin;
    }

    public void MoveRoad()
    {     
        int whichprefab = UnityEngine.Random.Range(0, 16);

        while (true)
        {

            if (whichprefab==lastswhcihprefab && (lastswhcihprefab==11 || lastswhcihprefab==12))
            {
                whichprefab = UnityEngine.Random.Range(0, 16);
            }
            else break;
        }

        lastswhcihprefab = whichprefab;

      
        lastswhcihprefab = whichprefab;
        if (whichprefab >= 0 && whichprefab <= 10)
        {
            GetNewLocation_1(prefab0);
            NewTransform = RoadsType[0];
        }
        if (whichprefab == 11)//若抽到向右的prefab
        {         
            GetNewLocation_1(prefab0);
            NewTransform = RoadsType[1];
            currentdirection++;                      
        }
        else if (whichprefab == 12)//若抽到向左的prefab
        {          
            GetNewLocation_1(prefab0);
            NewTransform = RoadsType[2];
            currentdirection--;
            if (currentdirection == 0)
            {
                currentdirection += 4;
            } 
        }
        else if (whichprefab == 13 && LastPrefab !=RoadsType[3])//若抽到hole prefab
        {
            GetNewLocation_1(hole_prefab0);
            NewTransform = RoadsType[3];
        }
        else if (whichprefab == 13 && LastPrefab == RoadsType[3])//若抽到hole prefab且上一個也為hole
        {
            GetNewLocation_1(hole_hole);
            NewTransform = RoadsType[3];
        }
        else if(whichprefab==14)//若抽到crossbar
        {
            GetNewLocation_1(prefab0);
            NewTransform = RoadsType[4];
        }
        else if (whichprefab == 15)//若抽到treerock
        {
            GetNewLocation_1(prefab0);
            NewTransform = RoadsType[5];
        }
       
       
        NewTransform.transform.position = new Vector3(RoadXLocation, 0, RoadZLocation);
        NewTransform.transform.rotation = Quaternion.Euler(0, RotateDegree, 0);
          
        NewCoin.transform.position=new Vector3(CoinXLocation,2,CoinZLocation);
        NewCoin.transform.rotation = Quaternion.Euler(0, RotateDegree, 0);

        i++;
        if (i <= 13)
        {
           
            This = Roads[0];
            Roads.Remove(This);        
            Destroy(This.gameObject, 5);
            Roads.Add(NewTransform);
            
            ProduceTransform = Instantiate(NewTransform, NewTransform.transform.position, NewTransform.transform.rotation, transform);          
            RoadToDestroy.Add(ProduceTransform);
            
        }
        else
        {
            This = Roads[0];
            Roads.Remove(This);
            Roads.Add(NewTransform);

           
            ProduceTransform = Instantiate(NewTransform, NewTransform.transform.position, NewTransform.transform.rotation, transform);
            
            RoadToDestroy.Add(ProduceTransform);
           

            DeleteTransform = RoadToDestroy[0];
            RoadToDestroy.Remove(DeleteTransform);
            Destroy(DeleteTransform.gameObject, 30);
           
        }
        Instantiate(NewCoin, NewCoin.transform.position, NewCoin.transform.rotation,transform);
    }

   
 
    private void GetNewLocation_1(int distance)
    {
        currentdirection = currentdirection % 4;
        if (currentdirection == 1)
        {
            //+Z方向增加地圖
            RoadZLocation = (int)Roads[12].localPosition.z + distance;         
            CoinZLocation = RoadZLocation - 2;
            CoinXLocation = RoadXLocation;
            RotateDegree = 0;
        }
        else if (currentdirection == 2)
        {
            //往+X增加地圖
            RoadXLocation = (int)Roads[12].localPosition.x + distance;
            CoinXLocation = RoadXLocation - 2;
            CoinZLocation = RoadZLocation;
            RotateDegree = 90;
        }
        else if (currentdirection == 3)
        {
            //往-Z方向增加地圖
            RoadZLocation = (int)Roads[12].localPosition.z - distance;
            CoinZLocation = RoadXLocation + 2;
            CoinXLocation = RoadXLocation;
            RotateDegree = 180;
        }
        else if (currentdirection == 0)
        {
            //往-X方向增加地圖
            RoadXLocation = (int)Roads[12].localPosition.x - distance;
            CoinXLocation = RoadXLocation + 2;
            CoinZLocation = RoadZLocation;
            RotateDegree = 270;
        }

    }

}
