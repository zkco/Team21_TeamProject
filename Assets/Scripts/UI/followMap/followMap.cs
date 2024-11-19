using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class followMap : MonoBehaviour
{
    private GameObject Player;

    void Start()
    {
        Player = GameObject.FindWithTag("Player");
    }

    private void LateUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, Player.transform.position, Time.deltaTime * 0.5f);
        //transform.position = Player.transform.position;
    }
}
