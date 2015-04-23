using UnityEngine;
using System.Collections;

public class InputCarController : MonoBehaviour 
{
    public CarController m_carController;
    public CarAttack m_atk;
    private bool m_released = true;
    public int m_playerControllerId = 0;
    private string m_controllerIdStr;

	// Use this for initialization
	void Start () 
    {
        m_playerControllerId = Mathf.Clamp(m_playerControllerId, 0,4);
        m_controllerIdStr = "P" + m_playerControllerId.ToString();
	}
	
	// Update is called once per frame
	void Update () 
    {
        m_carController.ThrustPedal(Input.GetAxis(m_controllerIdStr + "Thrust"));
        m_carController.SteeringWheel(Input.GetAxis(m_controllerIdStr + "Horizontal"));

        if (Input.GetAxis(m_controllerIdStr+"FireRight") > 0.0f && m_released)
        {
            m_atk.FireRight();
            m_released = false;
        }
        if (Input.GetAxis(m_controllerIdStr + "FireLeft") > 0.0f && m_released)
        {
            m_atk.FireLeft();
            m_released = false;
        }
        if (Input.GetAxis(m_controllerIdStr + "FireRight") < 0.1f && Input.GetAxis(m_controllerIdStr + "FireLeft") < 0.1f)
        {
            m_released = true;
        }
	}
}
