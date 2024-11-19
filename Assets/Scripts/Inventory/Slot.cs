using System;
using System.Text;
using Unity.VisualScripting;
using UnityEditorInternal.Profiling.Memory.Experimental;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class Slot : MonoBehaviour
{
    public Item item;
    public Image itemImage;
    public int code;

    private void Start()
    {
        itemImage = GetComponentInChildren<Image>();
    }

    public Item GetItem(int code)
    {
        if (this.code == code) return item;
        else return null;
    }

    public void SetItem(Item item)
    {
        this.item = item;
    }
        
    //public void SetItem(int code)
    //{
    //    수정하여 사용 예정
    //    string path = $"./item/{code}";
    //    this.item = Resources.Load(path).GetComponent<Item>();
    //}

    public void RemoveItem(int code)
    {
        if(this.code == code) this.item = null;
        return;
    }

    public void Regen()
    {
        if (item != null)
        {
            itemImage.sprite = Resources.Load<Sprite>(item.ItemData.iconPath);
        }
        else if(item == null)
        {
            itemImage.sprite = null;
        }
    }
}