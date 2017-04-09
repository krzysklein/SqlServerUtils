CREATE FUNCTION IntRange
(	
	@minValue INT,
	@maxValue INT
)
RETURNS TABLE (intValue INT)
EXTERNAL NAME SqlServerUtils.[SqlServerUtils.Numerics].IntRange
GO
