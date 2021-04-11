using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextSlide : MonoBehaviour
{
    public RectTransform[] texts;

    //float xStart = 5013f;

    // Start is called before the first frame update
    void Start()
    {
        /*
        foreach (RectTransform rect in texts)
        {
            Debug.Log(rect.transform.position);
            Debug.Log(rect.rect.width);
        }
        */
    }

    // Update is called once per frame
    void Update()
    {
        foreach(RectTransform rect in texts)
        {
            rect.transform.localPosition -= new Vector3(2f * Time.deltaTime,0f,0f);
            //if (rect.transform.localPosition.x < 232f) rect.transform.localPosition += new Vector3(xStart, 0f, 0f);

        }
    }
}
