using System;
using System.Linq;
using Dan.Main;
using Dan.Models;
using UnityEngine;
using UnityEngine.UIElements;

namespace LeaderBoard
{
    [RequireComponent(typeof(UIDocument))]
    public class LeaderBoardUI : MonoBehaviour
    {
        private Entry[] _entries;

        private VisualElement _root;
        private ListView _listView;

        private void Awake()
        {
            _root = GetComponent<UIDocument>().rootVisualElement;
        }

        private void Start()
        {
            Leaderboards.LeaderBoard.GetEntries(entries =>
            {
                _entries = entries;
                
                InitializeListView();
            });
        }

        private void InitializeListView()
        {
            _listView = _root.Q<ListView>();
            
            _listView.itemsSource = _entries;
            
            Func<VisualElement> makeItem = () => new LeaderBoardEntryUI();
            _listView.makeItem = makeItem;

            Action<VisualElement, int> bindItem = (element, i) =>
            {
                if (element is not LeaderBoardEntryUI leaderBoardEntryUI) return;
                
                var entry = _entries[i];

                leaderBoardEntryUI.Rank.text = entry.Rank.ToString();
                leaderBoardEntryUI.Username.text = entry.Username;
                leaderBoardEntryUI.Score.text = entry.Score.ToString();
            };
            _listView.bindItem = bindItem;
        }
    }
}
