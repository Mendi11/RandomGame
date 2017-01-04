using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour {


    [SerializeField]
    int m_Health;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            TakeDamage(col.gameObject.GetComponent<EnemieBase>().Damage);
        }


    }

    void TakeDamage(int dmg)
    {
        m_Health -= dmg;
    }
}
