using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ApplePicker : MonoBehaviour
{

    public GameObject basketPrefab;
    public int numberOfBaskets = 3;
    public float basketBottomY = -6f;
    public float basketSpacingY = 1f;

    List<GameObject> baskets = new List<GameObject>();

    void Start()
    {
        for (int i = 0; i < numberOfBaskets; i++)
        {
            GameObject tBasketGO = Instantiate<GameObject>(basketPrefab);
            Vector3 pos = Vector3.zero;
            pos.y = basketBottomY + basketSpacingY * i;
            tBasketGO.transform.position = pos;
            baskets.Add(tBasketGO);
        }

        Apple.OnDestroy += TryDestroyBasket;
        
    }

    private void OnDisable()
    {
        Apple.OnDestroy -= TryDestroyBasket;


    }

    private void TryDestroyBasket()
    {
        if (baskets.Count > 0)
        {
            var last = baskets[baskets.Count - 1];
            Destroy(last);
            baskets.RemoveAt(baskets.Count - 1);
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
