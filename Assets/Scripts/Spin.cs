using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin : MonoBehaviour
{
	[SerializeField] private float speed = 1f;

	void Update()
	{
		gameObject.transform.Rotate(new Vector3(0f, speed * Time.deltaTime, 0f));
	}
}
