using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CellSettings : ScriptableObject
{
	[SerializeField]
    private Color m_colorTypePlains;
    public Color ColorTypePlains
	{
		get
		{
			return m_colorTypePlains;
		}
	}

	[SerializeField]
	private Color m_colorTypeForest;
	public Color ColorTypeForest
	{
		get
		{
			return m_colorTypeForest;
		}
	}

	[SerializeField]
	private Color m_colorTypeMountain;
	public Color ColorTypeMountain
	{
		get
		{
			return m_colorTypeMountain;
		}
	}

	[SerializeField]
	private Color m_colorTypeNoMansLand;
	public Color ColorTypeNoMansLand
	{
		get
		{
			return m_colorTypeNoMansLand;
		}
	}
}
