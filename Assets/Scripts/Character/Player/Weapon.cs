using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QxFramework.Core;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;//��ȡ�����ʼ��λ��

    void Update() {
        if (Input.GetKeyDown(KeyCode.J)) {
            Shoot();
        }
    }
    void Shoot() {
        ResourceManager.Instance.Instantiate("Prefabs/Bullet", firePoint);
    }
}

