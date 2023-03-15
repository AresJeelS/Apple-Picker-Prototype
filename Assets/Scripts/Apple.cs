using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : MonoBehaviour
{
    public static float BottomY = - 20f;

    private void Update()
    {
        if (transform.position.y < BottomY)
        {
            Destroy(this.gameObject);
            ApplePicker apScript = Camera.main.GetComponent<ApplePicker>();
            apScript.AppleDestroyed();
        }
    }

}
