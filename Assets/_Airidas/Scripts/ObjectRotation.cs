using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectRotation : MonoBehaviour
{
	public MousePosition mPos;
	public Vector3 difference;

	PickUp pick;

	// Start is called before the first frame update
	void Start()
    {
		pick = GetComponent<PickUp>();
    }

    // Update is called once per frame
    void Update()
    {
		if(pick.isPickedUp)
		{
			difference = mPos.mousePos - gameObject.transform.position;
			float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
			gameObject.transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ);
		}
	}
}
