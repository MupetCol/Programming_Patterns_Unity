using TMPro;
using UnityEngine;

namespace GPP
{
    public class ProfitVisuals : MonoBehaviour
    {    
        // Visual add operation 
        public TMP_Text walletText, expensesText, gasText, totalText; 

        // Level Goal "Resell Profit / Goal Text" Use tmp colors 
        public TMP_Text goalText;
        private void Awake()
        {

        }

        public void UpdateVisuals(float gasBill, float shopBill){

        }
    }
}