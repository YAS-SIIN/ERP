USE [ERP]
GO
/****** Object:  StoredProcedure [dbo].[CARSignList]    Script Date: 7/31/2022 5:42:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[CARSignList]
	-- Add the parameters for the stored procedure here
	@UserId as int, 
	@Status as smallint = 1
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
IF @Status = 0
BEGIN
SELECT        CARCartables.FieldCode, CARCartables.RequestDate, CARCartableTraces_NewLevel.CARTableId, CARCartableTraces_NewLevel.SignTitle, CARCartableTraces_NewLevel.SignTitleFa, 
			  CARTables.TableName, AdminForms.FormName, AdminForms.FormNameFa, @Status as Status, CARCartables.EMPEmployeeId, CARCartableTraces_1.OrderNo
FROM            AdminForms INNER JOIN
                         CARTables ON AdminForms.Id = CARTables.AdminFormId INNER JOIN
                         CARCartables INNER JOIN
                             (SELECT        CARCartables_1.FieldCode, CARCartables_1.RequestDate, MAX(CARCartableTraces.OrderNo) AS MaxOrderNo
                               FROM            CARCartables AS CARCartables_1 INNER JOIN
                                                         CARCartableTraces ON CARCartables_1.CARCartableTraceId = CARCartableTraces.Id
                               WHERE        (CARCartables_1.Status = 1)
                               GROUP BY CARCartables_1.FieldCode, CARCartables_1.RequestDate) AS CartableRequests ON CARCartables.FieldCode = CartableRequests.FieldCode AND 
                         CARCartables.RequestDate = CartableRequests.RequestDate INNER JOIN
                         CARCartableTraces AS CARCartableTraces_1 ON CARCartables.CARCartableTraceId = CARCartableTraces_1.Id AND CartableRequests.MaxOrderNo = CARCartableTraces_1.OrderNo INNER JOIN
                         CARCartableTraces AS CARCartableTraces_NewLevel ON CARCartableTraces_1.OrderNo + 1 = CARCartableTraces_NewLevel.OrderNo AND CARCartableTraces_1.CARTableId = CARCartableTraces_NewLevel.CARTableId ON 
                         CARTables.Id = CARCartableTraces_NewLevel.CARTableId INNER JOIN
                         AdminUserRoles ON CARCartableTraces_NewLevel.AdminRoleId = AdminUserRoles.AdminRoleId
WHERE        (AdminUserRoles.AdminUserId = @UserId)
END
ELSE
BEGIN
SELECT        CARCartables.FieldCode, CARCartables.RequestDate, CARCartableTraces_NewLevel.CARTableId, CARCartableTraces_NewLevel.SignTitle, CARCartableTraces_NewLevel.SignTitleFa, 
			  CARTables.TableName, AdminForms.FormName, AdminForms.FormNameFa, @Status as Status, CARCartables.EMPEmployeeId, CARCartableTraces_1.OrderNo
FROM            AdminForms INNER JOIN
                         CARTables ON AdminForms.Id = CARTables.AdminFormId INNER JOIN
                         CARCartables INNER JOIN
                             (SELECT        CARCartables_1.FieldCode, CARCartables_1.RequestDate, MAX(CARCartableTraces.OrderNo) AS MaxOrderNo
                               FROM            CARCartables AS CARCartables_1 INNER JOIN
                                                         CARCartableTraces ON CARCartables_1.CARCartableTraceId = CARCartableTraces.Id
                               WHERE        (CARCartables_1.Status = 1)
                               GROUP BY CARCartables_1.FieldCode, CARCartables_1.RequestDate) AS CartableRequests ON CARCartables.FieldCode = CartableRequests.FieldCode AND 
                         CARCartables.RequestDate = CartableRequests.RequestDate INNER JOIN
                         CARCartableTraces AS CARCartableTraces_1 ON CARCartables.CARCartableTraceId = CARCartableTraces_1.Id AND CartableRequests.MaxOrderNo = CARCartableTraces_1.OrderNo INNER JOIN
                         CARCartableTraces AS CARCartableTraces_NewLevel ON CARCartableTraces_1.OrderNo = CARCartableTraces_NewLevel.OrderNo AND CARCartableTraces_1.CARTableId = CARCartableTraces_NewLevel.CARTableId ON 
                         CARTables.Id = CARCartableTraces_NewLevel.CARTableId INNER JOIN
                         AdminUserRoles ON CARCartableTraces_NewLevel.AdminRoleId = AdminUserRoles.AdminRoleId
WHERE        (AdminUserRoles.AdminUserId = @UserId)
END

END