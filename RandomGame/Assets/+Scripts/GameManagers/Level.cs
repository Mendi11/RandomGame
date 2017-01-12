using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour {
 
    // Use this for initialization
    void Start ()
    {

    
	}
	
	// Update is called once per frame
	void Update ()
    {
       
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            if(Application.loadedLevelName == "Secne01")
                Application.LoadLevel(1);
            else
                Application.LoadLevel(0);

        }


    }
}
