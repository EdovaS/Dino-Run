using System;
using System.Collections.Generic;
using UnityEngine;

namespace DinoRunGame.ObjectPooling
{
    [Serializable]
    public enum PoolType {smallObstacle1, smallObstacle2, smallObstacle3, largeObstacle1, largeObstacle2, largeObstacle3, FlyingObstacle}

    [Serializable]
    public class ObjectPool
    {
        public PoolType PoolType;
        public GameObject PrefabObject;
        public Queue<GameObject> objectQueue;
    }
    
    public class ObjectPooler : MonoBehaviour
    {
        public ObjectPool[] ObjectPools;

        private void Start()
        {
            foreach (ObjectPool objectPool in ObjectPools)
            {
                objectPool.objectQueue = new Queue<GameObject>();
            }
        }

        public void AddToPool(PoolType poolType, GameObject item)
        {
            item.SetActive(false);
            FindByPoolType(poolType).objectQueue.Enqueue(item);
        }

        public GameObject GetFromPool(PoolType poolType)
        {
            ObjectPool objectPool = FindByPoolType(poolType);
            if (objectPool.objectQueue.Count > 0) return objectPool.objectQueue.Dequeue();
            else{ return Instantiate(objectPool.PrefabObject);}
            
        }

        private ObjectPool FindByPoolType(PoolType poolType)
        {
            ObjectPool result = null;
            foreach (var objectPool in ObjectPools)
            {
                if (objectPool.PoolType == poolType)
                {
                    result = objectPool;
                }
            }
            return result;
        }
    }
}
