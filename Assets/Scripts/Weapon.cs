using UnityEngine;

[System.Serializable]
public class Weapon
{
    [SerializeField]string _name;
    [SerializeField]Sprite _icon;
    [SerializeField]int _strength;
    [SerializeField]int _hitRate;
    [SerializeField]int _cost;
    [SerializeField]Item[] _itemsRequired;
    [SerializeField]GameObject _model;
    [SerializeField]EquipMask _equipableCharacter;
    [SerializeField]GameObject _hitParticleSystem;
    [SerializeField]GameObject _hitCriticalParticleSystem;

    public string Name
    {
        get { return _name; }
    }
    public Sprite Icon
    {
        get { return _icon; }
    }
    public int Strength
    {
        get { return _strength; }
    }
    public int HitRate
    {
        get { return _hitRate; }
    }
    public int Cost
    {
        get { return _cost; }
    }
    public Item[] ItemsRequired
    {
        get { return _itemsRequired; }
    }
    public GameObject Model
    {
        get { return _model; }
    }
    public EquipMask EquipableCharacter
    {
        get { return _equipableCharacter; }
    }
    public GameObject HitParticleSystem
    {
        get { return _hitParticleSystem; }
    }
    public GameObject HitCriticalParticleSystem
    {
        get { return _hitCriticalParticleSystem; }
    }
}