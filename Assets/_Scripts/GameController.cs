using UnityEngine;
using System.Collections;

using UnityEngine.UI;

using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {
	// PUBLIC INSTANCE VARIABLES
	public int enemyCount;
	public GameObject enemy;

    private int _livesValue;
    private int _scoreValue;
   

    [Header("UI Objects")]
    public Text LivesLabel;
    public Text Score;
    public Text Gameover;
    public Text fScore;
    public Button restart; 

    public int LivesValue
    {
        get
        {
            return this._livesValue;
        }

        set
        {
            this._livesValue = value;
            if (this._livesValue <= 0)
            {
                this._endGame();
            }
            else
            {
                this.LivesLabel.text = "Hull: " + this._livesValue;
            }
        }
    }

    public int ScoreValue
    {
        get
        {
            return this._scoreValue;
        }

        set
        {
            this._scoreValue = value;
            this.Score.text = "Score: " + this._scoreValue;
        }
    }

    // Use this for initialization
    void Start () {
        this.LivesValue = 5;
        this.ScoreValue = 10;

        this.Gameover.gameObject.SetActive(false);
        this.fScore.gameObject.SetActive(false);
        this.restart.gameObject.SetActive(false);
        this._GenerateEnemies ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    private void _endGame()
    {
        this.Gameover.gameObject.SetActive(true);
        this.fScore.text = "Final Score: " + this.ScoreValue;
        this.fScore.gameObject.SetActive(true);
        this.restart.gameObject.SetActive(true);
        this.Score.gameObject.SetActive(false);
        this.LivesLabel.gameObject.SetActive(false);
        
    }

    // generate Clouds
    private void _GenerateEnemies() {
		for (int count=0; count < this.enemyCount; count++) {
			Instantiate(enemy);
		}
	}

    public void RestartButton_Click()
    {
        SceneManager.LoadScene("Menu");
    }
}
