with SrcRows AS ( 
	SELECT NumberRow
	FROM (VALUES (1),(2),(3),(4),(5),(6),(7),(8),(9),(10)) AS SR (NumberRow)
   ) 
   INSERT Category (Category)
   select 'Size' + CAST(Id AS nvarchar(max)) AS Category
	FROM (SELECT ROW_NUMBER() OVER (ORDER BY (SELECT 1)) AS Id 
		  FROM SrcRows AS Ten, 
			   SrcRows AS Hundred
		  )  AS ResultingRows;
		  