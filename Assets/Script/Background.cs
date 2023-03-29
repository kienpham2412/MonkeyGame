using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    public SpriteRenderer backgroundSprite;
    private Material backgroundMat;
    private Vector2 offset;
    public float speed;

    private void Awake() {
        backgroundMat = backgroundSprite.material;
    }

    private void Update()
    {
        offset.x += (speed * Time.deltaTime) * 0.1f;
        backgroundMat.mainTextureOffset = offset;
    }
}
