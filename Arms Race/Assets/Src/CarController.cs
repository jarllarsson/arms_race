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
    public Transform[] m_spinningWheels;
    public float[] m_spinningWheelsRadii;
    public Transform[] m_turningWheels;
    public Transform[] m_personSteerRotators;

    private float m_currentSteer=0.0f;
    
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
        float vel = m_rigidBody.velocity.magnitude*Time.deltaTime;

        if (m_spinningWheels != null)
        {
            for (int i=0;i<m_spinningWheels.Length;i++)
            {
                Transform wheel = m_spinningWheels[i];
                float rotVal=-((vel/m_spinningWheelsRadii[i])*360.0f);
                wheel.localRotation *= Quaternion.Euler(new Vector3(rotVal*Time.deltaTime, 0.0f, 0.0f));
            }
        }
	}

    public void ThrustPedal(float p_toTheMetalAmount)
    {
        //if (p_toTheMetalAmount>0.0f)
        //{
        //    m_thrust += m_thrustPwr * p_toTheMetalAmount * Time.deltaTime;
        //    if (m_thrust > m_maxThrust) m_thrust = m_maxThrust;
        //    m_thrustCooldown = 1.0f;
        //}
        m_thrust = m_thrustPwr * Mathf.Clamp01(p_toTheMetalAmount);
    }

    public void SteeringWheel(float p_rotationDir)
    {
        p_rotationDir=Mathf.Clamp(p_rotationDir,-1.0f,1.0f);

        if (m_turningWheels != null && (p_rotationDir > 0.0f || p_rotationDir<0.0f))
        {
            foreach (Transform wheel in m_turningWheels)
            {
                wheel.localEulerAngles = new Vector3(0.0f, p_rotationDir * 50.0f, 0.0f);
            }
            m_currentSteer = p_rotationDir;
        }
       

        m_swheelTurnPower = p_rotationDir * m_turnPwr * Mathf.Clamp01(m_speedTurnRatio*m_rigidBody.velocity.magnitude);
    }

    private void LateUpdate()
    {
        
        if (m_personSteerRotators != null)
        {
            foreach (Transform wheel in m_personSteerRotators)
            {
                wheel.localEulerAngles = new Vector3(wheel.localEulerAngles.x, wheel.localEulerAngles.y, m_currentSteer * 10.0f);
            }
        }
    }


    void FixedUpdate()
    {
        m_rigidBody.AddRelativeForce(0f, 0f, m_thrust);
        m_rigidBody.AddRelativeTorque(0f, m_swheelTurnPower, 0f);
    }

}
