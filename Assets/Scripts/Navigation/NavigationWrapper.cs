using UnityEngine;

namespace Navigation
{
    public class NavigationWrapper : MonoBehaviour
    {
        [SerializeField] private NavigationHolder navigationHolder;

        private void OnValidate()
        {
            if (navigationHolder == null) return;
            
            navigationHolder.Position = transform.position;
        }
    }
}