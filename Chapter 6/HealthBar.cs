using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public HitPoints hitPoints;

    [HideInInspector]
    public Character character;

    public Image meterImage;

    public Text hpText;

    float maxHitPoints;

    void Start()
    {
        maxHitPoints = character.maxHitPoints;
    }

    void Update()
    {
        if (character != null)
        {
            meterImage.fillAmount = hitPoints.value / maxHitPoints;
            hpText.text = "HP:" + (meterImage.fillAmount * 100);
        }
    }
}
