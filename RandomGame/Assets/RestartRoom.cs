using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartRoom : MonoBehaviour {

    GameObject m_Room;
    GameObject m_PG;

    [SerializeField]
    GameObject m_PGG;

	// Use this for initialization
	void Start ()
    {
  
        m_Room = GameObject.Find("Rooms(Clone)");
        m_PG = GameObject.Find("PGcubes(Clone)");
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.K))
        {
            Destroy(m_Room);
            Destroy(m_PG);

        }
        if (Input.GetKeyDown(KeyCode.J))
        {
            Instantiate(m_PGG, new Vector3(0, 0, 0), Quaternion.identity);
            m_Room = GameObject.Find("Rooms(Clone)");
            m_PG = GameObject.Find("PGcubes(Clone)");
        }



    }
}
