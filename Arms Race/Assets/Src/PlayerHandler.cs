using UnityEngine;
using System.Collections;

public class PlayerHandler : MonoBehaviour 
{
    public GameObject[] m_players;
    public GameObject[] m_correspondingCPU_toRemove;
    public bool[] m_playersActive;
	private GameObject[] m_curatedPlayerList;

	public enum PlayerOneMode
	{
		KEYBOARD=0, GAMEPAD=1
	}
	public PlayerOneMode m_playerOneInputMode=PlayerOneMode.KEYBOARD;
	private int m_inputIdOffset=0;

	// Use this for initialization
	void Awake() 
    {
        loadFromSettings();
		m_playersActive[0]=true; // always

		if (m_playerOneInputMode==PlayerOneMode.GAMEPAD)
		{
			m_inputIdOffset=1;
		}
		for(int i=1;i<m_players.Length;i++) // never check slot 1
        {
            if (i<m_playersActive.Length && !m_playersActive[i])
            {
                DestroyImmediate(m_players[i]); // remove player if not active
            }
            else
            {
                // if player is active, remove CPU with same color
                DestroyImmediate(m_correspondingCPU_toRemove[i]);
            }
        }
		// Finally assign correct joystick id to players (0 is keyboard)
		GameObject[] cars = getCars();
		for(int i=0;i<cars.Length;i++)
		{
			InputCarController inputController = cars[i].GetComponent<InputCarController>();
			inputController.m_playerControllerId = i+m_inputIdOffset;
		}
	}

    private void loadFromSettings()
    {
        GameObject settingsObj = GameObject.FindGameObjectWithTag("playerInitSettings");    
        if (settingsObj)
        {
            SettingsKeeper settingsScript = settingsObj.GetComponent<SettingsKeeper>();
            if (settingsScript)
            {
                m_playerOneInputMode = settingsScript.m_playerOneInputMode;
                if (settingsScript.m_playersActive.Length<=m_playersActive.Length)
                {
                    for (int i=0;i<m_playersActive.Length;i++)
                    {
                        m_playersActive[i]=settingsScript.m_playersActive[i];
                    }
                }
            }
            Destroy(settingsObj);
        }       
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
