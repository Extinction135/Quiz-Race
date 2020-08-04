using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;


public class GameManager : MonoBehaviour
{
    public Question[] questions;
    private static List<Question> unansweredQuestions;

    private Question currentQuestion;

    [SerializeField]
    private Text factText;

    [SerializeField]
    private Text trueAnswerText;

    [SerializeField]
    private Text falseAnswerText;


    [SerializeField]
    private float timeBetweenQuestions = 1f;

    [SerializeField]
    private Button TrueButton;

    [SerializeField]
    private Button FalseButton;

    public float speed;
    public int score;


    public AudioClip audCorrect;
    public AudioClip audWrong;


    // Start is called before the first frame update
    void Start()
    {
        if (unansweredQuestions == null || unansweredQuestions.Count == 0)
        {
            unansweredQuestions = questions.ToList<Question>();
        }

        SetCurrentQuestion();

    }

    void SetCurrentQuestion()
    {
        int randomQuestionIndex = Random.Range(0, unansweredQuestions.Count);
        currentQuestion = unansweredQuestions[randomQuestionIndex];

        factText.text = currentQuestion.fact;

        if (currentQuestion.isTrue)
        {
            trueAnswerText.text = "CORRECT";
            trueAnswerText.color = new Color32(28, 82, 0, 255);
            falseAnswerText.text = "WRONG";
            falseAnswerText.color = new Color32(125, 0, 0, 255);
        }
        else
        {
            trueAnswerText.text = "WRONG";
            trueAnswerText.color = new Color32(125, 0, 0, 255);
            falseAnswerText.text = "CORRECT";
            falseAnswerText.color = new Color32(28, 82, 0, 255);
        }

    } 

    IEnumerator TransitionToNextQuestion ()
    {
        unansweredQuestions.Remove(currentQuestion);

        yield return new WaitForSeconds(timeBetweenQuestions);

        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        SetCurrentQuestion();
        TrueButton.gameObject.SetActive(true);
        FalseButton.gameObject.SetActive(true);
        TrueButton.enabled = true;
        FalseButton.enabled = true;

        EventSystem.current.SetSelectedGameObject(null);
        
    }
    
    public void UserSelectTrue()
    {
        if (currentQuestion.isTrue)
        {
            FalseButton.gameObject.SetActive(false);
            TrueButton.enabled = false;
            Debug.Log("CORRECT!");

            speed = speed + 1;
            score = score + 1;

            AudioSource audio = GetComponent<AudioSource>();
            audio.PlayOneShot(audCorrect);


        }
        else
        {
            FalseButton.gameObject.SetActive(false);
            TrueButton.enabled = false;
            Debug.Log("WRONG!");

            speed = speed - 0.5f;

            AudioSource audio = GetComponent<AudioSource>();
            audio.PlayOneShot(audWrong);

            if (speed < 0)
            {
                speed = 0;
            }
        }

        StartCoroutine(TransitionToNextQuestion());
    }

    public void UserSelectFalse()
    {
        if (!currentQuestion.isTrue)
        {
            TrueButton.gameObject.SetActive(false);
            FalseButton.enabled = false;
            Debug.Log("CORRECT!");

            speed = speed + 1;
            score = score + 1;

            AudioSource audio = GetComponent<AudioSource>();
            audio.PlayOneShot(audCorrect);
        }
        else
        {
            TrueButton.gameObject.SetActive(false);
            FalseButton.enabled = false;
            Debug.Log("WRONG!");

            speed = speed - 0.5f;

            AudioSource audio = GetComponent<AudioSource>();
            audio.PlayOneShot(audWrong);

            if (speed < 0)
            {
                speed = 0;
            }
            
        }

        StartCoroutine(TransitionToNextQuestion());

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
