using UnityEngine;

[CreateAssetMenu(fileName = "Item Type", menuName = "Item Type")]
public class ItemType : ScriptableObject
{
    [SerializeField]Sprite _icon;

    public Sprite Icon
    {
        get { return _icon; }
    }
}