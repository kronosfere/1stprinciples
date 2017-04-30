using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundSpawner : MonoBehaviour {

	[SerializeField]
	int NumberOfRandomBackgroundObjectsAtStart = 0;
	[SerializeField]
	float MaximumSizeOfBackgroundObject = 2.5f;
	[SerializeField]
	float MinimumSizeOfBackgroundObject = 0.5f;
	[SerializeField]
	float MinimumSpeed = 0.01f;
	[SerializeField]
	float MaximumSpeed = 0.5f;
	[SerializeField]
	int TypesOfBackgroundObj = 2;
	[SerializeField]
	float MinimumTimeNextSpawn = 0.01f;
	[SerializeField]
	float MaximumTimeNextSpawn = 1.0f;

	float top;
	float bottom;
	float left;
	float right;
	float TimeNextSpawn = 0.0f;

	void GetBoundaries()
	{
		// Search the Game for the boundaries, returb exception if unable
		try
		{
			top = GameObject.Find("Top_Bound").transform.position.y;
			bottom = GameObject.Find("Bottom_Bound").transform.position.y;
			left = GameObject.Find("Left_Bound").transform.position.x;
			right = GameObject.Find("Right_Bound").transform.position.x;
		}
		catch
		{
			Debug.Log("Unable to find the all boundaries! Check game scene for all boundaries.");
		}
	}

	// Use this for initialization
	void Start () {
		GetBoundaries();

		// Randomly spawn background objects at the start
		for (int i = 0; i < NumberOfRandomBackgroundObjectsAtStart; ++i)
		{
			Spawn();
		}
	}

	void Spawn(bool noRand = false)
	{
		// Generate Random Y, X, Size, Speed
		float y = Random.Range(top, bottom);
		float x;
		if (noRand)
			x = right;
		else
			x = Random.Range(left, right);
		float size = Random.Range(MinimumSizeOfBackgroundObject, MaximumSizeOfBackgroundObject);
		float speed = Random.Range(MinimumSpeed, MaximumSpeed);
		int type = (int)Random.Range(1, TypesOfBackgroundObj + 1);

		GameObject obj;

		switch (type)
		{
			case 1:
				obj = (GameObject)Instantiate(Resources.Load("Background/Background_Obj"));
				obj.transform.parent = this.transform;
				obj.transform.localScale = new Vector3(size, size);
				obj.transform.position = new Vector3(x, y);
				obj.GetComponent<BackgroundObject>().SetScrollSpeed(speed);
				break;
			case 2:
				obj = (GameObject)Instantiate(Resources.Load("Background/Background_Obj_2"));
				obj.transform.parent = this.transform;
				obj.transform.localScale = new Vector3(size, size);
				obj.transform.position = new Vector3(x, y);
				obj.GetComponent<BackgroundObject>().SetScrollSpeed(speed);
				break;
			default:
				break;
		}
	}

	// Update is called once per frame
	void Update () {
		if (TimeNextSpawn < 0.0f)
		{
			// Spawn in random time interval
			TimeNextSpawn = Random.Range(MinimumTimeNextSpawn, MaximumTimeNextSpawn);

			Spawn(true);
		}

		TimeNextSpawn -= Time.deltaTime;
	}
}
