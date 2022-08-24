using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum UnitType
{
    Scout = 0,
    Sniper = 1,
    Tank = 2,
    Artillery = 3
}

[System.Serializable]
public struct UnitStats
{
    public int HP;
    public int Defense;
    public int Damage;
    public int Movement;
    public int Cost;
}

public class Unit : MonoBehaviour
{
    #region Variables
    ////////////////////////
    /// Variables
    ////////////////////////
    
    [Header("Settings")]
    [SerializeField]
    private UnitType m_type;
    public UnitType Type
	{
        get
		{
            return m_type;
		}
	}

    [Header("Cached Variables")]
    [SerializeField]
    private UnitType m_nemesis;
    public UnitType Nemesis
	{
        get
		{
            return m_nemesis;
		}
	}
    [SerializeField]
    private UnitType m_victim;
    public UnitType Victim
	{
        get
		{
            return m_victim;
		}
	}
    
    [SerializeField]
    private UnitStats m_stats;
    public UnitStats Stats
	{
        get
		{
            return m_stats;
		}
	}

    [SerializeField]
    private Cell m_currentCell;
    public Cell CurrentCell
	{
        get
		{
            return m_currentCell;
		}
	}

    [SerializeField]
    private SpriteRenderer m_rendererFill;
    [SerializeField]
    private SpriteRenderer m_rendererSelection;

    #endregion

    #region Unity Methods
    ////////////////////////
    /// Unity Methods
    ////////////////////////

    void Start()
    {
        InitUnit(GameplayManager.Instance.UnitsManager.UnitSettings.GetUnitData(m_type));
    }

    void Update()
    {
        
    }

    #endregion

    #region Class Methods
    ////////////////////////
    /// Class Methods
    ////////////////////////
    
    public void InitUnit(UnitData _data)
	{
        m_stats = _data.Stats;
        m_rendererSelection.color = GameplayManager.Instance.UnitsManager.UnitSettings.UnitColorDefault;
    }

    public void SelectUnit(bool _bSelect)
	{
        if(_bSelect)
		{
            m_rendererSelection.color = GameplayManager.Instance.UnitsManager.UnitSettings.UnitColorSelected;

        }
        else
		{
            m_rendererSelection.color = GameplayManager.Instance.UnitsManager.UnitSettings.UnitColorDefault;
        }
    }

    #endregion
}
