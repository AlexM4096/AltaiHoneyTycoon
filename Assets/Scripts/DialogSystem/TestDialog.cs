using UnityEngine;

namespace DialogSystem
{
    public class TestDialog : MonoBehaviour
    {
        [SerializeField] public DialogData dialogData;
        [SerializeField] public DialogPlayer dialogPlayer;

        public void OnButtonClick()
        {
            dialogPlayer.PlayDialog(dialogData);
        }
    }
}