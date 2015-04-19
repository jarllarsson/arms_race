using UnityEngine;
using System.Collections;

public class InputCarController : MonoBehaviour 
{
    public CarController m_carController;
    public CarAttack m_atk;
    private bool m_released = true;

	// Use this for initialization
	void Start () 
    {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
        m_carController.ThrustPedal(Input.GetAxis("Thrust"));
        m_carController.SteeringWheel(Input.GetAxis("Horizontal"));

        if (Input.GetAxis("FireRight") > 0.0f && m_released)
        {
            m_atk.FireRight();
            m_released = false;
        }
        if (Input.GetAxis("FireLeft") > 0.0f && m_released)
        {
            m_atk.FireLeft();
            m_released = false;
        }
        if (Input.GetAxis("FireRight") < 0.1f && Input.GetAxis("FireLeft") < 0.1f)
        {
            m_released = true;
        }
	}
}
