using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class OxygenUI : MonoBehaviour
{
    [SerializeField] private Image fill;

    private void Update()
    {
        float percent = OxygenSystem.Instance.oxygen / 100f;
        fill.fillAmount = percent;
    }
}