using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    PlayerControls controls;

    [SerializeField]
    List<Button> buttonsList;

    private Button selectedButton;
    private int btnIdx = 0;


    private void Awake() 
    {
        controls = new PlayerControls();

        controls.Menu.Previous.performed += ctx => Previous();
        controls.Menu.Next.performed += ctx => Next();
        controls.Menu.Confirm.performed += ctx => Confirm();
    }
    private void OnEnable() {
        controls.Enable();
    }

    private void OnDisable() {
        controls.Disable();
    }

    private void Start() 
    {
        if (buttonsList.Count != 0)
            Select(buttonsList[0]);
    }

    void Previous()
    {
        if (btnIdx > 0)
            Select(buttonsList[--btnIdx]);
    }

    void Next()
    {
        if (btnIdx < buttonsList.Count-1)
            Select(buttonsList[++btnIdx]);
    }
    
    void Confirm()
    {
        selectedButton.onClick.Invoke();
    }

    void Select(Button btn)
    {
        if (selectedButton != null)
            selectedButton.image.color = Color.white;
        selectedButton = btn;
        btn.image.color = Color.yellow;
    }
}
