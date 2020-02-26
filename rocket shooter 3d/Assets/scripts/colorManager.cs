using UnityEngine.UI;
using UnityEngine;

public class colorManager : MonoBehaviour
{
    public static Color mainColor;
    public Color[] from;
    public Color[] to;
    Color oldColor, newColor;
     float time=0f;
    float changeOverTime;
    public Text distanceText;
    float distance;
    public static bool veryFirst = true, newClr = false;
    public static int clrPointer;
    // Start is called before the first frame update
    void Start()
    {
        FindAColor();
        mainColor = Color.gray;
        oldColor = from[clrPointer];
        newColor = to[clrPointer];
        int lvl= PlayerPrefs.GetInt("gameLevel");
        checkForGameTime(lvl);
    }

    void FindAColor()
    {
        if (veryFirst == true)
        {
            clrPointer = Random.Range(0, from.Length);
            
            veryFirst = false;
        }
        else
        {
            if (newClr)
            {
                int i = clrPointer;
                int f = Random.Range(0, from.Length);
                if (i != f)
                {
                    clrPointer = f; newClr = false;
                    
                }
                else { FindAColor(); }
            }
        }


    }
    void checkForGameTime(int lvl)
    {
        if (lvl < 5)
        {
            changeOverTime = 50;
        }
        else if (lvl >= 5 && lvl < 15)
        {
            changeOverTime = 40;
        }
        else if (lvl >= 15 && lvl < 25)
        {
            changeOverTime = 30;
        }
        else if (lvl >= 25 && lvl < 55)
        {
            changeOverTime = 20;
        }
        else
        {
            changeOverTime = 10;
        }
        

    }
    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime/ changeOverTime;
        
        if(time<1)
        mainColor = Color.Lerp(oldColor, newColor, time);

        //  if(GameObject.FindGameObjectWithTag("Player").transform.position.y<=transform.position.y)
        // transform.LookAt(GameObject.FindGameObjectWithTag("Player").transform );
       /* if (GameObject.FindGameObjectWithTag("Player")!=null)
        {
            if (GameObject.FindGameObjectWithTag("lazer") != null)
            {
                distance = GameObject.FindGameObjectWithTag("Player").transform.position.y - GameObject.FindGameObjectWithTag("lazer").transform.position.y;
                distanceText.text = "" + (int)distance;
            }
        }*/
           


    }
}
