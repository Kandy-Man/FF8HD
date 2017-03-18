using UnityEngine;

[System.Serializable]
public class CharacterRecord
{
    [SerializeField]string _name;
    [SerializeField]int _level;
    [SerializeField]AnimationCurve _baseHP; //before junction alterations
    [SerializeField]AnimationCurve _strength;
    [SerializeField]AnimationCurve _vitality;
    [SerializeField]AnimationCurve _magic;
    [SerializeField]AnimationCurve _spirit;
    [SerializeField]AnimationCurve _speed;
    [SerializeField]AnimationCurve _luck;
    [SerializeField]int _hpBonus;
    [SerializeField]int _strengthBonus;
    [SerializeField]int _vitalityBonus;
    [SerializeField]int _magicBonus;
    [SerializeField]int _spiritBonus;
    [SerializeField]int _speedBonus;
    [SerializeField]int _luckBonus;
    [SerializeField] Weapon _equippedWeapon;
    //[SerializeField] LimitBreak[] _limitBreaks;
    [SerializeField]int _numberOfKills;
    [SerializeField]int _currentHP;
    [SerializeField]int _maxHP;  //after junction alterations
    [SerializeField]int _currentEXP;
    [SerializeField]int _expToNextLevel;

    public string Name
    {
        get { return _name; }
    }
    public int Level
    {
        get { return _level; }
    }
    public int BaseHP
    {
        get { return Mathf.FloorToInt(_baseHP.Evaluate(_level)); }
    }
    public int Strength
    {
        get { return Mathf.FloorToInt(_strengthBonus + _strength.Evaluate(_level) + _equippedWeapon.Strength); }
    }
    public int Vitality
    {
        get { return Mathf.FloorToInt(_vitalityBonus + _vitality.Evaluate(_level)); }
    }
    public int Magic
    {
        get { return Mathf.FloorToInt(_magicBonus + _magic.Evaluate(_level)); }
    }
    public int Spirit
    {
        get { return Mathf.FloorToInt(_spiritBonus + _spirit.Evaluate(_level)); }
    }
    public int Speed
    {
        get { return Mathf.FloorToInt(_speedBonus + _speed.Evaluate(_level)); }
    }
    public int Luck
    {
        get { return Mathf.FloorToInt(_luckBonus + _luck.Evaluate(_level)); }
    }
    public int HpBonus
    {
        get { return _hpBonus; }
    }
    public int StrengthBonus
    {
        get { return _strengthBonus; }
    }
    public int VitalityBonus
    {
        get { return _vitalityBonus; }
    }
    public int MagicBonus
    {
        get { return _magicBonus; }
    }
    public int SpiritBonus
    {
        get { return _spiritBonus; }
    }
    public int SpeedBonus
    {
        get { return _speedBonus; }
    }
    public int LuckBonus
    {
        get { return _luckBonus; }
    }
    public Weapon EquippedWeapon
    {
        get { return _equippedWeapon; }
    }
    //public LimitBreak[] LimitBreaks
    //{
    //    get { return _limitBreaks; }
    //}
    public int NumberOfKills
    {
        get { return _numberOfKills; }
    }
    public int CurrentHP
    {
        get { return _currentHP; }
    }
    public int MaxHP
    {
        get { return _maxHP; }
    }
    public int CurrentEXP
    {
        get { return _currentEXP; }
    }
    public int ExpToNextLevel
    {
        get { return _expToNextLevel; }
    }
}