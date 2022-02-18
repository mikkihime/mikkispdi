using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    private Transform shooter;
    
    [field: SerializeField]
    private Projectile projectile;

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
        if (Input.GetButtonDown("Fire1"))
            Shoot();
    }

    void Shoot()
    {
        Vector2 shooterPosition = new Vector2(shooter.position.x, shooter.position.y);
        Instantiate(projectile, shooterPosition, quaternion.identity);
    }
}
