using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    public string Name;
    public int Lv;
    public int Hp;
    private int maxHp;
    public int MaxHp { get { return maxHp + AddMaxHp; } }
    public int Mp;
    private int maxMp;
    public int MaxMp { get { return MaxMp + AddMaxMp; } }
    public int Exp;
    public int MaxExp;
    private float speed;
    public float Speed { get { return speed + AddSpeed; } }
    private int damage;
    public int Damage { get { return damage + AddDamage; } }
    private float attackRate;
    public float AttackRate { get { return (attackRate * 3) / (attackRate + AddAttackRate); } }
    public int Gold;
    public Sprite PlayerSprite;
    public Sprite PlayerWeaponsprite;

    public int AddMaxHp = 0;
    public int AddMaxMp = 0;
    public int AddDamage = 0;
    public float AddSpeed = 0;
    public int AddAttackRate = 0;

    public List<Item> EquippedItem;

    public void LevelUp()
    {
        if (Exp >= MaxExp)
        {
            LevelUpStat();
        }
    }

    private void LevelUpStat()
    {
        Lv++;
        maxHp += 10;
        maxMp += 10;
        damage += 1;
        Exp = 0;
        MaxExp = Mathf.CeilToInt(MaxExp * 1.2f);
        Hp = MaxHp;
        Mp = MaxMp;
    }

    /// <summary>
    /// target에 value만큼 값을 즉시 추가(-로 입력하여 뺄셈가능)
    /// </summary>
    /// <param name="target">(max)hp,mp,exp,damage,gold 등 전부 소문자로</param>
    /// <param name="value">추가할 정수 값</param>
    public void AddValueTemp(string target, float value)
    {
        switch (target)
        {
            case "hp":
                Hp += (int)value;
                if (Hp > MaxHp) { Hp = MaxHp; }
                break;
            case "maxhp": AddMaxHp += (int)value; break;
            case "mp":
                Mp += (int)value;
                if (Mp > MaxMp) { Mp = MaxMp; }
                break;
            case "maxmp": AddMaxMp += (int)value; break;
            case "exp": Exp += (int)value; break;
            case "maxexp": MaxExp += (int)value; break;
            case "damage": AddDamage += (int)value; break;
            case "gold": Gold += (int)value; break;
            case "speed": AddSpeed += value; break;
            default: Debug.Log("Target Error"); break;
        }
    }

    /// <summary>
    /// time값 만큼 매 초마다 실행(-로 입력하여 뺄셈가능)
    /// </summary>
    /// <param name="target">(max)hp,mp,exp,damage,gold 등 전부 소문자로</param>
    /// <param name="value">매 초 마다 추가할 값</param>
    /// <param name="time">지속 시간</param>
    public void AddValueDur(string target, float value, float time)
    {
        StartCoroutine(CoAddValueDur(target, value, time));
    }

    /// <summary>
    /// target에 value만큼 값을 천천히 추가(-로 입력하여 뺄셈가능)
    /// </summary>
    /// <param name="target">(max)hp,mp,exp,damage,gold 등 전부 소문자로</param>
    /// <param name="value">매 초마다 추가할 값</param>
    /// <param name="delay">delay 초마다 값 만큼 변화</param>
    /// <param name="time">지속 시간</param>
    public void AddValueDur(string target, float value, float delay, float time)
    {
        StartCoroutine(CoAddValueDur(target, value, delay, time));
    }

    /// <summary>
    /// target에 value만큼 time동안 값을 추가, time 소모 시 value만큼 값을 제거
    /// </summary>
    /// <param name="target">(max)hp,mp,exp,damage,gold 등 전부 소문자로</param>
    /// <param name="value">지속 시간 동안 추가될 값</param>
    /// <param name="time">지속 시간</param>
    public void AddBuff(string target, float value, float time)
    {
        StartCoroutine(CoAddBuff(target, value, time));
    }

    private IEnumerator CoAddValueDur(string target, float value, float delay, float time)
    {
        WaitForSeconds wait = new WaitForSeconds(delay);
        float durtime = 0;
        while (durtime <= time)
        {
            durtime += Time.deltaTime;
            AddValueTemp(target, value);
            yield return wait;
        }
        yield return null;
    }

    private IEnumerator CoAddValueDur(string target, float value, float time)
    {
        WaitForSeconds wait = new WaitForSeconds(1f);
        float durtime = 0;
        while (durtime <= time)
        {
            AddValueTemp(target, value);
            yield return wait;
        }
        yield return null;
    }

    private IEnumerator CoAddBuff(string target, float value, float time)
    {
        WaitForSeconds wait = new WaitForSeconds(time);
        AddValueTemp(target, value);
        yield return wait;
        AddValueTemp(target, -value);
        yield return null;
    }

    public void AddEquippedItemValue()
    {
        AddMaxHp = 0;
        AddMaxMp = 0;
        AddSpeed = 0;
        AddDamage = 0;
        AddAttackRate = 0;
        for (int i = 0; i < EquippedItem.Count; i++)
        {
            if (EquippedItem[i] == null) continue;
            for (int j = 0; j < EquippedItem[i].ItemData.values.Count; j++)
            {
                AddValueTemp(EquippedItem[i].ItemData.targets[j].ToString().ToLower(), EquippedItem[i].ItemData.values[j]);
            }
        }
    }
}
