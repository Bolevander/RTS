using UnityEngine;

public class MainBuilding : MonoBehaviour, IUnitProducer, ISelectable
{
    [SerializeField] private GameObject _unitPrefab;
    [SerializeField] private Transform _unitParent;

    [SerializeField] private float _maxHealth = 1000;
    [SerializeField] private Sprite _icon;
    [SerializeField] private string _name;
    [SerializeField] private Material _material;
    [SerializeField] private MeshRenderer[] _meshRenderers;

    private float _health = 1000;

    public float Health => _health;

    public float MaxHealth => _maxHealth;

    public Sprite Icon => _icon;

    public string Name => _name;

    public Material MaterialSellection => _material;

    public MeshRenderer[] MeshRenderers => _meshRenderers;

    public void ProduceUnit()
    {
        Instantiate(_unitPrefab, new Vector3(_unitParent.position.x + Random.Range(1, 3), _unitParent.position.y,
            _unitParent.position.z + Random.Range(1, 3)), Quaternion.identity, _unitParent);
    }
}
