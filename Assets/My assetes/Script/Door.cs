using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class Door : MonoBehaviour
{
    private Outline outline;
    private XRBaseInteractable interactable;
    [SerializeField] private TMP_Text textUI;
    void Awake(){
        interactable = GetComponent<XRBaseInteractable>();
        outline = gameObject.GetComponent<Outline>();
        outline.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (interactable.isHovered){
            outline.enabled = true;
        }
        else{
            outline.enabled = false;
        }

        if (interactable.isSelected){
            int score = PlayerPrefs.GetInt("score");
            if (score == 0){
                textUI.SetText("The door is locked and you can't get out. Is there something you can do or should you try the dice again?");
            }
            else{
                textUI.SetText($"You collected {score} gold pieces worth of valuables, however the door is still locked. Find a way to open it.");
            }
        }
    }
}
