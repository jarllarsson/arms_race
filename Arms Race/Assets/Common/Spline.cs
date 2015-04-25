using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Spline : MonoBehaviour {

    public Transform[] nodes = new Transform[4];
    public bool catmullRom = true;
    public int resolution = 12;
    public float radius = 20.0f;

    private float b(int i, float t)
    {
        if (catmullRom)
        {
            switch(i)
            {
                case -2:
                    return ((-t + 2) * t - 1) * t / 2;
                case -1:
                    return (((3 * t - 5) * t) * t + 2) / 2;
                case 0:
                    return ((-3 * t + 4) * t + 1) * t / 2;
                case 1:
                    return ((t - 1) * t * t) / 2;
                default:
                    return 0.0f;
            }
        }
        else
        {
            return 0;
        }
    }

    public Vector3 GetPos(int nodeIndex, float step)
    {
        Vector3 reval = Vector3.zero;
        if (nodeIndex>=2)
        {
            for (int j=-2; j<=1; j++) // Must have at least 4 nodes
            {
                reval += b(j, step) * nodes[nodeIndex + j].position;
            }
        }
        return reval;
    }

    // Use this for initialization
    void Start()
    {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    // Draw path
    void OnDrawGizmos()
    {
        int len = nodes.Length;
        Vector3 to = transform.position; Vector3 from=to;
        if (len>3 && CheckNodes())
        {
            for (int i=2; i<len-1; i++)
            {
                for (int j = 1; j <= resolution; j++)
                {
                    to = GetPos(i, j / (float)resolution);
                    Gizmos.DrawLine(from, to); 
                    // Gizmos.DrawWireSphere(from, radius);
                    from = to;
                }
            }
        }
       
    }

    private bool CheckNodes() // check to see if nodes are not null
    {
        foreach (Transform p in nodes)
            if (p==null) return false;
        return true;
    }
}
