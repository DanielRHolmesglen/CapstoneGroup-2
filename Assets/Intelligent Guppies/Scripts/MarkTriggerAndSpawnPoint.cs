using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarkTriggerAndSpawnPoint : MonoBehaviour
{
    void OnDrawGizmos()
    {
        foreach (Transform child in transform)
        {
            if (child.name == "Trigger Enter")
            {
                Gizmos.color = Color.blue;
                Gizmos.DrawCube(child.position, child.transform.localScale);
            }
            for (int i = 0; i <= 10; i++)
            {
                if (child.name == "Spawn Point (" + i + ")")
                {
                    Gizmos.color = Color.yellow;
                    Gizmos.DrawSphere(child.position, .8f);
                }
            }
            if (child.name == "End Point")
            {
                Gizmos.color = Color.red;
                Gizmos.DrawCube(child.position, child.transform.localScale);
            }
        }
    }
}
