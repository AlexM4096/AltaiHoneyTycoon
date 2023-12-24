using UnityEngine;
using UnityEngine.UI;

namespace Navigation
{
    public class NavigationSystem : MonoBehaviour
    {
        [SerializeField] private NavigationHolder navigationHolder;
        [SerializeField] private Transform followPoint;

        [SerializeField] private Button upButton;
        [SerializeField] private Button rightButton;
        [SerializeField] private Button downButton;
        [SerializeField] private Button leftButton;
        
        private void Awake()
        {
            UpdatePosition();
        }

        private void UpdatePosition()
        {
            followPoint.position = navigationHolder.Position;
            
            upButton.onClick.RemoveAllListeners();
            rightButton.onClick.RemoveAllListeners();
            downButton.onClick.RemoveAllListeners();
            leftButton.onClick.RemoveAllListeners();

            if (navigationHolder.Up != null)
            {
                upButton.gameObject.SetActive(true);
                upButton.onClick.AddListener((() =>
                {
                    navigationHolder = navigationHolder.Up;
                    UpdatePosition();
                }));
            }
            else
            {
                upButton.gameObject.SetActive(false);
            }

            if (navigationHolder.Right != null)
            {
                rightButton.gameObject.SetActive(true);
                rightButton.onClick.AddListener((() =>
                {
                    navigationHolder = navigationHolder.Right;
                    UpdatePosition();
                }));
            }
            else
            {
                rightButton.gameObject.SetActive(false);
            }

            if (navigationHolder.Down != null)
            {
                downButton.gameObject.SetActive(true);
                downButton.onClick.AddListener((() =>
                {
                    navigationHolder = navigationHolder.Down;
                    UpdatePosition();
                }));
            }
            else
            {
                downButton.gameObject.SetActive(false);
            }
            
            if (navigationHolder.Left != null)
            {
                leftButton.gameObject.SetActive(true);
                leftButton.onClick.AddListener((() =>
                {
                    navigationHolder = navigationHolder.Left;
                    UpdatePosition();
                }));
            }
            else
            {
                leftButton.gameObject.SetActive(false);
            }
        }
    }
}