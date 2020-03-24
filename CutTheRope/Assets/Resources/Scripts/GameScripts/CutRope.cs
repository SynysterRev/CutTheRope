using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CutRope : MonoBehaviour
{
    Vector2 posStart;
    LayerMask mask;
    RaycastHit2D hit;
    [SerializeField] GameObject candy;
    [SerializeField] int indexLevel;
    public bool isLevelFinished;
    static public int numberStars;
    bool pause;
    // Use this for initialization
    void Start()
    {
        mask = LayerMask.GetMask("Rope");
        numberStars = 0;
        isLevelFinished = false;
        DataManager.dataManager.ChangeMusic(SceneManager.GetActiveScene().buildIndex);
        pause = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!pause)
        {
            if (Input.GetMouseButton(0))
            {
                hit = Physics2D.Linecast(Camera.main.ScreenToWorldPoint(posStart), Camera.main.ScreenToWorldPoint(Input.mousePosition), mask);
                Debug.DrawLine(Camera.main.ScreenToWorldPoint(posStart), Camera.main.ScreenToWorldPoint(Input.mousePosition), Color.red);

                if (hit.collider != null && hit.collider.CompareTag("Link"))
                {
                    hit.collider.GetComponent<HingeJoint2D>().enabled = false;
                    if (GameObject.Find("Candy") != null)
                    {
                        HingeJoint2D[] joint = GameObject.Find("Candy").GetComponents<HingeJoint2D>();
                        Rigidbody2D rb = hit.collider.GetComponentInParent<GenerateRope>().LastLink.GetComponent<Rigidbody2D>();
                        for (int i = 0; i < joint.Length; i++)
                        {
                            if (joint[i].connectedBody == rb)
                            {
                                Destroy(joint[i]);
                            }
                        }
                    }
                }
            }
            posStart = Input.mousePosition;
        }
        if (!isLevelFinished && candy == null)
        {
            ReloadScene();
        }
    }

    public void AddAStar()
    {
        numberStars++;
    }

    public void ReloadScene()
    {
        DataManager.dataManager.sounds[(int)DataManager.TypeSounds.button].start();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void SaveScore()
    {
        DataManager.dataManager.StopSounds();
        if (isLevelFinished)
        {
            DataManager.dataManager.SaveProgress(indexLevel, numberStars);
        }
    }
}
