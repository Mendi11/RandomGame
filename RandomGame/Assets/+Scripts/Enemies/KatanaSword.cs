using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KatanaSword : MonoBehaviour {

    Animator m_KatanaSword;
    // Use this for initialization
    void Start () {
        m_KatanaSword = GetComponent<Animator>();
        //  m_KatanaSword.Play("Idle");
       
    }
	
	// Update is called once per frame
	void Update () {

        
    }
    public void AttackAnimator()
    {
      
        m_KatanaSword.Play("KatanaAni");
        
    }
    public void IdleAnimator()
    {
        m_KatanaSword.Play("Idle");

    }
    public IEnumerator coroutinAni(float sec)
    {
        AttackAnimator();
        yield return new WaitForSeconds(sec);
        IdleAnimator();
    }

}
