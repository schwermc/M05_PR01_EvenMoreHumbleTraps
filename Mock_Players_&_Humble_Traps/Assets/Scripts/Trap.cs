public class Trap
{
    public void HandleCharacterEnter(ICharacter player, TrapTargetType trapTargetType, int damage = 1)
    {
        if (player.IsPlayer)
        {
            if (trapTargetType == TrapTargetType.Player)
                player.Health -= damage;
            
            player.HealthCheck();
            return;
        }

        if (!player.IsPlayer)
        {
            if (trapTargetType == TrapTargetType.Npc)
                player.Health -= damage;
            if (trapTargetType == TrapTargetType.Enemy)
                player.Health += damage;

            player.HealthCheck();
            return;
        }
    }
}

public enum TrapTargetType { Player, Npc, Enemy }