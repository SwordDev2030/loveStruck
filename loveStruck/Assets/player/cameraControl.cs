using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraControl : MonoBehaviour {
    public float rotateSpeed;
    public Transform Target,Pivot;  
    public Vector3 offSet;
    public bool HideMouse;
    public float Distance;
    // Use this for initialization
    void Start () {
        offSet = Target.position - transform.position;
        Pivot.transform.position = Target.position;
        Pivot.transform.parent = Target.parent;
        if (HideMouse == true) Cursor.lockState = CursorLockMode.Locked;
    }

   
    private  void LateUpdate()
    {
        float Horizontal = Input.GetAxis("Mouse X") * rotateSpeed;
        Target.Rotate(0, Horizontal, 0);
        float Vertical = Input.GetAxis("Mouse Y") * rotateSpeed;
        Pivot.Rotate(-Vertical, 0, 0);

        #region rotateCam
        float DesireedYAngel = Target.eulerAngles.y, DesireedXAngel = Pivot.eulerAngles.x;
        Quaternion rotation = Quaternion.Euler(DesireedXAngel,DesireedYAngel,0);
        
        #endregion
        transform.position = Target.position-(rotation*offSet);
        #region camcheck
        if(transform.position.y <Target.position.y)
        {
            transform.position = new Vector3(transform.position.x,Target.position.y-Distance,transform.position.z);
        }
        #endregion
        transform.LookAt(Target.transform);
        
    }

}
