using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class Unlockable : MonoBehaviour
{
    public Rigidbody rb;
    private Outline outline;
    private XRBaseInteractable interactable;
    [SerializeField] private TMP_Text textUI;
    private InputDevice device;
    private AudioSource zvok;
    private bool hint = false;
    void Awake(){
        zvok = gameObject.GetComponent<AudioSource>();
        interactable = GetComponent<XRBaseInteractable>();
        outline = gameObject.GetComponent<Outline>();
        rb = GetComponent<Rigidbody>();
        
        var rightHandDevices = new List<InputDevice>();
        InputDevices.GetDevicesAtXRNode(XRNode.RightHand, rightHandDevices);

        if(rightHandDevices.Count == 1){
            device = rightHandDevices[0];
        }
        
        outline.enabled = false;
        outline.OutlineMode = Outline.Mode.OutlineVisible;
        outline.OutlineColor = Color.red;
        outline.OutlineWidth = 5f;
        
    }
    
    void Update()
    {
        if (hint == false){
            if (interactable.isHovered){
                outline.enabled = true;
            }
            else{
                outline.enabled = false;
            }
        }

        if (interactable.isSelected){
            switch (gameObject.name){
                case "Soup_Ladle":
                    textUI.SetText("This soup ladle is huge! Could it be used as a crowbar? No, this is ridiculous! Unless...?");
                    break;
                case "mf_book_01":
                    textUI.SetText("This book is called: 'Door whisperer - beginners guide to door socialization'. Perhaps you could convince the door to open itself? Or maybe you could just let the book do the talking.");
                    break;
                case "mf_potion_01":
                    textUI.SetText("This potion looks magical. The label is not helpful tho, just some weird letters. You could try drinking it, but is it really worth taking the risk? Maybe it's better if you just throw it into the door and see what happens.");
                    break;
                case "Key-Desk":
                    textUI.SetText("Incredible! An actual key! Who would've guessed you could open the door with that! But something seems strange... if the key is here, who locked the door in the first place?");
                    break;
            }
            
            
        }
    }

    private void OnCollisionEnter(Collision other){
        if (other.gameObject.name == "Door"){
            
            SceneManager.LoadScene("Outside");
        }
    }

    public void Hint(){
        hint = true;
        outline.enabled = true;
        outline.OutlineMode = Outline.Mode.OutlineAndSilhouette;
        outline.OutlineColor = Color.white;
        outline.OutlineWidth = 10f;
    }

}
