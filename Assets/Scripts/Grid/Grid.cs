using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    [Header("Grid Settings")]
    [SerializeField]
    private int m_width;
    public int Width
	{
        get
		{
            return m_width;
		}
	}
    [SerializeField]
    private int m_height;
    public int Height
	{
        get
		{
            return m_height;
		}
	}
    [SerializeField]
    private int m_cellHP;
    public int CellHP
	{
        get
		{
            return m_cellHP;
		}
	}

    [Header("Cached Variables")]
    [SerializeField]
    private GameObject m_cellPrefab;
    [SerializeField]
    private float m_cellSize;
    public float CellSize
	{
        get
        { 
            return m_cellSize;
        }
	}
    [SerializeField]
    private List<List<Cell>> m_cells;
    
	void Start()
    {
        GenerateGrid();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GenerateGrid()
	{
        if(m_cells == null)
		{
            m_cells = new List<List<Cell>>();
        }

        if(m_cellPrefab && m_cells.Count == 0)
		{
            FlushGrid();

            m_cells = new List<List<Cell>>();

            GameObject tempCell = GameObject.Instantiate<GameObject>(m_cellPrefab);
            m_cellSize = tempCell.GetComponentInChildren<Cell>().BoxCollider.size.x;

            DestroyImmediate(tempCell);

            for(int i = 0; i < m_height; i++)
			{
                for(int j = 0; j < m_width; j++)
				{
                    if(j == 0)
					{
                        m_cells.Add(new List<Cell>());
					}

                    GameObject newCell = GameObject.Instantiate<GameObject>(m_cellPrefab);
                    newCell.transform.position = new Vector3(m_cellSize * (j + 0.5f), 0f, m_cellSize * (i + 0.5f));
                    newCell.transform.rotation = Quaternion.identity;
                    newCell.transform.parent = this.transform;

                    Cell newCellScript = newCell.GetComponentInChildren<Cell>();
                    newCellScript.SetCoordinates(i, j);

                    m_cells[i].Add(newCellScript);
				}
			}
		}
	}

    public void FlushGrid()
	{
        int childCount = transform.childCount;

        for(int i = childCount - 1; i >= 0; i--)
		{
            DestroyImmediate(transform.GetChild(i).gameObject);
		}

        m_cells.Clear();
	}

    public Vector3 GetGridCenter()
	{
        if(m_cells.Count > 0)
		{
            return m_cells[m_height / 2][m_width / 2].transform.position;
		}

        return Vector3.zero;
	}
}
