using UnityEngine;

public abstract class Item : MonoBehaviour
{
    public ItemData ItemData;
    protected Player player;

    protected virtual void Start()
    {
        player = Managers.PlayerManager.Player;
    }
    public abstract void Use();
}
