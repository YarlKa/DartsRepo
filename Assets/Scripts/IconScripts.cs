using UnityEngine;
using UnityEngine.UI;

public class IconScripts : MonoBehaviour
{
    [SerializeField]
    private GameObject restartButton;

    [Header("darts display")]
    [SerializeField]
    private GameObject panelDarts;
    [SerializeField]
    private GameObject iconDarts;
    [SerializeField]
    private Color dartsIconColor;

    public void ShowRestartButton()
    {
        restartButton.SetActive(true);
    }

    public void SetDisplay(int count)
    {
        for (int i = 0; i < count; i++)
            Instantiate(iconDarts, panelDarts.transform);
    }

    private int dartsIconChange = 0;
    public void DisplaiDarts()
    {
        panelDarts.transform.GetChild(dartsIconChange++)
            .GetComponent<Image>().color = dartsIconColor;
    }



}
