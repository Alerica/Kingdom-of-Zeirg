using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int gold = 100;
    [SerializeField]
    private TextMeshProUGUI goldText;

    void Update()
    {
        goldText.SetText(gold.ToString());
    }
}
