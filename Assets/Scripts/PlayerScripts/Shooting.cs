using System;
using System.Collections;
using System.Collections.Generic;
using PlayerScripts;
using SceneControllers;
using Unity.Mathematics;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    private enum ProjectileType
    {
        standard,
        bouncy
    }
    private Transform shooter;

    private bool cooldown = false;
    
    [field: SerializeField]
    private Projectile StandardProjectile;

    [field: SerializeField]
    private Projectile BouncyProjectile;

    [field: SerializeField]
    private PlayerController playerController;

    private void Awake()
    {
        // MUDEI POR SER OBSOLETO, PORÉM PODE TRAZER PROBLEMAS CASO MEXA NA HIERARQUIA DO PREFAB DE PLAYER
        //shooter = transform.FindChild("Shooter");
        shooter = transform.GetChild(1);

        if (shooter == null)
            Debug.LogError("Erro no Player, sem Shooter");
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1") && !cooldown && !Level01.gameIsPaused)
        {
            Shoot(ProjectileType.standard);
            StartCoroutine(ShootingCooldown());
        }
        
        if (Input.GetButtonDown("Fire2") && !cooldown && !Level01.gameIsPaused)
        {
            Shoot(ProjectileType.bouncy);
            StartCoroutine(ShootingCooldown());
        }
    }

    void Shoot(ProjectileType projectileType)
    {
        Vector2 shooterPosition = new Vector2(shooter.position.x, shooter.position.y);
        Instantiate(projectileType == ProjectileType.bouncy? BouncyProjectile : StandardProjectile, shooterPosition, quaternion.identity).SetDirection(playerController.facingRight);
    }

    IEnumerator ShootingCooldown()
    {
        cooldown = true;
        yield return new WaitForSeconds(.5f);
        cooldown = false;

    }
}
