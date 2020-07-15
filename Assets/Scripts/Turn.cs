using UnityEngine;

public class Turn : MonoBehaviour
{
    private Quaternion target;
    private float speed = 0.5f;

    void FixedUpdate()
    {
        if (transform.rotation.z >= 0)
            target = Quaternion.Euler(0, 0, 45);
        else
            target = Quaternion.Euler(0, 0, -45);

        speed = 0.1f;

        if (Input.GetKey(KeyCode.Space) && Mathf.Abs(Input.GetAxis("Horizontal")) > 0)
        {
            target = Quaternion.Euler(0, 0, -Input.GetAxis("Horizontal") * 30);
            speed = 0.5f;
        }

        transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * speed);
    }
}
