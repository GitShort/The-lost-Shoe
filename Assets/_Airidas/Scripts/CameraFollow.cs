using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
	public Transform target;

	public float smoothSpeed = 0.125f;
	public Vector3 offset;

	private void Update()
	{
		Vector3 desiredPos = target.position + offset;
		transform.position = desiredPos;

		transform.LookAt(target);
	}
}
