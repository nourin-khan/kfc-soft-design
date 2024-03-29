USE KFC_DB5
GO

--table FOOD_GROUP
INSERT INTO FOOD_GROUP( FoodGroupID, FoodGroupName )
VALUES  ('00001',N'Gà rán truyền thống')
INSERT INTO FOOD_GROUP( FoodGroupID, FoodGroupName )
VALUES  ('00002', N'Phần ăn Combo')
INSERT INTO FOOD_GROUP( FoodGroupID, FoodGroupName )
VALUES  ('00003', N'Thức ăn nhẹ')
INSERT INTO FOOD_GROUP( FoodGroupID, FoodGroupName )
VALUES  ('00004', N'Thức ăn phụ')
INSERT INTO FOOD_GROUP( FoodGroupID, FoodGroupName )
VALUES  ('00005', N'Món tráng miệng - Giải khát')
INSERT INTO FOOD_GROUP( FoodGroupID, FoodGroupName )
VALUES  ('00006', N'Phần ăn cho trẻ em')
GO

INSERT INTO FOOD( FoodID ,FoodName ,FoodStatus, FoodPrice , DiscountPrice ,Image ,Description ,FoodGroupID)
VALUES('10001',N'1 MIẾNG' ,1, 28000 ,0 ,'/Ga_ran_truyen_thong/1_mieng.png' ,N'1 pc' ,'00001')
INSERT INTO FOOD( FoodID ,FoodName ,FoodStatus, FoodPrice , DiscountPrice ,Image ,Description ,FoodGroupID)
VALUES('10002', N'3 MIẾNG',1, 79000,0, '/Ga_ran_truyen_thong/3_mieng.png',N'1 pc','00001')
INSERT INTO FOOD( FoodID ,FoodName ,FoodStatus, FoodPrice , DiscountPrice ,Image ,Description ,FoodGroupID)
VALUES('10003', N'10 MIẾNG',1, 254000, 0, '/Ga_ran_truyen_thong/10_mieng.png',N'1 pc' , '00001')
INSERT INTO FOOD( FoodID ,FoodName ,FoodStatus, FoodPrice , DiscountPrice ,Image ,Description ,FoodGroupID)
VALUES('20001', N'COMBO GÀ TRUYỀN THỐNG A',1, 69000, 0, '/Phan_an_combo/Combo_ga_truyen_thong_a.png', N'2 miếng Gà Truyền thống + 1 Khoai Tây Chiên(vừa) + 1 Pepsi(vừa)', '00002')
INSERT INTO FOOD( FoodID ,FoodName ,FoodStatus, FoodPrice , DiscountPrice ,Image ,Description ,FoodGroupID)
VALUES('20002', N'COMBO GÀ TRUYỀN THỐNG B',1, 69000, 0, '/Phan_an_combo/Combo_ga_truyen_thong_b.png', N'2 miếng Gà Truyền thống + 1 Khoai Tây Chiên(vừa) + 1 Bắp Cải Trộn KFC', '00002')
INSERT INTO FOOD( FoodID ,FoodName ,FoodStatus, FoodPrice , DiscountPrice ,Image ,Description ,FoodGroupID)
VALUES('20003', N'COMBO CÁNH GÀ FLAVA ROAST',1, 72000, 0, '/Phan_an_combo/Combo_canh_ga_flava_roast.png', N'2 miếng Cánh Gà Flava Roast + 1 Khoai Tây Chiên(vừa) + 1 Pepsi(vừa)','00002')
INSERT INTO FOOD( FoodID ,FoodName ,FoodStatus, FoodPrice , DiscountPrice ,Image ,Description ,FoodGroupID)
VALUES('20004', N'COMBO GÀ GIÒN KHÔNG XƯƠNG',1, 56000, 0, '/Phan_an_combo/Combo_ga_gion_khong_xuong.png', N'3 miếng Gà Giòn Không Xương + 1 Khoai Tây Chiên + 1 Pepsi(vừa)', '00002')

INSERT INTO FOOD( FoodID ,FoodName ,FoodPrice ,DiscountPrice ,Image ,Description ,FoodGroupID)
VALUES('20005', N'COMBO GÀ GIÒN CAY A', 69000, 0, '/Phan_an_combo/Combo_ga_gion_cay_a.png', N'2 miếng Gà Truyền Thống + 1 Khoai Tây Chiên (vừa) + 1 Pepsi (vừa)', '00002')

INSERT INTO FOOD( FoodID ,FoodName ,FoodPrice ,DiscountPrice ,Image ,Description ,FoodGroupID)
VALUES('20006', N'COMBO GÀ GIÒN CAY B', 69000, 0, '/Phan_an_combo/Combo_ga_gion_cay_b.png', N'2 miếng Gà Giòn Cay + 1 Khoai Tây Nghiền (vừa) + 1 Bắp Cải Trộn KFC (vừa) + 1 Bánh Mì Mềm + 1 Pepsi', '00002')

INSERT INTO FOOD( FoodID ,FoodName ,FoodPrice ,DiscountPrice ,Image ,Description ,FoodGroupID)
VALUES('20007', N'COMBO ShareNjoy A', 205000, 0, '/Phan_an_combo/Combo_sharenjoy_a.png',N'3 miếng Gà Giòn Cay + 3 miếng Gà Truyền Thống + 1 Khoai Tây Nghiền' ,'00002')

