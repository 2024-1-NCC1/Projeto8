using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    public Text timerText;  // Refer�ncia ao texto UI para exibir o cron�metro
    public float gameDuration = 180f;  // Dura��o do jogo em segundos (3 minutos)

    private float timeRemaining;
    private bool gameEnded = false;

    void Start()
    {
        timeRemaining = gameDuration;

        // Verificar se a refer�ncia do texto do cron�metro est� configurada
        if (timerText == null)
        {
            Debug.LogError("TimerText n�o est� atribu�do no Inspector!");
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
        // Aqui voc� pode adicionar qualquer l�gica adicional para encerrar o jogo,
        // como mostrar uma tela de fim de jogo ou desabilitar controles.
        // Por exemplo:
        // ShowGameOverScreen();
        // DisablePlayerControls();
        // etc.
    }
}