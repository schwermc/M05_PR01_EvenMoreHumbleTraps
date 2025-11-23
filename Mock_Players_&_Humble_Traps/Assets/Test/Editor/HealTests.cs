using NSubstitute;
using NUnit.Framework;

public class HealTests
{
    [Test]
    public void PlayerEnteringHeal_PlayerTargetedHeal_WithHealAmount()
    {
        Heal heal = new Heal();
        ICharacter player = Substitute.For<ICharacter>();
        player.IsPlayer.Returns(true);
        int healAmount = 1;

        player.FullHealth.Returns(healAmount);
        heal.HandleCharacterEnter(player, TrapTargetType.Player, healAmount);

        Assert.AreEqual(player.FullHealth, player.Health);
    }

    [Test]
    public void PlayerEnteringHeal_PlayerTargetedHeal_WithoutHealAmount()
    {
        Heal heal = new Heal();
        ICharacter player = Substitute.For<ICharacter>();
        player.IsPlayer.Returns(true);

        player.FullHealth.Returns(3);
        heal.HandleCharacterEnter(player, TrapTargetType.Player);

        Assert.AreEqual(player.FullHealth, player.Health);
    }

    [Test]
    public void NpcEnteringHeal_NpcTargetedHeal_WithHealAmount()
    {
        Heal heal = new Heal();
        ICharacter npc = Substitute.For<ICharacter>();
        int healAmount = 1;

        npc.FullHealth.Returns(healAmount);
        heal.HandleCharacterEnter(npc, TrapTargetType.Npc, healAmount);

        Assert.AreEqual(npc.FullHealth, npc.Health);
    }

    [Test]
    public void NpcEnteringHeal_NpcTargetedHeal_WithoutHealAmount()
    {
        Heal heal = new Heal();
        ICharacter npc = Substitute.For<ICharacter>();

        npc.FullHealth.Returns(2);
        npc.Health.Returns(1);
        heal.HandleCharacterEnter(npc, TrapTargetType.Npc);

        Assert.AreEqual(npc.FullHealth, npc.Health);
    }

    [Test]
    public void EnemyEnteringHeal_EnemyTargetedHeal_WithHealAmount()
    {
        Heal heal = new Heal();
        ICharacter enemy = Substitute.For<ICharacter>();
        int healAmount = 1;

        enemy.FullHealth.Returns(healAmount);
        heal.HandleCharacterEnter(enemy, TrapTargetType.Enemy, healAmount);

        Assert.AreNotEqual(enemy.FullHealth, enemy.Health);
    }

    [Test]
    public void EnemyEnteringHeal_EnemyTargetedHeal_WithoutHealAmount()
    {
        Heal heal = new Heal();
        ICharacter enemy = Substitute.For<ICharacter>();

        enemy.FullHealth.Returns(2);
        enemy.Health.Returns(1);
        heal.HandleCharacterEnter(enemy, TrapTargetType.Enemy);

        Assert.AreNotEqual(enemy.FullHealth, enemy.Health);
    }
}
