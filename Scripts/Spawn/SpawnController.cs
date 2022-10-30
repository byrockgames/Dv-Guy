using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Spawn
{
 public class SpawnController : MonoBehaviour
 {
  [Serializable]
  public struct ObjectPooling
  {
    public Queue<GameObject> Objects;
    public GameObject SpawnObject;
    public int SpawnObjectSize;

  }

  [Header("Pools")]
  [SerializeField] public ObjectPooling[] Pools;

  [Header("SpwanPivot")]
  [SerializeField] private Transform SpawnPivot;

  private void Awake()
  {
    for(int i = 0; i < Pools.Length; i++)
    {
      Pools[i].Objects = new Queue<GameObject>();

      for(int j = 0; j < Pools[i].SpawnObjectSize; j++)
      {
         GameObject temp = Instantiate(Pools[i].SpawnObject, SpawnPivot);
         temp.transform.position = new Vector3(SpawnPivot.position.x,((float)Pools.Length),SpawnPivot.position.z);
         temp.SetActive(false);
         Pools[i].Objects.Enqueue(temp);
      }
    }
    
  }
  public GameObject GetPoolObject(int ObjectType)
  {
    if(ObjectType >= Pools.Length) return null;
    if(Pools[ObjectType].Objects.Count == 0)
      AddSizePool(amount:5f, ObjectType);
    GameObject temp = Pools[ObjectType].Objects.Dequeue();
    temp.SetActive(true);
    return(temp);
  }

  public void SetPoolObject(GameObject PooledObjects, int ObjectType)
  {
    if(ObjectType >= Pools.Length) return;
    Pools[ObjectType].Objects.Enqueue(PooledObjects);
    PooledObjects.SetActive(false);
  }

  public void AddSizePool(float amount, int ObjectType)
  {
    for(int i = 0; i < amount; i++)
    {
       GameObject temp = Instantiate(Pools[ObjectType].SpawnObject);
       temp.SetActive(false);
       Pools[ObjectType].Objects.Enqueue(temp);
    }
  }
 }
}