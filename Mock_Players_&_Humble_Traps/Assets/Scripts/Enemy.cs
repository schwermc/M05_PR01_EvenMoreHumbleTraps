using UnityEngine;

public class Enemy : MonoBehaviour, ICharacter
{
    public int Health { get; set; }
    public int FullHealth { get; set; }
    public bool IsAlive { get; set; }
    public bool IsPlayer => isPlayer;

    [SerializeField] bool isPlayer;
    [SerializeField] Material material;

    public Enemy(int health = 25)
    {
        FullHealth = health;
        Health = health;
        IsAlive = true;
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
