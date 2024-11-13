using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FloatingTextManager : MonoBehaviour
{
    public static FloatingTextManager Instance;
    public GameObject textPrefab;

    private void Awake()
    {
        Instance = this;
    }

    public void Show(string text, Vector3 worldPos)
    {
        Vector2 screenPos = Camera.main.WorldToScreenPoint(worldPos);

        GameObject textObj = Instantiate(textPrefab, transform);
        textObj.transform.position = screenPos;

        TextMeshProUGUI temp = textObj.GetComponent<TextMeshProUGUI>();
        if (temp != null)
        {
            temp.text = text;

            StartCoroutine(AnimateText(textObj));
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator AnimateText(GameObject textObj)
    {
        float duration = 1f;
        float timer = 0;

        Vector3 startPos = textObj.transform.position;
        TextMeshProUGUI temp = textObj.GetComponent<TextMeshProUGUI>();

        while (timer < duration)
        {
            timer += Time.deltaTime;
            float progess = timer / duration;

            textObj.transform.position = startPos + Vector3.up * (progess * 50f);

            if (temp != null)
            {
                temp.alpha = 1 - progess;
            }

            yield return null;
        }
        Destroy(textObj);
    }
}
