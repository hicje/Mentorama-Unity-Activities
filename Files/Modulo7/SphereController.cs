using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SphereController : MonoBehaviour
{
    [Header("Configurações da Esfera")]
    public float bounceForce = 500f; // Força aplicada para manter a esfera no ar
    private Rigidbody rb;

    [Header("UI")]
    public Text scoreText; // Referência para o texto de pontuação

    [HideInInspector]
    public int score = 0; // Variável para armazenar a pontuação

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        UpdateScoreText(); // Atualiza o texto do score no início
    }

    void Update()
    {
        // Detecta o clique do botão esquerdo do mouse ou toque na tela
        if (Input.GetMouseButtonDown(0))
        {
            // Cria um Ray a partir da posição do mouse na tela
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // Executa o Raycast e verifica se atingiu algo
            if (Physics.Raycast(ray, out hit))
            {
                // Verifica se o objeto clicado tem a tag "Sphere"
                if (hit.collider.CompareTag("Sphere"))
                {
                    Debug.Log("Esfera clicada: " + hit.collider.gameObject.name);

                    // Zera a velocidade atual e aplica uma força para cima na esfera
                    rb.velocity = Vector3.zero;
                    rb.AddForce(Vector3.up * bounceForce);

                    // Incrementa a pontuação
                    score++;
                    UpdateScoreText(); // Atualiza o texto do score
                }
                else
                {
                    Debug.Log("Nenhum objeto interativo foi clicado.");
                }
            }
            else
            {
                Debug.Log("Nenhum objeto foi atingido pelo Raycast.");
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        // Verifica se a colisão é com o chão ou com um obstáculo
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("A esfera colidiu com " + collision.gameObject.tag + "! Você perdeu. Pontuação: " + score);
            RestartGame();
        }
    }

    void RestartGame()
    {
        // Reinicia a cena atual após um breve atraso para permitir a leitura da mensagem de derrota
        Invoke("ReloadScene", 2f);
    }

    void ReloadScene()
    {
        score = 0; // Zera a pontuação
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = "Pontuação: " + score;
        }
        else
        {
            Debug.LogWarning("Score Text não está atribuído no Inspector.");
        }
    }
}
