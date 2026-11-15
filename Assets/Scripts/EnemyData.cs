using UnityEngine;

[CreateAssetMenu(fileName = "NewEnemyData", menuName = "Zombest/Enemy Data")]
public class EnemyData : ScriptableObject
{
    public float speed = 3f;
    public int health = 3;
    public int damage = 1;
    public int score = 1;
}