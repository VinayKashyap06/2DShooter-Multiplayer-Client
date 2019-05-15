using System;
using System.Collections.Generic;
using Commons;
using ScriptableObjects;
using UnityEngine;

namespace BulletSystem
{
    public class BulletService : IBulletService
    {
        private ObjectPooling<BulletController> pool;
        private BulletView bulletPrefab;
        public BulletService(BulletScriptableObject bulletScriptableObject)
        {
           pool = new ObjectPooling<BulletController>();
           bulletPrefab = bulletScriptableObject.bulletView;
        }        

        public void SpawnBullet(Vector3 position, float speed)
        {
            BulletController bulletController = pool.Get<BulletController>();     
            bulletController.SpawnBullet(position, speed,bulletPrefab);

        }
    }
}
