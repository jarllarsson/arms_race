using UnityEngine;
using System.Collections;

public class InputCarController : MonoBehaviour 
{
    public CarController m_carController;
    public CarAttack m_atk;

	// Use this for initialization
	void Start () 
    {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
        m_carController.ThrustPedal(Input.GetAxis("Thrust"));
        m_carController.SteeringWheel(Input.GetAxis("Horizontal"));

        if (Input.GetAxis("FireRight") > 0.0f)
            m_atk.FireRight();
        if (Input.GetAxis("FireLeft") > 0.0f)
            m_atk.FireLeft();
	}
}
