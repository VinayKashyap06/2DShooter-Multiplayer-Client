using System;
using System.Collections.Generic;
using Commons;
using ScriptableObjects;
using UnityEngine;

namespace BulletSystem
{
    public class BulletService : IBulletService
    {
        private ObjectPooling<BulletView> pool;
        private BulletView bulletPrefab;
        public BulletService(BulletScriptableObject bulletScriptableObject)
        {
           pool = new ObjectPooling<BulletView>();
            bulletPrefab = bulletScriptableObject.bulletView;
        }
        public void SpawnBullet()
        {
            
        }
    }
}
