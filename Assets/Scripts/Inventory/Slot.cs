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
    public Image OutLine;
    public int code;

    private Color _equipColor;
    private Color _baseColor;

    private void Start()
    {
        itemImage = GetComponentInChildren<Image>();
        OutLine = GetComponent<Image>();
        _baseColor = new Color(171 / 255f, 73 / 255f, 20 / 255f, 1f);
        _equipColor = new Color(20 / 255f, 171 / 255f, 169 / 255f, 1f);
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

    public void EquipItem(int code)
    {
        if (this.code == code)
        {
            item?.Equip();
            isEquipped();
        }
        else return;
        
    }

    public void UnequipItem(int code)
    {
        if (this.code == code)
        {
            item?.Unequip(item);
            isEquipped();
        }
        else return;
    }

    public void Use(int code)
    {
        if (this.code == code)
        {
            item?.Use();
        }
    }

    public void RemoveItem(int code)
    {
        if (this.code == code)
        {
            item?.Unequip(item);
            item?.Remove();
        }
    }

    private void isEquipped()
    {
        if (item == null) return;
        if (item.isEquipped == true)
        {
            OutLine.color = _equipColor;
        }
        else
        {
            OutLine.color = _baseColor;
        }
    }
}