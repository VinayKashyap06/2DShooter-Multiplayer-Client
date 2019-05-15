using System;
using UnityEngine;
using Commons;

namespace BulletSystem
{
    public class BulletController: IPoolable
    {
        private BulletView bulletView;                  
        public void SpawnBullet( Vector3 position, float speed, BulletView bulletPrefab)
        {
            GameObject bulletObj = GameObject.Instantiate(bulletPrefab.gameObject, position, Quaternion.identity);
            bulletView=bulletObj.GetComponent<BulletView>();
            bulletView.SetSpeed(speed);
            
        }

        public void ResetItem()
        {
            GameObject.Destroy(bulletView.gameObject);
        }
    }
}
