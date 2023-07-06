CREATE PROCEDURE [dbo].[Sp_GetAttendanceSummary]
	@UserCode nvarchar(450)
AS
BEGIN
	SELECT (SELECT COUNT(*) FROM [AttendanceRegisters] WHERE UserCode = @UserCode AND IsPresent = 1) AS TotalPresent,
	(SELECT COUNT(*) FROM [AttendanceRegisters] WHERE UserCode = @UserCode AND IsPresent = 0) AS TotalAbsent
END