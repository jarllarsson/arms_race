using UnityEngine;
using System.Collections;

public class CarController : MonoBehaviour 
{
    public float m_thrustPwr=1.0f;
    public float m_turnPwr = 1.0f;
    public float m_maxThrust = 500.0f;
    public float m_speedTurnRatio=0.1f;

    private float m_swheelTurnPower;
    private float m_thrust;
    public Rigidbody m_rigidBody;

    private float m_thrustCooldown;

    
	// Use this for initialization
	void Start () 
    {
	
	}
	
	// Update is called once per frame
	void Update () 
    {

        // "slow" thrust cooldown
       //m_thrustCooldown -= 5.0f*Time.deltaTime;
       //if (m_thrustCooldown < 0.0f)
       //    m_thrust = 0.0f;
	}

    public void ThrustPedal(float p_toTheMetalAmount)
    {
        //if (p_toTheMetalAmount>0.0f)
        //{
        //    m_thrust += m_thrustPwr * p_toTheMetalAmount * Time.deltaTime;
        //    if (m_thrust > m_maxThrust) m_thrust = m_maxThrust;
        //    m_thrustCooldown = 1.0f;
        //}
        m_thrust = m_thrustPwr * p_toTheMetalAmount;
    }

    public void SteeringWheel(float p_rotationDir)
    {
        m_swheelTurnPower = p_rotationDir * m_turnPwr * Mathf.Clamp01(m_speedTurnRatio*m_rigidBody.velocity.magnitude);
    }


    void FixedUpdate()
    {
        m_rigidBody.AddRelativeForce(0f, 0f, m_thrust);
        m_rigidBody.AddRelativeTorque(0f, m_swheelTurnPower, 0f);
    }

}
