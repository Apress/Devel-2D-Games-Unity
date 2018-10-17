using UnityEngine;

public abstract class Character : MonoBehaviour {

    public HitPoints hitPoints;

    public float startingHitPoints;
    public float maxHitPoints;

    public enum CharacterCategory
    {
        PLAYER,
        ENEMY
    }

    public CharacterCategory characterCategory;
}
