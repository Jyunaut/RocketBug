using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PondMove : MonoBehaviour
{
    public GameObject pond;
    public Transform rocketTransform;
    private float timer = 0f;
    private float scale = 0.0008f;
    private float speed = 15f;

    void Update()
    {
        timer += Time.deltaTime;
        pond.transform.position += new Vector3(rocketTransform.rotation.z / speed, 0, 0);
        pond.transform.localScale += new Vector3(scale, scale, 0f);
        
        if (timer >= 30) {
            scale = 0.0016f;
            speed = 5f;
        }
    }
}
