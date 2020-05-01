using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    #region Variables
    [Header("Score Properties")]
    [SerializeField]
    private Text _scoreText=null;
    [SerializeField]
    private float _scoreMultiplier = 5f;


    private float _finalScore = 1000;
    float _score = 1;
    public float FinalScore { get => _finalScore;}
    #endregion
    #region Builtin Methods
    private void Start()
    {
        _scoreText.text = "Score: 0";
        /*if (PlayerPrefs.HasKey("Score"))
        {
            _scoreText.text = PlayerPrefs.GetString("Score");
        }*/
    }
    #endregion
    #region --Public Custom Methods--
    public void SetScore()
    {
        _score *= _scoreMultiplier;
        _finalScore += _score;

        _scoreText.text = "Score " + _finalScore.ToString();
        PlayerPrefs.SetFloat("Score", FinalScore);
        Debug.Log("Score is "+FinalScore.ToString());

    }
    #endregion
    #region --Private Custom Methods--

    #endregion

}
