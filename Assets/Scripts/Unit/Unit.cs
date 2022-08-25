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
    
    [Header("Cached Variables")]
    [SerializeField]
    private UnitType m_type;
    public UnitType Type
    {
        get
        {
            return m_type;
        }
    }
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
    private int m_playerID;
    public int PlayerID
	{
        get
		{
            return m_playerID;
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
    [SerializeField]
    private GameObject m_influenceRoot;
    [SerializeField]
    private List<SpriteRenderer> m_influenceRenderers;
    [SerializeField]
    private List<BoxCollider> m_influenceColliders;
    [SerializeField]
    private List<Cell> m_influencedCells;

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
        m_rendererFill.color = GameplayManager.Instance.UnitsManager.UnitSettings.UnitColorPlayers[m_playerID - 1];

        m_influenceRenderers = new List<SpriteRenderer>();
        m_influenceColliders = new List<BoxCollider>();
        m_influencedCells = new List<Cell>();

        for(int i = 0; i < m_influenceRoot.transform.childCount; i++)
		{
            SpriteRenderer newRenderer = m_influenceRoot.transform.GetChild(i).gameObject.GetComponentInChildren<SpriteRenderer>();

            if(newRenderer)
			{
                Color newColor = GameplayManager.Instance.UnitsManager.UnitSettings.UnitColorPlayers[m_playerID - 1];
                newColor.a = GameplayManager.Instance.UnitsManager.UnitSettings.InfluenceColorAlpha;
                newRenderer.color = newColor;
                m_influenceRenderers.Add(newRenderer);
                m_influenceColliders.Add(m_influenceRoot.transform.GetChild(i).gameObject.GetComponentInChildren<BoxCollider>());
            }
		}
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

    public void OnMovedToCell(Cell _cell)
	{
        m_currentCell = _cell;
        UpdateInfluence();
	}

    private void UpdateInfluence()
	{
        foreach(Cell cell in m_influencedCells)
		{
            cell.OnInfluenceStop(m_playerID);
		}

        m_influencedCells.Clear();

        foreach(BoxCollider collider in m_influenceColliders)
		{
            RaycastHit[] hits = Physics.BoxCastAll(collider.transform.position, collider.bounds.extents, -1f * Vector3.up, collider.transform.rotation);

            foreach(RaycastHit hit in hits)
			{
                Cell influencedCell = hit.transform.GetComponentInChildren<Cell>();
                if(influencedCell)
				{
                    m_influencedCells.Add(influencedCell);
                    Debug.Log("Influencing Cell: " + influencedCell.gameObject.name);
				}
			}
		}

        foreach (Cell cell in m_influencedCells)
        {
            cell.OnInfluenceStart(m_playerID);
        }
    }

    #endregion
}
