using UnityEngine;
using UnityEngine.UI;

public class Cube : MonoBehaviour, IPuzzle
{
    public bool IsCompleted { get; private set; }
    public event System.Action OnPuzzleCompleted;

    public Color redColor = Color.red;
    public Color yellowColor = Color.yellow;
    public Color greenColor = Color.green;

    public float switchSpeed = 1f;
    public GameObject cubePrefab;
    private Image img;
    private int colorIndex = 0; // 0=rouge, 1=jaune, 2=vert

    private void Start()
    {
        img = GetComponent<Image>();
        InvokeRepeating(nameof(SwitchColor), 0f, switchSpeed);

        // Connecter le click du button
        GetComponent<Button>().onClick.AddListener(OnClick);
    }

    private void SwitchColor()
    {
        if (IsCompleted) return;

        colorIndex = (colorIndex + 1) % 3;

        if (colorIndex == 0) img.color = redColor;
        if (colorIndex == 1) img.color = yellowColor;
        if (colorIndex == 2) img.color = greenColor;
    }

    private void OnClick()
    {
        if (IsCompleted) return;
        
        if (colorIndex == 2)
        {
            CompletePuzzle();
            cubePrefab.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

    private void CompletePuzzle()
    {
        IsCompleted = true;
        img.color = Color.cyan; // indique que c'est réussi

        Debug.Log("🎉 Puzzle UI terminé !");
        OnPuzzleCompleted?.Invoke();
    }
}