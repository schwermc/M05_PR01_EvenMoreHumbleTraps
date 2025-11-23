using UnityEngine;

public class Enemy : MonoBehaviour, ICharacter
{
    public TrapTargetType trapType { get; set; }
    public int Health { get; set; }
    public int FullHealth { get; set; }
    public bool IsAlive { get; set; }
    public bool IsPlayer => isPlayer;

    [SerializeField] bool isPlayer;

    public Enemy(int health = 25)
    {
        FullHealth = health;
        Health = health;
        IsAlive = true;
        trapType = TrapTargetType.Enemy;
    }

    public void HealthCheck()
    {
        if (Health == 0)
        {
            IsAlive = false;
            return;
        }
        
        if (Health > FullHealth)
        {
            Health = FullHealth;
            return;
        }
    }
}
