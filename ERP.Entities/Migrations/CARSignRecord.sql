USE [ERP]
GO
/****** Object:  StoredProcedure [dbo].[CARSignRecord]    Script Date: 7/31/2022 9:34:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[CARSignRecord]
	-- Add the parameters for the stored procedure here
	@TableName As nvarchar(50),
    @FieldCode As nvarchar(20),
    @RequestDate As nvarchar(10) = '', 
	@EmployeeId As int,
    @DeleteFlag As int,
    @Description As nvarchar(250)='',
	@OrderNoIN as int = 0,
	@SignDate As nvarchar(10),
    @ConfirmType As int = 0
AS
declare	
	@TableId As int = 0,
    @CartableID As float = 0,
	@CartableTraceId As int=0,
	@AdminUserId As int=0,
	@OrderNo as int = 0,
	@AdminRoleId As int=0,
	@YearMonthDay As nvarchar(100)='',
	@SignTime As nvarchar(100)= format(getdate(),'HH:mm:ss'),
	@sqlCommand As nvarchar(500)=''
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets From
	-- interfering with Select statements.
SET NOCOUNT ON;

Set @TableId = (Select Id From CARTables Where TableName = @TableName AND Status = 1)

IF @RequestDate = ''
BEGIN 
	Set @RequestDate = (Select Top 1 CARCartables.RequestDate From CARCartables INNER JOIN
                         CARCartableTraces ON CARCartables.CARCartableTraceId = CARCartableTraces.Id INNER JOIN
                         CARTables ON CARCartableTraces.CARTableId = CARTables.Id
		Where        CARTables.Id = @TableId AND CARCartables.FieldCode = @FieldCode AND CARCartables.Status = 1 AND CARCartableTraces.Status = 1)
END 

IF @OrderNoIN = 0
	BEGIN
		Set @OrderNo = (Select        CAST(ISNULL(MAX(CARCartableTraces.OrderNo), 0) AS decimal) AS MaxCode
		From            CARCartables INNER JOIN
                         CARCartableTraces ON CARCartables.CARCartableTraceId = CARCartableTraces.Id INNER JOIN
                         CARTables ON CARCartableTraces.CARTableId = CARTables.Id
		Where        CARTables.Id = @TableId AND CARCartables.FieldCode = @FieldCode AND CARCartables.RequestDate = @RequestDate AND CARCartables.Status = 1 AND CARCartableTraces.Status = 1)

	IF @DeleteFlag = 0 Set @OrderNo = @OrderNo + 1
END 
ELSE
BEGIN
	IF NOT EXISTS (Select * From CARCartableTraces Where OrderNo = @OrderNoIN AND CARTableId = @TableId AND Status = 1)
	BEGIN
		RETURN 2 
	END
	ELSE
	BEGIN
			Set @OrderNo = @OrderNoIN
	END
END
 
Set @AdminUserId = (Select Id From AdminUsers Where EMPEmployeeId = @EmployeeId AND Status = 1)

Set @CartableTraceId = (Select Id From CARCartableTraces Where OrderNo = @OrderNo AND CARTableId = @TableId AND Status = 1)
   

Set @YearMonthDay = SUBSTRING(@SignDate,1,4) + SUBSTRING(@SignDate,6,2) + SUBSTRING(@SignDate,9,2)
 
IF @DeleteFlag = 1 And @OrderNo <> 0  
BEGIN 
	Set @AdminRoleId = (Select AdminRoleId From CARCartableTraces Where Id = @CartableTraceId)
	IF @AdminRoleId <> 0
	BEGIN 
		IF NOT EXISTS (Select * From AdminUserRoles Where AdminRoleId = @AdminRoleId And AdminUserId = @AdminUserId AND Status = 1)
		BEGIN
			RETURN 0
		END
	END
	
	IF @OrderNo = 1
	BEGIN
		 
		SET @sqlCommand = 'UPDATE ' + @TableName + ' SET Status = 0 WHERE Id = ' + @FieldCode
		EXEC (@sqlCommand)
	END

    UPDATE CARCartables SET Status = 3 
    Where  CARCartableTraceId = @CartableTraceId AND FieldCode = @FieldCode AND RequestDate = @RequestDate AND Status = 1

END
ELSE
BEGIN
  
	Set @AdminRoleId = (Select AdminRoleId From CARCartableTraces Where Id = @CartableTraceId)
	IF @AdminRoleId <> 0
	BEGIN
		IF NOT EXISTS (Select * From AdminUserRoles Where AdminRoleId = @AdminRoleId And AdminUserId = @AdminUserId AND Status = 1)
		BEGIN
			RETURN 0
		END
	END

    Set @CartableID = (Select  ISNULL(max(Cast(Id as numeric)), + @YearMonthDay + '0000') + 1 As MaxCode From CARCartables Where Left(cast(Id as numeric),8) = @YearMonthDay)

	Insert INTO CARCartables(Id, FieldCode, RequestDate, ConfirmType, SignDate, EMPEmployeeId, CARCartableTraceId, Status, CreateDateTime, UpdateDateTime, Description) 
					 VALUES (@CartableID, @FieldCode, @RequestDate, @ConfirmType,  @SignDate, @EmployeeId, @CartableTraceId, 1, getdate(), getdate(), @Description) 

END
 
RETURN 1

END