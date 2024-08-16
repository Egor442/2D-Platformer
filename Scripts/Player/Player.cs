using UnityEngine;

[RequireComponent(typeof(PlayerMover))]
[RequireComponent(typeof(PlayerDeseader))]
[RequireComponent(typeof(PlayerFinisher))]
public class Player : MonoBehaviour
{
    [SerializeField] private GoldDisplay _goldDisplay;

    private PlayerMover _mover;
    private PlayerDeseader _deseader;
    private PlayerFinisher _finisher;

    private int _golds;

    public int Golds => _golds;

    public void Initialize()
    {
        _mover = GetComponent<PlayerMover>();
        _mover.Initialize();

        _deseader = GetComponent<PlayerDeseader>();
        _finisher = GetComponent<PlayerFinisher>();
    }

    private void Update()
    {
        _mover.TryMove();

        if (Input.GetKeyDown(KeyCode.Space) && _mover.IsGrounded)
        {
            _mover.Jump();
        }
    }

    public void PickUpGold()
    {
        _golds++;
        _goldDisplay.PickUp(_golds);
    }

    public void Die()
    {
        _deseader.Die();
    }

    public void Finish()
    {
        _finisher.Finish();
    }
}