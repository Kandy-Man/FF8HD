using UnityEngine;

[System.Serializable]
public class CharacterRecord
{
    [SerializeField]string _name;
    [SerializeField]int _level;
    [SerializeField]int _strength;
    [SerializeField]int _vitality;
    [SerializeField]int _magic;
    [SerializeField]int _spirit;
    [SerializeField]int _speed;
    [SerializeField]int _luck;
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
    [SerializeField]int _baseHP; //before junction alterations
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
    public int Strength
    {
        get { return _strength; }
    }
    public int Vitality
    {
        get { return _vitality; }
    }
    public int Magic
    {
        get { return _magic; }
    }
    public int Spirit
    {
        get { return _spirit; }
    }
    public int Speed
    {
        get { return _speed; }
    }
    public int Luck
    {
        get { return _luck; }
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
    public int BaseHP
    {
        get { return _baseHP; }
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