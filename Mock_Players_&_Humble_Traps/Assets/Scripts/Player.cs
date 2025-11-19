using UnityEngine;

public class Character : MonoBehaviour, ICharacter
{
    public int Health { get; set; }
    public bool IsPlayer => isPlayer;

    private CharacterController characterController;

    [SerializeField] bool isPlayer;
    [SerializeField] float speed = .5f;

    void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        characterController.Move(new Vector3(horizontal, 0, vertical) * speed);
    }
}
