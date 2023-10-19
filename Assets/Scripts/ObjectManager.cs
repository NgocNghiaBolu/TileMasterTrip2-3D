using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ObjectManager : MonoBehaviour
{
    public static ObjectManager instance;
    public List<Item> Items = new List<Item>();
    private Dictionary<Item, int> itemCounts = new Dictionary<Item, int>();

    public Transform itemContent;
    public GameObject InventoryItem;

    public Text level;
    public int currentLevel = 1;
    public Text point;
    public int currentPoint = 0;
    public string loadSceneName;
    public float waitLoad = 1.5f;

    [Header("Sound Game")]
    [HideInInspector]
    public AudioSource audi;
    public AudioClip soundStart;
    public AudioClip selectSound;

    [HideInInspector]
    public int currentTotalItems;
    public int lastScene;

    private void Awake()
    {
        instance = this;
        audi = GetComponent<AudioSource>();
    }

    private void Start()
    {
        currentTotalItems = ManagerJoy.instance.TotalItems();
        SoundStart();

    }

    public void Add(Item item)
    {
        if (itemCounts.ContainsKey(item))
        {
            itemCounts[item]++;
        }
        else
        {
            itemCounts[item] = 1;
        }
        Items.Add(item);
        CheckAndRemoveItems(item);
    }

    public void Remove(Item item)
    {
        if (itemCounts.ContainsKey(item))
        {
            itemCounts[item]--;
            if (itemCounts[item] <= 0)
            {
                itemCounts.Remove(item);
            }
        }
        Items.Remove(item);
    }

    public void CheckAndRemoveItems(Item item)
    {
        if (itemCounts.ContainsKey(item) && itemCounts[item] >= 3)
        {
            currentPoint += 1;
            UpdatePoint();
            audi.PlayOneShot(selectSound);

            for (int i = Items.Count - 1; i >= 0; i--)
            {
                if (Items[i] == item)
                {
                    Items.RemoveAt(i);
                    itemCounts[item]--;
                    if (itemCounts[item] <= 0)
                    {
                        itemCounts.Remove(item);
                    }
                }
            }
        }

        CheckLose();

        NextSceneSuccess();

    }

    void CheckLose()
    {
        if (Items.Count >= 7)
        {
            lastScene = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene("GameOver");
        }
    }

    void SoundStart()
    {
        audi.PlayOneShot(soundStart);
        audi.Play();
    }


    void UpdateLevel()
    {
        level.text = "Level " + currentLevel;
        currentLevel += 1;
    }

    void UpdatePoint()
    {
        point.text = "Point: " + currentPoint;
    }

    void NextSceneSuccess()
    {
        if (currentTotalItems <= 0)
        {
            SceneManager.LoadScene(loadSceneName);
            UpdateLevel();
        }
    }

    public void ListItems()
    {
        foreach (Transform item in itemContent)
        {
            Destroy(item.gameObject);
        }

        foreach (var iTem in Items)
        {
            GameObject obj = Instantiate(InventoryItem, itemContent);
            var Itemname = obj.transform.Find("ItemName").GetComponent<TextMeshProUGUI>();
            var Itemicon = obj.transform.Find("ItemIcon").GetComponent<Image>();

            Itemname.text = iTem.NameItem;
            Itemicon.sprite = iTem.icon;
        }
        
    }
}