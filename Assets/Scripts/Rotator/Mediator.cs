
using UnityEngine;

public class Mediator : MonoBehaviour
{
    [SerializeField] private Rotator rotator;
    [SerializeField] private ProgressBar progressBar;

    [SerializeField] private float speed;

    private void Update()
    {
        float angleSpeed = rotator.DeltaAngel;
        if (Mathf.Abs(angleSpeed) < speed) return;
        
        progressBar.SetFillAmount(rotator.Angel / 1080);
    }
}