SELECT CONCAT(c.FirstName, ' ', c.LastName) as 'Full Name',
	   c.Age,
	   o.OrderID,
	   o.DataCreated,
	   o.MethodOfPurchase as 'Purchase Method',
	   od.ProductNumber,
	   od.ProductOrigin
  FROM OrdersDetail od
 INNER JOIN Orders o
    ON o.OrderId = od.OrderID
 INNER JOIN Customers c
    ON c.PersonId = o.PersonID
 WHERE od.ProductId = 1112222333
  