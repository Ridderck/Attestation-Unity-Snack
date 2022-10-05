using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public Material wallMaterial;
    public int countWals = 10;

    private void GenerateLevel()
    {

        for (int i = 0; i < countWals; i++)
        { // ������� ���

            GameObject wall = GameObject.CreatePrimitive(PrimitiveType.Cube);
            // �������� ��� "Wall"

            wall.name = "Wall";
            // ����������� ��� ��������

            wall.transform.localScale = new Vector3(2, 2, 2);
            // ����������� ��� ���, ����� ���������� ���� �� � ������ �������� ����

            var pos = new Vector3(Random.Range(-40, 41), 0, Random.Range(-40, 41));

            while (Mathf.Abs(pos.x) < 5 || Mathf.Abs(pos.z) < 5)
            {
                pos = new Vector3(Random.Range(-40, 41), 0, Random.Range(-40, 41));
            }
            wall.transform.position = pos;

            // � ��������� ��������


            wallMaterial = wall.GetComponent<Material>();

        }
    }
}