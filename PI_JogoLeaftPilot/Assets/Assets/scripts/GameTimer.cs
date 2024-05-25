using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    public Text timerText;  // Referência ao texto UI para exibir o cronômetro
    public float gameDuration = 180f;  // Duração do jogo em segundos (3 minutos)

    private float timeRemaining;
    private bool gameEnded = false;

    void Start()
    {
        timeRemaining = gameDuration;

        // Verificar se a referência do texto do cronômetro está configurada
        if (timerText == null)
        {
            Debug.LogError("TimerText não está atribuído no Inspector!");
        }
    }

    void Update()
    {
        if (gameEnded)
            return;

        timeRemaining -= Time.deltaTime;

        if (timeRemaining <= 0)
        {
            timeRemaining = 0;
            EndGame();
        }

        UpdateTimerText();
    }

    void UpdateTimerText()
    {
        int minutes = Mathf.FloorToInt(timeRemaining / 60);
        int seconds = Mathf.FloorToInt(timeRemaining % 60);

        if (timerText != null)
        {
            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
    }

    void EndGame()
    {
        gameEnded = true;
        SceneManager.LoadScene("PI_TelaFim");
        Debug.Log("Tempo esgotado! Jogo encerrado.");
        // Aqui você pode adicionar qualquer lógica adicional para encerrar o jogo,
        // como mostrar uma tela de fim de jogo ou desabilitar controles.
        // Por exemplo:
        // ShowGameOverScreen();
        // DisablePlayerControls();
        // etc.
    }
}