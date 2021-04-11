using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public Transform targetStart;
    public Transform targetMain;
    public Transform targetOption;
    public GameObject target;

    bool _lock;

    float speedH = 8f;
    float speedV = 3f;

    [HideInInspector]public static Camera Instance;
    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        SwitchCam(0);
        LockCam(true);
    }

    public void SwitchCam(int idx)
    {
        Transform trans;
        if (idx == 0) trans = targetStart;
        else if (idx == 1) trans = targetMain;
        else if (idx == 2) trans = targetOption;
        else trans = targetMain;

        target.transform.position = trans.position;
        target.transform.rotation = trans.rotation;
    }

    public void LockCam(bool locked)
    {
        _lock = locked;
    }

    void Update()
    {
        if (!_lock && Input.GetMouseButton(0))
        {
            target.transform.rotation *= Quaternion.AngleAxis(Input.GetAxis("Mouse X") * speedH, Vector3.up);
            target.transform.rotation *= Quaternion.AngleAxis(Input.GetAxis("Mouse Y") * speedV, Vector3.right);

            Vector3 angles = target.transform.localEulerAngles;
            angles.z = 0;

            if (angles.x > 180 && angles.x < 360)
            {
                angles.x = 360;
            }
            else if (angles.x < 180 && angles.x > 80)
            {
                angles.x = 80;
            }

            // Target rotation
            target.transform.localEulerAngles = angles;
        }
    }
}
