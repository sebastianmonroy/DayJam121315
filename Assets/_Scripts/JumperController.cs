using UnityEngine;
using InControl;
using System.Collections;

//// NOTES FROM AJ:
// Triggers override each other?
// Terminal falling velocity is weird
// Movement speed different depending on size (including fall speed)

public class JumperController : InputController 
{
	public Jumper jumper;
	public float resizeFactor;
	public float movementFactor;
	public float surfacePushFactor, playerPushFactor;

	public float prevRadius, currRadius;

	public override void Idle() 
	{
		// Override this method with stuff that should be run when the controller is not in use
	}

	public override void Controls() 
	{
		ResizeControls(LeftTrigger, RightTrigger);
		MovementControls(LeftStick);
	}

	public void ResizeControls(float contractInput, float expandInput)
	{
		prevRadius = currRadius;
		currRadius = jumper.radius;
		jumper.LerpRadius(1.0f + (expandInput - contractInput) * resizeFactor);
	}

	public void MovementControls(Vector2 movementInput)
	{
		float lateralMovement = movementInput.x;
		if (Mathf.Abs(lateralMovement) > 0.05f) 
		{
			jumper.GetComponent<Rigidbody2D>().AddForce(new Vector2(lateralMovement * movementFactor, 0f));
		}
	}

	void OnCollisionStay2D(Collision2D coll)
	{
		if (currRadius > prevRadius) 
		{
			if (coll.gameObject.tag == "Surface") 
			{
				Vector2 pushVector = Vector2.zero;
				foreach (ContactPoint2D cp in coll.contacts) 
				{
					pushVector += cp.normal;
				}
				GetComponent<Rigidbody2D> ().AddForce (pushVector.normalized * surfacePushFactor * Mathf.Pow(currRadius - prevRadius, 0.5f));
			} 
			else if (coll.gameObject.tag == "Player") 
			{
				Vector2 pushVector = Vector2.zero;
				Vector2 pullVector = Vector2.zero;
				foreach (ContactPoint2D cp in coll.contacts) 
				{
					pushVector += cp.normal/2f;
					pullVector -= cp.normal/2f;
				}
				GetComponent<Rigidbody2D>().AddForce(pushVector.normalized * playerPushFactor * Mathf.Pow(currRadius - prevRadius, 0.5f));
				coll.gameObject.GetComponent<Rigidbody2D>().AddForce(pullVector.normalized * playerPushFactor * Mathf.Pow(currRadius - prevRadius, 0.5f));
			}
		}
	}
}