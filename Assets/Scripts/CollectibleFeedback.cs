using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditor.Rendering;

public class CollectibleFeedback : MonoBehaviour
{
	[SerializeField] TextMeshPro text;
	[SerializeField] float speed = 2f;

	public void SetText(string t)
	{
		text.text = "+" + t;
	}

	void Start()
	{
		StartCoroutine(Move());
	}

	IEnumerator Move()
	{
		float elapsedTime = 0;
		while (elapsedTime < 0.5f)
		{
			gameObject.transform.position += new Vector3(0f, Time.deltaTime * speed, 0f);
			text.color = new Color(1f, 1f, 1f, 1f - elapsedTime / 0.5f);
			elapsedTime += Time.deltaTime;
			yield return null;
		}
		Destroy(gameObject);
	}
}
