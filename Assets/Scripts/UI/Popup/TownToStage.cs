using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TownToStage : BasePopup
{

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("wall"))
        {
            
        }
    }
}
