using System.Collections;
using System.Collections.Generic;
using System.Xml.Schema;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
// MEMBER VARIABLES
    private Button _btn;
    private int _foodId;
    private Sprite _buttonTexture;
    public GameObject _foodItem;

// GETTERS AND SETTERS
    public int FoodId
    {
        set { _foodId = value; }
    }

    public Sprite ButtonTexture
    {
        set
        {
            _buttonTexture = value;
            _btn.GetComponent<Image>().sprite = _buttonTexture;
        }
    }

    public string ButtonName
    {
        set
        {
            _btn.GetComponent<Text>().text = value;
        }
    }

// FUNCTIONS
    void Start()
    { 
        _btn = GetComponent<Button>();
        _btn.onClick.AddListener(SelectObject);
    }

    void Update()
    {
        // UI animation needs changes

       /* if (UIManager.Instance.OnEntered(gameObject))
        {
            transform.localScale = Vector3.one * 2;
        }
        else
        {
            transform.localScale = Vector3.one;
        }*/
    }

// DELEGATE BIND
    void SelectObject()
    {
        DataHandler.Instance.SetFoodItem(_foodId);
    }
    
}
