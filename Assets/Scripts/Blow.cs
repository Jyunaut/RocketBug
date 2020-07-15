using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blow : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D targetCollider)
    {
        Destroy(targetCollider.gameObject);
        SpawnFire.fireCount--;
    }
}
