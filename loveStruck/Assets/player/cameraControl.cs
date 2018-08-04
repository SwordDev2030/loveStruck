using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraControl : MonoBehaviour {
    public Transform Target,Pivot;
    public float roateSpeed,MaxViewAngle = 45,MinViewAngle;
    [Space]
    public Vector3 offset;
    public bool LockCursor;
 
    // Use this for initialization
    void Start () {
         offset = Target.position - transform.position;
        Pivot.transform.position = Target.transform.position;
        Pivot.transform.parent = null;
        if (LockCursor == true)
        {
             Cursor.lockState = CursorLockMode.Locked;
             Cursor.visible = false;
        }
    }

   
    private  void LateUpdate()

    {
        float Horizontal = Input.GetAxis("Mouse X") * roateSpeed;
        Pivot.Rotate(0, Horizontal, 0);
        float Vertical = Input.GetAxis("Mouse Y") * roateSpeed;
        Pivot.Rotate(Vertical, 0, 0);
        if (Pivot.rotation.eulerAngles.x > MaxViewAngle && Pivot.rotation.eulerAngles.x < 180f) Pivot.rotation = Quaternion.Euler(MaxViewAngle, 0, 0);
        if (Pivot.rotation.eulerAngles.x > 180 && Pivot.rotation.eulerAngles.x < 360 + MinViewAngle) Pivot.rotation = Quaternion.Euler(360 + MinViewAngle, 0, 0);
        float DesiredY = Pivot.eulerAngles.y;
        float DesiredX = Pivot.eulerAngles.x;
        Pivot.Rotate(0, Horizontal, 0);
        Quaternion Rotation = Quaternion.Euler(DesiredX, DesiredY, 0);
        if (Pivot.rotation.eulerAngles.x > MaxViewAngle && Pivot.rotation.eulerAngles.x < 180f) Pivot.rotation = Quaternion.Euler(MaxViewAngle, DesiredY, 0);
        transform.position = Target.position - (Rotation * offset);
        if (Pivot.rotation.eulerAngles.x > 180f && Pivot.rotation.eulerAngles.x < 360f + MinViewAngle) Pivot.rotation = Quaternion.Euler(360f + MinViewAngle, DesiredY, 0);
        if (transform.position.y < Target.position.y) transform.position = new Vector3(transform.position.x, Target.position.y, transform.position.z);


        transform.LookAt(Target);

    }

}
