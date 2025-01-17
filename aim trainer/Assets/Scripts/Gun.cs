using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class Gun : MonoBehaviour
{
    public float range = 100f;
    public float ammoMax = 10f;
    public float ammo = 10f;
    public Camera fpsCamera;
    private InputAction attackAction;
    public bool canShoot = true;
    public float reloadTime = 1f;

    private void Start()
    {
        attackAction = InputSystem.actions.FindAction("Attack");
    }
    private void Update()
    {
        if (canShoot)
        {
            if (attackAction.WasPressedThisFrame())
            {
                Shoot();
            }
            if (Input.GetKeyDown(KeyCode.R))
            {
                StartCoroutine(Reload());
            }
        }
    }
    void Shoot()
    {
        if (ammo > 0) 
        {
            ammo -= 1;
            RaycastHit hit;
            if (Physics.Raycast(fpsCamera.transform.position, fpsCamera.transform.forward, out hit))
            {
                Debug.Log($"hit {hit.collider.name}");
                Debug.DrawLine(fpsCamera.transform.position, hit.point, Color.red, 2f);

                TargetBehavior target = hit.collider.GetComponent<TargetBehavior>();
                CapsulEnemy capsulEnemy = hit.collider.GetComponent<CapsulEnemy>();

                
                if (target != null)
                {
                    target.TakeDamage(10); // Generic damage
                    return;
                }

                // Check for specific target types
                
                if (capsulEnemy != null)
                {
                    capsulEnemy.TakeDamage(10); // 
                    return;
                }
            }
        }
        else
        {
            StartCoroutine(Reload());
        }
    }
    private IEnumerator Reload()
    {
        if (ammo >= 1)
        {
            yield return new WaitForSeconds(reloadTime);
            ammo = ammoMax;
        }
        else
        {
            yield return new WaitForSeconds(reloadTime);
            ammo = 9;
        }
    }
}
