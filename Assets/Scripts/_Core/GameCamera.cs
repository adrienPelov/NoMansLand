using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCamera : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField]
    private float m_movementSpeed = 50f;
    [SerializeField]
    private float m_movementStep = 5f;
    [SerializeField]
    private float m_zoomSpeed = 10f;
    [SerializeField]
    private float m_zoomMin = 1f;
    [SerializeField]
    private float m_zoomMax = 25f;
    [SerializeField]
    private float m_zoomStep = 1f;

    [Header("Cached Variables")]
    [SerializeField]
    private Vector2 m_targetPosition;
    [SerializeField]
    private float m_targetHeight;

    // Start is called before the first frame update
    void Start()
    {
        InitCamera();
    }

    // Update is called once per frame
    void UpdateCamera()
    {
        UpdateCamera();
    }

    private void InitCamera()
	{
        m_targetHeight = m_zoomMax;

        Vector3 gridCenter = GameplayManager.Instance.Grid.GetGridCenter();
        m_targetPosition = new Vector2(gridCenter.x, gridCenter.z);
	}

    public void OnZoom(float _zoomValue)
    {
        if(_zoomValue != 0f)
		{
            m_targetHeight = Mathf.Clamp(m_targetHeight - Mathf.Sign(_zoomValue) * m_zoomStep, m_zoomMin, m_zoomMax);
        }
    }

    public void UpdateMovement(Vector2 _direction)
    {
        m_targetPosition += _direction * m_movementStep * Time.deltaTime;
    }

    private void Update()
    {
        Vector3 newPosition = transform.position;

        // Zoom
        newPosition.y = Mathf.Lerp(newPosition.y, m_targetHeight, Time.deltaTime * m_zoomSpeed);

        // Position
        newPosition.x = Mathf.Lerp(newPosition.x, m_targetPosition.x, Time.deltaTime * m_movementSpeed);
        newPosition.z = Mathf.Lerp(newPosition.z, m_targetPosition.y, Time.deltaTime * m_movementSpeed);

        transform.position = newPosition;
    }
}
