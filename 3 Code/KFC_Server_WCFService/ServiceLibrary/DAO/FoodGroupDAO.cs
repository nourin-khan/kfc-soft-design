using System;
using System.ComponentModel;
using DTO;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Collections.Generic;

namespace ServiceLibrary
{
    public class FoodGroupDAO
    {

        /* 
        * Description: add new foodGroup to database
        * Input: FoodGroupDTO - foodGroup object
        * Output: int - number of rows affected
        * Author:
        */
        public bool insert(FoodGroupDTO info)
        {
            bool successfull = false;
            var db = new KFCDatabaseClassesDataContext(ServiceLibrary.Properties.ConnectionSettings.ConnectionString);
            try
            {
                FOOD_GROUP foodGrp = new FOOD_GROUP();
                foodGrp.FoodGroupID = info.FoodGroupID;
                foodGrp.FoodGroupName = info.FoodGroupName;
                db.FOOD_GROUPs.InsertOnSubmit(foodGrp);
                db.SubmitChanges();
                successfull = true;
            }
            catch
            {
            	successfull = false;
            }
            return successfull;
        }

        /* 
        * Description: delete foodGroup, commit to database
        * Input: FoodGroupDTO - foodGroup object, or foodGroupID
        * Output: int - number of rows affected
        * Author:
        */
        public bool delete(FoodGroupDTO info)
        {
            bool successfull = false;
            var db = new KFCDatabaseClassesDataContext(ServiceLibrary.Properties.ConnectionSettings.ConnectionString);
            try
            {
                var foodGrp = db.FOOD_GROUPs.SingleOrDefault(f => f.FoodGroupID == info.FoodGroupID);
                if (foodGrp != null)
                {
                    db.FOOD_GROUPs.DeleteOnSubmit(foodGrp);
                    db.SubmitChanges();
                    successfull = true;
                } 
                else
                {
                    successfull = false;
                }
            }
            catch
            {
            	successfull = false;
            }
            return successfull;
        }

        public bool delete(string foodGroupID)
        {
            bool successfull = false;
            var db = new KFCDatabaseClassesDataContext(ServiceLibrary.Properties.ConnectionSettings.ConnectionString);
            try
            {
                var foodGrp = db.FOOD_GROUPs.SingleOrDefault(f => f.FoodGroupID == foodGroupID);
                if (foodGrp != null)
                {
                    db.FOOD_GROUPs.DeleteOnSubmit(foodGrp);
                    db.SubmitChanges();
                    successfull = true;
                } 
                else
                {
                    successfull = false;
                }
            }
            catch
            {
            	successfull = false;
            }
            return successfull;
        }

        /* 
        * Description: update new information of foodGroup into database
        * Input: @ oldInfo - foodGroup obj with old information (old foodGroupID)
         *       @ newInfo - new information
         *       @ oldFoodGroupID - old foodGroupID
        * Output: int - number of rows affected
        * Author:
        */
        public bool update(FoodGroupDTO info)
        {
            bool successfull = false;
            var db = new KFCDatabaseClassesDataContext(ServiceLibrary.Properties.ConnectionSettings.ConnectionString);
            try
            {
                var foodGrp = db.FOOD_GROUPs.SingleOrDefault(f => f.FoodGroupID == info.FoodGroupID);
                if (foodGrp != null)
                {
                    foodGrp.FoodGroupID = info.FoodGroupName;
                    db.SubmitChanges();
                    successfull = true;
                } 
                else
                {
                    successfull = false;
                }
            }
            catch
            {
            	successfull = false;
            }
            return successfull;
        }
       

        /* 
         * Description: select list of foodGroup, or one foodGroup information
         * Input: @foodGroupDTO - foodGroup obj, null when you want to select all foodGroup
         *          @foodGroupID
         * Output: FoodGroupDTO[] - list of foodGroup satisfied the requirement
         * Author:
         */
        public FoodGroupDTO[] selectInfo(FoodGroupDTO info = null)
        {
            var db = new KFCDatabaseClassesDataContext(ServiceLibrary.Properties.ConnectionSettings.ConnectionString);
            try
            {
                if (info == null)
                {
                    var allGroups = db.FOOD_GROUPs;
                    List<FoodGroupDTO> groups = new List<FoodGroupDTO>();
                    foreach(var g in allGroups)
                    {
                        FoodGroupDTO foodGrp = new FoodGroupDTO(g.FoodGroupID, g.FoodGroupName);
                        groups.Add(foodGrp);
                    }
                    return groups.ToArray();
                } 
                else
                {
                    List<FoodGroupDTO> groups = new List<FoodGroupDTO>();
                    var g = db.FOOD_GROUPs.SingleOrDefault(f => f.FoodGroupID == info.FoodGroupID);
                    FoodGroupDTO foodGrp = new FoodGroupDTO(g.FoodGroupID, g.FoodGroupName);
                    groups.Add(foodGrp);
                    return groups.ToArray();
                }
            }
            catch
            {
            	return null;
            }
        }

        public FoodGroupDTO[] selectInfo(string foodGroupID)
        {
            return selectInfo(new FoodGroupDTO(foodGroupID, string.Empty));
        }
    }

}
