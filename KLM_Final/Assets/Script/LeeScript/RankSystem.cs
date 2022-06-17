using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RankSystem : MonoBehaviour
{
    public TextMeshProUGUI[] rankText;

    private int[] rankScore = new int[5];


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < 5; i++)
        {
            rankScore[i] = PlayerPrefs.GetInt(i + "BestScore");
            rankText[i].text = rankScore[i].ToString() + "Á¡";
        }
    }
}
