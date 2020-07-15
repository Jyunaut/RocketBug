using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BugAnim : MonoBehaviour
{
    Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (!Input.GetKey(KeyCode.Space)) {
            animator.SetFloat("Horizontal", Mathf.Abs(Input.GetAxisRaw("Horizontal")));
        }

        if (Input.GetAxisRaw("Horizontal") > 0) {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (Input.GetAxisRaw("Horizontal") < 0) {
            transform.localScale = new Vector3(-1, 1, 1);
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            animator.SetTrigger("Blow");
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetFloat("Horizontal", 0);
            animator.SetBool("Space", true);
        }
        
        if (Input.GetKeyUp(KeyCode.Space))
        {
            animator.SetBool("Space", false);
        }
    }
}
