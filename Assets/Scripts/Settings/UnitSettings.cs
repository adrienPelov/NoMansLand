using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct UnitData
{
	public UnitType Type;
	public GameObject Prefab;
	[Tooltip("Unit Type that takes LESS damage when attacked by this one.")]
	public UnitType Nemesis;
	[Tooltip("Unit Type that takes MORE damage when attacked by this one.")]
	public UnitType Victim;
	public UnitStats Stats;
}

public class UnitSettings : ScriptableObject
{
	[SerializeField]
	private Color[] m_unitColorPlayers;
	public Color[] UnitColorPlayers
	{
		get
		{
			return m_unitColorPlayers;
		}
	}

	[SerializeField]
	private float m_influenceColorAlpha = 0.25f;
	public float InfluenceColorAlpha
	{
		get
		{
			return m_influenceColorAlpha;
		}
	}

	[SerializeField]
	private Color m_unitColorDefault;
	public Color UnitColorDefault
	{
		get
		{
			return m_unitColorDefault;
		}
	}

	[SerializeField]
	private Color m_unitColorSelected;
	public Color UnitColorSelected
	{
		get
		{
			return m_unitColorSelected;
		}
	}

	[SerializeField]
	private UnitData[] m_unitsData;

	public UnitData GetUnitData(UnitType _type)
	{
		UnitData dataToReturn = new UnitData();

		foreach(UnitData data in m_unitsData)
		{
			if(data.Type == _type)
			{
				return data;
			}
		}

		return dataToReturn;
	}
}
