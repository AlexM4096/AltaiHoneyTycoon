using UnityEngine;

namespace Navigation
{
    [System.Serializable][CreateAssetMenu]
    public class NavigationHolder : ScriptableObject
    {
        [field: SerializeField] public Vector3 Position { get; set; }
        
        [field: Header ("Directions")]
        [field: SerializeField] public NavigationHolder Up { get; private set; }
        [field: SerializeField] public NavigationHolder Right { get; private set; }
        [field: SerializeField] public NavigationHolder Down { get; private set; }
        [field: SerializeField] public NavigationHolder Left { get; private set; }
    }
}