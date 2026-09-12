

public interface ISaveLoad
{
    void Save(SaveData data);
    SaveData Load();
    bool HasSave();
    void DeleteSave();
}
