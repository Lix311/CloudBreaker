using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BusterSword : MonoBehaviour
{
    [SerializeField] float screenWidthInUnits = 23f;
    [SerializeField] float minX = 2f;
    [SerializeField] float maxX = 21f;

    // cached references
    GameSession theGameSession;
    Materia theMateria;
    // Start is called before the first frame update
    void Start()
    {
        theGameSession = FindObjectOfType<GameSession>();
        theMateria = FindObjectOfType<Materia>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 swordPos = new Vector2(transform.position.x, transform.position.y);
        swordPos.x = Mathf.Clamp(GetXPos(), minX, maxX);
        transform.position = swordPos;
    }

    private float GetXPos()
    {
        if (theGameSession.IsAutoPlayEnabled())
        {
            return theMateria.transform.position.x;
        }
        else
        {
            return Input.mousePosition.x / Screen.width * screenWidthInUnits;
        }
    }
}
