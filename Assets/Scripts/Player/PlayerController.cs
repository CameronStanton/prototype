using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public float speed = 5f;
    private Animator animator;
    private Rigidbody rb;

	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame, game code here
	void Update () {

        print(Camera.main.orthographicSize);
	}

    //called before physics calculations
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 force = new Vector3(moveHorizontal, 0.0f, moveVertical);
        //force.z *= 2;
        force *= speed;
        rb.velocity = force;
        if (moveHorizontal > 0)
        {
            if (moveVertical > 0)
            {
                animator.SetInteger("Direction", 1);
                animator.SetFloat("Speed", 1);
            }
            else if(moveVertical < 0)
            {
                animator.SetInteger("Direction", 3);
                animator.SetFloat("Speed", 1);
            }
            else
            {
                animator.SetInteger("Direction", 2);
                animator.SetFloat("Speed", 1);
                force.z = 0f;
                rb.velocity = force;
            }
        }
        if (moveHorizontal < 0)
        {
            if (moveVertical > 0)
            {
                animator.SetInteger("Direction", 7);
                animator.SetFloat("Speed", 1);
            }
            else if (moveVertical < 0)
            {
                animator.SetInteger("Direction", 5);
                animator.SetFloat("Speed", 1);
            }
            else
            {
                animator.SetInteger("Direction", 6);
                animator.SetFloat("Speed", 1);
                force.z = 0f;
                rb.velocity = force;
            }
        }
        if (moveVertical > 0 && moveHorizontal == 0)
        {
            animator.SetInteger("Direction", 0);
            animator.SetFloat("Speed", 1);
            force.x = 0f;
            rb.velocity = force;
            //rb.AddForce(force * speed, ForceMode.VelocityChange);

        }
        if (moveVertical < 0 && moveHorizontal == 0)
        {
            animator.SetInteger("Direction", 4);
            animator.SetFloat("Speed", 1);
            force.x = 0f;
            rb.velocity = force;
            //rb.AddForce(force * speed, ForceMode.VelocityChange);
        }
        if(moveHorizontal == 0 && moveVertical == 0)
        {
            animator.SetFloat("Speed", 0);
            rb.velocity = Vector3.zero;
            //rb.AddForce(force * 0, ForceMode.VelocityChange);
        }
    }
}
