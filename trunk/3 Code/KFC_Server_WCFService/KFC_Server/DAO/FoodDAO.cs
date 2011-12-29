using System;
using System.ComponentModel;
using DTO;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace ServiceLibrary
{
    public class FoodDAO 
    {
        /* 
        * Description: add new food to database
        * Input: FoodDTO - food object
        * Output: true : successfull and vice versa
        * Author: vantuanlee@gmail.com
        */
        public bool insert(FoodDTO info)
        {
            bool successfull = false;
            var db = new KFCDatabaseClassesDataContext(ServiceLibrary.Properties.Settings.connectionString);

            try
            {
                FOOD f = new FOOD();
                f.FoodName = info.FoodName;
                f.FoodPrice = (int)info.FoodPrice;
                f.FoodID = info.FoodID;
                f.Image = info.Image;
                f.Description = info.Description;
                f.DiscountPrice = (int)info.DiscountPrice;
                f.FoodGroupID = info.FoodGroupID;
                db.FOODs.InsertOnSubmit(f);
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
        * Description: delete food, commit to database
        * Input: FoodDTO - food object, or foodID
        * Output: true : successfull and vice versa
        * Author: vantuanlee@gmail.com
        */
        public bool delete(FoodDTO info)
        {
            bool successfull = false;

            var db = new KFCDatabaseClassesDataContext(ServiceLibrary.Properties.Settings.connectionString);
            try
            {
                FOOD food = db.FOODs.Single(f => f.FoodID == info.FoodID);
                if (food != null)
                {
                    // mark the food for deletion
                    db.FOODs.DeleteOnSubmit(food);
                    db.SubmitChanges();

                    successfull = true;
                }
            }
            catch 
            {
                successfull = false;
            }
            return successfull;
        }

        public bool delete(string foodID)
        {
            bool successfull = false;

            var db = new KFCDatabaseClassesDataContext(ServiceLibrary.Properties.Settings.connectionString);
            try
            {
                FOOD food = db.FOODs.Single(f => f.FoodID == foodID);
                if (food != null)
                {
                    // mark the food for deletion
                    db.FOODs.DeleteOnSubmit(food);
                    db.SubmitChanges();

                    successfull = true;
                }
            }
            catch
            {
                successfull = false;
            }
            return successfull;
        }

        /* 
        * Description: update new information of food into database
        * Input: @ oldInfo - food obj with old information (old foodID)
         *       @ newInfo - new information
         *       @ oldFoodID - old foodID
        * Output: true : successfull and vice versa
        * Author: vantuanlee@gmail.com
        */
        public bool update(FoodDTO info)
        {
            bool successfull = false;
            var db = new KFCDatabaseClassesDataContext(ServiceLibrary.Properties.Settings.connectionString);
            try
            {
                var food = db.FOODs.SingleOrDefault(f => f.FoodID == info.FoodID);
                if (food != null)
                {
                    food.FoodName = info.FoodName;
                    food.FoodPrice = (int)info.FoodPrice;
                    food.FoodID = info.FoodID;
                    food.Image = info.Image;
                    food.Description = info.Description;
                    food.DiscountPrice = (int)info.DiscountPrice;
                    food.FoodGroupID = info.FoodGroupID;

                    db.SubmitChanges();
                    successfull = true;
                }
            }
            catch
            {
                successfull = false;
            }
            return successfull;
        }
        /* 
         * Description: select list of food, or one food information
         * Input: @foodDTO - food obj, null when you want to select all food
         *          @foodID
         * Output: FoodDTO[] - list of food satisfied the requirement
         * Author: vantuanlee@gmail.com
         */
        public FoodDTO[] selectInfo(FoodDTO info)
        {
            var db = new KFCDatabaseClassesDataContext(ServiceLibrary.Properties.Settings.connectionString);
            try
            {
                if (info == null) // get all food
                {
                    var allFoods = db.FOODs;
                    List<FoodDTO> foods = new List<FoodDTO>();
                    foreach (var food in allFoods)
                    {
                        // new data
                        FoodDTO f = new FoodDTO();
                        f.FoodID = food.FoodID;
                        f.FoodName = food.FoodName;
                        f.FoodPrice = float.Parse(food.FoodPrice.ToString());
                        f.FoodGroupID = food.FoodGroupID;
                        f.DiscountPrice = float.Parse(food.DiscountPrice.ToString());
                        f.Image = food.Image;
                        f.Description = food.Description;
                        foods.Add(f);
                    }
                    return foods.ToArray();
                } 
                else
                {
                    var food = db.FOODs.SingleOrDefault(f => f.FoodID == info.FoodID);
                    if (food == null)
                    {
                        return null;
                    }
                    else
                    {
                        List<FoodDTO> foods = new List<FoodDTO>();
                        // new data
                        FoodDTO f = new FoodDTO();
                        f.FoodID = food.FoodID;
                        f.FoodName = food.FoodName;
                        f.FoodPrice = float.Parse(food.FoodPrice.ToString());
                        f.FoodGroupID = food.FoodGroupID;
                        f.DiscountPrice = float.Parse(food.DiscountPrice.ToString());
                        f.Image = food.Image;
                        f.Description = food.Description;
                        foods.Add(f);
                        return foods.ToArray();
                    }
                }
            }
            catch
            {
                return null;
            }
        }

        public FoodDTO[] selectInfo(string foodID)
        {
            return selectInfo(new FoodDTO(foodID));
        }
    }
}
