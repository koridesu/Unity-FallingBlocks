using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomCreate : MonoBehaviour
{
    public List<GameObject> cube = new List<GameObject>();
    public Vector3 pos;
    public Vector3 rotate;
    List<GameObject> temp = new List<GameObject>();
    public int count, i = 0, startCount;
    public int color;

    // Start is called before the first frame update
    void Start()
    {   
        startCount = count;
        pos = transform.position;
        RandomCreater();
        Spawn();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (Time.timeScale == 0)
                Time.timeScale = 1;
            else
                Time.timeScale = 0;
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            for (int i = 0; i < startCount; i++)
            {
                Destroy(temp[i]);
            }
            count = startCount;
            temp.Clear();
            pos.y = 1;
            RandomCreater();
            Spawn();
        }
    }
    void RandomCreater()
    {
        color = Random.Range(0,8);
        pos.x = Random.Range(0.0f, 1.1f);
        transform.Rotate(0, Random.Range(0, 360), 0);
    }
    void Spawn()
    {
        Material m;
        

        while (count != 0)
        {
            temp.Add(Instantiate(cube[color], pos, transform.rotation));
            RandomCreater();
            count--;

            pos.y += 1.2f;
        }
        Time.timeScale = 0;
    }
}
