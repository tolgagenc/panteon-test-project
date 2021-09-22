using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gameplay : MonoBehaviour
{
    PlayerController PC;

    GameObject[] playerRank = new GameObject[11];

    // Start is called before the first frame update
    void Start()
    {
        int i = 1;
        PC = FindObjectOfType<PlayerController>();
        playerRank[0] = PC.gameObject;
        var AIO = FindObjectsOfType<AIController>();
        foreach (var item in AIO)
        {
            playerRank[i] = item.gameObject;
            i++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!Prefrences.isFinish)
        {
            sort(playerRank);

            for (int i = 0; i < playerRank.Length; i++)
            {
                if (playerRank[i].name == "Boy")
                {
                    playerRank[i].GetComponent<PlayerController>().rank = i + 1;
                }
            }
        }
    }
    static void sort(GameObject[] PlayerRank)
    {
        int n = PlayerRank.Length;

        // One by one move boundary of unsorted subarray
        for (int i = 0; i < n - 1; i++)
        {
            // Find the minimum element in unsorted array
            int min_idx = i;
            for (int j = i + 1; j < n; j++)
                if (PlayerRank[j].transform.position.z > PlayerRank[min_idx].transform.position.z)
                    min_idx = j;

            // Swap the found minimum element with the first
            // element
            GameObject temp = PlayerRank[min_idx];
            PlayerRank[min_idx] = PlayerRank[i];
            PlayerRank[i] = temp;
        }
    }
}
