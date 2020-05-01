using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    #region Variables
    private static GameManager instance;
    [SerializeField]
    private int _selectedGrid;

    public GameObject goScreen = null;
    public GameObject bombSlider = null;

    public Vector2 grid;
    private Score score;
    private BombTimer bt;

    public int SelectedGrid { get => _selectedGrid; }
    public static GameManager Instance {
        get
        {
            if(instance == null)
            {
                instance = new GameManager();
            }
            return instance;
        }
    }
    #endregion
    #region Builtin Methods

    private void Start()
    {
        score = FindObjectOfType<Score>();
        bt = FindObjectOfType<BombTimer>();
        DontDestroyOnLoad(this);
    }

    private void Update()
    {
        /*if (SceneManager.GetActiveScene())
        {
            if (score.FinalScore == 1000)
            {
                bombSlider.gameObject.SetActive(true);
                bt.TimeOut();
                if (bt.bombSlider.value >= bt.bombSlider.maxValue)
                {
                    Debug.Log("GameOver");
                    GameOver();
                }
            }
        }*/
    }

    #endregion
    #region --Public Custom Methods--
    public void GetSelectedGrid(int selGrid)
    {
        _selectedGrid = selGrid;
    }
    #endregion
    #region --Private Custom Methods--
    private void GameOver()
    {
        Time.timeScale = 0;
        goScreen.SetActive(true);
    }
    #endregion

}
