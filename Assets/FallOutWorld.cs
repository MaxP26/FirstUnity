using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallOutWorld : MonoBehaviour
{
	Vector3 checkpoint;
	private void Start()
	{
		checkpoint = transform.position;
	}
	// Update is called once per frame
	void Update()
    {
		if (transform.position.y < -20)
		{
			transform.position = checkpoint;
			transform.rotation = new Quaternion();
			var rb=GetComponent<Rigidbody>();
			if (rb != null)
			{
				rb.velocity = new Vector2(0, 0);
			}
		}
    }
}
