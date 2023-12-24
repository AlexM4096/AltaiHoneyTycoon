using UnityEngine;

namespace Navigation
{
    public class NavigationWrapper : MonoBehaviour
    {
        [SerializeField] private NavigationHolder navigationHolder;
        
        #if UNITY_EDITOR
            private void OnValidate()
            {
                if (navigationHolder == null) return;
                
                navigationHolder.Position = transform.position;
            }
        #endif
    }
}