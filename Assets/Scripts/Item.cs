using UnityEngine;

[System.Serializable]
public class Item
{
    [SerializeField]string _name;
    [SerializeField]string _description;
    [SerializeField]int _cost;
    [SerializeField]ItemType _type;
    [SerializeField]ItemAttackTarget _attackTarget;

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

    /*
     * each item contains: 
     *      restriction mask(
     *          Appears in Item Menu. Does not appear in Battle Menu (Not usable at all);
     *          Appears in Battle Menu & Item Menu (Not usable at all);
     *          Appears in Item Menu. Does not appear in Battle Menu (Usable in Battle Menu);
     *          Appears in Battle Menu & Item Menu (Usable in Battle Menu);
     *          Appears in Item Menu. Does not appear in Battle Menu (Usable in Item Menu);
     *          Appears in Battle Menu & Item Menu (Usable in Item Menu);
     *          Appears in Item Menu. Does not appear in Battle Menu (Usable in Item Menu & Battle Menu);
     *          Appears in Battle Menu & Item Menu (Usable in Item Menu & Battle Menu);
     *          Appears in Item Menu. Does not appear in Battle Menu (Usable in Battle Menu);
     *          Appears in Battle Menu & Item Menu (Usable in Battle Menu)),
     *      
     *      restore apply(
     *          damage/restore by value,
     *          damage/restore by %,
     *          causes damage,
     *          affects stats,
     *          none),
     *          
     *      status effects,
     *      element
    */
}

public enum ItemAttackTarget
{
    ONE_TARGET,
    MULTIPLE_TARGETS,
    PARTY_ONLY
}