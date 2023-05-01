using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Tree : MonoBehaviour, IPointerClickHandler
{
    public Animator fruitAnimator;
    public float speed;

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
