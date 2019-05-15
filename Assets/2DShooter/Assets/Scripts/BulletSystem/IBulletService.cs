using System;
using System.Collections.Generic;
using UnityEngine;

namespace BulletSystem
{
    public interface IBulletService
    {
        void SpawnBullet(Vector3 position, float speed);
    }
}
