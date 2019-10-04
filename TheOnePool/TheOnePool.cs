using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//"One Pool to rule them all, One pool to find them,
//One Pool to bring them all and in the inspector bind them"
//							-inspired by The One Ring Poem, j.R.R.Tolkin 

//Code by Robert Rood, Originally made for use in Unity 2019.1, MIT License

[DisallowMultipleComponent]
public class TheOnePool : MonoBehaviour
{
    //Long term references
    public static TheOnePool instance; // allow for the OnePool to be accessed in script without a reference;
    [SerializeField] ObjectPool[] objectPools = new ObjectPool[1]; //default to at least one pool when attaching monobehavior 

    // Initialize

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        OpenThePool();
    }


    private void OpenThePool()
    {
        for (int j = 0; j < objectPools.Length; j++)
        {
            objectPools[j].pooledObjects = new List<GameObject>();

            for (int i = 0; i < objectPools[j].poolSize; i++)
            {
                GameObject obj = (GameObject)Instantiate(objectPools[j].pooledObject);
                obj.SetActive(false);
                objectPools[j].pooledObjects.Add(obj);
            }
        }
    }

    //Intervals
    //get object
    public GameObject GetObjectOutOfPool(int pool)
    {
        //if its a pooled partical system, just grab the first one and make it play
        if (objectPools[pool].poolType.Equals(PoolType.ParticleSystem))
        {
            objectPools[pool].pooledObjects[0].SetActive(true);
            objectPools[pool].pooledObjects[0].GetComponent<ParticleSystem>().Play();
            return objectPools[pool].pooledObjects[0];
        }

        for (int i = 0; i < objectPools[pool].pooledObjects.Count; i++)
        {
            if (!objectPools[pool].pooledObjects[i].activeInHierarchy)
            {
                objectPools[pool].pooledObjects[i].SetActive(true);
                return objectPools[pool].pooledObjects[i];
            }
        }

        if (objectPools[pool].canResize)
        {
            GameObject obj = (GameObject)Instantiate(objectPools[pool].pooledObject);
            objectPools[pool].pooledObjects.Add(obj);
            objectPools[pool].poolSize++;
            return obj;
        }

        return null;
    }
    //get object and set its tranform
    public GameObject GetObjectOutOfPool(int pool, Vector3 pos, Quaternion rot)
    {

        //if its a pooled partical system, just grab the first one and make it play
        if (objectPools[pool].poolType.Equals(PoolType.ParticleSystem))
        {
            GameObject obj = objectPools[pool].pooledObjects[0];
            obj.transform.position = pos;
            obj.transform.rotation = rot;
            obj.SetActive(true);
            obj.GetComponent<ParticleSystem>().Play();
            return obj;
        }

        for (int i = 0; i < objectPools[pool].pooledObjects.Count; i++)
        {
            if (!objectPools[pool].pooledObjects[i].activeInHierarchy)
            {
                GameObject obj = objectPools[pool].pooledObjects[i];
                obj.transform.position = pos;
                obj.transform.rotation = rot;
                obj.SetActive(true);
                return obj;
            }
        }
        if (objectPools[pool].canResize)
        {
            GameObject obj = Instantiate(objectPools[pool].pooledObject, pos, rot);
            objectPools[pool].pooledObjects.Add(obj);
            objectPools[pool].poolSize++;
            return obj;
        }
        return null;
    }

    //get object by pool name and set its transform
    public GameObject GetObjectOutOfPool(string poolName, Vector3 pos, Quaternion rot)
    {
        int pool = 0;
        for (int p = 0; p < objectPools.Length; p++)
        {
            if (objectPools[p].poolName.Equals(poolName))
            {
                pool = p;
                break;
            }
        }
        //if its a pooled partical system, just grab the first one and make it play
        if (objectPools[pool].poolType.Equals(PoolType.ParticleSystem))
        {
            GameObject obj = objectPools[pool].pooledObjects[0];
            obj.transform.position = pos;
            obj.transform.rotation = rot;
            obj.SetActive(true);
            obj.GetComponent<ParticleSystem>().Play();
            return obj;
        }

        for (int i = 0; i < objectPools[pool].pooledObjects.Count; i++)
        {
            if (!objectPools[pool].pooledObjects[i].activeInHierarchy)
            {
                GameObject obj = objectPools[pool].pooledObjects[i];
                obj.transform.position = pos;
                obj.transform.rotation = rot;
                obj.SetActive(true);
                return obj;
            }
        }
        if (objectPools[pool].canResize)
        {
            GameObject obj = Instantiate(objectPools[pool].pooledObject, pos, rot);
            objectPools[pool].pooledObjects.Add(obj);
            objectPools[pool].poolSize++;
            //if its a pooled partical system make it play
            if (objectPools[pool].poolType.Equals(PoolType.ParticleSystem))
            {
                obj.GetComponent<ParticleSystem>().Play();
            }
            return obj;
        }
        return null;
    }
}

 
