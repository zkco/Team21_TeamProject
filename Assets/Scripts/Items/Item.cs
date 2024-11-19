using UnityEngine;

public abstract class Item : MonoBehaviour
{
    public ItemData ItemData;

    public abstract void Use();
}
