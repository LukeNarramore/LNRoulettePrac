USE [NorthWind]
GO

/*
Return a summary of orders
*/
CREATE OR ALTER PROCEDURE dbo.pr_GetOrderSummary
(
    @StartDate DATE,
    @EndDate DATE,
    @EmployeeID INT = NULL,
    @CustomerID NVARCHAR(30) = NULL
)
AS
BEGIN

    SELECT CONCAT(MAX(E.TitleOfCourtesy), ' ', MAX(E.FirstName), ' ', MAX(E.LastName)) [EmployeeFullName],
           MAX(S.CompanyName) [Shipper CompanyName],
           MAX(C.CompanyName) [Customer CompanyName],
           COUNT(O.OrderId) [NumberOfOders],
           O.OrderDate [Date],
           SUM(O.Freight) [TotalFreightCost],
           COUNT(DISTINCT OD.ProductID) [NumberOfDifferentProducts],
           SUM(CONVERT(DECIMAL(14, 2), OD.Quantity * (1 - OD.Discount) * OD.UnitPrice)) [TotalOrderValue]
    FROM dbo.[Orders] O
        INNER JOIN dbo.[Order Details] OD
            ON O.OrderId = OD.OrderID
        INNER JOIN dbo.[Customers] C
            ON O.CustomerID = C.CustomerID
        INNER JOIN dbo.Employees E
            ON O.EmployeeID = E.EmployeeID
        INNER JOIN dbo.Shippers S
            ON O.ShipVia = S.ShipperID
    WHERE O.OrderDate
          BETWEEN @StartDate AND @EndDate
          AND
          (
              @EmployeeID IS NULL
              OR @EmployeeID = O.EmployeeID
          )
          AND
          (
              @CustomerID IS NULL
              OR @CustomerID = O.CustomerID
          )
    GROUP BY O.OrderDate,
             O.EmployeeID,
             O.CustomerID,
             O.ShipVia

END



GO
