using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    private Button btn;
    public GameObject food;

    // Start is called before the first frame update
    void Start()
    {
        btn = GetComponent<Button>();
        btn.onClick.AddListener(SelectObject); // Attach the SelectObject method to the button's click event
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SelectObject()
    {
        DataHandler.Instance.food = food;  
    }
}
