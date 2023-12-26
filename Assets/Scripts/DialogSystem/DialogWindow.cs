using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace DialogSystem
{
    public class DialogWindow : MonoBehaviour
    {
        [SerializeField] private TMP_Text tmpText;
        [SerializeField] private Button button;

        public static event Action DialogStart;
        public static event Action DialogEnd; 
        
        private bool _canPlayDialog = true;
        private int _index = 0;

        private DialogData _dialogData;
        private Coroutine _coroutine;

        private void OnEnable()
        {
            button.onClick.AddListener(PlayLine);
        }

        private void OnDisable()
        {
            button.onClick.RemoveListener(PlayLine);
        }

        public void PlayDialog(DialogData dialogData)
        {
            if (!_canPlayDialog) return;
            
            OnDialogStart();
            
            _dialogData = dialogData;
            _canPlayDialog = false;
            gameObject.SetActive(true);
            
            _index = 0;
            PlayLine();
        }

        private void PlayLine()
        {
            if (_index >= _dialogData.Lines.Count)
            {
                OnDialogEnd();
                
                gameObject.SetActive(false);
                _canPlayDialog = true;
                return;
            }
            
            tmpText.SetText(_dialogData.Lines[_index]);
            _index++;
        }

        private static void OnDialogStart()
        {
            DialogStart?.Invoke();
        }

        private static void OnDialogEnd()
        {
            DialogEnd?.Invoke();
        }
    }
}