using TMPro;
using UnityEngine;

public class UiScript : MonoBehaviour
{
    [SerializeField] private GameObject[] _menuElements;
    private int lvl;

    private void Start()
    {
        LvlCounterShow();
    }

    public void HideUi()
    {
        for (int i = 0; i < _menuElements.Length; i++)
        {
            _menuElements[i].SetActive(false);
        }
    }

    public void ShowUi()
    {
        for (int i = 0; i < _menuElements.Length; i++)
        {
            _menuElements[i].SetActive(true);
        }
        var lvlCount = GameObject.FindGameObjectWithTag("Respawn").GetComponent<SaveSystem>();
        lvlCount.Save();
    }

    public void LvlCounterShow()
    {
        var setLvl = GameObject.FindGameObjectWithTag("Respawn").GetComponent<Spawner>(); 
        lvl = setLvl._levelCount;
        var text = this.GetComponentInChildren<TMP_Text>();
        text.text = "Current level " + lvl;
    }
}
