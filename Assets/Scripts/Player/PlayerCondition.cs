using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCondition : MonoBehaviour
{
    private PlayerStatus status;

    public Image Health;
    public Image Mana;
    public Image Exp;
    public TextMeshProUGUI level;

    private void Start()
    {
        status = Managers.PlayerManager.Player.Status;
        Managers.PlayerManager.Player.Condition = this;
    }

    private void Update()
    {
        Health.fillAmount = Mathf.Min((float)status.Hp / (float)status.MaxHp, 1f);
        Mana.fillAmount = Mathf.Min((float)status.Mp / (float)status.MaxMp, 1f);
        Exp.fillAmount = Mathf.Min((float)status.Exp / (float)status.MaxExp, 1f);
        level.text = status.Lv.ToString();
    }
}