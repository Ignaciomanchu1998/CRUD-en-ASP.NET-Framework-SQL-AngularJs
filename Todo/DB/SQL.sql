--- CREATE DATABASE ---
CREATE DATABASE Tarea 
USE Tarea

CREATE TABLE Tarea(
	idTarea INT NOT NULL PRIMARY KEY IDENTITY(1,1)
	,titulo NVARCHAR(50) NOT NULL
	,detalle NVARCHAR(300) NOT NULL
	,estado BIT NOT NULL DEFAULT 1 
	,fechaRegistro DATETIME NOT NULL DEFAULT GETDATE()
)

----STORE PROCEDURE 
IF OBJECT_ID('SPAgregarTarea') IS NOT NULL
BEGIN 
	DROP PROC SPAgregarTarea
END 
GO 
CREATE PROC SPAgregarTarea
@titulo NVARCHAR(20)
,@detalle NVARCHAR(150)
AS 
BEGIN 
	SET NOCOUNT ON;
	SET LANGUAGE SPANISH;

	BEGIN TRY
		BEGIN TRAN 
			INSERT INTO dbo.Tarea(titulo, detalle) 
			VALUES(@titulo, @detalle)
		COMMIT TRAN
		SELECT '1', 'Registrado exitosamente', 'Tarea'
		RETURN
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0 ROLLBACK TRAN
		BEGIN
			SELECT '0', 'Error en procedimiento de agregar'+ ERROR_MESSAGE(), 'Tarea'
			RETURN
		END
	END CATCH
END
GO 


IF OBJECT_ID('SPListarTarea') IS NOT NULL
BEGIN 
	DROP PROC SPListarTarea
END 
GO 
CREATE PROC SPListarTarea
AS 
BEGIN 
	SET NOCOUNT ON;
	SET LANGUAGE SPANISH;

	SELECT '1', '',''
	,idTarea
	,titulo
	,detalle
	,estado
	FROM dbo.Tarea
	ORDER BY fechaRegistro DESC
END
GO

GO
IF OBJECT_ID('SPActualizarTarea') IS NOT NULL
BEGIN 
	DROP PROC SPActualizarTarea
END 
GO 
CREATE PROC SPActualizarTarea
@idTarea INT
,@titulo NVARCHAR(20)
,@detalle NVARCHAR(150)
,@estado BIT
AS 
BEGIN 
	SET NOCOUNT ON;
	SET LANGUAGE SPANISH;

	BEGIN TRY
		BEGIN TRAN 
			UPDATE dbo.Tarea SET titulo = @titulo
								 ,detalle = @detalle
								 ,estado = @estado
								 WHERE idTarea = @idTarea
		COMMIT TRAN
		SELECT '1', 'Actualizado exitosamente', 'Tarea'
		RETURN
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0 ROLLBACK TRAN
		BEGIN
			SELECT '0', 'Error en procedimiento de actualizar'+ ERROR_MESSAGE(), 'Tarea'
			RETURN
		END
	END CATCH
END
GO 


IF OBJECT_ID('SPEliminarTarea') IS NOT NULL
BEGIN 
	DROP PROC SPEliminarTarea
END 
GO 
CREATE PROC SPEliminarTarea
@idTarea INT
,@titulo NVARCHAR(20)
AS 
BEGIN 
	SET NOCOUNT ON;
	SET LANGUAGE SPANISH;

	BEGIN TRY
		BEGIN TRAN 
			DELETE FROM dbo.Tarea WHERE idTarea = @idTarea AND titulo = @titulo
		COMMIT TRAN
		SELECT '1', 'Eliminado exitosamente', 'Tarea'
		RETURN
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0 ROLLBACK TRAN
		BEGIN
			SELECT '0', 'Error en procedimiento de eliminar'+ ERROR_MESSAGE(), 'Tarea'
			RETURN
		END
	END CATCH
END
GO 
