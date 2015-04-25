using UnityEngine;
using System.Collections;

public class SettingsKeeper : MonoBehaviour 
{
    public PlayerHandler.PlayerOneMode m_playerOneInputMode;
    public bool[] m_playersActive;
    private int m_currentId=1;
	// Use this for initialization
	void Start () 
    {
        DontDestroyOnLoad(gameObject);
	}

    public void updatePlayerOneInputMode(float p_modeVal)
    {
        if (p_modeVal<0.5f)
            m_playerOneInputMode = PlayerHandler.PlayerOneMode.KEYBOARD;
        else
            m_playerOneInputMode = PlayerHandler.PlayerOneMode.GAMEPAD;
    }

    public void setCurrentPlayerId(int p_playerId)
    {
        m_currentId = p_playerId;
    }

    public void updatePlayerStatus(bool p_setting)
    {
        m_playersActive[m_currentId] = p_setting;
    }
	
	// Update is called once per frame
	void Update () 
    {
	
	}
}
