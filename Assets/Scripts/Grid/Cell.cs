using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CellType
{
    Plains = 0,
    Forest = 1,
    Mountain = 2,
    NoMansLand = 3,
    Building = 4
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
    #region Variables
    ////////////////////////
    /// Variables
    ////////////////////////
    
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
    private List<int> m_influencePlayerIDs;

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

    #endregion

    #region Unity Methods
    ////////////////////////
    /// Unity Methods
    ////////////////////////

    void Start()
    {
        InitCell();
    }

    void Update()
    {
        
    }

    #endregion

    #region Class Methods
    ////////////////////////
    /// Class Methods
    ////////////////////////
    
    public void SetCoordinates(int _row, int _column)
	{
        m_row = _row;
        m_column = _column;
	}

    private void InitCell()
	{
        m_hp = m_settings.CellHP;
        m_state = CellState.Default;
        m_influencePlayerIDs = new List<int>();

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

    private void SetState(CellState _newState)
	{
        m_state = _newState;

        Debug.Log("Cell_[" + m_row + "][" + m_column + "] -> new State: " + _newState);

        switch (_newState)
        {
            default:
			{
                break;
			}
        }
	}

    public void OnInfluenceStart(int _playerID)
	{
        if (!m_influencePlayerIDs.Contains(_playerID))
        {
            m_influencePlayerIDs.Add(_playerID);

            if (m_influencePlayerIDs.Count > 1)
            {
                SetState(CellState.Contested);
            }
            else
            {
                SetState(CellState.Influenced);
            }
        }
	}

    public void OnInfluenceStop(int _playerID)
	{
        m_influencePlayerIDs.Remove(_playerID);

        if (m_influencePlayerIDs.Count > 1)
        {
            SetState(CellState.Contested);
        }
        else if (m_influencePlayerIDs.Count == 1)
        {
            SetState(CellState.Influenced);
        }
        else
		{
            SetState(CellState.Default);
        }
    }

    #endregion
}
