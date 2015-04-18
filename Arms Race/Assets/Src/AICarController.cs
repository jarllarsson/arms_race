using UnityEngine;
using System.Collections;

public class AICarController : MonoBehaviour 
{
    public CarController m_carController;


	// Use this for initialization
	void Start () 
    {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
        m_carController.ThrustPedal(Random.Range(0.0f, 1.0f));
        m_carController.SteeringWheel(Random.Range(-1.0f, 1.0f));
	}
}
