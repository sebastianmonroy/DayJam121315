using UnityEngine;
using System.Collections;

public class Jumper : Player 
{
	public float defaultRadius;
	public float radius;
	public float radiusLerpSpeed;
	public float health = 1.0f;

	void Start()
	{
		defaultRadius = this.GetComponent<CircleCollider2D>().radius;
		SetRadius(defaultRadius);
	}

	public void SetRadius(float radius)
	{
		if (this.radius != 0f) 
		{
			this.transform.localScale *= radius / this.radius;
		}

		this.radius = radius;
	}

	public float LerpRadius(float factor)
	{
		float newRadius = Mathf.Lerp(radius, defaultRadius * factor, Time.deltaTime * radiusLerpSpeed);

		SetRadius(newRadius);

		return newRadius;
	}
}
