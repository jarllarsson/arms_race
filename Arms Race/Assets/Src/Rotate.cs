using UnityEngine;
using System.Collections;

public class Rotate : MonoBehaviour {
    public Vector3 m_velocity;
    public bool m_active = true;
	// Use this for initialization
	void Start () {
	
	}

    public void active(bool m_set)
    {
        m_active = m_set;
    }
	
	// Update is called once per frame
	void Update () {
       if (m_active) transform.Rotate(m_velocity * Time.deltaTime);
	}
}
