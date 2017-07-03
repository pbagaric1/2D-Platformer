using UnityEngine;

public class HealthBarBoss : MonoBehaviour
{
    public Boss Boss;
    public Transform ForegroundSprite;
    public SpriteRenderer ForeGroundRenderer;
    public Color MaxHealthColor = new Color(255 / 255f, 63 / 255f, 63 / 255f);
    public Color MinHealthColor = new Color(64 / 255f, 137 / 255f, 255 / 255f);

    public void Update()
    {
        var healthPercent = Boss.Health / (float)Boss.MaxHealth;

        ForegroundSprite.localScale = new Vector3(healthPercent, 1, 1);
        ForeGroundRenderer.color = Color.Lerp(MaxHealthColor, MinHealthColor, healthPercent);
    }
}

