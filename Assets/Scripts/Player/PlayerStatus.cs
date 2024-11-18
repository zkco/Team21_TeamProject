using System;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    public string Name;
    public int Lv;
    public int Hp;
    public int MaxHp;
    public int Mp;
    public int MaxMp;
    public int Exp;
    public int MaxExp;
    public float Speed;
    public int Damage;
    public float AttackRate;
    public int Gold;
    public Sprite PlayerSprite;

    public void LevelUp()
    {
        if (Exp >= MaxExp)
        {
            Lv++;
            Exp = 0;
            MaxExp = Mathf.CeilToInt(MaxExp * 1.2f);
        }
    }

    /// <summary>
    /// target에 value만큼 값을 추가
    /// </summary>
    /// <param name="target">(max)hp,mp,exp,damage,gold 등 전부 소문자로</param>
    /// <param name="value">추가할 정수 값</param>
    public void AddValueTo(string target, int value)
    {
        switch(target)
        {
            case "hp": Hp += value; break;
            case "maxhp": MaxHp += value; break;
            case "mp": Mp += value; break;
            case "maxmp": MaxMp += value; break;
            case "exp": Exp += value; break;
            case "maxexp": MaxExp += value; break;
            case "damage": Damage += value; break;
            case "gold": Gold += value; break;
            case "speed": Speed += value; break;
            default: Debug.Log(""); break;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="parameter">Hp,Mp,Exp,Damage,Gold</param>
    public void ReduceValueTo(int parameter)
    {

    }
}
