using UnityEngine;

public class OxygenSystem : MonoBehaviour
{
    public static OxygenSystem Instance;

    [Range(0, 100)]
    public float oxygen = 100f;

    public bool oxygenDepleting = false;
    public bool oxygenFix = false;
    public float depletionSpeed = 2f; // baisse par seconde

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        if (oxygenDepleting)
        {
            oxygen -= depletionSpeed * Time.deltaTime;

            if (oxygen <= 0)
            {
                oxygen = 0;
                Debug.Log("GAME OVER : manque d'oxygène !");
            }
        }
        if (oxygenFix)
        {
            oxygen += depletionSpeed * Time.deltaTime;

            if (oxygen >= 100)
            {
                oxygen = 100;
                Debug.Log("️ ✔ Oxygène réparé !");
                if (oxygen == 100)
                    oxygenFix = false;
            }
        }
    }

    public void StartLeak()
    {
        oxygenFix = false;
        oxygenDepleting = true;
        Debug.Log("⚠️ L'OXYGÈNE BAISSE !");
    }

    public void FixLeak()
    {
        oxygenDepleting = false;
        oxygenFix = true;
    }
}