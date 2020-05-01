using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GridCreator : MonoBehaviour
{
    #region Variables
    private static GridCreator _instance;
    public Vector2 grid;
    public Transform hexPrefab;
    public float gap=0.1f;
    public Material[] hexMaterials;
    public float camOffset = 0.8f;

    [SerializeField]
    float _hexWidth=1.73f;
    [SerializeField]
    float _hexHeight=2.0f;

    Vector3 _startPosition;
    private GameManager gm;

    public static GridCreator Instance {
        get
        {
            if (_instance == null)
                _instance = new GridCreator();

            return _instance;
        }
    }
    private void Awake()
    {
        
        //var arguments = mc.GetSelectedAgruments();
        //grid = gm.grid;
        CalcGap();
        CalcStartPosition();
        CreateGrid();
    }
    #endregion
    #region --Private Custom Methods--
    private void CalcGap()
    {
        _hexWidth += _hexWidth * gap;
        _hexHeight += _hexHeight * gap;
    }
    private void CalcStartPosition()
    {
        //_startPosition = Vector3.zero;

        float offset = 0;
        if(grid.y/2 %2!=0)
        {
            offset = _hexWidth / 2;
        }
        float x = -_hexWidth * (grid.x / 2) - offset+camOffset;
        float y = -_hexHeight * 0.75f * (grid.y / 2);

        _startPosition = new Vector3(x, y,0);
    }
    private void CreateGrid()
    {
        for (int y = 0; y < grid.y; y++)
        {
            for (int x = 0; x < grid.x; x++)
            {
                Transform hex = Instantiate(hexPrefab) as Transform;
                Vector2 gridPos = new Vector2(x, y);
                hex.position = CalculateWorldPos(gridPos);
                hex.parent = this.transform;
                hex.name = "Hexagon " + x + "|" + y;
                MeshRenderer mr = hex.GetComponentInChildren<MeshRenderer>();
                mr.material = hexMaterials[Random.Range(0, hexMaterials.Length)];
                hex.gameObject.AddComponent<CircleCollider2D>();
                hex.gameObject.tag = "Hexagon";
            }
        }
    }

    private Vector3 CalculateWorldPos(Vector2 gridPos)
    {
        float offset = 0f;
        if (gridPos.y % 2 == 0)
        {
            offset = _hexWidth / 2f;
        }
        float x = _startPosition.x + gridPos.x * _hexWidth + offset;
        float y = _startPosition.y + gridPos.y * _hexHeight * 0.75f;

        return new Vector3(x, y, 0);
    }
    #endregion

}
