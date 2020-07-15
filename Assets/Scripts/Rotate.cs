using UnityEngine;

public class Rotate : MonoBehaviour
{
    void FixedUpdate()
    {
        if (!Input.GetKey(KeyCode.Space) && Mathf.Abs(Input.GetAxis("Horizontal")) > 0)
        {
            Quaternion target = Quaternion.Euler(0, 0, transform.rotation.z);
            transform.Rotate(0, 0, Input.GetAxis("Horizontal") * 2);
        }
    }
}
