using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour {

    
    Animator m_SwordAni;
    GameObject m_Player;
    private int m_Damage;

	// Use this for initialization
	void Start ()
    {
        m_Damage = 1;
        m_Player = GameObject.FindGameObjectWithTag("Player");
        Physics.IgnoreCollision(m_Player.GetComponent<CapsuleCollider>(), GetComponent<BoxCollider>());
        m_SwordAni = GetComponent<Animator>();

    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetMouseButton(0))
        {
            m_SwordAni.Play("SwordAni");
        }
        else if (Input.GetMouseButtonUp(0))
            m_SwordAni.Play("Idle");


    }
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            col.gameObject.GetComponent<EnemieBase>().TakingDamage(m_Damage);
        }

    }
}
