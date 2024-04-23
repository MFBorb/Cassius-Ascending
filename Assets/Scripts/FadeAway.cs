using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeAway : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;

    void Update() {
        float tempColor = spriteRenderer.color.a - 10 * Time.deltaTime;

        if (tempColor <= 0) {
            Destroy(gameObject.transform.parent.gameObject);
        }
        else {
            spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, tempColor);
        }


    }
}
