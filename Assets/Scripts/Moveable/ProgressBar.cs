using UnityEngine;
using UnityEngine.UI;

namespace Moveable
{
    public class ProgressBar : MonoBehaviour
    {
        [SerializeField] private Image image;

        public void SetFillAmount(float amount)
        {
            if (amount < 0) return;

            if (amount > 1)
            {
                image.fillAmount = 1;
                return;
            }

        
            image.fillAmount = amount;
        }
    }
}