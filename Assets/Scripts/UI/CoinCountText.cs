using UnityEngine;
using TMPro;

public class CoinCountText : MonoBehaviour
{
    [SerializeField] private TMP_Text textCoinCount;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        textCoinCount.text = "Hello";
        int aaa = 1;
        textCoinCount.text = aaa.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
