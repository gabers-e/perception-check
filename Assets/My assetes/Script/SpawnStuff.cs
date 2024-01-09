using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnStuff : MonoBehaviour
{
    
    private int dice;
    public GameObject[] stuff;
    void Start()
    {
        dice  =  PlayerPrefs.GetInt("dice");
        Debug.Log(dice);

        for (int i = 19; i >= dice; i--){
            stuff[i].SetActive(false);
        }
        PlayerPrefs.SetInt("score",0);
    }
    
}
