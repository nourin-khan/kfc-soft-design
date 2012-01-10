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
            var db = new KFCDatabaseClassesDataContext(ServiceLibrary.Properties.ConnectionSettings.ConnectionString);

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
                f.FoodStatus = info.FoodStatus;
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

            var db = new KFCDatabaseClassesDataContext(ServiceLibrary.Properties.ConnectionSettings.ConnectionString);
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

            var db = new KFCDatabaseClassesDataContext(ServiceLibrary.Properties.ConnectionSettings.ConnectionString);
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
            var db = new KFCDatabaseClassesDataContext(ServiceLibrary.Properties.ConnectionSettings.ConnectionString);
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
                    food.FoodStatus = info.FoodStatus;
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
            var db = new KFCDatabaseClassesDataContext(ServiceLibrary.Properties.ConnectionSettings.ConnectionString);
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
                        f.FoodStatus = food.FoodStatus.Value;
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
                        f.FoodStatus = food.FoodStatus.Value;
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

        public string getNewFoodId(string foodGroupId)
        {
             SQLConnection db = new SQLConnection();
             try
             {
                 string sqlQuery = "SELECT dbo.func_getFoodID('" + foodGroupId + "')";
                 DataTable data = db.ThucThiCauTruyVan_TraVeBang(sqlQuery);
                 return data.Rows[0][0].ToString();
             }
            catch(Exception ex)
             {
                 throw ex;
             }
        }

        public FoodDTO[] searchFood(FoodDTO foodDto)
        {
            SQLConnection db = new SQLConnection();
            try
            {
                string sqlQuery = "SELECT * FROM FOOD f WHERE f.FoodID like '%" + foodDto.FoodID + "%' and f.FoodName like N'%" + foodDto.FoodName + "%'";
                DataTable data = db.ThucThiCauTruyVan_TraVeBang(sqlQuery);
                if (!(data == null || data.Rows.Count == 0))
                {
                    FoodDTO[] list = new FoodDTO[data.Rows.Count];
                    for (int i = 0; i < data.Rows.Count; i++)
                    {
                        list[i] = new FoodDTO();
                        list[i].FoodID = data.Rows[i]["FoodID"].ToString();
                        list[i].FoodName = data.Rows[i]["FoodName"].ToString();
                        list[i].FoodPrice = int.Parse(data.Rows[i]["FoodPrice"].ToString());
                        list[i].FoodStatus = data.Rows[i]["FoodStatus"].ToString() == "True" ? true : false;
                        list[i].DiscountPrice = int.Parse(data.Rows[i]["DiscountPrice"].ToString());
                        list[i].Image = data.Rows[i]["Image"].ToString();
                        list[i].Description = data.Rows[i]["Description"].ToString();
                        list[i].FoodGroupID = data.Rows[i]["FoodGroupID"].ToString();
                    }
                    return list;
                }
                else
                    return null;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }
    }
}
