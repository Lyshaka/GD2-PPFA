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

	public void GenerateSpline(Transform startKnot)
	{
		start.position = startKnot.position;
		start.rotation = startKnot.rotation;
		end.localPosition = Vector3.Lerp(endA.localPosition, endB.localPosition, Random.Range(0f, 1f));
		end.localRotation = Quaternion.Lerp(endA.localRotation, endB.localRotation, 0.5f);

        //Debug.Log("Spline : [" + start.position + "] -> [" + end.position + "]");

        //spline.Spline.SetKnot(0, new BezierKnot(start.localPosition));
        //spline.Spline.SetKnot(1, new BezierKnot(end.localPosition)); (Vector3.Distance(start.position, end.position) / 2)

        // Set spline knots and tangents
        spline.Spline.SetKnot(0, new BezierKnot(start.localPosition, Vector3.zero, Vector3.Distance(start.position, end.position) / 2, start.localRotation));
		spline.Spline.SetKnot(1, new BezierKnot(end.localPosition, Vector3.Distance(start.position, end.position) / 2, Vector3.zero, end.localRotation));
		spline.Spline.SetTangentMode(TangentMode.Mirrored);

        //spline.Spline.SetKnot(0, new BezierKnot(start.localPosition, Vector3.Distance(start.position, end.position) / 2, Vector3.zero, start.localRotation));
        //spline.Spline.SetKnot(1, new BezierKnot(end.localPosition, Vector3.zero, Vector3.Distance(start.position, end.position) / 2, end.localRotation));
    }

    public Transform GetEnd()
	{
		return end;
	}

	/*public Vector3 GetTangentOut()
	{
		return null;
	}*/
}
