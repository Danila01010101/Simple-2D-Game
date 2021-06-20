using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;


public class CellBehaviour : MonoBehaviour
{
    private string _name;
    private Sprite _icon;
    private string _cellSpawnerTag = "Cell Spawner";
    [SerializeField]
    private ParticleSystem _starsParticles;
    private CellSpawner _cellSpawner;
    [SerializeField]
    private float _shakeForce = 0.1f;


    private void Start()
    {
        gameObject.transform.GetChild(0).GetComponentInChildren<SpriteRenderer>().sprite = _icon;
        _cellSpawner = GameObject.FindGameObjectWithTag(_cellSpawnerTag).GetComponent<CellSpawner>();
    }

    public void SetCell(string name, Sprite icon)
    {
        _name = name;
        _icon = icon;
    }
    public string GetName()
    {
        return _name;
    }

    public void OnMouseDown()
    {
        float animationTime = 2.0f;
        if (_name == _cellSpawner.GetRightAnswer())
        {
            _starsParticles.Play();
            transform.GetChild(0).DOShakePosition(animationTime-0.5f, strength: new Vector3(0, _shakeForce, 0), vibrato: 3, randomness: 1, snapping: false, fadeOut: true);
            Invoke("EndLevelFromCellBehavior", animationTime);
        }
        else
        {
            transform.GetChild(0).DOShakePosition(2.0f, strength: new Vector3(_shakeForce, 0, 0), vibrato: 3, randomness: 1, snapping: false, fadeOut: true);
        }
    }

    public void EndLevelFromCellBehavior()
    {
        _cellSpawner.EndLevel();
    }
}