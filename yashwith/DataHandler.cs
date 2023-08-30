using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class DataHandler : MonoBehaviour
{
//  EDITOR FIELDS
    [SerializeField] private ButtonManager buttonPrefab;
    [SerializeField] private GameObject buttonContainer;
    [SerializeField] private List<MenuItem> _menuFoodList;
    [SerializeField] private string label;

// MEMBER VARIABLES
    private int _currId = 0;
    private GameObject _foodItem;
    private static DataHandler _instance;

// INLINE GETTERS AND SETTERS
    /*
     * Singleton Instance created in a shared memory space.
     */
    public static DataHandler Instance 
    {
        get
        {
            if(Instance == null)
            {
                _instance = FindObjectOfType<DataHandler>();
            }
            return _instance;
        } 
    }

// FUNCTIONS

    /*
     * Async fetch of all the cloud assets to List.
     * Create Dynamic Buttons based on the values in the List.
     */
    private async void Start()
    {
        // Initiate Items.
        _menuFoodList = new List<MenuItem>();
        await Get(label);
        CreateButtons();
    }

    // Creates Button for each food item on the list.
    void CreateButtons()
    {
        foreach (MenuItem item in _menuFoodList)
        {
            ButtonManager bManager = Instantiate(buttonPrefab, buttonContainer.transform);
            bManager.FoodId = _currId;
            bManager.ButtonTexture = item.foodImage;
            bManager.ButtonName = item.foodName;
            _currId++;
        }
    }

    /*
     * Go to the cloud, fetch the result and Load it onto MenuItem.
     * Add the fetched Objects to the _items list.
     */
    public async Task Get(string label)
    {
        var locations = await Addressables.LoadResourceLocationsAsync(label).Task;

        foreach (var location in locations)
        {
            var obj = await Addressables.LoadAssetAsync<MenuItem>(location).Task;
            _menuFoodList.Add(obj);

            // What if operation not completed?
            // Asset Label reference can be used to filter out models to spawn the one we want.
        }
    }

 // INLINE GETTERS AND SETTERS
    public void SetFoodItem(int id){ _foodItem = _menuFoodList[id].food3D; }

    public GameObject GetFoodItem(){ return _foodItem;}

}
