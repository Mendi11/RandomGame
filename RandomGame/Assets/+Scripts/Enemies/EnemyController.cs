using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    List<GameObject> m_Enemies;
    CreateRoom m_Rooms;

    [SerializeField]
    GameObject m_SlowEnemie;

    bool m_SpawnSlowEnemis = true;

    // Use this for initialization
    void Start()
    {
        m_Rooms = GameObject.FindGameObjectWithTag("PG").GetComponent<CreateRoom>();



    }
	
	// Update is called once per frame
	void Update ()
    {
        if (m_Rooms.done == true)
        { 
            Invoke("SpawnSlowEnemies", 1f);
            StopSpawn();
        }
    }

    void SpawnSlowEnemies()
    {
        int randTime = Random.Range(1, 5);
        //Randoms how many enemies spawns. Then Randoms the room the enemy should spawn in.
        for (int i = 0; i < randTime; i++)
        {
            int randRoom = Random.Range(0, m_Rooms.Rooms.Count);
            GameObject enemie = Instantiate(m_SlowEnemie, m_Rooms.Rooms[randRoom].transform.position + new Vector3(0, 2, 0), Quaternion.identity);
            enemie.GetComponent<SlowEnemie>().m_RoomSize = m_Rooms.Rooms[randRoom].transform.localScale; // Get the size of the room it spawnd in. And set it to the variable m_RoomSize
        }
       
        m_SpawnSlowEnemis = false;
    }
    void StopSpawn()
    {
        if(!m_SpawnSlowEnemis)
            CancelInvoke("SpawnSlowEnemies");


    }

}
