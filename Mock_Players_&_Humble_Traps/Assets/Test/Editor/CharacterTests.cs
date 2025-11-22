using NSubstitute;
using NUnit.Framework;

public class CharacterTests
{
    [Test]
    public void EnemyHealthCheck_DoesHealthGoOverFullHealth()
    {
        
    }

    [Test]
    public void EnemyHealthCheck_IsEnemyDead()
    {
        ICharacter enemy = Substitute.For<ICharacter>();

        Assert.AreEqual(false, enemy.IsAlive);
    }
}
