public interface ICharacter
{
    int Health { get; set; }
    int FullHealth { get; set; }
    bool IsAlive { get; set; }
    bool IsPlayer { get; }

    void HealthCheck();
}
