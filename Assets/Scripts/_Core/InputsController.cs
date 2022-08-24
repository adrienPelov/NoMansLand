using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputsController : MonoBehaviour
{
	#region Variables
	////////////////////////
	/// Variables
	////////////////////////
	
	[SerializeField]
	private bool m_bisMovingLeft = false;
	[SerializeField]
	private bool m_bisMovingRight = false;
	[SerializeField]
	private bool m_bisMovingForward = false;
	[SerializeField]
	private bool m_bisMovingBackward = false;

	#endregion

	#region Unity Methods
	////////////////////////
	/// Unity Methods
	////////////////////////

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

		GameplayManager.Instance.GameCamera.OnMovement(movement);
	}

	#endregion

	#region Class Methods
	////////////////////////
	/// Class Methods
	////////////////////////
	
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

	public void OnSelect(InputValue _input)
	{
		Vector2 mousePosition = Mouse.current.position.ReadValue();
		Vector3 rayOrigin = Camera.main.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, Camera.main.transform.position.y));
		RaycastHit[] hits = Physics.RaycastAll(rayOrigin + Vector3.up * 10f , Vector3.up * -1f, 30f);

		if (hits.Length > 0)
		{
			Unit selectedUnit = null;
			Cell selectedCell = null;

			foreach (RaycastHit hit in hits)
			{
				GameObject hitObject = hit.transform.gameObject;
				selectedUnit = hitObject.GetComponentInChildren<Unit>();
				selectedCell = hitObject.GetComponentInChildren<Cell>();
			}

			// Select Unit
			if (selectedUnit != null)
			{
				GameplayManager.Instance.UnitsManager.OnUnitSelected(selectedUnit);
			}
			// Try Moving Unit
			else if(selectedCell)
			{
				GameplayManager.Instance.UnitsManager.TryMoveToCell(selectedCell);
			}
			// Nothing
			else
			{
				GameplayManager.Instance.UnitsManager.OnNoUnitSelected();
			}
		}
	}

	public void OnRotateUnitLeft(InputValue _input)
	{
		GameplayManager.Instance.UnitsManager.TryRotateLeft();
	}

	public void OnRotateUnitRight(InputValue _input)
	{
		GameplayManager.Instance.UnitsManager.TryRotateRight();
	}

	#endregion
}
