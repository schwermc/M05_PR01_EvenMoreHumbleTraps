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

        Assert.AreEqual(-damage, player.Health);
    }

    [Test]
    public void NpcEnteringTrap_NpcTargetedTrap_ReduceHealthByOne()
    {
        Trap trap = new Trap();
        ICharacter player = Substitute.For<ICharacter>();
        int damage = 1;

        trap.HandleCharacterEnter(player, TrapTargetType.Npc, damage);

        Assert.AreEqual(-damage, player.Health);
    }
}