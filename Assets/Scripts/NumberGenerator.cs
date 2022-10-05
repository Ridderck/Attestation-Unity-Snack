using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = System.Random;

public class NumberGenerator : MonoBehaviour
{
    public int HpSegment;
    public int HpFood;
    private float _color;

    public TextMesh TextMesh;
    public MeshRenderer _componentMeshRenderer;
    
    //private GameObject _currentGameObject;
    void Start()
    {
        
    }
    private void Awake()
    {
        _componentMeshRenderer = GetComponent<MeshRenderer>();
        
        Random random = new Random();
        HpSegment = RandomRange(random, 1, 7);

        HpFood = RandomRange(random, 1, 2);

        if (gameObject.tag == "Food")
        {
            TextMesh.text = HpFood.ToString();
        }
        else
        {
            TextMesh.text = HpSegment.ToString();
        }
        Remap(HpSegment, 1, 6, 0, 1, out _color);
    }

    /*void UnityRemapfloat4(float4 In, float2 InMinMax, float2 OutMinMax, out float4 Out)
    {
        Out = OutMinMax.x + (In - InMinMax.x) * (OutMinMax.y - OutMinMax.x) / (InMinMax.y - InMinMax.x);
    }*/

    void Remap(float from, float fromMin, float fromMax, float toMin, float toMax, out float to)
    {
        {
            var fromAbs = from - fromMin;
            var fromMaxAbs = fromMax - fromMin;

            var normal = fromAbs / fromMaxAbs;

            var toMaxAbs = toMax - toMin;
            var toAbs = toMaxAbs * normal;

            to = toAbs + toMin;
        }
    }
    

    private int RandomRange(Random random, int min, int maxExclusive)
    {
        int number = random.Next();
        int lenght = maxExclusive - min;
        number %= lenght;
        return min + number;
    }

    

    Color lerpedColor = Color.white;

    void Update()
    {
        lerpedColor = Color.Lerp(Color.green, Color.red, _color);
        
        gameObject.GetComponent<MeshRenderer>().material.color = lerpedColor;
    }

    
}
