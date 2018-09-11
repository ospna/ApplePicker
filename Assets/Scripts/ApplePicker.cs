using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ApplePicker : MonoBehaviour
{
    [Header("Set in Inspector")]

    public GameObject basketPrefab;
    public int numBaskets = 3;
    public float basketBottomY = -14f;
    public float basketSpacing = 2f;
    public List<GameObject> basketList;

    // Use this for initialization
    void Start ()
    {
        basketList = new List<GameObject>();
		for(int i = 0; i < numBaskets; i++)
        {
            GameObject tBasketGO = Instantiate<GameObject>(basketPrefab);
            Vector3 pos = Vector3.zero;
            pos.y = basketBottomY + (basketSpacing * i);
            tBasketGO.transform.position = pos;
            basketList.Add(tBasketGO);
        }
	}

    public void AppleDestroyed()
    {
        // Destory all of the falling apples
        GameObject[] tAppleArray = GameObject.FindGameObjectsWithTag("Apple");

        foreach(GameObject tGO in tAppleArray)
        {
            Destroy(tGO);
        }

        // Get the index of the last Basket in basketList
        int basketIndex = basketList.Count - 1;

        // Get a reference to that Basket GameObject
        GameObject tBasketGo = basketList[basketIndex];

        // Remove the Basket from the list and destroy the GameObject
        basketList.RemoveAt(basketIndex);
        Destroy(tBasketGo);

        // Restart the game if none are left
        if(basketList.Count == 0)
        {
            SceneManager.LoadScene("Scene");
        }
    }
}
