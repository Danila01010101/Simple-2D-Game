using DG.Tweening;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class CellSpawner : MonoBehaviour
{

    [SerializeField]
    private GameObject _cellPrefab;

    [SerializeField]
    private List<Cell> _alphabet;
    
    [SerializeField]
    private List<Cell> _numbers;

    private List<Cell>[] _cellContent;

    [SerializeField]
    private Button _restartButton;

    [SerializeField]
    private Text _goalText;

    [SerializeField]
    private ParticleSystem _starsParticles;

    [SerializeField]
    private UnityEvent EndLevelEvent;

    private List<string> _cellsOnScene = new List<string>();

    private List<string> _answersOnThisLevel = new List<string>();

    private string _rightAnswer;

    private string _cellsTag = "Cell";

    private int _currentLevel = 1;

    private void Start()
    {
        StartLevel();
    }


    public void StartLevel()
    {
        int _randomContentIndex = Random.Range(0, 2);
        if (_currentLevel > 3)
            _currentLevel = 1;
        switch (_currentLevel)
        {
            case 1:
                _cellContent = new List<Cell>[2] { _alphabet, _numbers };
                _cellsOnScene = new List<string>();
                transform.DOShakePosition(1f, strength: new Vector3(0, 6, 0), vibrato: 4, randomness: 1, snapping: false, fadeOut: true);
                DrawFirstLevelCells(_randomContentIndex);
                 _rightAnswer = FindRightAnswer(_cellsOnScene, _answersOnThisLevel);
                _answersOnThisLevel.Add(_rightAnswer);
                UpdateGoalText("Find " + _rightAnswer);
                break;
            case 2:
                _cellContent = new List<Cell>[2] { _alphabet, _numbers };
                _cellsOnScene = new List<string>();
                DrawSecondLevelCells(_randomContentIndex);
                _rightAnswer = FindRightAnswer(_cellsOnScene, _answersOnThisLevel);
                _answersOnThisLevel.Add(_rightAnswer);
                UpdateGoalText("Find " + _rightAnswer);
                break;
            case 3:
                _cellContent = new List<Cell>[2] { _alphabet, _numbers };
                _cellsOnScene = new List<string>();
                DrawThirdLevelCells(_randomContentIndex);
                _rightAnswer = FindRightAnswer(_cellsOnScene, _answersOnThisLevel);
                _answersOnThisLevel.Add(_rightAnswer);
                UpdateGoalText("Find " + _rightAnswer);
                break;
        }
    }

    public void EndLevel()
    {
        _currentLevel++;
        foreach (GameObject _cell in GameObject.FindGameObjectsWithTag(_cellsTag))
                Destroy(_cell);
        if (_currentLevel > 3)
        {
            Debug.Log("конец игры");
            _restartButton.gameObject.SetActive(true);
            EndLevelEvent.Invoke();
        }
        else
        {
            Debug.Log("победа");
            StartLevel();
        }
    }

    public void HideRestartButton()
    {
        _restartButton.gameObject.SetActive(false);
    }

    private void SpawnCell(Vector3 cellPosition, int contentIndex)
    {
        int cellIndex = Random.Range(0, _cellContent[contentIndex].Count);
        while (_cellsOnScene.Contains(_cellContent[contentIndex][cellIndex]._name))
            cellIndex = Random.Range(0, _cellContent[contentIndex].Count);
        GameObject _newCell = Instantiate(_cellPrefab, cellPosition, _cellPrefab.transform.rotation, transform);
        _cellsOnScene.Add(_cellContent[contentIndex][cellIndex]._name);
        _newCell.GetComponent<CellBehaviour>().SetCell(_cellContent[contentIndex][cellIndex]._name, _cellContent[contentIndex][cellIndex]._sprite);
    }

    [System.Serializable]
    public class Cell
    {
        [SerializeField]
        public string _name;
        [SerializeField]
        public Sprite _sprite;
    }

    public string GetRightAnswer()
    {
        return _rightAnswer;
    }

    private void UpdateGoalText(string text)
    {
        _goalText.text = text;
    }

    private string FindRightAnswer(List<string> cellsOnScene, List<string> answersOnThisLevel)
    {
        string rightAnswer = cellsOnScene[Random.Range(0, _cellsOnScene.Count)];
        while (_answersOnThisLevel.Contains(rightAnswer))
        {
            rightAnswer = _cellsOnScene[Random.Range(0, _cellsOnScene.Count)];
        }
        return rightAnswer;
    }

    private void DrawFirstLevelCells(int randomContentIndex)
    {
        SpawnCell(new Vector3(-2.6f, 0), randomContentIndex);
        SpawnCell(new Vector3(0, 0), randomContentIndex);
        SpawnCell(new Vector3(2.6f, 0), randomContentIndex);
    }
    private void DrawSecondLevelCells(int randomContentIndex)
    {
        SpawnCell(new Vector3(-2.6f, -1.1f), randomContentIndex);
        SpawnCell(new Vector3(0, -1.1f), randomContentIndex);
        SpawnCell(new Vector3(2.6f, -1.1f), randomContentIndex);
        SpawnCell(new Vector3(-2.6f, 1.4f), randomContentIndex);
        SpawnCell(new Vector3(0, 1.4f), randomContentIndex);
        SpawnCell(new Vector3(2.6f, 1.4f), randomContentIndex);
    }
    private void DrawThirdLevelCells(int randomContentIndex)
    {
        SpawnCell(new Vector3(-2.6f, 0), randomContentIndex);
        SpawnCell(new Vector3(0, 0), randomContentIndex);
        SpawnCell(new Vector3(2.6f, 0), randomContentIndex);
        SpawnCell(new Vector3(-2.6f, -2.5f), randomContentIndex);
        SpawnCell(new Vector3(0, -2.5f), randomContentIndex);
        SpawnCell(new Vector3(2.6f, -2.5f), randomContentIndex);
        SpawnCell(new Vector3(-2.6f, 2.5f), randomContentIndex);
        SpawnCell(new Vector3(0, 2.5f), randomContentIndex);
        SpawnCell(new Vector3(2.6f, 2.5f), randomContentIndex);
    }

}
