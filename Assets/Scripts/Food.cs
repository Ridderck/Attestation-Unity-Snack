using UnityEngine;


public class Food : MonoBehaviour
{
    
    public GameObject Object;
    private LevelGenerator LevelGenerator;
    private Game Game;
    private int NumberOfGaps;
    private float DistanceBetweenWalls;
    public Material FoodMaterial;
    private int _hpFood;
    

    private void Start()
    {
        var Qwerty = Object.GetComponent<LevelGenerator>();
        NumberOfGaps = Qwerty.WallsCount;
        DistanceBetweenWalls = Qwerty.DistanceBetweenWalls;

        GenerateFood();
        
    }

    private void GenerateFood()
    {
        for (int i = 0; i < (NumberOfGaps * 2) - (NumberOfGaps / 2); i++)
        {   // ������� ��� 
            GameObject food = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            GameObject basefood = new GameObject();
            food.transform.parent = basefood.transform;
            
            // �������� �� � ��������� ����
            food.name = "Food";
            food.tag = "Food";
            basefood.tag = "BaseFood";
            basefood.name = "BaseFood";
            
            // ����������� ��� ���, ����� ���������� ���� �� � ������ �������� ����
            var pos = new Vector3(Random.Range((float)-7, (float)7), 1, Random.Range((float)5.17295, NumberOfGaps * DistanceBetweenWalls));

            while (Mathf.Abs(pos.x) < 5 || Mathf.Abs(pos.z) < 5)
            
            {
                pos = new Vector3(Random.Range((float)-7, (float)7), 1, Random.Range((float)5.17295, NumberOfGaps * DistanceBetweenWalls));
            }
            
            basefood.transform.position = pos;

            _hpFood = Random.Range(1, 3);

            // ����� �� ��������� ���, ��� �� ���������?
            basefood.AddComponent<TextMesh>();
            basefood.AddComponent<HpFoodGenerator>();
            basefood.AddComponent<SphereCollider>().center = new Vector3(0, 0, 0);
            basefood.GetComponent<SphereCollider>().radius = (float)0.5;
            Destroy(food.GetComponent<SphereCollider>()); 
            
            food.GetComponent<MeshRenderer>().material = FoodMaterial;
            
        }
    }

    

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            PrintDistanceCountWalls();
        }
    }

    private void PrintDistanceCountWalls()
    {
        Debug.Log("��������� ����� �������: " + DistanceBetweenWalls + "; ����������� �����������: " + NumberOfGaps);
    }
}
