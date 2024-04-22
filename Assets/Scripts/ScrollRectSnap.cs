using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollRectSnap : MonoBehaviour
{
    // PUBLIC
    public RectTransform panel;
    public Button[] button;
    public RectTransform center;

    // PRIVATE
    private float[] distance;
    private float[] distReposition;
    private bool dragging = false;
    private int buttonDist;
    private int minButtonNum;
    private int buttonLength;
    
    void Start()
    {
        int buttonLength = button.Length;
        distance = new float[buttonLength];
        distReposition = new float[buttonLength];

        /**b1 = button[1].GetComponent<RectTransform>();
        b0 = button[0].GetComponent<RectTransform>();**/
        buttonDist = (int)Mathf.Abs(button[1].GetComponent<RectTransform>().anchoredPosition.x - button[0].GetComponent<RectTransform>().anchoredPosition.x);
    }

    void Update()
    {
        for (int i = 0; i < button.Length; i++) {
            distReposition[i] = center.GetComponent<RectTransform>().position.x - button[i].GetComponent<RectTransform>().position.x;
            distance[i] = Mathf.Abs(distReposition[i]);
        
        if (distReposition[i] > 1200)
			{
				float curX = button[i].GetComponent<RectTransform>().anchoredPosition.x;
				float curY = button[i].GetComponent<RectTransform>().anchoredPosition.y;

				Vector2 newAnchoredPos = new Vector2(curX + (buttonLength * buttonDist), curY);
				button[i].GetComponent<RectTransform>().anchoredPosition = newAnchoredPos;
			}

            if (distReposition[i] < -1200)
			{
				float curX = button[i].GetComponent<RectTransform>().anchoredPosition.x;
				float curY = button[i].GetComponent<RectTransform>().anchoredPosition.y;

				Vector2 newAnchoredPos = new Vector2 (curX - (buttonLength * buttonDist), curY);
				button[i].GetComponent<RectTransform>().anchoredPosition = newAnchoredPos;
			}
        }

        float minDistance = Mathf.Min(distance);

        for (int a = 0; a < button.Length; a++) {
            if (minDistance == distance[a]) {
                minButtonNum = a;
            }
        }
        if (!dragging) {
            LerpToButton(-button[minButtonNum].GetComponent<RectTransform>().anchoredPosition.x);
        }
    }
    
    void LerpToButton(float position) 
    {
        float newX = Mathf.Lerp(panel.anchoredPosition.x, position, Time.deltaTime * 10f);
        Vector2 newPosition = new Vector2(newX, panel.anchoredPosition.y);

        panel.anchoredPosition = newPosition;
    }
    public void StartDrag() 
    {
        dragging = true;
    }
    public void EndDrag()
    {
        dragging = false;
    }

}
