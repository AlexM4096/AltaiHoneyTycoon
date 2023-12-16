using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    [SerializeField] private Image image;

    public void SetFillAmount(float amount)
    {
        if (amount < 0 || amount > 1) return;

        image.fillAmount = amount;
    }
}