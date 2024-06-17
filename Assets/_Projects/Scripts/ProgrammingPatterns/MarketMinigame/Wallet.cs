using System.Collections.Generic;
using UnityEngine;

namespace GPP
{
    public class Wallet : MonoBehaviour
    {    
        public Stack<float> gasExpenses = new Stack<float>();  
        public Stack<float> shopExpenses = new Stack<float>();  
        

        private ProfitVisuals profitVisualsHandler;

        private float GasTotal(){
            var total = 0f;
            foreach(var item in gasExpenses){
                total += item;
            }
            return total;
        }

        private float ShopTotal(){
            var total = 0f;
            foreach(var item in shopExpenses){
                total += item;
            }
            return total;
        }

        private void Awake(){
            profitVisualsHandler = FindObjectOfType<ProfitVisuals>();
        }
        
        public void BuyItem(float bill)
        {
            shopExpenses.Push(bill);
            profitVisualsHandler.UpdateVisuals(GasTotal(), ShopTotal());
        }

        public void PayGas(float bill)
        {
            gasExpenses.Push(bill);
            profitVisualsHandler.UpdateVisuals(GasTotal(), ShopTotal());
        }

        public void ReturnItem(){

            //DEPENDING ON THE COMMAND POP OF A SPECIFIC STACK AND UPDATE PROFIT VISUALS
            shopExpenses.Pop();
        }

        public void ReturnGas(){

            //DEPENDING ON THE COMMAND POP OF A SPECIFIC STACK AND UPDATE PROFIT VISUALS
            gasExpenses.Pop();
        }
    }
}