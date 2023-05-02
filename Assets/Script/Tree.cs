using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
#if UNITY_EDITOR
using UnityEditor;
using UnityEditor.SceneManagement;
#endif

public class Tree : MonoBehaviour, IPointerClickHandler
{
    public GameObject fruitPrefab;
    public GameObject treeSegmentPrefab;
    public GameObject fruitInstance;
    public Animator fruitAnimator;
    public BoxCollider treeCollider;
    public float speed;
    public int treeHeight;
    public int fruitPosition;
    public GameObject[] treeSegments;

#if UNITY_EDITOR
    public void BuildTree()
    {
        treeSegments = new GameObject[treeHeight];
        for (int i = 0; i < treeHeight; i++)
        {
            if (i == fruitPosition)
            {
                fruitInstance = Instantiate(fruitPrefab, transform);
                fruitInstance.transform.localPosition = new Vector3(0, i, 0);
                treeSegments[i] = fruitInstance.gameObject;
            }
            else
            {
                GameObject segment = Instantiate(treeSegmentPrefab, transform);
                segment.transform.localPosition = new Vector3(0, i, 0);
                treeSegments[i] = segment;
            }
        }

        fruitAnimator = fruitInstance.transform.GetComponentInChildren<Animator>();
        treeCollider.size = new Vector3(1, treeHeight, 1);
        treeCollider.center = new Vector3(0, treeHeight * 0.5f, 0);

        // PrefabUtility.ApplyPrefabInstance(gameObject, InteractionMode.UserAction);
    }

    public void Clear()
    {
        for (int i = transform.childCount - 1; i >= 0; i--)
            DestroyImmediate(transform.GetChild(i).gameObject);
    }
#endif

    private void Awake()
    {
        fruitAnimator.keepAnimatorStateOnDisable = false;
    }

    private void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);
    }

    private void DropFruit()
    {
        fruitAnimator.Play("Fruit");
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        DropFruit();
    }

    private void OnMouseDown()
    {
        DropFruit();
    }

    private void OnEnable()
    {
        fruitAnimator.gameObject.SetActive(true);
    }
}
