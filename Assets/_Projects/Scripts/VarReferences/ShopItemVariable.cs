using UnityEngine;

namespace GPP
{
    [CreateAssetMenu(menuName = "Variables/ShopItem", fileName = "Item")]
    public class ShopItemVariable : Variable<ShopItemData> { }

    [System.Serializable]
    public class ShopItemReference : VariableReference<ShopItemData> { }
}