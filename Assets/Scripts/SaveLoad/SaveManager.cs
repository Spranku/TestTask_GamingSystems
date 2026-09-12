using UnityEngine;

public class SaveManager : MonoBehaviour
{
    public static SaveManager Instance { get; private set; }

    private ISaveLoad saveLoad;
    private SaveData currentData;

    public SaveData Data => currentData;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;

        saveLoad = new PlayerPrefsSaveLoad();
        currentData = saveLoad.Load();
    }

    public void Save()
    {
        saveLoad.Save(currentData);
    }

    public void DeleteSave()
    {
        saveLoad.DeleteSave();
        currentData = SaveData.Default;
    }

    /* Money */
    public void AddCurrency(int amount)
    {
        currentData.currency += amount;
        Save();
    }


}
