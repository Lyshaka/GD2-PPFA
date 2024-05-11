using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTrigger : MonoBehaviour
{
	[SerializeField] Enemy enemy;

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.layer == 13)
		{
			enemy.SetActivated(true);
			Destroy(gameObject);
		}
	}
}
