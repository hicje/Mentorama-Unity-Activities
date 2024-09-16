using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    void Start()
    {
        int N = 576; // Exemplo de valor para N; você pode modificar este valor para diferentes testes.
        int notas100, notas50, notas20, notas10, notas5, notas2, notas1;

        // Exibindo o valor inicial
        Debug.Log("Valor inicial: " + N);

        // Cálculo das notas de R$ 100,00
        notas100 = N / 100; // Quantidade de notas de R$ 100,00
        N = N % 100; // Atualizando N para o restante
        Debug.Log(notas100 + " nota(s) de R$ 100,00");

        // Cálculo das notas de R$ 50,00
        notas50 = N / 50; // Quantidade de notas de R$ 50,00
        N = N % 50; // Atualizando N para o restante
        Debug.Log(notas50 + " nota(s) de R$ 50,00");

        // Cálculo das notas de R$ 20,00
        notas20 = N / 20; // Quantidade de notas de R$ 20,00
        N = N % 20; // Atualizando N para o restante
        Debug.Log(notas20 + " nota(s) de R$ 20,00");

        // Cálculo das notas de R$ 10,00
        notas10 = N / 10; // Quantidade de notas de R$ 10,00
        N = N % 10; // Atualizando N para o restante
        Debug.Log(notas10 + " nota(s) de R$ 10,00");

        // Cálculo das notas de R$ 5,00
        notas5 = N / 5; // Quantidade de notas de R$ 5,00
        N = N % 5; // Atualizando N para o restante
        Debug.Log(notas5 + " nota(s) de R$ 5,00");

        // Cálculo das notas de R$ 2,00
        notas2 = N / 2; // Quantidade de notas de R$ 2,00
        N = N % 2; // Atualizando N para o restante
        Debug.Log(notas2 + " nota(s) de R$ 2,00");

        // Cálculo das notas de R$ 1,00
        notas1 = N; // Quantidade de notas de R$ 1,00
        Debug.Log(notas1 + " nota(s) de R$ 1,00");
    }
}
