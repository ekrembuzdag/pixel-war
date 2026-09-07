using Unity.GraphToolkit.Editor;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{
    public GameObject fireballPrefab;
    public Transform firePoint;
    public float spawnDistance = 0.8f;
    public float spawnHeight = 1.5f;
    public float attackCooldown = 0.3f;

    private float facingDirection = 1f;
    private float nextAttackTime;

    void Update()
    {
        if (Keyboard.current == null)
            return;

        if (Keyboard.current.aKey.isPressed ||
            Keyboard.current.leftArrowKey.isPressed)
        {
            facingDirection = -1f;
        }
        else if (Keyboard.current.dKey.isPressed ||
                 Keyboard.current.rightArrowKey.isPressed)
        {
            facingDirection = 1f;
        }

        if (Keyboard.current.fKey.wasPressedThisFrame &&
            Time.time >= nextAttackTime)
        {
            Animator animator = transform.Find("ignisvisual").GetComponent<Animator>();
            animator.SetTrigger("attack");
            Invoke(nameof(Shoot), 0.42f);
        }
    }

    void Shoot()
    {
        Transform ignisVisual = transform.Find("ignisvisual");

        Vector3 facingDirection =
            ignisVisual.localScale.x < 0 ? Vector3.left : Vector3.right;
        Vector3 spawnPosition = firePoint.position;
        GameObject newFireball = Instantiate(
            fireballPrefab,
            spawnPosition,
            Quaternion.identity
        );

        fireball fireball = newFireball.GetComponent<fireball>();

        if (fireball != null)
        {
            fireball.Launch(facingDirection);
        }

        nextAttackTime = Time.time + attackCooldown;
    }
}