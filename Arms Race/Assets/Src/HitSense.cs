using UnityEngine;
using System.Collections;

public class HitSense : MonoBehaviour 
{
    private bool m_isSensing = false;
    private float m_timer;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (m_timer > 0.0f)
        {
            m_timer -= Time.deltaTime;
        }
        else
        {
            m_isSensing = false;
        }
	}
    public bool isSensing()
    {
        return m_isSensing;
    }

    void OnTriggerEnter(Collider coll)
    {
        OnColl(coll);
    }

    void OnTriggerStay(Collider coll)
    {
        OnColl(coll);
    }

    void OnColl(Collider coll)
    {
        if (coll.gameObject.tag == "car" && coll.gameObject.name != gameObject.name)
        {
            m_isSensing = true;
            m_timer = 0.2f;
        }
    }
}
