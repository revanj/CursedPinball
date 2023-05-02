using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Sirenix.OdinInspector;

public class LevelSelectionController : MonoBehaviour
{
    [SerializeField]
    private List<SceneReference> _scenes;
    [SerializeField]
    [Required]
    private GameObject _buttonPrefab;
    [SerializeField]
    [Required]
    private Transform _buttonParent;
    [SerializeField]
    private List<GameObject> _buttons;
    [SerializeField]
    private Color _selectedColor;
    [SerializeField]
    [Required]
    private GameObject _exitButton;
    [SerializeField]
    private int _selectedIndex = 0;
    public int SelectedIndex
    {
        get => _selectedIndex;
        set
        {
            if (value < 0)
            {
                _selectedIndex = _buttons.Count - 1;
            }
            else if (value > _buttons.Count - 1)
            {
                _selectedIndex = 0;
            }
            else
            {
                _selectedIndex = value;
            }
        }
    }
    private void Start()
    {
        int index = 1;
        foreach (var scene in _scenes)
        {
            var button = Instantiate(_buttonPrefab, _buttonParent);
            button.GetComponentInChildren<Text>().text = index.ToString();
            button.GetComponent<Button>().onClick.AddListener(() =>
            {
                BGM.PreservePrevious = false;
                SceneManager.MoveGameObjectToScene(GameObject.FindWithTag("Music"), SceneManager.GetActiveScene());
                SceneManager.LoadScene(scene);
            });
            _buttons.Add(button);
            index++;
        }
    }
}
