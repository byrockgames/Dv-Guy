using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Spawn
{
 public class CollisionSpawnController : MonoBehaviour
 {
    [Header("SpawnControllerScript")]
    private SpawnController SpawnController;

    [Header("SpawnObjectsQue")]
    public Queue<GameObject> Sausages = new Queue<GameObject>();
    
    public List<GameObject> SausageObjects = new List<GameObject>();

    private void Start()
    {
      SpawnController = GameObject.Find("SpawnController").GetComponent<SpawnController>();
    }
    private void OnCollisionEnter(Collision other) 
    {
      if(other.gameObject.CompareTag("Sausage"))
      {
        for(int i = 0; i< SausageObjects.Count; i++)
        {
          SausageObjects[i].SetActive(false);
        }

        var Sausage = SpawnController.GetPoolObject(0);
        Sausages.Enqueue(Sausage);

      }
    }
 }
}