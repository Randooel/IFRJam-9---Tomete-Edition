using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public enum PoolType
{
    VFX,
    SFX,
}

public class ObjectPoolManager : MonoBehaviour
{
    private static GameObject emptyHolder;
    private static GameObject VFXEmpty;
    private static GameObject SFXEmpty;

    private static Dictionary<GameObject, ObjectPool<GameObject>> objectPools;
    private static Dictionary<GameObject, GameObject> cloneToPrefabMap;

    public static PoolType PoolingType;

    private void Awake()
    {
        objectPools = new Dictionary<GameObject, ObjectPool<GameObject>>();
        cloneToPrefabMap = new Dictionary<GameObject, GameObject>();

        SetupEmpties();
    }

    private void SetupEmpties()
    {
        emptyHolder = new GameObject("Object Pools");
        VFXEmpty = new GameObject("VFXs");
        VFXEmpty.transform.SetParent(emptyHolder.transform);

        SFXEmpty = new GameObject("SFXs");
        SFXEmpty.transform.SetParent(emptyHolder.transform);
    }

    private static void CreatePool(GameObject prefab, Vector3 position, Quaternion rotation, PoolType poolType)
    {
        ObjectPool<GameObject> pool = new ObjectPool<GameObject>(
         createFunc: () => CreateObject(prefab, position, rotation, poolType),
         actionOnGet: OnGetObject,
         actionOnRelease: OnReleaseObject,
         actionOnDestroy: OnDestroyObject);

        objectPools.Add(prefab, pool);
    }

    private static GameObject CreateObject(GameObject prefab, Vector3 position, Quaternion rotation, PoolType poolType)
    {
        prefab.SetActive(false);
        GameObject gameObject = Instantiate(prefab, position, rotation);
        prefab.SetActive(true);

        GameObject parentObject = SetParentObject(poolType);
        gameObject.transform.SetParent(parentObject.transform);

        return gameObject;
    }

    private static GameObject SetParentObject(PoolType poolType)
    {
        switch (poolType)
        {
            case PoolType.VFX:
                {
                    return VFXEmpty;
                }

            case PoolType.SFX:
                {
                    return SFXEmpty;
                }

            default:
                return null;
        }
    }

    private static void OnGetObject(GameObject gameObject)
    {

    }

    private static void OnReleaseObject(GameObject gameObject)
    {
        gameObject.SetActive(false);
    }

    private static void OnDestroyObject(GameObject gameObject)
    {
        if (cloneToPrefabMap.ContainsKey(gameObject))
        {
            cloneToPrefabMap.Remove(gameObject);
        }
    }

    private static T SpawnObject<T>(GameObject gameObject, Vector3 position, Quaternion rotation, PoolType poolType) where T : UnityEngine.Object
    {
        if (!objectPools.ContainsKey(gameObject))
        {
            CreatePool(gameObject, position, rotation, poolType);
        }

        GameObject obj = objectPools[gameObject].Get();

        if (obj != null)
        {
            if (!cloneToPrefabMap.ContainsKey(obj))
            {
                cloneToPrefabMap.Add(obj, gameObject);
            }

            obj.transform.position = position;
            obj.transform.rotation = rotation;
            obj.SetActive(true);

            if (typeof(T) == typeof(GameObject))
            {
                return obj as T;
            }

            T component = obj.GetComponent<T>();

            if (component == null)
            {
                Debug.LogWarning($"Object {gameObject.name} doesn't have component of type {typeof(T)}");
                return null;
            }

            return component;
        }

        return null;
    }

    public static T SpawnObject<T>(T typeOfPrefab, Vector3 position, Quaternion rotation, PoolType poolType) where T : Component
    {
        return SpawnObject<T>(typeOfPrefab.gameObject, position, rotation, poolType);
    }

    public static GameObject SpawnObject(GameObject gameObject, Vector3 position, Quaternion rotation, PoolType poolType)
    {
        return SpawnObject<GameObject>(gameObject, position, rotation, poolType);
    }

    public static void ReturnObjectToPool(GameObject obj, PoolType poolType)
    {
        if (cloneToPrefabMap.TryGetValue(obj, out GameObject prefab))
        {
            GameObject parentObject = SetParentObject(poolType);

            if (obj.transform.parent != parentObject.transform)
            {
                obj.transform.SetParent(parentObject.transform);
            }

            if (objectPools.TryGetValue(prefab, out ObjectPool<GameObject> pool))
            {
                pool.Release(obj);
            }

            else Debug.LogWarning("Trying to return that is not pooled " + obj.name);
        }
    }
}
