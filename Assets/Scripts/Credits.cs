using UnityEngine;
using UnityEngine.UI;


public class Credits : MonoBehaviour
{

    public float scrollSpeed = 40f;

    public bool credit = false;

    public static Credits text;

    private RectTransform rectTransform;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        rectTransform.anchoredPosition = new Vector2(-533, -596);
    }

    private void Awake()
    {
        text = this;
    }
    // Update is called once per frame
    void Update()
    {

        if (credit)
        {
            credit = false;
            rectTransform.anchoredPosition = new Vector2(-533, -596);
        }

        rectTransform.anchoredPosition += new Vector2(0, scrollSpeed * Time.deltaTime);
    }
}
