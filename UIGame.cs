using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameUi : MonoBehaviour
{
    [SerializeField]
    private GameObject restartButton;

    [Header("Darts Count Display")]
    [SerializeField]
    private GameObject panelDarts;
    [SerializeField]
    private GameObject iconDarts;
    [SerializeField]
    private Color usedDartsIconColor;

    public void ShowRestartButton()
    {
        restartButton.SetActive(true);
    }

    public void SetInitialDisplayedDartsCount(int count)
    {
        for (int i = 0; i < count; i++)
            Instantiate(iconDarts, panelDarts.transform);
    }
    private int dartsIconIndexToChange = 0;
    public void DecrementDisplayedDartsCount()
    {
        panelDarts.transform.GetChild(dartsIconIndexToChange++)
            .GetComponent<Image>().color = usedDartsIconColor;
    }
}
