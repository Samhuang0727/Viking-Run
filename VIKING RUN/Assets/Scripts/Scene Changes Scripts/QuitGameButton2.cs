using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class QuitGameButton2 : MonoBehaviour ,IPointerClickHandler
{
    public int SceneDestination;

    public void OnPointerClick(PointerEventData eventData)
    {
        SceneManager.LoadScene(SceneDestination);
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
