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
        private TextField _username;
        private IntegerField _score;

        private Coroutine _coroutine;

        private void Awake()
        {
            _root = GetComponent<UIDocument>().rootVisualElement;
            _button = _root.Q<Button>("Button");
            _username = _root.Q<TextField>("Username");
            _score = _root.Q<IntegerField>("Score");

            _button.clicked += () =>
            {
                Leaderboards.LeaderBoard.UploadNewEntry(_username.value, _score.value);
                UpdateEnties();
            };
            
            InitializeListView();
        }

        private void OnEnable()
        {
            //_coroutine = StartCoroutine(Coroutine());
        }

        private void Start()
        {
            _coroutine = StartCoroutine(Coroutine());
        }

        private void OnDisable()
        {
            if (_coroutine is not null)
                StopCoroutine(_coroutine);
        }

        IEnumerator Coroutine()
        {
            while (true)
            {
                UpdateEnties();
                yield return new WaitForSeconds(15);
            }
        }

        private void UpdateEnties()
        {
            Leaderboards.LeaderBoard.GetEntries(entries =>
            {
                _entries = entries;
                _listView.itemsSource = _entries;
                _listView.RefreshItems();
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