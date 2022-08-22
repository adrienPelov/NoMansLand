using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputsController : MonoBehaviour
{
	[SerializeField]
	private bool m_bisMovingLeft = false;
	[SerializeField]
	private bool m_bisMovingRight = false;
	[SerializeField]
	private bool m_bisMovingForward = false;
	[SerializeField]
	private bool m_bisMovingBackward = false;

	private void Update()
	{
		Vector2 movement = Vector2.zero;

		if(m_bisMovingLeft)
		{
			movement.x -= 1f;
		}

		if (m_bisMovingRight)
		{
			movement.x += 1f;
		}

		if (m_bisMovingForward)
		{
			movement.y += 1f;
		}

		if (m_bisMovingBackward)
		{
			movement.y -= 1f;
		}

		GameplayManager.Instance.GameCamera.UpdateMovement(movement);
	}

	public void OnCameraMoveLeft(InputValue _input)
	{
		m_bisMovingLeft = _input.Get<float>() == 1f;
	}

	public void OnCameraMoveRight(InputValue _input)
	{
		m_bisMovingRight = _input.Get<float>() == 1f;
	}

	public void OnCameraMoveForward(InputValue _input)
	{
		m_bisMovingForward = _input.Get<float>() == 1f;
	}

	public void OnCameraMoveBackward(InputValue _input)
	{
		m_bisMovingBackward = _input.Get<float>() == 1f;
	}

	public void OnCameraZoom(InputValue _input)
	{
		GameplayManager.Instance.GameCamera.OnZoom(_input.Get<float>());
	}
}
