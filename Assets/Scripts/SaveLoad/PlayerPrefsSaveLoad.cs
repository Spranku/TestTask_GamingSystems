using UnityEngine;

public class PlayerPrefsSaveLoad : ISaveLoad
{
    private const string KEY_CURRENCY = "save_currency";
    /* private const string KEY_BEST_TIME = "save_best_time"; */


    public void Save(SaveData data)
    {
        /*PlayerPrefs.SetInt(KEY_CURRENCY, data.currency);
         * ...
         */
        
        //Debug.Log("PlayerPrefsSaveLoad::Save - Success saved");
    }

    public SaveData Load() 
    {
        if (!HasSave()) return SaveData.Default;

        return new SaveData
        {
            currency = PlayerPrefs.GetInt(KEY_CURRENCY, 0),
            //bestTime = PlayerPrefs.GetFloat(KEY_BEST_TIME, 0f),
        };
    }

    public bool HasSave()
    {
        /*return PlayerPrefs.GetInt(KEY_HAS_SAVE, 0) == 1;
         * 
         */
        return false;
    }

    public void DeleteSave()
    {

    }
}
