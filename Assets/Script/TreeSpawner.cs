using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KpModules.ObjectPooling;

public class TreeSpawner : MonoBehaviour
{
    private Dictionary<Tree, DynamicPool<Tree>> treeDictionary;
    public Vector3 spawnPoint;
    public Tree[] treePrefabs;

    private void Awake()
    {
        treeDictionary = new Dictionary<Tree, DynamicPool<Tree>>();
        for (int i = 0; i < treePrefabs.Length; i++)
        {
            treeDictionary.Add(treePrefabs[i], new DynamicPool<Tree>(treePrefabs[i], Vector3.zero, 10, 100));
            treeDictionary[treePrefabs[i]].CreateObjects(10);
        }
    }

    public void StartSpawning()
    {
        StartCoroutine(SpawnTreeRoutine());
    }

    private IEnumerator SpawnTreeRoutine()
    {
        Tree tree;
        while (true)
        {
            Tree prefab = treePrefabs.Random();
            tree = treeDictionary[prefab].GetObject();
            tree.transform.position = spawnPoint;
            tree.gameObject.SetActive(true);
            yield return new WaitForSeconds(4);
        }
    }
}
