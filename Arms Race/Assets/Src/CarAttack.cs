using UnityEngine;
using System.Collections;

public class CarAttack : MonoBehaviour 
{
    public Animator m_animator;
	// Use this for initialization
	void Start () 
    {
	
	}

    public void FireRight()
    {
        m_animator.SetTrigger("HitRight");
    }

    public void FireLeft()
    {
        m_animator.SetTrigger("HitLeft");
    }

	// Update is called once per frame
	void Update () 
    {
        
	}
}
