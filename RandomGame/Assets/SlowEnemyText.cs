using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlowEnemyText : MonoBehaviour {
    Text m_Text;
    EnemieBase m_Stats;
    // Use this for initialization
    void Start () {
        m_Text = GetComponent<Text>();
        m_Stats = this.gameObject.transform.parent.gameObject.transform.parent.GetComponent<EnemieBase>();
    
	}
	
	// Update is called once per frame
	void Update ()
    {
        m_Text.text = m_Stats.Health.ToString();
	}
}
