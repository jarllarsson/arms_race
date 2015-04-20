using UnityEngine;
using System.Collections;

public class HitBox : MonoBehaviour 
{
    public Collider m_collider;
    private float m_timer;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
	    if (m_timer>0.0f)
        {
            m_timer-=Time.deltaTime;
        }
        else
        {
            m_collider.enabled=false;
        }
	}

    public bool Activate(float p_t)
    {
        if (m_timer <= 0.0f)
        {
            m_timer = p_t;
            m_collider.enabled = true;
            return true;
        }
        return false;
    }
}