INSERT INTO FOOD( FoodID ,FoodName ,FoodPrice ,DiscountPrice ,Image ,Description ,FoodGroupID)
VALUES('20008', N'COMBO ShareNjoy B', 132000, 0, '/Phan_an_combo/Combo_sharenjoy_b.png',N'2 miếng Gà Giòn Cay + 2 miếng Gà Truyền Thống + 1 Khoai Tây Chiên' ,'00002')

INSERT INTO FOOD( FoodID ,FoodName ,FoodPrice ,DiscountPrice ,Image ,Description ,FoodGroupID)
VALUES('20009', N'CƠM GÀ KFC', 53000, 0, '/Phan_an_combo/Com_ga_kfc.png', N'1 Cơm Gà KFC + 1 Súp Gà Ngũ Sắc + 1 Pepsi (vừa)', '00002')

INSERT INTO FOOD( FoodID ,FoodName ,FoodPrice ,DiscountPrice ,Image ,Description ,FoodGroupID)
VALUES('20010', N'CƠM GÀ FLAVA ROAST', 53000, 0, '/Phan_an_combo/Com_ga_flava_roast.png', N'1 Cơm Gà Flava Roast + 1 Súp Gà Ngũ Sắc + 1 Pepsi (vừa)', '00002')


INSERT INTO FOOD( FoodID ,FoodName ,FoodPrice ,DiscountPrice ,Image ,Description ,FoodGroupID)
VALUES('30001', N'GÀ POPCORN KFC(vừa)', 33000, 0, '/Thuc_an_nhe/Ga_popcorn_kfc_vua.png',N'Vừa' , '00003')
INSERT INTO FOOD( FoodID ,FoodName ,FoodPrice ,DiscountPrice ,Image ,Description ,FoodGroupID)
VALUES('30002', N'HAM-BƠ-GƠ TÔM',42000, 0, '/Thuc_an_nhe/Hambogo_tom.png',N'1 pc' ,'00003' )
INSERT INTO FOOD( FoodID ,FoodName ,FoodPrice ,DiscountPrice ,Image ,Description ,FoodGroupID)
VALUES('40001', N'KHOAI TÂY CHIÊN(vừa)', 19000, 0, '/Thuc_an_phu/Khoai_tay_chien_vua.png', N'Vừa', '00004')
INSERT INTO FOOD( FoodID ,FoodName ,FoodPrice ,DiscountPrice ,Image ,Description ,FoodGroupID)
VALUES('40002', N'BẮP CẢI TRỘN(lớn)', 23000, 0, '/Thuc_an_phu/Bap_cai_tron_lon.png', N'Lớn', '00004')
INSERT INTO FOOD( FoodID ,FoodName ,FoodPrice ,DiscountPrice ,Image ,Description ,FoodGroupID)
VALUES('50001', N'KEM CONE KFC', 7000, 0, '/Mon_trang_mieng/Kem_cone_kfc.png', N'1 cây', '00005')
INSERT INTO FOOD( FoodID ,FoodName ,FoodPrice ,DiscountPrice ,Image ,Description ,FoodGroupID)
VALUES('50002', N'PEPSI', 17000, 0, '/Mon_trang_mieng/Pepsi_lon.png', N'Lớn', '00005')
INSERT INTO FOOD( FoodID ,FoodName ,FoodPrice ,DiscountPrice ,Image ,Description ,FoodGroupID)
VALUES('60001', N'CHICKY 01', 55000, 0, '/Phan_an_tre_em/Chicky_01.png', N'Snacker hải sản', '00006')
INSERT INTO FOOD( FoodID ,FoodName ,FoodPrice ,DiscountPrice ,Image ,Description ,FoodGroupID)
VALUES('60002', N'CHICKY 02', 55000, 0, 'Phan_an_tre_em/Chicky_02.png', N'Nuggets Cá', '00006')

go
INSERT INTO dbo.PERMISSION
        ( PositionID, Position, Permission )
VALUES  ( '00001', -- PositionID - varchar(5)
          N'Quản lý', -- Position - nvarchar(100)
          'AllPermission'  -- Permission - varchar(100)
          )
INSERT INTO dbo.PERMISSION
        ( PositionID, Position, Permission )
VALUES  ( '00002', -- PositionID - varchar(5)
          N'Thu ngân', -- Position - nvarchar(100)
          'CashierPermission'  -- Permission - varchar(100)
          )
INSERT INTO dbo.PERMISSION
        ( PositionID, Position, Permission )
VALUES  ( '00003', -- PositionID - varchar(5)
          N'Đầu bêp', -- Position - nvarchar(100)
          'KitchenPermission'  -- Permission - varchar(100)
          )              
INSERT INTO dbo.PERMISSION
        ( PositionID, Position, Permission )
VALUES  ( '00004', -- PositionID - varchar(5)
          N'Bồi bàn', -- Position - nvarchar(100)
          'NoPermission'  -- Permission - varchar(100)
          )                    
          
go
CREATE FUNCTION func_getFoodID(@foodGroupID varchar(5))
RETURNS varchar(5)
AS
begin
DECLARE @numFood INT;
DECLARE @foodID VARCHAR(5);
SELECT @numFood = COUNT(f.FoodID)
FROM dbo.FOOD f
WHERE f.FoodGroupID = @foodGroupID;
SELECT @foodID = CAST(((CAST(@foodGroupID AS INT))*10000 + @numFood + 1) AS VARCHAR(5))
RETURN @foodID
END
go