using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerLight : BaseTower {

	[SerializeField]
	float HoverRange;
	[SerializeField]
	float HoverSpeed;

	bool MovingUp = true;
	float HoverMidPoint;

	private void Start()
	{
		BaseStart();
		HoverMidPoint = this.transform.position.y;
	}

	void Hover()
	{
		if (MovingUp)
		{
			Vector3 tmp = new Vector3(0, HoverSpeed * Time.deltaTime, 0);
			this.transform.Translate(tmp);

			if (HoverMidPoint + HoverRange < this.transform.position.y)
				MovingUp = false;
		}

		else
		{
			Vector3 tmp = new Vector3(0, -HoverSpeed * Time.deltaTime, 0);
			this.transform.Translate(tmp);

			if (HoverMidPoint - HoverRange > this.transform.position.y)
				MovingUp = true;
		}
	}

	void Update()
	{
		BaseUpdate();

		Hover();
	}
}
