using UnityEngine;
using System.Collections;

public class InputCarController : MonoBehaviour 
{
    public CarController m_carController;


	// Use this for initialization
	void Start () 
    {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
        m_carController.ThrustPedal(Input.GetAxis("Thrust"));
        m_carController.SteeringWheel(Input.GetAxis("Horizontal"));
	}
}
