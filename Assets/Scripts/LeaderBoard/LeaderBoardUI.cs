using System;
using System.Collections;
using Dan.Main;
using Dan.Models;
using UnityEngine;
using UnityEngine.UIElements;
using Random = UnityEngine.Random;

namespace LeaderBoard
{
    [RequireComponent(typeof(UIDocument))]
    public class LeaderBoardUI : MonoBehaviour
    {
        private Entry[] _entries = Array.Empty<Entry>();

        private VisualElement _root;
        private ListView _listView;
        
        private Button _button;
        
        private VisualElement _popup;
        private Label _label;
        private TextField _textField;
        private Button _saveButton;
        private Button _closeButton;

        private int _score;

        private Coroutine _coroutine;

        private void Awake()
        {
            _root = GetComponent<UIDocument>().rootVisualElement;
            
            _button = _root.Q<Button>("StartGame");
            _button.clicked += SceneLoader.LoadGameplayScene;

            _score = PlayerPrefs.GetInt("score", 0);
            
            _popup = _root.Q("Popup");
            _popup.style.display = DisplayStyle.None;
            
            _label = _root.Q<Label>("Texty");
            _label.text += $"{_score}";
            
            _textField = _root.Q<TextField>("Field");
            _textField.RegisterCallback<FocusEvent>(evt => _textField.value = "");

            _saveButton = _root.Q<Button>("Save");
            _saveButton.clicked += () =>
            {
                _popup.style.display = DisplayStyle.None;
                Leaderboards.LeaderBoard.UploadNewEntry(_textField.value, _score);
            };

            _closeButton = _root.Q<Button>("Close");
            _closeButton.clicked += () =>
            {
                _popup.style.display = DisplayStyle.None;
            };

            InitializeListView();
        }

        private void Start()
        {
            UpdateEntries();
        }

        // private void OnEnable()
        // {
        //     //_coroutine = StartCoroutine(Coroutine());
        // }
        //
        // private void Start()
        // {
        //     _coroutine = StartCoroutine(Coroutine());
        // }

        // private void OnDisable()
        // {
        //     if (_coroutine is not null)
        //         StopCoroutine(_coroutine);
        // }

        IEnumerator Coroutine()
        {
            while (true)
            {
                UpdateEntries();
                yield return new WaitForSeconds(15);
            }
        }

        private void UpdateEntries()
        {
            Leaderboards.LeaderBoard.GetEntries(entries =>
            {
                _entries = entries;
                _listView.itemsSource = _entries;
                _listView.RefreshItems();
                
                if (_score > 0)
                    _popup.style.display = DisplayStyle.Flex;
            });
        }

        private void InitializeListView()
        {
            _listView = _root.Q<ListView>();
            _listView.itemsSource = _entries;
            _listView.makeItem = MakeItem;
            _listView.bindItem = BindItem;
        }
        
        private VisualElement MakeItem() => new LeaderBoardEntryUI();
        
        private void BindItem(VisualElement element, int index)
        {
            if (element is not LeaderBoardEntryUI leaderBoardEntryUI) return;

            var entry = _entries[index];

            leaderBoardEntryUI.Rank.text = entry.Rank.ToString();
            leaderBoardEntryUI.Username.text = entry.Username;
            leaderBoardEntryUI.Score.text = entry.Score.ToString();
        }
    }
}
