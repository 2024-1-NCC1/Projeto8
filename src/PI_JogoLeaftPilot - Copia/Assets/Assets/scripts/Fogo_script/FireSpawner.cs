using UnityEngine;

public class FireSpawner : MonoBehaviour
{
    public GameObject firePrefab;        // Prefab do fogo a ser instanciado
    public float spawnInterval = 5.0f;   // Intervalo de tempo entre os spawns
    public Terrain terrain;              // Referência ao terreno

    private float timer = 0.0f;
    private float terrainWidth;
    private float terrainLength;
    private float terrainPosX;
    private float terrainPosZ;

    void Start()
    {
        // Obter os limites do terreno
        terrainWidth = terrain.terrainData.size.x;
        terrainLength = terrain.terrainData.size.z;
        terrainPosX = terrain.transform.position.x;
        terrainPosZ = terrain.transform.position.z;
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            SpawnFire();
            timer = 0.0f;
        }
    }

    void SpawnFire()
    {
        // Gerar uma posição aleatória dentro dos limites do terreno
        float randomX = Random.Range(terrainPosX, terrainPosX + terrainWidth);
        float randomZ = Random.Range(terrainPosZ, terrainPosZ + terrainLength);

        // Obter a altura do terreno na posição aleatória
        float yPos = terrain.SampleHeight(new Vector3(randomX, 0, randomZ)) + terrain.transform.position.y;

        // Instanciar o fogo na posição aleatória no terreno com rotação correta
        Vector3 spawnPosition = new Vector3(randomX, yPos, randomZ);
        Quaternion spawnRotation = Quaternion.Euler(-90, 0, 0); // Define a rotação para o prefab

        Instantiate(firePrefab, spawnPosition, spawnRotation);
    }
}