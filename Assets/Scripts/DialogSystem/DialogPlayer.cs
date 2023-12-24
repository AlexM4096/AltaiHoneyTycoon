using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace DialogSystem
{
    [RequireComponent(typeof(TMP_Text))]
    public class DialogPlayer : MonoBehaviour
    {
        private TMP_Text _tmpText;

        private bool _completeRevealed = false;
        private bool _canPlayDialog = true;

        private DialogData _dialogData;
        
        private Coroutine _coroutine;
        private WaitUntil _waitUntil;

        private void Awake()
        {
            _tmpText = GetComponent<TMP_Text>();
            
            _waitUntil = new WaitUntil(() => _completeRevealed);
        }

        private void OnEnable()
        {
            TypewriterEffect.CompleteTextRevealed += SetCompleteRevealedToTrue;
        }

        private void OnDisable()
        {
            TypewriterEffect.CompleteTextRevealed -= SetCompleteRevealedToTrue;
        }

        public void PlayDialog(DialogData dialogData)
        {
            if (!_canPlayDialog) return;
            
            if (_coroutine != null)
                StopCoroutine(Enumerator());

            _canPlayDialog = false;
            _dialogData = dialogData;
            StartCoroutine(Enumerator());
        }

        private IEnumerator Enumerator()
        {
            IEnumerable<string> lines = _dialogData.Lines;

            foreach (string line in lines)
            {
                yield return null;
                _tmpText.SetText(line);
                
                yield return new WaitUntil(() => _completeRevealed);
                _completeRevealed = false;
            }

            _canPlayDialog = true;
        }

        private void SetCompleteRevealedToTrue()
        {
            _completeRevealed = true;
        }
    }
}