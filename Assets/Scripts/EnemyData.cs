using UnityEngine;

[CreateAssetMenu(fileName = "NewEnemyData", menuName = "Zombest/Enemy Data")]
public class EnemyData : ScriptableObject
{
    public float speed = 3f;
    public float health = 3f;
    public float damage = 1f;
    public int score = 1;
}