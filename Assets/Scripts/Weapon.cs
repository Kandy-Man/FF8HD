using UnityEngine;

[System.Serializable]
public class Weapon
{
    [SerializeField]string _name;
    [SerializeField]Sprite _portrait;
    [SerializeField]int _strength;
    [SerializeField]int _hitRate;
    [SerializeField]int _cost;
    //[SerializeField]Item[] _itemsRequired;
}