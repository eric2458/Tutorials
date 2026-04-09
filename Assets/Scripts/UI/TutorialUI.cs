using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using TMPro;
public class TutorialUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI KeyMoveUpText;
    [SerializeField] private TextMeshProUGUI KeyMoveDownText;
    [SerializeField] private TextMeshProUGUI KeyMoveLeftText;
    [SerializeField] private TextMeshProUGUI KeyMoveRightText;
    [SerializeField] private TextMeshProUGUI KeyInteractText;
    [SerializeField] private TextMeshProUGUI KeyInteractAlternateText;
    [SerializeField] private TextMeshProUGUI KeyPauseText;
    [SerializeField] private TextMeshProUGUI KeyGamepadInteractText;
    [SerializeField] private TextMeshProUGUI KeyGamepadInteractAlternateText;
    [SerializeField] private TextMeshProUGUI KeyGamepadPauseText;

    private void Start()
    {
        GameInput.Instance.OnBindingRebind += GameInput_OnBindingRebind;
        UpdateVisual();
    }

    private void GameInput_OnBindingRebind(object sender, System.EventArgs e)
    {
        UpdateVisual();
    }

    private void UpdateVisual()
    {
        KeyMoveUpText.text = GameInput.Instance.GetBindingText(GameInput.Binding.Move_Up);
        KeyMoveDownText.text = GameInput.Instance.GetBindingText(GameInput.Binding.Move_Down);
        KeyMoveLeftText.text = GameInput.Instance.GetBindingText(GameInput.Binding.Move_Left);
        KeyMoveRightText.text = GameInput.Instance.GetBindingText(GameInput.Binding.Move_Right);
        KeyInteractText.text = GameInput.Instance.GetBindingText(GameInput.Binding.Interact);
        KeyInteractAlternateText.text = GameInput.Instance.GetBindingText(GameInput.Binding.InteractAlternate);
        KeyPauseText.text = GameInput.Instance.GetBindingText(GameInput.Binding.Pause);
       // KeyGamepad_InteractText.text = GameInput.Instance.GetBindingText(GameInput.Binding.Gamepad_Interact);
        //KeyGamepad_InteractAlternateText.text = GameInput.Instance.GetBindingText(GameInput.Binding.Gamepad_InteractAlternate);
        //KeyGamepad_PauseText.text = GameInput.Instance.GetBindingText(GameInput.Binding.Gamepad_Pause);
    }
}
