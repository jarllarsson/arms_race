using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AIPathFinder : MonoBehaviour 
{
    List<Checkpoint> m_checkpoints = new List<Checkpoint>();
    public CheckpointChecker m_checkpointChecker;
    private int m_oldCheckpoint = -1;
    private int m_nextCheckpointIdx = 0;
    private Transform m_nextCheckpointTransform;
    private Checkpoint m_nextCheckpoint;

	// Use this for initialization
	void Start () 
    {
        m_checkpoints.Add(GameObject.FindGameObjectWithTag("goal").GetComponent<Checkpoint>());
        GameObject[] checkpoints = GameObject.FindGameObjectsWithTag("checkpoint");
        for (int i=0;i<checkpoints.Length;i++)
        {
            int wantedId = i + 1;
            foreach (GameObject obj in checkpoints)
            {
                Checkpoint chkPnt = obj.GetComponent<Checkpoint>();
                if (chkPnt != null && chkPnt.getId() == wantedId)
                    m_checkpoints.Add(chkPnt);
            }
        }
	}

    public Transform getNextCheckpoint()
    {
        return m_nextCheckpointTransform;
    }

	
	// Update is called once per frame
	void Update () 
    {
        int currentId=m_checkpointChecker.getCurrentId();
        if (m_oldCheckpoint != currentId)
        {
            m_nextCheckpointIdx++;
            if (m_nextCheckpointIdx >= m_checkpoints.Count)
            {
                m_nextCheckpointIdx = 0;
            }
            m_nextCheckpointTransform = m_checkpoints[m_nextCheckpointIdx].transform;
            m_oldCheckpoint = currentId;
        }
	}
}
