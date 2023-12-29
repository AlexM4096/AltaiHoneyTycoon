using UnityEngine;
using UnityEngine.Scripting;
using UnityEngine.UIElements;

namespace LeaderBoard
{
    public class LeaderBoardEntryUI : VisualElement
    {
        public readonly Label Rank;
        public readonly Label Username;
        public readonly Label Score;

        public LeaderBoardEntryUI()
        {
            var a = Resources.Load<VisualTreeAsset>("UI/LeaderBoardEntry")
                .Instantiate().Q("VisualElement");

            Rank = a.Q<Label>("Rank");
            Username = a.Q<Label>("Username");
            Score = a.Q<Label>("Score");
            
            Add(a);
        }
        
        #region UXML

            [Preserve] public new class UxmlFactory : UxmlFactory<LeaderBoardEntryUI, UxmlTraits> {}

            [Preserve]
            public new class UxmlTraits : VisualElement.UxmlTraits
            {
                // private readonly UxmlStringAttributeDescription _rank = new() { name = "rank-text" };
                //
                // public override void Init(VisualElement ve, IUxmlAttributes bag, CreationContext cc)
                // {
                //     base.Init(ve, bag, cc);
                //
                //     if (ve is not LeaderBoardEntryUI ate) return;
                //
                //     ate.Rank.text = _rank.GetValueFromBag(bag, cc);
                // }
            }

        #endregion
        
    }
}