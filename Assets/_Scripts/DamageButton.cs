using UnityEngine;
using UnityEngine.UI;

public class DamageButton : MonoBehaviour
{
    public HealthSystem healthSystem;
    public Button damageButton;

    private void Start()
    {
        if (damageButton != null && healthSystem != null)
        {
            damageButton.onClick.AddListener(() => healthSystem.TakeDamage(10));
        }
    }

    private void Update()
    {
        if(Input.GetKeyUp(KeyCode.C)) { healthSystem.TakeDamage(10); }
    }
}
