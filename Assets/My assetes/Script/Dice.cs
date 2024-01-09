using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

[RequireComponent(typeof(Rigidbody))]
public class Dice : MonoBehaviour{
    public Transform[] dicefaces;
    public Rigidbody rb;
    [SerializeField] private GameObject continueButton;
    
    private bool isPickedUp;

    public static UnityAction<int> OnDiceResult;
    
    private XRBaseInteractable interactable;
    private InputDevice device;

    private Outline outline;
    private AudioSource zvok;
    
    private void Awake(){
        zvok=gameObject.GetComponent<AudioSource>();
        continueButton.SetActive(false);
        rb = GetComponent<Rigidbody>();
        interactable = GetComponent<XRBaseInteractable>();
        isPickedUp = false;
        var rightHandDevices = new List<InputDevice>();
        InputDevices.GetDevicesAtXRNode(XRNode.RightHand, rightHandDevices);

        if(rightHandDevices.Count == 1){
            device = rightHandDevices[0];
        }

        outline = gameObject.GetComponent<Outline>();
        outline.enabled = false;

    }

    

    // Update is called once per frame
    void Update(){

        if (interactable.isHovered){
            outline.enabled = true;
        }
        else{
            outline.enabled = false;
        }
        if(interactable.isSelected){
            isPickedUp = true;
        }
        
        if (isPickedUp&&rb.velocity.sqrMagnitude==0f &&rb.position.y<0.2){
            isPickedUp = false;
            GetNumberOnTopFace();
            
        }
    }
    [ContextMenu("Get top face")]
    private int GetNumberOnTopFace(){
        if(dicefaces==null)return -1;
        var topFace = 0;
        var lastYPos = dicefaces[0].position.y;

        for (int i = 0; i < dicefaces.Length; i++){
            if (dicefaces[i].position.y>lastYPos){
                lastYPos = dicefaces[i].position.y;
                topFace = i;
            }
        }
        
        PlayerPrefs.SetInt("dice", topFace+1);
        Debug.Log($"Dice result {topFace+1}.");
        continueButton.SetActive(true);
        OnDiceResult.Invoke(topFace+1);
        return topFace+1;
    }

    private void OnCollisionEnter(Collision other){
        zvok.Play();
    }
}
