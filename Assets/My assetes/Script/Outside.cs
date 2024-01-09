using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Outside : MonoBehaviour
{
    [SerializeField] private TMP_Text textUI;
    private GameObject bag2;
    void Start(){
        int score = PlayerPrefs.GetInt("score");
        textUI.SetText($"Congratulations, you escaped! Your bag holds {score} gold worth of things!\nThank you for playing Perception check!");
        bag2 = GameObject.Find("Sack");
        float size = score / 50;
        bag2.transform.position += new Vector3(0f, score*10, 0f);
        bag2.transform.localScale += new Vector3(size,size,size);
    }


}
