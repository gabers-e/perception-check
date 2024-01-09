using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class Lootable : MonoBehaviour
{
    private GameObject bag2;
    private Outline outline;
    private XRBaseInteractable interactable;
    private InputDevice device;
    private GameObject zvok;
    void Awake(){
        zvok = GameObject.Find("Zvok");
        
        bag2 = GameObject.Find("Sack");
        interactable = GetComponent<XRBaseInteractable>();
        outline = gameObject.GetComponent<Outline>();
        
        
        var rightHandDevices = new List<InputDevice>();
        InputDevices.GetDevicesAtXRNode(XRNode.RightHand, rightHandDevices);

        if(rightHandDevices.Count == 1){
            device = rightHandDevices[0];
        }
        outline.enabled = false;
        outline.OutlineMode = Outline.Mode.OutlineVisible;
        outline.OutlineColor = Color.yellow;
        outline.OutlineWidth = 2f;
        
    }
    
    void Update()
    {
        if (interactable.isHovered){
            outline.enabled = true;
        }
        else{
            outline.enabled = false;
        }

        if (interactable.isSelected){
            zvok.GetComponent<AudioSource>().Play();
            Destroy(gameObject);
            bag2.transform.localScale += new Vector3(0.05f,0.05f,0.05f);
            PlayerPrefs.SetInt("score",PlayerPrefs.GetInt("score")+10);
            Debug.Log(PlayerPrefs.GetInt("score"));
        }
    }
}
