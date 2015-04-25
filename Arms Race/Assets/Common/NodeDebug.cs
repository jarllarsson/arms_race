using UnityEngine;

public class NodeDebug : MonoBehaviour
{
    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawIcon(transform.position, "node.png");
        Gizmos.DrawWireSphere(transform.position, transform.localScale.x);
    }
}
