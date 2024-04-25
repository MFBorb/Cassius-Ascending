using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSprite : MonoBehaviour
{
    public GameObject[] itemSprites;
    public GameObject button;
    private int id;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //this.GetComponent<SpriteRenderer>().sprite = itemSprites[item.GetComponent<ButtonInfo>().ItemID + 1].GetComponent<SpriteRenderer>().sprite;
        int id = button.GetComponent<ButtonInfo>().ItemID;
        if (GameObject.Find("Shop").activeSelf == true) {
            transform.GetChild(id).gameObject.SetActive(true);
        }
    }
}
