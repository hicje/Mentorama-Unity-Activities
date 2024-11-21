using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SeletorDeEnigma : MonoBehaviour
{
    [SerializeField] ListaEnigmas lista;
    [SerializeField] Dropdown dropdown; 
    [SerializeField] Text perguntaTexto;
    [SerializeField] Text botao1Texto;
    [SerializeField] Text botao2Texto;
    [SerializeField] Text botao3Texto;
    [SerializeField] Text botao4Texto;
    [SerializeField] Text scoreTexto;
    [SerializeField] Text recordTexto;
    private List<string> respostasPossiveis = new List<string>();
    private List<Enigma> listaAtual; 
    private int score;
    private int record;
    private int index;
    private int indexRespostas;
    private int dificuldade;
    private int powerupCount;
    public GameObject win;

    void Start()
    {
        
        win.SetActive(false);

        scoreTexto.text = "Score: " + score.ToString();

        // Pega a variável armazenada no PlayerPrefs e define o recorde
        record = PlayerPrefs.GetInt("record", 0);
        recordTexto.text = "Record: " + record.ToString();

        // Pega o valor da dificuldade do Dropdown
        dificuldade = dropdown.value;

        // Define a lista atual de enigmas com base na dificuldade
        listaAtual = Dificuldade();

        // Exibe a primeira questão
        AtualizarQuestoes();
    }

    // Retorna a lista de enigmas com base na dificuldade
    public List<Enigma> Dificuldade()
    {
        switch (dificuldade)
        {
            case 0:
                Debug.Log("Easy");
                return lista.listaEnigmasEasy;
            case 1:
                Debug.Log("Medium");
                return lista.listaEnigmasMedium;
            case 2:
                Debug.Log("Hard");
                return lista.listaEnigmasHard;
        }
        return lista.listaEnigmasEasy; // Default para Easy
    }

    // Atualiza e exibe uma nova questão
    void AtualizarQuestoes()
    {
        if (listaAtual.Count == 0)
        {
            // Exibe o botão de vitória se acabarem as questões
            win.SetActive(true);
            return;
        }

        // Escolhe uma questão aleatória
        index = Random.Range(0, listaAtual.Count);

        // Adiciona as respostas possíveis à lista
        respostasPossiveis.Clear();
        respostasPossiveis.Add(listaAtual[index].respostaCorreta);
        respostasPossiveis.Add(listaAtual[index].respostaErrada1);
        respostasPossiveis.Add(listaAtual[index].respostaErrada2);
        respostasPossiveis.Add(listaAtual[index].respostaErrada3);

        // Embaralha as respostas
        Shuffle(respostasPossiveis);

        // Exibe a pergunta e as respostas
        perguntaTexto.text = listaAtual[index].pergunta;
        botao1Texto.text = respostasPossiveis[0];
        botao2Texto.text = respostasPossiveis[1];
        botao3Texto.text = respostasPossiveis[2];
        botao4Texto.text = respostasPossiveis[3];
    }

    // Embaralha uma lista (método auxiliar)
    void Shuffle<T>(List<T> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            int rnd = Random.Range(0, list.Count);
            T temp = list[i];
            list[i] = list[rnd];
            list[rnd] = temp;
        }
    }

    // Atualiza a pontuação
    public void Score()
    {
        switch (dificuldade)
        {
            case 0:
                score += 5; // Easy
                break;
            case 1:
                score += 10; // Medium
                break;
            case 2:
                score += 15; // Hard
                break;
        }

        // Atualiza a pontuação na tela
        scoreTexto.text = "Score: " + score.ToString();

        // Verifica se é um novo recorde
        if (score > record)
        {
            record = score;
            recordTexto.text = "Record: " + record.ToString();
            PlayerPrefs.SetInt("record", record); // Salva o novo recorde
        }
    }

    // Ao clicar em uma resposta
    public void OnClick(Text textoBotao)
    {
        if (textoBotao.text == listaAtual[index].respostaCorreta)
        {
            // Remove a questão correta
            listaAtual.RemoveAt(index);
            Score();
            AtualizarQuestoes();
        }
        else
        {
            // Reinicia a cena
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    // PowerUp (remove a questão automaticamente como correta)
    //Limite de um unico uso durante o jogo
    public void PowerUp()
    {
        if (powerupCount <= 0)
        {
            listaAtual.RemoveAt(index);
            powerupCount++;
            Score();
            AtualizarQuestoes();
        }
    }

    // Quando o botão de vitória é clicado
    public void OnClickWin()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // Quando a dificuldade no Dropdown é alterada
    public void OnDifficultyChanged()
    {
        dificuldade = dropdown.value;
        listaAtual = Dificuldade();
        AtualizarQuestoes();
    }
}
