using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BatteryPuzzle : MonoBehaviour, IPuzzle
{
    public bool IsCompleted { get; private set; }
    public event System.Action OnPuzzleCompleted;

    [Header("UI")]
    public Image batteryFill;     
    public TextMeshProUGUI percentageText;

    [Header("Values")]
    public int battery = 0;

    private void Start()
    {
        UpdateUI();
    }

    public void Add30()
    {
        if (IsCompleted) return;
        ModifyBattery(30);
    }

    public void Add20()
    {
        if (IsCompleted) return;
        ModifyBattery(20);
    }

    public void Sub10()
    {
        if (IsCompleted) return;
        ModifyBattery(-10);
    }

    private void ModifyBattery(int amount)
    {
        battery += amount;

        // dépassement = RESET
        if (battery > 100 || battery < 0)
        {
            Debug.Log("❌ Dépassement ! RESET puzzle.");
            battery = 0;
            UpdateUI();
            return;
        }

        UpdateUI();

       
        if (battery == 100)
        {
            gameObject.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            CompletePuzzle();
        }
    }

    private void UpdateUI()
    {
        if (batteryFill != null)
            batteryFill.fillAmount = battery / 100f;

        if (percentageText != null)
            percentageText.text = battery + "%";
    }

    private void CompletePuzzle()
    {
        IsCompleted = true;
        Debug.Log("🔋✔ Batterie chargée à 100% — Puzzle Complété !");
        OnPuzzleCompleted?.Invoke();

        // Option : désactiver l'UI
        gameObject.SetActive(false);
    }
}