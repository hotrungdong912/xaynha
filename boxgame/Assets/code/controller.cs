using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class controller : MonoBehaviour
{
    public static controller instance;

    public spawn box_spawn;

    [HideInInspector]
    public box box;
    public camera camera_follow;
    private int count;
     void Awake()
    {
        if (instance == null)
            instance = this;
    }
    void Start()
    {
        box_spawn.SpawnBox();
    }

    // Update is called once per frame
    void Update()
    {
        DetecInput();
    }

    void DetecInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            box.drop();
        }
    }

    public void spwannewbox()
    {
        Invoke("newbox",0.5f);
    }

    void newbox()
    {
        box_spawn.SpawnBox();
    }


    public void movecamera()
    {
        count++;
        Debug.Log(count);
        if (count == 3)
        {
            count = 0;
            camera_follow.targetpos.y += 2f;
        }
    }

    public void restartgame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
