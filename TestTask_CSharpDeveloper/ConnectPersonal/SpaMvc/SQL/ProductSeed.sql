with SrcRows AS ( 
	SELECT NumberRow
	FROM (VALUES (1),(2),(3),(4),(5),(6),(7),(8),(9),(10)) AS SR (NumberRow)
   ) 
   INSERT Products (Product, Descriptions, Cost, Color)
	Select 'T-Shirt' + CAST(Id AS nvarchar(max)) AS Product,
		'Cool t-shirt' + Cast(Id as nvarchar(100)) as Descriptions,
	 Id as Cost,
	 'White' + CAST(Id as nvarchar(15)) as Color
	 
	FROM (SELECT ROW_NUMBER() OVER (ORDER BY (SELECT 1)) AS Id 
		  FROM SrcRows AS Ten, 
			   SrcRows AS Hundred,
			   SrcRows AS Thousand, 
			   SrcRows AS TenThousand, 
			   SrcRows AS HundredThousand,
			   SrcRows AS Million
		  )  AS ResultingRows; 