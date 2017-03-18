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
    //[SerializeField] Weapon _equippedWeapon;
    //[SerializeField] LimitBreak[] _limitBreaks;
    [SerializeField]int _numberOfKills;
    [SerializeField]int _currentHP;
    [SerializeField]int _baseHP; //before junction alterations
    [SerializeField]int _maxHP;  //after junction alterations
    [SerializeField]int _currentEXP;
    [SerializeField]int _expToNextLevel;
}