using UnityEngine;
using System.Collections;

public class uvScroller : MonoBehaviour {
    public Vector2 m_velocity;
    private Material m_mat;
	// Use this for initialization
	void Start () {
        m_mat = GetComponent<MeshRenderer>().material;
	}
	
	// Update is called once per frame
	void Update () {
        m_mat.mainTextureOffset += m_velocity*Time.deltaTime;
	}
}
