using NSubstitute;
using NUnit.Framework;

public class TrapTests
{
    [Test]
    public void PlayerEnteringTrap_PlayerTargetedTrap_ReduceHealthByOne()
    {
        Trap trap = new Trap();
        ICharacter player = Substitute.For<ICharacter>();
        player.IsPlayer.Returns(true);
        int damage = 1;

        trap.HandleCharacterEnter(player, TrapTargetType.Player, damage);

        Assert.AreEqual(player.FullHealth - damage, player.Health);
    }

    [Test]
    public void NpcEnteringTrap_NpcTargetedTrap_ReduceHealthByOne()
    {
        Trap trap = new Trap();
        ICharacter npc = Substitute.For<ICharacter>();
        int damage = 1;

        trap.HandleCharacterEnter(npc, TrapTargetType.Npc, damage);

        Assert.AreEqual(npc.FullHealth - damage, npc.Health);
    }

    [Test]
    public void EnemyEnteringTrap_EnemyTargetedTrap_HealsHealthByOne_WithoutCurrentDamage()
    {
        Trap trap = new Trap();
        ICharacter enemy = Substitute.For<ICharacter>();

        trap.HandleCharacterEnter(enemy, TrapTargetType.Enemy);
        enemy.FullHealth.Returns(10);
        enemy.Health.Returns(10);


        Assert.AreEqual(enemy.FullHealth, enemy.Health);
    }

    [Test]
    public void EnemyEnteringTrap_EnemyTargetedTrap_HealsHealthByOne_WithCurrentDamage()
    {
        Trap trap = new Trap();
        ICharacter enemy = Substitute.For<ICharacter>();

        enemy.FullHealth.Returns(10);
        enemy.Health.Returns(9);
        trap.HandleCharacterEnter(enemy, TrapTargetType.Enemy);

        Assert.AreEqual(enemy.FullHealth, enemy.Health);
    }
}