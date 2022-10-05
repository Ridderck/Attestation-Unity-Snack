using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpFoodGenerator : MonoBehaviour
{
    private int _hpFood;

    private TextMesh TextMesh;

    void Start()
    {
        _hpFood = Random.Range(1, 3);

        TextMesh = gameObject.GetComponent<TextMesh>();
        TextMesh.text = _hpFood.ToString();

    }

}
