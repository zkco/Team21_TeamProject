using UnityEngine;
using EnumTypes;
using Constants;
using UnityEngine.UI;
public class ShopEntrance : MonoBehaviour
{
    //[SerializeField] private ShopCode shopId;
    [SerializeField] private Image image;
    [SerializeField] private LayerMask playerLayer;
    private void Update()
    {
        Debug.DrawRay(transform.position, Vector2.left * 2.5f);
        if (CheckNear())
        {
            Debug.Log("on");
            image.gameObject.SetActive(true);
        }
        else image.gameObject.SetActive(false);
    }
    private bool CheckNear()
    {
        Ray[] rays = new Ray[2]
        {
            new Ray(transform.position, Vector3.left),
            new Ray(transform.position, Vector3.right)
        };

        for(int i=0; i < rays.Length; i++)
        {
            if (Physics.Raycast(rays[i], 2.3f, playerLayer))
                return true;

        }

        return false;
    }
}