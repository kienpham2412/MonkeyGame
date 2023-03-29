using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KpModules.ObjectPooling
{
    public abstract class Pool<T> where T : Component
    {
        public abstract T GetObject();
        public abstract void CreateObjects(int amount);
        public abstract IEnumerable GetActiveObjects();
        public abstract IEnumerable GetInactiveObjects();
        public abstract IEnumerable GetAllObjects();
    }

    public class DynamicPool<T> : Pool<T> where T : Component
    {
        public DynamicPool(T prefab, Vector3 hidePosition, int appendNumbers, int poolCapacity = 4, Action<T> onEveryObjectCreated = null)
        {
            this.hidePosition = hidePosition;
            this.prefab = prefab;
            this.appendNumbers = appendNumbers;
            this.index = 0;
            if (onEveryObjectCreated != null) this.onEveryObjectCreated = onEveryObjectCreated;
            list = new List<T>(poolCapacity);
        }

        public DynamicPool(T prefab, Vector3 hidePosition, Transform parent, int appendNumbers, int poolCapacity = 4, Action<T> onEveryObjectCreated = null)
        {
            this.hidePosition = hidePosition;
            this.prefab = prefab;
            this.parent = parent;
            this.appendNumbers = appendNumbers;
            this.index = 0;
            if (onEveryObjectCreated != null) this.onEveryObjectCreated = onEveryObjectCreated;
            list = new List<T>(poolCapacity);
        }

        public Action<T> onEveryObjectCreated;
        private List<T> list;
        private Vector3 hidePosition;
        private T prefab;
        private int index = 0;
        public int appendNumbers = 1;
        private Transform parent;

        public override T GetObject()
        {
            if (list[index].gameObject.activeInHierarchy)
            {
                index = list.Count;
                CreateObjects(appendNumbers);
            }
            T result = list[index];
            index = (index + 1) % list.Count;
            return result;
        }

        public void RemoveObject(T obj)
        {
            if (list.Contains(obj)) list.Remove(obj);
        }

        public override void CreateObjects(int amount)
        {
            if (parent == null)
                for (int i = 0; i < amount; i++)
                {
                    T obj = GameObject.Instantiate(prefab, hidePosition, Quaternion.identity);
                    obj.gameObject.SetActive(false);
                    list.Add(obj);
                    if (onEveryObjectCreated != null) onEveryObjectCreated(obj);
                }
            else
                for (int i = 0; i < amount; i++)
                {
                    T obj = GameObject.Instantiate(prefab, parent);
                    obj.transform.localPosition = hidePosition;
                    obj.gameObject.SetActive(false);
                    list.Add(obj);
                    if (onEveryObjectCreated != null) onEveryObjectCreated(obj);
                }
        }

        public override IEnumerable GetActiveObjects()
        {
            foreach (T obj in list)
                if (obj.gameObject.activeInHierarchy) yield return obj;
        }

        public override IEnumerable GetInactiveObjects()
        {
            foreach (T obj in list)
                if (!obj.gameObject.activeInHierarchy) yield return obj;
        }

        public override IEnumerable GetAllObjects()
        {
            foreach (T obj in list)
                yield return obj;
        }
    }
}

