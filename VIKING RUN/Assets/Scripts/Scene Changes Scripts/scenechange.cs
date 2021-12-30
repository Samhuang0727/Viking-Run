using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class scenechange : MonoBehaviour ,IPointerClickHandler
{
    public int SceneIndexDestination = 0;
   

    public void OnPointerClick(PointerEventData eventData)
    {
        SceneManager.LoadScene(SceneIndexDestination);
    }
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
