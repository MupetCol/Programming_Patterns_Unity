using UnityEngine;

namespace GPP
{
    public class Reseller : MonoBehaviour
    {
        [SerializeField] private InventoryUI inventory;
        public void ResellInventory()
        {
            foreach (var item in inventory.itemsOwned) {
                item.unitsOwned = 0;
                // add value to players coin
                // CREATE TRADE ITEM SCRIPTABLE OBJECT
                // reset inventory ui
            }
        }
    }
}