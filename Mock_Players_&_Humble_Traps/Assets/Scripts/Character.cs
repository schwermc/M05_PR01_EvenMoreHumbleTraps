using UnityEngine;

public class Character : MonoBehaviour, ICharacter
{
    public TrapTargetType trapType { get; set; }
    public int Health { get; set; }
    public int FullHealth { get; set; }
    public bool IsAlive { get; set; }
    public bool IsPlayer => isPlayer;

    private CharacterController characterController;

    [SerializeField] bool isPlayer;
    [SerializeField] TrapTargetType characterTag;
    [SerializeField] float speed = .5f;

    public Character(int health = 10)
    {
        FullHealth = health;
        Health = health;
        IsAlive = true;
    }

    void Awake()
    {
        characterController = GetComponent<CharacterController>();
        trapType = characterTag;
    }

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        characterController.Move(new Vector3(horizontal, 0, vertical) * speed);
    }

    public void HealthCheck()
    {
        if (Health == 0)
        {
            if (trapType == TrapTargetType.Npc)
                IsAlive = false;
            if (trapType == TrapTargetType.Player)
                Health = FullHealth / 2;
            return;
        }
        
        if (Health > FullHealth)
        {
            Health = FullHealth;
            return;
        }
    }
}
