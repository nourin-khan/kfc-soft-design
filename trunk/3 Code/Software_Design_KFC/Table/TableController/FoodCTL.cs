using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TableController.KfcService;
using System.ServiceModel;


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
            ServiceClient wsClient = ConnectionCTL.connectWebService();
            try
            {
                if (foodGroupName == null) // get all food
                {
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
