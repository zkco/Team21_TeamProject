using UnityEngine;
using UnityEngine.UI;

public class PlayerCondition : MonoBehaviour
{
    private PlayerStatus status;

    public Image Health;
    public Image Mana;
    public Image Exp;

    private void Awake()
    {
        status = Managers.PlayerManager.Player.Status;
    }

    private void Update()
    {
        Health.fillAmount = Mathf.Min(status.Hp / status.MaxHp , 1);
        Mana.fillAmount = Mathf.Min(status.Mp / status.MaxMp, 1);
        Exp.fillAmount = Mathf.Min(status.Exp / status.MaxExp, 1);
    }
}