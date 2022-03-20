using UnityEngine;
using UnityEngine.UI;

public class DestroyPlayer : MonoBehaviour
{
    public GameObject pauseButton;
    
    public Text finalScore;

    public GameObject scoreCounter;

    private int currentHighScore;

    public GameObject explosion_1;
    public GameObject explosion_2;

    public float explosion_diff;
    private Vector3 explosion_position;

    public AudioSource coin_source;
    public AudioClip coin_clip;

    public AudioSource boost_source;
    public AudioClip boost_clip;

    public AudioSource slower_source;
    public AudioClip slower_clip;

    public GameObject playincr;

    public int scoreInt;
    public Text multiplier;
    public int currentMultiplier;

    //public GameObject scoreCounterObject;

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Block")
        {
            finalScore.text = "Score : " + ScoreCounter.score;

            currentHighScore = PlayerPrefs.GetInt("HighScore", 0);

            if (ScoreCounter.score > currentHighScore)
            {
                PlayerPrefs.SetInt("HighScore", ScoreCounter.score);
            }

            pauseButton.SetActive(false);
            //ScoreCounter.displayPanel = true;
            scoreCounter.GetComponent<ScoreCounter>().DisplayFinalPanel();
            gameObject.SetActive(false);

            explosion_position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z - explosion_diff);
            Instantiate(explosion_1, explosion_position, explosion_1.transform.rotation);
            Instantiate(explosion_2, explosion_position, explosion_2.transform.rotation);
            //replayPanel.SetActive(true);
        }
        else if(other.gameObject.tag == "Coin")
        {
            coin_source.PlayOneShot(coin_clip);
            ScoreCounter.score += scoreInt;
            scoreCounter.GetComponent<ScoreCounter>().UpdateScore();
            //ScoreCounter.numCoin += 1;
            Destroy(other.gameObject);
            //Debug.Log(ScoreCounter.numCoin);
        }
        else if(other.gameObject.tag == "Boost")
        {
            boost_source.PlayOneShot(boost_clip);
            playincr.GetComponent<PlayerController>().Increase();
            Destroy(other.gameObject);
            scoreInt = scoreInt * 2;
            currentMultiplier++;
            multiplier.text = "X " + currentMultiplier;
            
        }
        else
        {
            slower_source.PlayOneShot(slower_clip);
            playincr.GetComponent<PlayerController>().Decrease();
            Destroy(other.gameObject);
            scoreInt = scoreInt / 2;
            currentMultiplier--;
            multiplier.text = "X " + currentMultiplier;
        }

    }

    public void Mult_reset()
    {
        scoreInt = 20;
        currentMultiplier = 6;
        multiplier.text = "X " + currentMultiplier;
    }


}
