using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	[SerializeField] private float roadLength = 0f;
	[SerializeField] private float currentLength;

	private bool milestone = false;


	public void AddRoadLength(float value)
	{
		milestone = false;
		if ((int)(roadLength / 100) != (int)((roadLength + value) / 100))
		{
			milestone = true;
		}
		roadLength += value;
	}

	public float GetCurrentLength()
	{
		return currentLength;
	}

	public void SetCurrentLength(float value)
	{
		currentLength = value;
	}

	public bool ReachedMilestone()
	{
		return milestone;
	}

	public int GetMilestoneValue()
	{
		return ((int)(roadLength / 100) * 100);
	}
	public float GetRoadLength()
	{
		return roadLength;
	}
}
