using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
[RequireComponent(typeof(Rigidbody))]
public class DestructableBuilding : MonoBehaviour
{
    private Rigidbody rb;
    private ScoreText scoreTextObject;
    private TextMeshProUGUI scoreText;
    int score;

    private void OnAwake()
    {
        scoreTextObject = FindObjectOfType<ScoreText>();
        if(scoreTextObject != null)
        {
            scoreText = scoreTextObject.GetComponent<TextMeshProUGUI>();
            Debug.Log("Found ScoreText");
        }
       
    }

    private void Update()
    {
        int.TryParse(scoreText.text, out score);
    }

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    public Rigidbody GetRigidbody()
    {
        return rb;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("ground"))
        {
            score++;
            scoreText.text = score.ToString();
        }
    }
}
