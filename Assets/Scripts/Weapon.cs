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

    /*
        each weapon contains: 
            equip mask (equipable on 'specific character'),
            attack texture graphics (could be particle system or something in unity, will need one for critical too),
            restriction mask (
                Appears in Item Menu. Does not appear in Battle Menu (Not usable at all);
                Appears in Battle Menu & Item Menu (Not usable at all);
                Appears in Item Menu. Does not appear in Battle Menu (Usable in Battle Menu);
                Appears in Battle Menu & Item Menu (Usable in Battle Menu);
                Appears in Item Menu. Does not appear in Battle Menu (Usable in Item Menu);
                Appears in Battle Menu & Item Menu (Usable in Item Menu);
                Appears in Item Menu. Does not appear in Battle Menu (Usable in Item Menu & Battle Menu);
                Appears in Battle Menu & Item Menu (Usable in Item Menu & Battle Menu);
                Appears in Item Menu. Does not appear in Battle Menu (Usable in Battle Menu);
                Appears in Battle Menu & Item Menu (Usable in Battle Menu);
            ) 
    */
}