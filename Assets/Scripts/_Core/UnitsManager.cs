using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitsManager : MonoBehaviour
{
    #region Variables
    ////////////////////////
    /// Variables
    ////////////////////////

    [Header("Cached Variables")]
    [SerializeField]
    private Unit m_selectedUnit;
    public Unit SelectedUnit
    {
        get
        {
            return m_selectedUnit;
        }
    }

    [SerializeField]
    private UnitSettings m_unitSettings;
    public UnitSettings UnitSettings
    {
        get
        {
            return m_unitSettings;
        }
    }

    #endregion

    #region Unity Methods
    ////////////////////////
    /// Unity Methods
    ////////////////////////

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    #endregion

    #region Class Methods
    ////////////////////////
    /// Class Methods
    ////////////////////////

    public void OnUnitSelected(Unit _unit)
	{
        if (m_selectedUnit)
        {
            m_selectedUnit.SelectUnit(false);
        }

        _unit.SelectUnit(true);
        m_selectedUnit = _unit;
    }

    public void OnNoUnitSelected()
    {
        if(m_selectedUnit)
		{
            m_selectedUnit.SelectUnit(false);
            m_selectedUnit = null;
		}
    }

    public void TryMoveToCell(Cell _cell)
	{
        if(m_selectedUnit)
		{
            m_selectedUnit.transform.position = _cell.transform.position;
            m_selectedUnit.OnMovedToCell(_cell);
		}

        OnNoUnitSelected();
    }

    public void TryRotateLeft()
	{
        if(m_selectedUnit)
		{
            m_selectedUnit.transform.Rotate(0f, -90f, 0f);
		}

        OnNoUnitSelected();
    }

    public void TryRotateRight()
    {
        if (m_selectedUnit)
        {
            m_selectedUnit.transform.Rotate(0f, 90f, 0f);
        }

        OnNoUnitSelected();
    }

    #endregion
}
