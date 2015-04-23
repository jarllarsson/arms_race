using UnityEngine;
using System.Collections;

public class CamRigsSetup : MonoBehaviour 
{
    public CameraComposition[] m_camSetups;
    private int m_cameraMode = 0;
	public PlayerHandler m_playerHandler;
    
	// Use this for initialization
	void Awake() 
    {
		m_cameraMode = m_playerHandler.getCars().Length;
		SetupComposition(m_cameraMode-1);
		RemoveAllCompositionsExcept(m_cameraMode-1);
	}

    void SetupComposition(int p_idx)
    {
		m_camSetups[p_idx].gameObject.SetActive(true);
		m_camSetups[p_idx].SetRacerCars(m_playerHandler.getCars());
    }

    void RemoveAllCompositionsExcept(int p_idx)
    {
        for (int i=0;i<m_camSetups.Length;i++)
        {
			if (i!=p_idx && m_camSetups[i]!=null)
                DestroyImmediate(m_camSetups[i].gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
	
	}
}
