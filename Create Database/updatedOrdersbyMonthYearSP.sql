USE [BATZ]
GO
/****** Object:  StoredProcedure [dbo].[SalesByMonthYear]    Script Date: 12/7/2016 1:56:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[SalesByMonthYear]
AS BEGIN
Select Year(Orders.OrderDate) AS SalesYear, Month(Orders.OrderDate) AS SalesMonth, SUM(Orders.Quantity * Products.Price) as MoneyMade
from Orders 
inner join Products
on Orders.ProductId = Products.ProductId
GROUP BY Year(Orders.OrderDate), Month(Orders.OrderDate) ORDER BY Year(Orders.OrderDate), Month(Orders.OrderDate)
END

