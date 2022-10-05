using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class LevelGenerator : MonoBehaviour
{
    public GameObject[] WallPrefabs;
    public GameObject FirstWallPrefab;
    public Game Game;
    private int MinWalls = 2;
    private int MaxWalls = 4;
    public float DistanceBetweenWalls;
    public int WallsCount;
    public Transform FinishWall;
    public Vector3 LevelLength;
    

    private void Awake()
    {
        int levelIndex = Game.LevelIndex;
        Random random = new Random(levelIndex);
        WallsCount = RandomRange(random, MinWalls, MaxWalls + 1);
        WallsCount += levelIndex;

        for (int i = 0; i < WallsCount; i++)
        {
            int prefabIndex = RandomRange(random, 0, WallPrefabs.Length);
            GameObject wallPrefab = i == 0 ? FirstWallPrefab : WallPrefabs[prefabIndex];
            GameObject wall = Instantiate(wallPrefab, transform);
            wall.transform.localPosition = CalculateWallPosition(i);
        } 

        FinishWall.localPosition = CalculateWallPosition(WallsCount);
        print("Количество стен: " + WallsCount);

        

    }

    private int RandomRange(Random random, int min, int maxExclusive)
    {
        int number = random.Next();
        int lenght = maxExclusive - min;
        number %= lenght;
        return min + number;
    }

    private Vector3 CalculateWallPosition(int platformIndex)
    {
        return new Vector3(0, 0, DistanceBetweenWalls * platformIndex);
    }
}
