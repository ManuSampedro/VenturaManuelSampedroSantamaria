using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detector : MonoBehaviour
{
    //Zona de variables Globales
    public GameManager GameManagerScript;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider infoAccess)
    {
        if (infoAccess.CompareTag("JohnLemon"))
        {
            Debug.Log("Pillado");
            GameManagerScript.IsPlayerCaught = true;
        }


        
    }
}
