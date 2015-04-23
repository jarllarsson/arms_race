using UnityEngine;
using System.Collections;

public class PlayerHandler : MonoBehaviour 
{
    public GameObject[] m_players;
    public bool[] m_playersActive;
	private GameObject[] m_curatedPlayerList;
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
		getCars();
	}

	int maxPlayerAmount()
	{
		return Mathf.Min(4,m_players.Length);
	}


	public GameObject[] getCars()
	{
		if (m_curatedPlayerList==null)
		{
			// build list first time it's accessed
			int sz=0;
			foreach (bool stat in m_playersActive)
				if (stat) sz++;
			if (sz>=maxPlayerAmount()) sz=maxPlayerAmount();
			m_curatedPlayerList=new GameObject[sz];
			int x=0;
			for (int i=0;i<m_players.Length;i++)
			{
				if (i<m_playersActive.Length && m_playersActive[i] && x<maxPlayerAmount())
				{
					m_curatedPlayerList[x]=m_players[i];
					x++;
				}
			}
		}

		return m_curatedPlayerList;
	}



	// Update is called once per frame
	void Update () {
	
	}
}
