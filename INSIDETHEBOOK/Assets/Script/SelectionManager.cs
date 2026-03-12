using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class SelectionManager : MonoBehaviour
{

    public static SelectionManager Instance {  get; set; }

    public bool onTarget; 

    public GameObject InteractionInfo;
    TextMeshProUGUI interaction_text;

   private void Start()
    {
        onTarget = false;
        interaction_text = InteractionInfo.GetComponent<TextMeshProUGUI>();
    }


    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            var selectionTransform = hit.transform;
            InteractableObject interactable = selectionTransform.GetComponent<InteractableObject>();


            if (interactable && interactable.playerInRange)
            {
                onTarget = true;


               
                interaction_text.text = interactable.GetItemName();
                InteractionInfo.SetActive(true);
            }
            else
            {
                onTarget = false;
                InteractionInfo.SetActive(false);
            }

        }
        else
        {
             onTarget = false;
            InteractionInfo.SetActive(false);
        }
    }
}