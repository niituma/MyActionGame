using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
	[Header("Character Input Values")]
	public Vector2 move;
	public bool attack;
	public bool jump;


#if ENABLE_INPUT_SYSTEM && STARTER_ASSETS_PACKAGES_CHECKED
	public void OnMove(InputValue value)
	{
		MoveInput(value.Get<Vector2>());
	}

	public void OnJump(InputValue value)
	{
		JumpInput(value.isPressed);
	}
	public void OnChange(InputValue value)
	{
		ChangeInput(value.isPressed);
	}
	public void OnLockOn(InputValue value)
	{
		LockOnInput(value.isPressed);
	}
	public void OnAvd(InputValue value)
	{
		AvdInput(value.isPressed);
	}
	public void OnAttack(InputValue value)
	{
		AttackInput(value.isPressed);
	}
	public void OnFire(InputValue value)
	{
		FireInput(value.isPressed);
	}

	public void OnSprint(InputValue value)
	{
		SprintInput(value.isPressed);
	}
	public void OnAim(InputValue value)
	{
		AimInput(value.isPressed);
	}
	public void OnShoot(InputValue value)
	{
		ShootInput(value.isPressed);
	}
#else
	// old input sys if we do decide to have it (most likely wont)...
#endif


	public void MoveInput(Vector2 newMoveDirection)
	{
		move = newMoveDirection;
	}

	public void JumpInput(bool newJumpState)
	{
		jump = newJumpState;
	}
	public void AttackInput(bool newJumpState)
	{
		attack = newJumpState;
	}
}
