using UnityEngine;
using System.Collections;

public class MeshWave : MonoBehaviour {
    private Mesh m_mesh;
    public float m_amplitude=0.01f;
    public float m_frequency = 10.0f;
    Vector3[] verticesOrig;
	// Use this for initialization
	void Start () 
    {
        m_mesh = GetComponent<MeshFilter>().mesh;
        verticesOrig = m_mesh.vertices;
	}
	
	// Update is called once per frame
	void Update () 
    {
        Vector3[] vertices = m_mesh.vertices;
        Vector3[] normals = m_mesh.normals;
        int i = 0;
        while (i < vertices.Length)
        {
            vertices[i] = verticesOrig[i] + normals[i] * Mathf.Sin(m_frequency*verticesOrig[i].x + Time.time) * m_amplitude;
            i++;
        }
        m_mesh.vertices = vertices;
	}
}
