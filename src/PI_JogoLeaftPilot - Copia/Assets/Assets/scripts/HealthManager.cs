using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public Slider healthBar;  // Referência à barra de vida
    public Text scoreText;  // Referência ao texto UI para exibir a pontuação
    public AudioSource waterJetSound;  // Referência ao AudioSource para o som de jato de água
    private int maxHealth = 100;  // Valor máximo de vida
    private int currentHealth;  // Vida atual
    private bool isOnFire = false;  // Indica se o avião está em contato com a partícula de fogo
    private GameObject currentFireParticles;  // Referência às partículas de fogo atuais
    private int score = 0;  // Pontuação do jogador

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.gameObject.SetActive(false);  // Oculta a barra de vida no início

        // Configurar o Slider
        if (healthBar != null)
        {
            healthBar.maxValue = maxHealth;
            healthBar.value = currentHealth;
        }
        else
        {
            Debug.LogError("HealthBar não está atribuído no Inspector!");
        }

        // Configurar o Texto de Pontuação
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score;
        }
        else
        {
            Debug.LogError("ScoreText não está atribuído no Inspector!");
        }

        // Verificar se o AudioSource está configurado
        if (waterJetSound == null)
        {
            Debug.LogError("WaterJetSound não está atribuído no Inspector!");
        }
    }

    void Update()
    {
        if (isOnFire && Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(10);  // Diminui a vida em 10 ao pressionar a tecla espaço
        }
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("OnTriggerEnter chamado com: " + other.gameObject.name);

        if (other.gameObject.CompareTag("FireParticles"))
        {
            Debug.Log("Avião entrou em contato com FireParticles.");
            isOnFire = true;
            currentFireParticles = other.gameObject;  // Armazena a referência às partículas de fogo atuais
            healthBar.gameObject.SetActive(true);  // Exibe a barra de vida ao colidir com a partícula de fogo
            ResetHealth();  // Reseta a vida ao entrar em uma nova partícula de fogo
        }
    }

    void OnTriggerExit(Collider other)
    {
        Debug.Log("OnTriggerExit chamado com: " + other.gameObject.name);

        if (other.gameObject.CompareTag("FireParticles") && other.gameObject == currentFireParticles)
        {
            Debug.Log("Avião saiu do contato com FireParticles.");
            isOnFire = false;
            healthBar.gameObject.SetActive(false);  // Oculta a barra de vida ao sair da partícula de fogo
            currentFireParticles = null;  // Limpa a referência às partículas de fogo atuais
        }
    }

    private void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth < 0) currentHealth = 0;
        healthBar.value = currentHealth;  // Atualiza o valor do Slider

        Debug.Log("Dano recebido. Vida atual: " + currentHealth);

        if (currentHealth == 0 && currentFireParticles != null)
        {
            Debug.Log("Vida zerada. Destruindo FireParticles.");

            // Tocar som de jato de água
            if (waterJetSound != null)
            {
                waterJetSound.Play();
            }

            Destroy(currentFireParticles);  // Destrói as partículas de fogo atuais
            currentFireParticles = null;  // Limpa a referência às partículas de fogo atuais
            isOnFire = false;
            healthBar.gameObject.SetActive(false);  // Oculta a barra de vida quando a vida é zero

            // Incrementa a pontuação
            score += 10;
            UpdateScoreText();
        }
    }

    private void ResetHealth()
    {
        currentHealth = maxHealth;
        healthBar.value = currentHealth;  // Atualiza o valor do Slider
    }

    private void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score;
        }
        else
        {
            Debug.LogError("ScoreText não está atribuído no Inspector!");
        }
    }
}