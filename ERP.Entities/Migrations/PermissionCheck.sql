-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE PermissionCheck
	-- Add the parameters for the stored procedure here
	@UserId As int,
    @RoleName As nvarchar(100)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
SELECT       Count(AdminUserRoles.Id) as SpReturnResult
FROM            AdminUsers INNER JOIN
                         AdminUserRoles ON AdminUsers.Id = AdminUserRoles.AdminUserId INNER JOIN
                         AdminRoles ON AdminUserRoles.AdminRoleId = AdminRoles.Id
where AdminUsers.Status = 1 AND AdminRoles.Status = 1 AND AdminUserRoles.Status = 1  AND AdminUsers.Id = @UserId AND AdminRoles.RoleName = @RoleName
END
GO
