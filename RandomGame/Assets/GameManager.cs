using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
 
    // Use this for initialization
    private static GameManager instance = null;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);


       

    }

	void Start ()
    {
    

		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
