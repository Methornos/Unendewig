using UnityEngine;
using UnityEngine.UI;

public class QuickAccess : MonoBehaviour
{
    [SerializeField]
    private RectTransform _boxes = default;

    private QuickAccessItem[] _commandBoxes = new QuickAccessItem[4];
    private string[] _commands = new string[4];

    private int _lastBox = 0;

    private void Awake()
    {
        for(int i = 0; i < _boxes.childCount; i++)
        {
            _commandBoxes[i] = _boxes.GetChild(i).GetComponent<QuickAccessItem>();
        }
    }

    public void SaveLastCommand(string name)
    {
        bool isRepeat = false;
        
        for(int i = 0; i < _commands.Length; i++)
        {
            if (_commands[i] == name) isRepeat = true;
        }

        if(!isRepeat)
        {
            _commandBoxes[_lastBox].transform.GetChild(0).GetComponent<Text>().text = name;
            _commandBoxes[_lastBox].GetComponent<Image>().color = new Color(1, 1, 1, 1);
            _commandBoxes[_lastBox].CommandName = name;
            _commands[_lastBox] = name;
            _lastBox++;
            if (_lastBox >= 4) _lastBox = 0;
        }
    }
}
