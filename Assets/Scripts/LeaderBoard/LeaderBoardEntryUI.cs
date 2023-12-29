using UnityEngine;
using UnityEngine.Scripting;
using UnityEngine.UIElements;

namespace LeaderBoard
{
    public class LeaderBoardEntryUI : VisualElement
    {
        private static readonly VisualTreeAsset Prefab;
        
        static LeaderBoardEntryUI()
        {
            Prefab = Resources.Load<VisualTreeAsset>("UI/LeaderBoardEntry");
        }

        public readonly Label Rank;
        public readonly Label Username;
        public readonly Label Score;

        public LeaderBoardEntryUI()
        {
            var a = Prefab.Instantiate().Q("VisualElement");

            Rank = a.Q<Label>("Rank");
            Username = a.Q<Label>("Username");
            Score = a.Q<Label>("Score");

            style.height = 200;
            
            Add(a);
        }
        
        #region UXML

            [Preserve] public new class UxmlFactory : UxmlFactory<LeaderBoardEntryUI, UxmlTraits> {}
            [Preserve] public new class UxmlTraits : VisualElement.UxmlTraits {}

        #endregion
        
    }
}