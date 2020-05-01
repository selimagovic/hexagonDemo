using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class HexController : MonoBehaviour
{
    #region Variables
    public Transform parentHexGo;
    [SerializeField]
    private Camera _mainCamera=null;

    private List<Transform> _hexList = new List<Transform>();
    private List<GameObject> _neighbours = new List<GameObject>();
    private List<CircleCollider2D> _circleCol2D = new List<CircleCollider2D>();
    #endregion
    #region Builtin Methods
    private void Start()
    {
        if (parentHexGo)
        {
            _hexList = parentHexGo.gameObject.GetComponentsInChildren<Transform>().ToList<Transform>();
            for (int i = 0; i < _hexList.Count; i++)
            {
                if (i == 0)
                {
                    //
                }
                else
                {
                    _circleCol2D.Add(_hexList[i].gameObject.GetComponent<CircleCollider2D>());
                    //check if all colliders are added to list
                    Debug.Log(_circleCol2D[i-1].name);
                }
            }
    }
        else
            Debug.LogError("Please insert parentGo");

        if(_mainCamera==null)
        {
            Debug.LogError("Please insert MainCamera");
        }
        FindNeighbours();
    }

    public void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SelectedGameObject();
        }
    }
    #endregion
    #region --Public Custom Methods--

    #endregion
    #region --Private Custom Methods--
    /// <summary>
    /// this function will select game objects that are in list based of mouse position on screen
    /// after that it will call another function for grouping hexagons by 3
    /// </summary>
    private void SelectedGameObject()
    {
        Vector2 ray = _mainCamera.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(ray, Vector2.zero, 0f);

        if (hit)
        {
            if(hit.transform != null)
            {
                PrintGOName(hit.transform.gameObject);
                GroupSelectedObjects(hit.transform.gameObject, hit);
            }
        }
        //create raycast hit 
        //create ray from camera using ScreenPointToRay
    }
    private void FindNeighbours()
    {
        /*for (int i = 0; i < _hexList.Count; i++)
        {
            if()
        }*/
        //foreach (Transform hexTransform in _hexList)
        //{
        //    if(hexTransform.gameObject.GetInstanceID()!=gameObject.GetInstanceID())
        //    {
        //        if (_circleCol2D[hexTransform.childCount].bounds.Intersects(hexTransform.gameObject.GetComponent<Collider2D>().bounds))
        //        {
        //            Debug.Log("[" +gameObject.name + "} found a neighbour" + hexTransform.name);
        //            _neighbours.Add(hexTransform.gameObject);
        //        }  
        //    }

        //}
    }
    private void GroupSelectedObjects(GameObject selectedGO,RaycastHit2D hit)
    {
        foreach (Transform hex in _hexList)
        {
            //group objects by 3 based of mouse position

        }
    }
    private void PrintGOName(GameObject go)
    {
        Debug.Log(go.name);
    }
    #endregion

}
