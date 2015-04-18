using UnityEngine;
using System.Collections;

public class CheckpointChecker : MonoBehaviour 
{
    public int m_currentCheckpointId;
    public int m_lap;

	// Use this for initialization
	void Start () 
    {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}

    void OnTriggerEnter(Collider p_object)
    {
        if (p_object.tag=="checkpoint")
        {
            Checkpoint chkPoint = p_object.gameObject.GetComponent<Checkpoint>();
            if (chkPoint!=null)
            {
                int chkPointId = chkPoint.getId();
                if (m_currentCheckpointId == chkPointId-1) // current id must be the checkpoint before this one
                {
                    m_currentCheckpointId = chkPointId;
                }
            }
        }
        if (p_object.tag == "goal" && m_currentCheckpointId!=0)
        {
            m_currentCheckpointId = 0;
            m_lap++;
        }
    }
}
