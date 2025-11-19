using UnityEngine;

public class TrapBehaviour : MonoBehaviour
{
    private Trap trap;

    [SerializeField] TrapTargetType trapType;
    [SerializeField] int damage = 1;

    void Awake()
    {
        trap = new Trap();
    }

    void OnTriggerEnter(Collider collider)
    {
        var player = collider.GetComponent<ICharacter>();
        trap.HandleCharacterEnter(player, trapType, damage);
    }
}


public class Trap
{
    public void HandleCharacterEnter(ICharacter player, TrapTargetType trapTargetType, int damage = 1)
    {
        if (player.IsPlayer)
        {
            if (trapTargetType == TrapTargetType.Player)
                player.Health -= damage;
        }
        else
        {
            if (trapTargetType == TrapTargetType.Npc)
                player.Health -= damage;
        }
    }
}

public enum TrapTargetType { Player, Npc }