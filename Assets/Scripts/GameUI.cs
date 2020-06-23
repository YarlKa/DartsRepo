using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour { 

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

    public void SetInitialDisplayDartsCount(int count)
    {
        for (int i = 0; i < count; i++)
            Instantiate(iconDarts, panelDarts.transform);
    }

    public int dartsIconIndexToChange = 0;
    public void DecremenalDisplayDartsCount()
    {
        panelDarts.transform.GetChild(dartsIconIndexToChange++)
            .GetComponent<Image>().color = usedDartsIconColor;
    }
}
