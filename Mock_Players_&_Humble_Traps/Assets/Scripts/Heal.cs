public class Heal : ITrap
{
    public void HandleCharacterEnter(ICharacter player, TrapTargetType trapTargetType, int heal = 0)
    {
        if (player.IsPlayer)
        {
            if (trapTargetType == TrapTargetType.Player)
                player.Health += IncomingHealNotZero(heal, player.FullHealth);
            
            player.HealthCheck();
            return;
        }

        if (!player.IsPlayer)
        {
            if (trapTargetType == TrapTargetType.Npc)
                player.Health += IncomingHealNotZero(heal, player.FullHealth, 2);
            if (trapTargetType == TrapTargetType.Enemy)
                player.Health -= IncomingHealNotZero(heal, player.FullHealth, 3);

            player.HealthCheck();
            return;
        }
    }

    int IncomingHealNotZero(int heal, int health, int newHeal = 1)
    {
        if (heal != 0)
            return heal;

        return health / newHeal;
    }
}
