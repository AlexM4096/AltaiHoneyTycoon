using System.Collections.Generic;
using UnityEngine;

namespace DialogSystem
{
    [CreateAssetMenu]
    public class DialogData : ScriptableObject
    {
        [SerializeField][TextArea] private List<string> lines;
        public IEnumerable<string> Lines => lines;
    }
}