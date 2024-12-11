using UnityEngine;
using UnityEngine.InputSystem;

public class Gun : MonoBehaviour
{
    public float range = 100f;
    public float ammoMax = 10f;
    public float ammo = 10f;
    public Camera fpsCamera;
    private InputAction attackAction;

    private void Start()
    {
        attackAction = InputSystem.actions.FindAction("Attack");
    }
    private void Update()
    {
        if (attackAction.WasPressedThisFrame())
        {
            shoot();
        }
    }
    void shoot()
    {
        if (ammo > 0) 
        {
            RaycastHit hit;
            if (Physics.Raycast(fpsCamera.transform.position, fpsCamera.transform.forward, out hit))
            {
                Debug.Log($"hit {hit.collider.name}");
                Debug.DrawLine(fpsCamera.transform.position, hit.point, Color.red, 2f);

                TargetBehavior target = hit.collider.GetComponent<TargetBehavior>();
                if (target != null)
                {
                    target.TakeDamage(10);
                }
            }
        }
        else
        {
            reload();
        }
    }
    void reload()
    {
        if (ammo >= 1)
        {
            ammo = ammo - ammoMax;
        }
        else
        {
            ammo = 9;
        }
    }
}
