using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Code by Robert Rood, Originally made for use in Unity 2019.1, MIT License

[System.Serializable]
public class ObjectPool
{

    public GameObject pooledObject;
    public int poolSize = 10;
    public bool canResize = true;
    public PoolType poolType;
    public List<GameObject> pooledObjects;
    public string poolName; //optional, allows for pool to be referenced by name, first pool with matching name will be used
}


