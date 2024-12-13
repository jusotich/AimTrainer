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
                if (target != null)
                {
                    target.TakeDamage(10);
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
            yield return new WaitForSeconds(2);
            ammo = ammoMax;
        }
        else
        {
            yield return new WaitForSeconds(3);
            ammo = 9;
        }
    }
}
