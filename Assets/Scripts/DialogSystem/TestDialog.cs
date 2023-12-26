using UnityEngine;
using UnityEngine.Serialization;

namespace DialogSystem
{
    public class TestDialog : MonoBehaviour
    {
        [SerializeField] public DialogData dialogData;
        [FormerlySerializedAs("dialogPlayer")] [SerializeField] public DialogWindow dialogWindow;

        public void OnButtonClick()
        {
            dialogWindow.PlayDialog(dialogData);
        }
    }
}