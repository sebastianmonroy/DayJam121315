using UnityEngine;
using InControl;
using System.Collections;

public class JumperController : InputController 
{
	public Jumper jumper;
	public float resizeFactor;

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

	public void MovementControls(Vector2 LeftStick)
	{

	}
}