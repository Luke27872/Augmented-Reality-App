using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(ARFaceManager))]
[RequireComponent(typeof(AudioSource))]

public class FaceController : MonoBehaviour
{
    [SerializeField]
    public FaceMaterial[] materials;

    [SerializeField]
    Text timer;

    [SerializeField]
    Text score;

    private ARFaceManager arFaceManager;
    private int counter = 0;
    public float startTime = 15;
    public float time;
    public float scoreNo = 0;

    private string textInput;
    private string correctAnswer = "";

    public GameObject correct;
    public GameObject incorrect;
    public GameObject outOFTime;

    public AudioSource audio;
    public AudioClip correctSFX;
    public AudioClip incorrectSFX;

    void Start()
    {
        correct = GameObject.FindGameObjectWithTag("correct");
        incorrect = GameObject.FindGameObjectWithTag("incorrect");
        outOFTime = GameObject.FindGameObjectWithTag("outOfTime");
        correct.SetActive(false);
        incorrect.SetActive(false);
        outOFTime.SetActive(false);
        audio = GetComponent<AudioSource>();
        time = startTime;
    }

    void Update()
    {
        time = time - 1 * Time.deltaTime;
        timer.text = time.ToString("0");
        if (time <= 0)
        {
            time = 10;
            StartCoroutine("outOfTime");
        }
        score.text = scoreNo.ToString("0");
    }

    void Awake()
    {
        arFaceManager = GetComponent<ARFaceManager>();
        arFaceManager.facePrefab.GetComponent<MeshRenderer>().material = materials[0].Material;

    }

    //swaps the face material on cube prefab
    void SwapFaces()
    {
        counter = counter == materials.Length - 1 ? 0 : counter + 1;
        foreach (ARFace face in arFaceManager.trackables)
        {
            face.GetComponent<MeshRenderer>().material = materials[counter].Material;
        }
    }

    //reads user input and compares to correct answer
    public void ReadStringInput(string str)
    {
        textInput = str;
        Debug.Log(textInput);
        if (counter == 0)
        {
            correctAnswer = "15";
        }
        else if (counter == 1)
        {
            correctAnswer = "30";
        }
        else if (counter == 2)
        {
            correctAnswer = "39";
        }
        else if (counter == 3)
        {
            correctAnswer = "54";
        }
        else if (counter == 4)
        {
            correctAnswer = "54";
        }
        else if (counter == 5)
        {
            correctAnswer = "8";
        }
        else if (counter == 6)
        {
            correctAnswer = "72";
        }
        else if (counter == 7)
        {
            correctAnswer = "9";
        }
        else if (counter == 8)
        {
            correctAnswer = "42";
        }
        else if (counter == 9)
        {
            correctAnswer = "67";
        }

        if (textInput == correctAnswer)
        {
            Debug.Log("correct");
            SwapFaces();
            textInput = "";
            correctAnswer = "";
            StartCoroutine("waitCorrect");
            
        }
        else
        {
            StartCoroutine("waitIncorrect");
        }
    }

    //controlls correct audio and popup
    IEnumerator waitCorrect()
    {
        correct.SetActive(true);
        scoreNo = scoreNo + 1;
        audio.PlayOneShot(correctSFX, 0.7f);
        yield return new WaitForSeconds(1);
        correct.SetActive(false);
        time = 15;

    }

    //controlls incorrect audio and popup
    IEnumerator waitIncorrect()
    {
        incorrect.SetActive(true);
        audio.PlayOneShot(incorrectSFX, 0.7f);
        yield return new WaitForSeconds(1);
        incorrect.SetActive(false);
        Debug.Log(incorrect);

    }

    //controlls out of time audio and popup
    IEnumerator outOfTime()
    {
        Object.Destroy(timer);
        outOFTime.SetActive(true);
        audio.PlayOneShot(incorrectSFX, 0.7f);
        yield return new WaitForSeconds(1);
        outOFTime.SetActive(false);
        yield return new WaitForSeconds(3);

        //restarts the game upon fail
        SceneManager.LoadScene("SampleScene");

    }
}

[System.Serializable]
public class FaceMaterial
{
    public Material Material;
}
