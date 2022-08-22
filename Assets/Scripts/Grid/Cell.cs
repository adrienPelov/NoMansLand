using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CellType
{
    Plains = 0,
    Forest = 1,
    Mountain = 2,
    NoMansLand = 3
}

public enum CellState
{
    Default = 0,
    Occupied = 1,
    Influenced = 2,
    Contested = 3,
}

public class Cell : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField]
    private CellType m_type;
    public CellType Type
	{
        get
		{
            return m_type;
		}
	}

    [Header("Cached Variables")]
    [SerializeField]
    private CellState m_state;
    public CellState State
	{
        get
		{
            return m_state;
		}
	}
    [SerializeField]
    private int m_hp;

    [SerializeField]
    private int m_row;
    [SerializeField]
    private int m_column;

    [SerializeField]
    private CellSettings m_settings;

    [SerializeField]
    private BoxCollider m_boxCollider;
    public BoxCollider BoxCollider
	{
        get
		{
            return m_boxCollider;
		}
	}

    [SerializeField]
    private SpriteRenderer m_rendererFill;
    [SerializeField]
    private SpriteRenderer m_rendererBorder;

    // Start is called before the first frame update
    void Start()
    {
        InitCell();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetCoordinates(int _row, int _column)
	{
        m_row = _row;
        m_column = _column;
	}

    private void InitCell()
	{
        m_hp = GameplayManager.Instance.Grid.CellHP;
        m_state = CellState.Default;
	}

    public void UpdateCellColor()
	{
        switch (m_type)
        {
            case CellType.Forest:
			{
                m_rendererFill.color = m_settings.ColorTypeForest;
                break;
			}

            case CellType.Mountain:
            {
                m_rendererFill.color = m_settings.ColorTypeMountain;
                break;
            }

            case CellType.NoMansLand:
            {
                m_rendererFill.color = m_settings.ColorTypeNoMansLand;
                break;
            }

            default:
			{
                m_rendererFill.color = m_settings.ColorTypePlains;
                break;
            }
        }
	}
}
