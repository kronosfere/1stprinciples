using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameGrid : MonoBehaviour {

	[SerializeField]
	float MaximumX = 50.0f;
	[SerializeField]
	float MaximumY = 50.0f;
	[SerializeField]
	float LineSpacing = 1.0f;
	[SerializeField]
	GameObject ParentObject;

	bool GridOn = false;
	List<GameObject> LineObjects;

	void CreateGameGrid()
	{
		ParentObject = GameObject.Find("GameController");

		int NumHorizontalLines = (int)(MaximumX / LineSpacing);

		List<Vector3> HorizontalLines = new List<Vector3>();
		List<Vector3> VerticalLines = new List<Vector3>();
		LineObjects = new List<GameObject>();

		for (int i = 0; i < NumHorizontalLines / 2; ++i)
		{
			LineObjects.Add(new GameObject());
			LineObjects.Add(new GameObject());
			LineObjects.Add(new GameObject());
			LineObjects.Add(new GameObject());
			HorizontalLines.Add(new Vector3(MaximumX, i * LineSpacing));
			HorizontalLines.Add(new Vector3(-MaximumX, i * LineSpacing));
			HorizontalLines.Add(new Vector3(MaximumX, -(i * LineSpacing)));
			HorizontalLines.Add(new Vector3(-MaximumX, -(i * LineSpacing)));
			VerticalLines.Add(new Vector3(i * LineSpacing, MaximumY));
			VerticalLines.Add(new Vector3(i * LineSpacing, -MaximumY));
			VerticalLines.Add(new Vector3(-(i * LineSpacing), MaximumY));
			VerticalLines.Add(new Vector3(-(i * LineSpacing), -MaximumY));
		}

		foreach (GameObject i in LineObjects)
			i.transform.parent = ParentObject.transform;

		for (int j = 0, LineObjectTracker = 0; j < HorizontalLines.Count; j+=4)
		{
			GameObject tmp1 = LineObjects[LineObjectTracker++];
			tmp1.AddComponent<LineRenderer>();
			LineRenderer lr1 = tmp1.GetComponent<LineRenderer>();
			lr1.enabled = false;
			lr1.material = new Material(Shader.Find("Particles/Alpha Blended Premultiply"));
			lr1.startWidth = 0.025f;
			lr1.endWidth = 0.025f;
			lr1.startColor = Color.green;
			lr1.endColor = Color.green;
			lr1.SetPosition(0, HorizontalLines[j]);
			lr1.SetPosition(1, HorizontalLines[j + 1]);

			if (j != 0)
			{
				GameObject tmp2 = LineObjects[LineObjectTracker++];
				tmp2.AddComponent<LineRenderer>();
				LineRenderer lr2 = tmp2.GetComponent<LineRenderer>();
				lr2.enabled = false;
				lr2.material = new Material(Shader.Find("Particles/Alpha Blended Premultiply"));
				lr2.startWidth = 0.025f;
				lr2.endWidth = 0.025f;
				lr2.startColor = Color.green;
				lr2.endColor = Color.green;
				lr2.SetPosition(0, HorizontalLines[j + 2]);
				lr2.SetPosition(1, HorizontalLines[j + 3]);
			}

			GameObject tmp3 = LineObjects[LineObjectTracker++];
			tmp3.AddComponent<LineRenderer>();
			LineRenderer lr3 = tmp3.GetComponent<LineRenderer>();
			lr3.enabled = false;
			lr3.material = new Material(Shader.Find("Particles/Alpha Blended Premultiply"));
			lr3.startWidth = 0.025f;
			lr3.endWidth = 0.025f;
			lr3.startColor = Color.green;
			lr3.endColor = Color.green;
			lr3.SetPosition(0, VerticalLines[j]);
			lr3.SetPosition(1, VerticalLines[j + 1]);

			if (j != 0)
			{
				GameObject tmp4 = LineObjects[LineObjectTracker++];
				tmp4.AddComponent<LineRenderer>();
				LineRenderer lr4 = tmp4.GetComponent<LineRenderer>();
				lr4.enabled = false;
				lr4.material = new Material(Shader.Find("Particles/Alpha Blended Premultiply"));
				lr4.startWidth = 0.025f;
				lr4.endWidth = 0.025f;
				lr4.startColor = Color.green;
				lr4.endColor = Color.green;
				lr4.SetPosition(0, VerticalLines[j + 2]);
				lr4.SetPosition(1, VerticalLines[j + 3]);
			}
		}
	}

	void SwitchGrid()
	{
		if(GridOn)
		{
			foreach(GameObject i in LineObjects)
			{

				LineRenderer lr = i.GetComponent<LineRenderer>();

				if (lr)
					lr.enabled = false;
			}

			GridOn = false;
		}

		else
		{
			foreach (GameObject i in LineObjects)
			{

				LineRenderer lr = i.GetComponent<LineRenderer>();

				if (lr)
					lr.enabled = true;
			}

			GridOn = true;
		}
	}

	private void Start()
	{
		CreateGameGrid();
	}

	// Update is called once per frame
	void Update () {
		if(Input.GetKeyUp("b"))
			SwitchGrid();
	}
}
