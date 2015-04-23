using UnityEngine;
using System.Collections;

public class PlayerHandler : MonoBehaviour 
{
    public GameObject[] m_players;
    public bool[] m_playersActive;
	// Use this for initialization
	void Awake() 
    {
	    for(int i=0;i<m_players.Length;i++)
        {
            if (i<m_playersActive.Length && !m_playersActive[i])
            {
                DestroyImmediate(m_players[i]);
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
