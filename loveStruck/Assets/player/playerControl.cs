using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerControl : MonoBehaviour
{
    public float MovementSpeed,JumpForce,gravityForce;
    public CharacterController ThePlayerC;
    private Vector3 moveDir;
    void Update()
    {
        #region movement
        //moveDir = new Vector3(Input.GetAxis("Horizontal") *MovementSpeed,moveDir.y,Input.GetAxis("Vertical") *MovementSpeed);
        float YStore = moveDir.y;
        moveDir = (transform.forward* Input.GetAxis("Vertical"))+(transform.right*Input.GetAxis("Horizontal"));
        moveDir = moveDir.normalized*MovementSpeed;
        moveDir.y = YStore;
        if (ThePlayerC.isGrounded)
        {
            moveDir.y = 0;
            if(Input.GetButtonDown("Jump")) moveDir.y = JumpForce;
        }
        moveDir.y = moveDir.y + (Physics.gravity.y*gravityForce);
        ThePlayerC.Move(moveDir*Time.deltaTime);
        #endregion

    }

}
