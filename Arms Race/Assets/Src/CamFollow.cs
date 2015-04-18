using UnityEngine;
using System.Collections;

public class CamFollow : MonoBehaviour 
{
    private Vector3 m_followV;
    public Transform m_goal;
    public Transform m_lookAt;
    public float m_time;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () 
    {
        transform.position = Vector3.SmoothDamp(transform.position, m_goal.position, ref m_followV, m_time);
        transform.LookAt(m_lookAt.position);
	}
}
