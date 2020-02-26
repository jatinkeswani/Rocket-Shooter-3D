using UnityEngine.UI;
using System.Collections;
using UnityEngine;

public class continueGame : MonoBehaviour
{
    public Text number;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ResourceTickOver());
    }
    IEnumerator ResourceTickOver()
    {
        yield return new WaitForSeconds(1);
        number.text = "8";
        yield return new WaitForSeconds(1);
        number.text = "7";
        yield return new WaitForSeconds(1);
        number.text = "6";
        yield return new WaitForSeconds(1);
        number.text = "5";
        yield return new WaitForSeconds(1);
        number.text = "4";
        yield return new WaitForSeconds(1);
        number.text = "3";
        yield return new WaitForSeconds(1);
        number.text = "2";
        yield return new WaitForSeconds(1);
        number.text = "1";
        yield return new WaitForSeconds(1);
        number.text = "0";
        exit();
    }
    void exit() {
        manager pum = GameObject.FindObjectOfType(typeof(manager)) as manager;
        pum.RestartBtnClicked();
    }

}
