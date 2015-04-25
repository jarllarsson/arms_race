using UnityEngine;
using System.Collections;

public class AICarController : MonoBehaviour 
{
    public CarController m_carController;
    public AIPathFinder m_pathFinder;
    public CarAttack m_atk;
    public int m_IQ=5; // 0-5
    float m_thinkCounter = 0.0f;
    private int m_maxIQ = 5;
    private float m_maxDecisionTimeGap = 0.5f;
    private float m_decisionTime = 0.2f, m_decisionTimeTick;

    private Transform m_oldCheckPoint;
    private float m_standingStillThrustTime = 0.0f;
    private Vector3 m_currentGoal;

    public HitSense m_leftSense, m_rightSense;

	// Use this for initialization
	void Start () 
    {
        if (m_IQ > m_maxIQ) m_IQ = m_maxIQ;
        if (m_IQ < 0) m_IQ = 0;
        if (m_IQ == m_maxIQ)
        {
            m_carController.m_thrustPwr *= 1.6f;
            m_carController.m_turnPwr *= 1.4f;
        }
        else
        {
            m_carController.m_thrustPwr *= 1.2f;
            m_carController.m_turnPwr *= 1.2f;
        }
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (m_thinkCounter < 0.0f)
        {
            Transform point = m_pathFinder.getNextCheckpoint();
            if (point)
            {
                if (point != m_oldCheckPoint || m_oldCheckPoint==null) 
                {
                    Vector2 spread = Random.insideUnitCircle;
                    m_currentGoal = point.position + new Vector3(spread.x * point.localScale.x * 0.25f, 0.0f, spread.y * point.localScale.z * 0.25f);
                    m_oldCheckPoint = point;
                }
                Vector3 diff = m_currentGoal - transform.position;
                float IQfac = ((float)m_IQ / (float)m_maxIQ);
                float sideDir = Vector3.Dot(diff, transform.right); // if in front of right, steer to the right(1.0), else to the left(-1.0)

                // if good IQ, find better point:
                //if (IQfac > 0.7f)
                //{
                //    Collider coll = point.GetComponent<Collider>();
                //    if (coll)
                //    {
                //        Vector3 checkPointClosestPoint = coll.ClosestPointOnBounds(transform.position);
                //        Vector3 diff2 = checkPointClosestPoint - transform.position;
                //        float sideDir2 = Vector3.Dot(diff2, transform.right);
                //        if (Mathf.Abs(sideDir2) < Mathf.Abs(sideDir)) diff = diff2;
                //    }
                //}

                Debug.DrawLine(transform.position, transform.position + diff, Color.magenta);

                float dir = Vector3.Dot(diff, transform.forward);
                //float sideDir = Vector3.Dot(diff, transform.right); // if in front of right, steer to the right(1.0), else to the left(-1.0)
                if (dir > 0.0f)
                {
                    float certaintyFac=Mathf.Clamp(1.0f - Mathf.Abs(sideDir), 0.025f, 1.0f); // the straighter the path, the more certain we are to give full thrust
                    m_carController.ThrustPedal(dir * certaintyFac); // move to next, if in front
                }
                m_carController.SteeringWheel(sideDir);
                if (m_decisionTimeTick < 0.0f)
                    m_thinkCounter = (1.0f-IQfac) * (m_maxDecisionTimeGap);
                else
                    m_decisionTimeTick -= Time.deltaTime;



                // if we have been standing still for very long, give small thrust
                if (m_carController.m_rigidBody.velocity.magnitude < 2.0f)
                {
                    m_standingStillThrustTime += Time.deltaTime;
                    if (m_standingStillThrustTime > 1.0f)
                    {
                        Debug.Log("emergency thrust "+transform.name);
                        m_carController.ThrustPedal(1.0f); // move to next, if in front
                    }
                }
            }
            // Atk
            if (m_leftSense.isSensing())
                m_atk.FireLeft();
            if (m_rightSense.isSensing())
                m_atk.FireRight();
        }
        else
            m_decisionTimeTick = m_decisionTime;
        m_thinkCounter -= Time.deltaTime;

	}

    void FixedUpdate()
    {
        if (m_carController.m_rigidBody.velocity.magnitude >= 2.0f)
        {
            m_standingStillThrustTime *= 0.7f;
        }
    }
}
