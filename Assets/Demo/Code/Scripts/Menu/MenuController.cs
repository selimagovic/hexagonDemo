using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor;
using System.Runtime.CompilerServices;

public class MenuController : MonoBehaviour
{
    #region Variables
    
    [SerializeField]
    private int level = 0;
    [SerializeField]
    private GameManager gm;
    [SerializeField]
    private static MenuController _instance;

    public MenuController Instance {
        get
        {
            if(_instance == null)
            {
                _instance = new MenuController();
            }
            return _instance;
        }
    }

    #endregion
    #region Builtin Methods
    private void Awake()
    {
        if(_instance != null)
        {
            Destroy(this);
        }
    }
    private void Start()
    {
        gm = FindObjectOfType<GameManager>();
        if(!gm)
        {
            Debug.LogError("No GameManager found");
            return;
        }
        DontDestroyOnLoad(this);
    }
    #endregion
    #region --Public Custom Methods--

    public void OnHomeButton(int level)
    {
        SceneManager.LoadScene(level);
    }
    public void OnPlayEnter()
    {
        if (gm.SelectedGrid == 0)
        {
            //grid = 
            gm.grid = new Vector2(8, 9); ;
    }
        else
            gm.grid = new Vector2(6, 7);
        SceneManager.LoadScene(level);
    }
    public void ExitGame()
    {
#if UNITY_EDITOR
        //Application.Quit();
        Application.Quit();
#else
        Application.Quit();
#endif
    }
    #endregion
    #region --Private Custom Methods--
    #endregion

}
