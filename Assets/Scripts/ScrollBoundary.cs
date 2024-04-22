using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScrollBoundary : MonoBehaviour
{
    //PUBLIC
    public Button lastButton;
    public GameObject boundary;
    public ScrollRect scrollRect;


    // Start is called before the first frame update

    void Start()
    {
        if (lastButton.GetComponent<RectTransform>().anchoredPosition.x == boundary.transform.position.x) {
            scrollRect.StopMovement();
        }
    }

    // Update is called once per frame
}
