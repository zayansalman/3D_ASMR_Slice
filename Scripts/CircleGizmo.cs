using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleGizmo : MonoBehaviour
{
	//largest cells come from the middle of the cube faces, so cube is not uniform 

	public int resolution = 10;

	private void OnDrawGizmosSelected()
	{
		float step = 2f / resolution;

		//show top points
		for (int i = 0; i <= resolution; i++)
		{
			ShowPoint(i * step - 1f, -1f);
			ShowPoint(i * step - 1f, 1f);
		}
		//show side points
		for (int i = 1; i < resolution; i++)
		{
			ShowPoint(-1f, i * step - 1f);
			ShowPoint(1f, i * step - 1f);
		}
	}

	//show egdes of square 
	private void ShowPoint(float x, float y)
	{
		Vector2 square = new Vector2(x, y);
		//show inner cicle
		Vector2 circle = square.normalized; 


		Gizmos.color = Color.black;
		Gizmos.DrawSphere(square, 0.025f);

		//circle points 
		Gizmos.color = Color.white;
		Gizmos.DrawSphere(circle, 0.025f);

		//outer
		Gizmos.color = Color.yellow;
		Gizmos.DrawLine(square, circle);

		//center
		Gizmos.color = Color.gray;
		Gizmos.DrawLine(circle, Vector2.zero);
	}
}
