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

    // Start is called before the first frame update
    void Start()
    {
        InitUnit(GameplayManager.Instance.UnitSettings.GetUnitData(m_type));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InitUnit(UnitData _data)
	{
        m_stats = _data.Stats;
	}

	private void OnTriggerEnter(Collider _other)
	{
       
	}
}
