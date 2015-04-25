using UnityEngine;
using System.Collections;

public class SceneChanger : MonoBehaviour 
{
    public string m_scene;
	// Use this for initialization
	void Start () 
    {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}

    public void gotoScene()
    {
        Application.LoadLevel(m_scene);
    }
}
