using UnityEngine;
using System.Collections;

public class CarAttack : MonoBehaviour 
{
    public Animator m_animator;
    public HitBox m_leftBox, m_rightBox;
	// Use this for initialization
	void Start () 
    {
	
	}

    public void FireRight()
    {
        if (m_rightBox.Activate(0.3f))
            m_animator.SetTrigger("HitRight");
    }

    public void FireLeft()
    {
        if (m_leftBox.Activate(0.3f))
            m_animator.SetTrigger("HitLeft");    
    }

    public void HitSuccess()
    {

    }

	// Update is called once per frame
	void Update () 
    {
        
	}
}
