using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Blade : MonoBehaviour {

	public GameObject bladeTrailPrefab;
	public float minCuttingVelocity = .001f;

	bool isCutting = false;
    public static bool playsoundAudio = false;
	Vector2 previousPosition;
    public AudioSource audioSource;
    GameObject currentBladeTrail;
    public GameObject mainCanvas;
    public Text scoretext;
    public static int score = 0;
    Rigidbody2D rb;
	Camera cam;
	CircleCollider2D circleCollider;

	void Start ()
	{
        scoretext = GameObject.FindWithTag("scoreTag").GetComponent<Text>();
        cam = Camera.main;
		rb = GetComponent<Rigidbody2D>();
		circleCollider = GetComponent<CircleCollider2D>();
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0))
		{
			StartCutting();
		} else if (Input.GetMouseButtonUp(0))
		{
			StopCutting();
		}

		if (isCutting)
		{
			UpdateCut();
		}
        scoretext.text = "Score : " + score;
        if (score == 20)
        {
            //mainCanvas.active =true;
            exit();


        }
        if (playsoundAudio)
        {
            audioSource.Play();
            playsoundAudio = false;
        }
    }

    public void exit()
    {
        score = 0;
        playSound.Startcreatfruit = false;
        SceneManager.LoadScene("frutcutting");
    }
    void UpdateCut ()
	{
		Vector2 newPosition = cam.ScreenToWorldPoint(Input.mousePosition);
        rb.position = newPosition;

		float velocity = (newPosition - previousPosition).magnitude * Time.deltaTime;
		if (velocity > minCuttingVelocity)
		{
			circleCollider.enabled = true;
		} else
		{
			circleCollider.enabled = false;
		}

		previousPosition = newPosition;
	}

	void StartCutting ()
	{
		isCutting = true;
		currentBladeTrail = Instantiate(bladeTrailPrefab, transform);
		previousPosition = cam.ScreenToWorldPoint(Input.mousePosition);
		circleCollider.enabled = false;
	}

	void StopCutting ()
	{
		isCutting = false;
		currentBladeTrail.transform.SetParent(null);
		Destroy(currentBladeTrail, 2f);
		circleCollider.enabled = false;
	}

   

}
