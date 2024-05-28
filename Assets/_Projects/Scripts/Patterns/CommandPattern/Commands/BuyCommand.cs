using UnityEngine;

namespace GPP
{
    public class BuyCommand : Command
    {     
        public enum PurchaseType {Gas, Item};
        private Wallet _wallet;
        private int _cost;
        private int _purchaseType;

        public BuyCommand(Wallet wallet, int cost, int purchaseType)
        {
            _wallet = wallet;
            _cost = cost;
            _purchaseType = purchaseType;
        }

        public override void Execute()
        {
            switch(_purchaseType){
                case(int)PurchaseType.Gas:
                _wallet.PayGas(_cost);
                break;
                
                case(int)PurchaseType.Item:
                _wallet.BuyItem(_cost);
                break;

                default:
                break;
            }
        }

        public override void Undo()
        {
            switch(_purchaseType){
                case(int)PurchaseType.Gas:
                _wallet.ReturnGas();
                break;
                
                case(int)PurchaseType.Item:
                _wallet.ReturnItem();
                break;

                default:
                break;
            }
        }
    }
}