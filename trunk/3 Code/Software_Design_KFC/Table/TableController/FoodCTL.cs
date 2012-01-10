using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using TableController.KfcService;
using System.ServiceModel;
using System.Data;
using TableController.KfcService;


namespace TableController
{
    public class FoodCTL
    {
        /*
         * Description: view information of food
         * Input: FoodDTO - some information of food, string - foodId
         * Output: list of food information
         * Author:
         * Note:
         */
        public FoodDTO[] viewFoodInfo(FoodDTO foodInfo)
        {
            return null;
        }
        public FoodDTO[] viewFoodInfo(string foodID)
        {
            return null;
        }

        public FoodDTO[] getFoodGroup(string foodGroupName = null)
        {
            try
            {
                if (foodGroupName == null) // get all food
                {
                    ServiceClient wsClient = ConnectionCTL.connectWebService();
                    return wsClient.SelectFoodByDTO(null);                    
                } 
                else
                {
                    return null;
                }
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }
    }
}
