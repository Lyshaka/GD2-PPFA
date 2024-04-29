using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	[SerializeField] private float roadLength = 0f;

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

	// Start is called before the first frame update
	void Start()
	{
		
	}

	// Update is called once per frame
	void Update()
	{
		
	}
}
