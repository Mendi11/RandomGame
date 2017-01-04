using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemieBase : MonoBehaviour {

    [SerializeField]
    private int m_Health;
    [SerializeField]
    private int m_Speed;
    [SerializeField]
    private int m_Damage;

   
    // Use this for initialization
    void Start()
    {
  

    }

    // Update is called once per frame
    void Update()
    {

    }

    public int Speed
    {
        get {return m_Speed; }

    }
    public int Health
    {
        get { return m_Health; }
        set { m_Health = value; }
    }
    public int Damage
    {
        get { return m_Damage; }
   
    }

    public void TakingDamage(int dmg)
    {
        m_Health -= dmg;
        if (m_Health <= 0)
        {
            Destroy(gameObject);

        }
    }


}
