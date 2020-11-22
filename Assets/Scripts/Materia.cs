using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Materia : MonoBehaviour
{
    // params
    [SerializeField] BusterSword bustersword1;

    // state
    Vector2 swordToMateriaVector;

    // Start is called before the first frame update
    void Start()
    {
        swordToMateriaVector = transform.position - bustersword1.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 swordPos = new Vector2(bustersword1.transform.position.x, bustersword1.transform.position.y);
        transform.position = swordPos + swordToMateriaVector;
    }
}
