using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow2 : MonoBehaviour
{
    public Transform target;         // player transform
    public Vector3 offset = new Vector3(0, 5, -8); // adjust in inspector
    public float followSpeed = 5f;   // how quickly camera catches up
    public float rotateSpeed = 5f;   // how quickly it rotates behind player

    void LateUpdate()
    {
        if (target == null) return;

        // Desired camera position
        Vector3 desiredPosition = target.position + target.TransformDirection(offset);

        // Smoothly move to that position
        transform.position = Vector3.Lerp(transform.position, desiredPosition, followSpeed * Time.deltaTime);

        // Smoothly rotate to face same direction as player
        Quaternion desiredRotation = Quaternion.LookRotation(target.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, desiredRotation, rotateSpeed * Time.deltaTime);
    }
}
