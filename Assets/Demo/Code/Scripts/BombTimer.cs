using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class BombTimer : MonoBehaviour
{
    #region Variables

    [Header("Bomb Properties")]

    public int bombSeconds;
    public Slider bombSlider;

    #endregion
    #region Builtin Methods
    private void Start()
    {
        bombSlider.maxValue = bombSeconds;
    }

    #endregion
    #region --Public Custom Methods--
    public void TimeOut()
    {
        StopAllCoroutines();
        StartCoroutine(BombCountDown());
    }
    #endregion
    #region --Private Custom Methods--
    private IEnumerator BombCountDown()
    {
        yield return new WaitForSeconds(1);
        for (int i = 0; i < bombSeconds; i++)
        {
            bombSlider.value++;
            yield return new WaitForSeconds(1);
            bombSlider.value++;
        }
    }
    #endregion

}
