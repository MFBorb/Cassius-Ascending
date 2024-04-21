using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ChangeSprite : MonoBehaviour
{
    public GameObject[] itemSprites;
    public GameObject item;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.GetComponent<SpriteRenderer>().sprite = itemSprites[item.GetComponent<ButtonInfo>().ItemID].GetComponent<SpriteRenderer>().sprite;
    }
}
