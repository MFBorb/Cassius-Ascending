using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponParent : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   
        //Vector3 mousePos = Input.mousePosition;
        //Vector3 screenPoint = Camera.main.WorldToScreenPoint(transform.position);
        //Vector2 offset = new Vector2(mousePos.x - screenPoint.x, mousePos.y - screenPoint.y);
        //float angle = Mathf.Atan2(offset.y, offset.x) * Mathf.Rad2Deg;
        //angle -= 90; // Adjust the angle by 90 degrees

                    
        //transform.rotation = Quaternion.Euler(0, 0, angle);
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float angle = Mathf.Atan2(mousePos.y-transform.position.y, mousePos.x-transform.position.x) * Mathf.Rad2Deg - 90f;
        transform.localRotation = Quaternion.Euler(0, 0,angle);
                
    }
}
