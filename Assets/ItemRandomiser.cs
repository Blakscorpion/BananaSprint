using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemRandomiser : MonoBehaviour
{
    public Sprite[] listSpriteLeft;
    public Sprite[] listSpriteDesk;
    public Sprite[] listSpriteTopDesk;
    public Sprite[] listSpriteWindow;
    public Sprite[] listSpriteRight;
    public GameObject SpriteLeft;
    public GameObject SpriteDesk;
    public GameObject SpriteTopDesk;
    public GameObject SpriteWindow;
    public GameObject SpriteRight;

    // Start is called before the first frame update
    void Start()
    {
        SpriteLeft.GetComponent<SpriteRenderer>().sprite = listSpriteLeft[Random.Range(0, listSpriteLeft.Length)];
        Debug.Log(Random.Range(0, listSpriteLeft.Length));
        SpriteDesk.GetComponent<SpriteRenderer>().sprite = listSpriteDesk[Random.Range(0, listSpriteDesk.Length)];
        Debug.Log(Random.Range(0, listSpriteDesk.Length));
        SpriteTopDesk.GetComponent<SpriteRenderer>().sprite = listSpriteTopDesk[Random.Range(0, listSpriteTopDesk.Length)];
        Debug.Log(Random.Range(0, listSpriteTopDesk.Length));
        SpriteWindow.GetComponent<SpriteRenderer>().sprite = listSpriteWindow[Random.Range(0, listSpriteWindow.Length)];
        Debug.Log(Random.Range(0, listSpriteWindow.Length));
        SpriteRight.GetComponent<SpriteRenderer>().sprite = listSpriteRight[Random.Range(0, listSpriteRight.Length)];
        Debug.Log(Random.Range(0, listSpriteRight.Length));
    }
}
