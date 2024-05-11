using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Splines;

public class CollectibleGenerator : MonoBehaviour
{
	[SerializeField] private SplineContainer spline;
	[SerializeField] private Transform startA;
	[SerializeField] private Transform startB;
	[SerializeField] private Transform endA;
	[SerializeField] private Transform endB;

	[SerializeField] private Transform start;
	[SerializeField] private Transform end;

	private float splineLength;


	public void GenerateCollectible(Transform previousEnd)
	{
		start.position = previousEnd.position;
		start.rotation = previousEnd.rotation;

		end.position = Vector3.Lerp(endA.position, endB.position, Random.Range(0f, 1f));
		end.rotation = Quaternion.Lerp(startA.rotation, startB.rotation, 0.5f);

		BezierKnot startKnot = spline.Spline.ToArray()[0];
		startKnot.Position = start.localPosition;
		BezierKnot endKnot = spline.Spline.ToArray()[1];
		endKnot.Position = end.localPosition;

		spline.Spline.SetKnot(0, startKnot);
		spline.Spline.SetKnot(1, endKnot);

		splineLength = spline.CalculateLength();
	}

	public Transform GetEnd()
	{
		return end;
	}
}
