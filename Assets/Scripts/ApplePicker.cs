using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ApplePicker : MonoBehaviour
{
    public GameObject BasketBrefab;
    public int NumBasket = 3;
    public float BasketBottomY = -14f;
    public float BasketSpacingY = 2f;
    public List<GameObject> BasketList;

    private void Start()
    {
        BasketList = new List<GameObject>();
        for (int i = 0; i < NumBasket; i++)
        {
            GameObject tBasketGO = Instantiate(BasketBrefab);
            Vector3 pos = Vector3.zero;
            pos.y = BasketBottomY + (BasketSpacingY * i);
            tBasketGO.transform.position = pos;
            BasketList.Add(tBasketGO);  
        }
    }
    public void AppleDestroyed()
    {
        GameObject[] tAppleArray = GameObject.FindGameObjectsWithTag("Apple");
        foreach (GameObject tGO in tAppleArray)
        {
            Destroy(tGO);
        }

        int basketIndex = BasketList.Count -1;
        GameObject tbasketGO = BasketList[basketIndex];
        BasketList.RemoveAt(basketIndex);
        Destroy(tbasketGO);

        if (BasketList.Count == 0)
        {
            SceneManager.LoadScene("SampleScene");
        }
    }
}
