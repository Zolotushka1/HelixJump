using UnityEngine;
using TMPro;

public class SaveSystem : MonoBehaviour
{
    private int _lvl;

    private void Start()
    {
        var lvlCount = GameObject.FindGameObjectWithTag("Respawn").GetComponent<Spawner>();
        lvlCount._levelCount = PlayerPrefs.GetInt("Level");
    }

    public void Save()
    {
        var lvlCount = GameObject.FindGameObjectWithTag("Respawn").GetComponent<Spawner>();
        _lvl = lvlCount._levelCount;
        PlayerPrefs.SetInt("Level", _lvl);
    }

    public void ReloadStats()
    {
        PlayerPrefs.DeleteAll();
        var lvlCount = GameObject.FindGameObjectWithTag("Respawn").GetComponent<Spawner>();
        lvlCount._levelCount = PlayerPrefs.GetInt("Level");
        var text = GameObject.FindGameObjectWithTag("LvlUi").GetComponent<TMP_Text>();
        text.text = "Current level " + PlayerPrefs.GetInt("Level");
    }
}
