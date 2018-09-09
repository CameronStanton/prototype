using UnityEngine;
using System.Collections;

public class FollowPlayer : MonoBehaviour {

    public GameObject player;
    public float cameraSpeed = 1f;
    void Awake()
    {
        transform.position = new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z);
    }


	void LateUpdate () {
        Vector3 groundLevelCamera = new Vector3(transform.position.x, player.transform.position.y, transform.position.z);
        float distance = Vector3.Distance(groundLevelCamera, player.transform.position);
	    if(distance > 5f)
        {
            Vector3 moveTowardsVector = new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z);
            //transform.position += moveTowardsVector;
            transform.position = Vector3.MoveTowards(transform.position, moveTowardsVector, cameraSpeed);

            /*
            CharacterController controller = GetComponent<CharacterController>();
            if (controller.isGrounded)
            {
                moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
                moveDirection = transform.TransformDirection(moveDirection);
                moveDirection *= speed;
                if (Input.GetButton("Jump"))
                    moveDirection.y = jumpSpeed;

            }
            moveDirection.y -= gravity * Time.deltaTime;
            controller.Move(moveDirection * Time.deltaTime);
             */
        }
	}
}
