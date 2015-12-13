using UnityEngine;
using InControl;
using System.Collections;

public class PlayerController : InputController 
{
	public override void Idle() {
		// Override this method with stuff that should be run when the controller is not in use
	}

	public override void Controls() {
		ResizeControls(RightTrigger);
	}

	public void ResizeControls(float input)
	{

	}
}