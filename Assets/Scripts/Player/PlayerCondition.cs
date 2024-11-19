using UnityEngine;
using UnityEngine.UI;

public class PlayerCondition : MonoBehaviour
{
    private PlayerStatus status;

    public Image Health;
    public Image Mana;
    public Image Exp;

    private void Start()
    {
        status = Managers.PlayerManager.Player.Status;
    }

    private void Update()
    {
        Health.fillAmount = Mathf.Min((float)(status.Hp / status.MaxHp), 1f);
        Mana.fillAmount = Mathf.Min((float)(status.Mp / status.MaxMp), 1f);
        Exp.fillAmount = Mathf.Min((float)(status.Exp / status.MaxExp), 1f);
    }
}