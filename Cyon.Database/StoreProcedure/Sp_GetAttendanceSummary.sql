CREATE PROCEDURE [dbo].[Sp_GetAttendanceSummary]
	@UserId nvarchar(450)
AS
BEGIN
	SELECT (SELECT COUNT(*) FROM [AttendanceRegisters] WHERE UserId = @UserId AND IsPresent = 1) AS TotalPresent,
	(SELECT COUNT(*) FROM [AttendanceRegisters] WHERE UserId = @UserId AND IsPresent = 0) AS TotalAbsent
END