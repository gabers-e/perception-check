using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChangeTextBox : MonoBehaviour
{

    [SerializeField] private TMP_Text textUI;
    
    private void OnEnable(){
        Dice.OnDiceResult += SetText;
    }

    

    private void SetText(int diceResult){
        textUI.SetText($"You rolled a {diceResult}. If you want to try the scenario with this result click continue. Otherwise you can roll the dice again. ");
    }
    

}
