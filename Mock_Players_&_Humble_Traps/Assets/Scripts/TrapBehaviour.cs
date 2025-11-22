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