using System;
using UnityEngine;

namespace DialogSystem
{
    [RequireComponent(typeof(Collider2D))]
    public class NPC : MonoBehaviour
    {
        [SerializeField] private DialogWindow dialogWindow;
        
        [SerializeField] private DialogData startDialog;
        [SerializeField] private DialogData itemDialog;

        // private void OnEnable()
        // {
        //     DialogWindow.DialogStart += OnDialogEnded;
        // }
        //
        // private void OnDisable()
        // {
        //     DialogWindow.DialogEnd -= OnDialogEnded;
        // }

        private void OnMouseDown()
        {
            dialogWindow.PlayDialog(startDialog);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            dialogWindow.PlayDialog(itemDialog);
        }

        // private void OnDialogEnded(DialogData dialogData)
        // {
        //     if (itemDialog == dialogData)
        //         TurnOff();
        // }
        //
        // private void TurnOff() => gameObject.SetActive(false);
    }
}
