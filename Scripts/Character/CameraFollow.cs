using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    private Vector3 Offset;
    private float y;
    public float speedFollow = 5f;
    private void Start()
    {
        Offset = transform.position;
    }
    private void LateUpdate()
    {
        Vector3 followPos = target.position + Offset;
        RaycastHit hit;

        if (Physics.Raycast(target.position, Vector3.down, out hit, 2.5f))
            y = Mathf.Lerp(y, hit.point.y, Time.deltaTime * speedFollow);
        else
            y = Mathf.Lerp(y, target.position.y, Time.deltaTime * speedFollow);

        followPos.y = Offset.y + y;
        transform.position = followPos;
    }
}
