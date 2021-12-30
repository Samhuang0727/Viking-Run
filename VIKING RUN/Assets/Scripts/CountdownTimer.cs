using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountdownTimer : MonoBehaviour
{
    float currenttime = 0f;
    float startingtime = 3f;
    float startcount = 0f;

    [SerializeField] Text CountdownText;
    [SerializeField] Text TimeButtonText;
   
   

    // Start is called before the first frame update
    void Start()
    {
        currenttime = startingtime;
        
    }

    // Update is called once per frame
    void Update()
    {
        currenttime -= 1 * Time.deltaTime;
       
        CountdownText.text = currenttime.ToString("0");
       
        Invoke("StartCountButton", 3f);

        if (currenttime <0.2 && currenttime >-1.5)
        {
            CountdownText.text = "Start!";
            CountdownText.color = Color.grey;
        }
        else if (currenttime < -1)
        {
            CountdownText.gameObject.SetActive(false);
        }
    }

    private void StartCountButton()
    {
        startcount += 1 * Time.deltaTime;
        TimeButtonText.text = startcount.ToString("0");
    }
}
