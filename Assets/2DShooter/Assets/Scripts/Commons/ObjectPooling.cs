using System;
using System.Collections.Generic;
using UnityEngine;

namespace Commons
{
    public class ObjectPooling<T> where T : IPoolable, new()
    {
        private int upperLimit = 50;
        private List<IPoolable> objectPool = new List<IPoolable>();
        public void ObjectPoolStart()
        {
            
        }
        public T Get<T>() where T : IPoolable, new()
        {
            T _itemToReturn = default(T);
            foreach (T item in objectPool)
            {
                if (item is T)
                {
                    objectPool.Remove(item);
                    _itemToReturn = item;
                    break;
                }
            }
            if (_itemToReturn == null)
            {
                _itemToReturn = new T();
                objectPool.Add(_itemToReturn);
            }
            return _itemToReturn;


        }
        public void ReturnToPool(T obj)
        {
            // Debug.Log("Object returning in list :" + objectPool.Count);
            if (objectPool.Count >= upperLimit)
            {
                return;
            }
            objectPool.Add(obj);
        }
        public void OnGameEnd()
        {
            foreach (IPoolable item in objectPool)
            {
                item.ResetItem();
            }
        }
    }
}
