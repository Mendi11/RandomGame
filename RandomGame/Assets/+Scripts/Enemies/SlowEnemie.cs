using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowEnemie : MonoBehaviour {

    enum AI_Movment { Patrol, Attack, MoveTowards, KnockBack }
    AI_Movment m_AIMovment;

    EnemieBase m_Stats;
    public Vector3 m_RoomSize;
    Transform m_Player;
    Rigidbody m_Rgb;

    float m_KnockBackPower = 300;



    // Use this for initialization
    void Start()
    {
        m_Stats = GetComponent<EnemieBase>();
        m_Player = GameObject.FindGameObjectWithTag("Player").transform;
        m_Rgb = GetComponent<Rigidbody>();



        m_AIMovment = AI_Movment.Patrol;
    }

    // Update is called once per frame
    void Update()
    {
        switch (m_AIMovment)
        {
            case AI_Movment.Patrol:
                Patrol();
                break;
            case AI_Movment.MoveTowards:
                MoveTowards();
                break;
            case AI_Movment.Attack:
                Attack();
                break;
            case AI_Movment.KnockBack:
                KnockBack();
                break;
        }

    }

    void Patrol()
    {
       
    
    }
    void MoveTowards()
    {
       Vector3 moveDirection = m_Player.position - transform.position;
       moveDirection = moveDirection.normalized;
        transform.position += new Vector3(moveDirection.x,0,moveDirection.z) * m_Stats.Speed * Time.deltaTime ;
    }
    void Attack()
    { }
    void KnockBack()
    {
        float timer = 2;
        Vector3 knockBackVelocity = (transform.position - m_Player.position) ;
       
        while (timer >= 0)
        {
            
            // print(timer + "knockback"); 
            timer -= Time.deltaTime;
            m_Rgb.velocity = new Vector3(knockBackVelocity.x, 0, knockBackVelocity.z) * Time.deltaTime * m_KnockBackPower;

        }   
        m_AIMovment = AI_Movment.Patrol;
    }



    public void TakingDamage(int dmg)
    {
        m_AIMovment = AI_Movment.KnockBack;
        m_Stats.Health -= dmg;

        if (m_Stats.Health <= 0)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider player)
    {
        if (player.gameObject.tag == "Player")
        {
            m_AIMovment = AI_Movment.MoveTowards;
        
        }
    }
    void OnTriggerExit(Collider player)
    {
        if (player.gameObject.tag == "Player")
        {
            m_AIMovment = AI_Movment.Patrol;    
        }

    }
    //private void OnCollisionEnter(Collision col)
    //{
    //    if (col.gameObject.tag == "Sword")
    //    {


    //    }
    //}

}
