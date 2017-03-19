using UnityEngine;

[System.Serializable]
public class Item
{
    [SerializeField]string _name;
    [SerializeField]string _description;
    [SerializeField]int _cost;
    [SerializeField]ItemType _type;
    [SerializeField]ItemAttackTarget _attackTarget;
    [SerializeField]ItemRestrictionMask _restrictionMask;
    [SerializeField]ItemRestoreType _restoreType;
    [SerializeField]Element _elementType;
    [SerializeField]StatusEffect[] _statusEffects;

    public string Name
    {
        get { return _name; }
    }
    public string Description
    {
        get { return _description; }
    }
    public int Cost
    {
        get { return _cost; }
    }
    public ItemType Type
    {
        get { return _type; }
    }
    public ItemAttackTarget AttackTarget
    {
        get { return _attackTarget; }
    }
    public ItemRestrictionMask RestrictionMask
    {
        get { return _restrictionMask; }
    }
    public ItemRestoreType RestoreType
    {
        get { return _restoreType; }
    }
    public Element ElementType
    {
        get { return _elementType; }
    }
    public StatusEffect[] StatusEffects
    {
        get { return _statusEffects; }
    }

    /*
     * each item contains: 
     *      
     *      restore apply(
     *          damage/restore by value,
     *          damage/restore by %,
     *          causes damage,
     *          affects stats,
     *          none),
    */
}

public enum ItemAttackTarget
{
    ONE_TARGET,
    MULTIPLE_TARGETS,
    PARTY_ONLY
}

public enum ItemRestrictionMask
{
    UNUSABLE,
    USABLE_IN_ITEM_MENU,
    USABLE_IN_BATTLE_MENU,
    USABLE_IN_ITEM_AND_BATTLE_MENU
}

public enum ItemRestoreType
{
    NONE,
    HP,
    AILMENT
}