using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [Header("Configurações de Spawn")]
    public GameObject obstaclePrefab; // Prefab do obstáculo
    public Transform[] spawnPoints; // Pontos onde os obstáculos podem aparecer
    public float spawnInterval = 5f; // Intervalo inicial de spawn em segundos
    public float spawnIntervalDecrease = 0.5f; // Redução do intervalo a cada spawn
    public float minSpawnInterval = 1f; // Intervalo mínimo de spawn

    private bool isSpawning = false;

    // Referência ao SphereController para acessar a pontuação
    public SphereController sphereController;

    void Start()
    {
        if (sphereController == null)
        {
            sphereController = FindObjectOfType<SphereController>();
            if (sphereController == null)
            {
                Debug.LogError("SphereController não foi encontrado na cena.");
            }
        }

        // Inicialmente, não está iniciando o spawn
    }

    void Update()
    {
        // Verifica se a pontuação atingiu ou ultrapassou 10 e inicia o spawn se ainda não começou
        if (!isSpawning && sphereController.score >= 10)
        {
            isSpawning = true;
            StartCoroutine(SpawnObstacles());
        }
    }

    IEnumerator SpawnObstacles()
    {
        while (isSpawning)
        {
            // Aguarda o intervalo atual
            yield return new WaitForSeconds(spawnInterval);

            // Escolhe um ponto de spawn aleatório
            int spawnIndex = Random.Range(0, spawnPoints.Length);
            Instantiate(obstaclePrefab, spawnPoints[spawnIndex].position, Quaternion.identity);

            // Reduz o intervalo de spawn para aumentar a dificuldade
            if (spawnInterval > minSpawnInterval)
            {
                spawnInterval -= spawnIntervalDecrease;
            }
        }
    }
}
