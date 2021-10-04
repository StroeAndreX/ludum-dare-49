using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SecondsDisplay : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] TextMeshProUGUI textMeshPro;
    [SerializeField] Days days;

    // Start is called before the first frame update
    void Start()
    {
        textMeshPro = this.GetComponent<TextMeshProUGUI>();
        days = GameObject.Find("Days").GetComponent<Days>(); 
    }

    // Update is called once per frame
    void Update()
    {
        textMeshPro.text = days.secondsRemain.ToString();
    }
}
