using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KpModules.ObjectPooling;

public class TreeSpawner : MonoBehaviour
{
    public Tree treePrefab;
    public DynamicPool<Tree> treePool;
    public Vector3 spawnPoint;

    private void Awake()
    {
        treePool = new DynamicPool<Tree>(treePrefab, Vector3.zero, 10, 100);
        treePool.CreateObjects(10);
    }

    private void Start() {
        StartCoroutine(SpawnTreeRoutine());
    }

    private IEnumerator SpawnTreeRoutine()
    {
        Tree tree;
        while (true)
        {
            tree = treePool.GetObject();
            tree.transform.position = spawnPoint;
            tree.gameObject.SetActive(true);
            yield return new WaitForSeconds(4);
        }
    }
}
