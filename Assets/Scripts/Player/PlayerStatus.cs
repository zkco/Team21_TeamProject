using System;
using System.Collections;
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
    public Sprite PlayerWeaponsprite;

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
    /// target에 value만큼 값을 즉시 추가(-로 입력하여 뺄셈가능)
    /// </summary>
    /// <param name="target">(max)hp,mp,exp,damage,gold 등 전부 소문자로</param>
    /// <param name="value">추가할 정수 값</param>
    public void AddValueTemp(string target, float value)
    {
        switch(target)
        {
            case "hp": Hp += (int)value; break;
            case "maxhp": MaxHp += (int)value; break;
            case "mp": Mp += (int)value; break;
            case "maxmp": MaxMp += (int)value; break;
            case "exp": Exp += (int)value; break;
            case "maxexp": MaxExp += (int)value; break;
            case "damage": Damage += (int)value; break;
            case "gold": Gold += (int)value; break;
            case "speed": Speed += value; break;
            default: Debug.Log("Target Error"); break;
        }
    }

    /// <summary>
    /// time값 만큼 매 초마다 실행(-로 입력하여 뺄셈가능)
    /// </summary>
    /// <param name="target">(max)hp,mp,exp,damage,gold 등 전부 소문자로</param>
    /// <param name="value">time초 동안 추가할 값</param>
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
            AddValueTemp(target, value/time);
            yield return wait;
        }
        yield return null;
    }
}
