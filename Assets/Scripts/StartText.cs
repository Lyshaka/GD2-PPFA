using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartText : MonoBehaviour
{
	[SerializeField] private AnimationCurve textMovement;
	[SerializeField] private float time = 1f;
	[SerializeField] private float speed = 10f;
	[SerializeField] private Transform textTransform;

	// Start is called before the first frame update
	void Start()
	{
		StartCoroutine(MoveText());
	}

	IEnumerator MoveText()
	{
		float elapsedTime = 0f;
		while (elapsedTime < time)
		{
			textTransform.position = new Vector3(textTransform.position.x, textMovement.Evaluate(elapsedTime / time) * speed + 540, textTransform.position.z);
			elapsedTime += Time.deltaTime;
			yield return null;
		}
		Destroy(gameObject.transform.parent.gameObject);
	}
}
