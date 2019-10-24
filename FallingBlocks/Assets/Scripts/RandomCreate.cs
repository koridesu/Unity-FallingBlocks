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
    public int color,deneme=1;
    Quaternion rota;

    // Start is called before the first frame update
    void Start()
    {
        
        startCount = count;
        pos = transform.position;
        //rota = Quaternion.Euler(transform.rotation.eulerAngles);
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
        if(Input.GetKeyDown(KeyCode.B))
        {
            string folderName = @"C:\Users\admin\Desktop\Blocks";

            System.IO.Directory.CreateDirectory(folderName);
            string fileName = "BlockData" + deneme + ".txt";
            folderName = System.IO.Path.Combine(folderName, fileName);
            if (!System.IO.File.Exists(folderName))
            {
                using (System.IO.StreamWriter fs = System.IO.File.CreateText(folderName))
                {
                    Vector3 posData = (temp[0].transform.position);
                    Vector3 posData1 = (temp[1].transform.position);


                    float anglex = temp[0].transform.localEulerAngles.x;
                    anglex = (anglex > 180) ? anglex - 360 : anglex;

                    float anglez = temp[0].transform.localEulerAngles.z;
                    anglez = (anglez > 180) ? anglez - 360 : anglez;

                    float angley = temp[0].transform.localEulerAngles.y;
                    angley = (angley > 180) ? angley - 360 : angley;


                    float anglex1 = temp[1].transform.localEulerAngles.x;
                    anglex1 = (anglex1 > 180) ? anglex1 - 360 : anglex1;

                    float anglez1 = temp[1].transform.localEulerAngles.z;
                    anglez1 = (anglez > 180) ? anglez1 - 360 : anglez1;

                    float angley1 = temp[1].transform.localEulerAngles.y;
                    angley1 = (angley1 > 180) ? angley1 - 360 : angley1;


                    fs.WriteLine(posData.x + "," + posData.y + "," + posData.z);
                    fs.WriteLine(anglex + "," + angley + "," + anglez);

                    fs.WriteLine(posData1.x + "," + posData1.y + "," + posData1.z);
                    fs.WriteLine(anglex1 + "," + angley1 + "," + anglez1);

                }
            }
            deneme++;
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
