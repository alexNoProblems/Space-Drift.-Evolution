using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreCounter : MonoBehaviour
{
    [SerializeField] private TMP_Text _scoreText;
    [SerializeField] private int _winScore = 20;

    private int _hits;

    private void Start()
    {
        UpdateText();
    }
    
    public void AddHit()
    {
        _hits++;
        UpdateText();

        if (_hits >= _winScore)
            SceneManager.LoadScene("YouWin");
    }

    private void UpdateText()
    {
        _scoreText.text = $"Hits: {_hits}";
    }
}
