using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BusterSword : MonoBehaviour
{
    [SerializeField] float screenWidthInUnits = 23f;
    [SerializeField] float minX = 2f;
    [SerializeField] float maxX = 21f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float mousePosInUnits = Input.mousePosition.x / Screen.width * screenWidthInUnits;
        Vector2 swordPos = new Vector2(mousePosInUnits, transform.position.y);
        swordPos.x = Mathf.Clamp(mousePosInUnits, minX, maxX);
        transform.position = swordPos;
    }
}
