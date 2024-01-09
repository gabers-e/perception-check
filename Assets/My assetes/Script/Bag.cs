using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class Bag : MonoBehaviour
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
    }
}
