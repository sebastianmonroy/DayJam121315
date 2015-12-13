using UnityEngine;
using InControl;
using System.Collections;

public class JumperController : InputController 
{
	public Jumper jumper;
	public float resizeFactor;
	public float movementFactor;

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
		jumper.LerpRadius(1.0f + (expandInput - contractInput) * resizeFactor);
	}

	public void MovementControls(Vector2 movementInput)
	{
		float lateralMovement = movementInput.x;
		if (Mathf.Abs(lateralMovement) > 0.05f) 
		{
			this.transform.position += new Vector3(lateralMovement * movementFactor, 0f);
		}
	}
}