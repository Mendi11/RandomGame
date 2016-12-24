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
        if (Input.GetKeyDown(KeyCode.R))
        { 
            if (Application.loadedLevel == 1)
            {
                Application.LoadLevel(0);
                

            }
            else
            {
                Application.LoadLevel(1);
              

            }
        }

    }
}
