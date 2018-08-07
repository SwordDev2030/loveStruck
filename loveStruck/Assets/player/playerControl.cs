using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerControl : MonoBehaviour
{
    public float MoveSpeed =4,JumpForce,GravityScale=10,turnSpeed=10;
    public CharacterController playerContoler;
    public Animator Ani;
    Vector3 MoveD;
    public Transform pivot;

    private void Update()
    {
        MoveD = (transform.forward* Input.GetAxis("Vertical")) + (transform.right*Input.GetAxis("Horizontal"));
        MoveD = MoveD.normalized*MoveSpeed;
        if(playerContoler.isGrounded && Input.GetButton("Jump")) MoveD.y = JumpForce;
        MoveD.y = MoveD.y + (Physics.gravity.y*GravityScale);
        playerContoler.Move(MoveD*Time.deltaTime);
        if(Input.GetAxis("Vertical") != 0|| Input.GetAxis("Horizontal") !=0)
        {
            transform.rotation = Quaternion.Euler(0f, pivot.rotation.eulerAngles.y, 0f);
            Quaternion newRotation = Quaternion.LookRotation(new Vector3(MoveD.x,0f,MoveD.z));
        }
         Ani.SetBool("isGrounded",playerContoler.isGrounded);
         Ani.SetFloat("Speed",(Mathf.Abs(Input.GetAxis("Vertical")))+ (Mathf.Abs(Input.GetAxis("Horizontal"))));
       
    }
  
}
