/*  ***************************************************************************************** 
	|						DDL(LENGUAJE DE DEFINICION DE DATOS)							| 
	***************************************************************************************** */
	USE MASTER
	GO
	DROP DATABASE  db_BDSistemaMantenimientosCCI
	GO
/*  ***************************************************************************************** 
	|						CREACION DE LA BASE DE DATOS DEL SISTEMA						|
	*****************************************************************************************  */
	CREATE DATABASE db_BDSistemaMantenimientosCCI
	GO

	/*========================================================================================================*/
	/*= = = = = = = = = = = = = = = = = = = = = = PRIMER SPRINT = = = = = = = = = = = = = = = = = = = = = =*/
	/*========================================================================================================*/

	/*  ***************************************************************************************** 
	|						CREACION DE LAS TABLAS DEL SISTEMA								|
	*****************************************************************************************  */
	-- Crear tipos de datos para las claves primarias
	USE db_BDSistemaMantenimientosCCI
	EXEC  sp_addtype  TCod_Estudiante, 'varchar(6)','NOT NULL'  -- Grupo 01
	EXEC  sp_addtype  TCod_Docente, 'varchar(6)','NOT NULL'		-- Grupo 03
	EXEC  sp_addtype  TCod_Curso,	'varchar(5)', 'not null'    -- Grupo 02
	--EXEC  sp_addtype  TCodCursoActivo, 'varchar(5)','NOT NULL' -- Grupo 05
	EXEC  sp_addtype  TCodBoleta, 'varchar(12)','NOT NULL'		-- Grupo 05
	EXEC  sp_addtype  TCodMatricula, 'varchar(8)','NOT NULL'	-- Grupo 05
	
	-- SEGUNDO SPRINT
	EXEC  sp_addtype  TNroBoleta, 'varchar(12)','NOT NULL'		-- MATRICULAS DAI
	EXEC  sp_addtype  NroCertificado, INT,'NOT NULL'	-- IMPRESION_CERTIFICADOS
	EXEC  sp_addtype  TCodLaboratorio, 'varchar(6)','NOT NULL'  -- MANTENIMIENTO_LABORATORIO
	EXEC  sp_addtype  TCodMantenimientoMatricula, 'varchar(12)','NOT NULL' -- MANTENIMIENTO_TIPO_MATRICULA
	EXEC  sp_addtype  TCodDetalles, 'varchar(6)','NOT NULL' --MANTENIMIENTO_TIPO_MATRICULA

	/*========================== TABLA ESTUDIANTE - GRUPO 01 ==========================*/
	CREATE TABLE TEstudiante
	(
		-- Lista de atributos de la tabla Estudiante
		Codigo_Estudiante TCod_Estudiante,
		Apellido_Paterno VARCHAR(40) NOT NULL,
		Apellido_Materno VARCHAR(40) NOT NULL,
		Nombres VARCHAR(20) NOT NULL,
		DNI VARCHAR(20) NOT NULL,
		Sexo VARCHAR(1) NOT NULL,
		Direccion VARCHAR(100) NOT NULL,
		Telefono VARCHAR(10) NOT NULL,
		Email VARCHAR(50) NOT NULL,
		Foto IMAGE,
		-- Definicion de claves
		PRIMARY KEY(Codigo_Estudiante)
	)
	GO

	/*========================== TABLA CURSO  - GRUPO 02 ==========================*/
	CREATE TABLE TCurso
	(
	-- Lista de atributos de la tabla Curso
		Codigo_Curso TCod_Curso,
		Nombre_Curso VARCHAR(50) NOT NULL,
		Tipo_Curso VARCHAR(5)	NOT NULL,
		Temas VARCHAR(50) NOT NULL,
		HorasxSemana INT,
		Estado Varchar(11) default 'DESACTIVADO',
		-- Definicion de claves
		PRIMARY KEY (Codigo_Curso)
	)
	GO

	/*========================== TABLA DOCENTE  - GRUPO 03 ==========================*/
	CREATE TABLE TDocentes
	(
		-- Lista de atributos de la tabla Docente
		Codigo_Docente TCod_Docente,
		Nombres VARCHAR(30) NOT NULL,
		Apellido_Paterno VARCHAR(20) NOT NULL,
		Apellido_Materno VARCHAR(20) NOT NULL,
		TipoDocentes VARCHAR(10) NOT NULL,
		Direccion VARCHAR(80) NOT NULL,
		Correo VARCHAR(50) NOT NULL,
		Celular VARCHAR(9) NOT NULL,
		Sexo VARCHAR(3)	NOT NULL,
		Foto IMAGE,
		-- Definicion de claves
		PRIMARY KEY (Codigo_Docente)
	)
	GO

	/*========================== TABLA DETALLE PAGO - grupo 04 ==========================*/

	/*========================== TABLA CONTROL ERRORES - GRUPO 04 ==========================*/
	create table TLogErrores
	(
		ErrorID			INT IDENTITY,
		ErrorNumbre		INT NOT NULL,
		ErrorMessage	VARCHAR(300),
		ErrorLine		INT,	
		ErrorProcedure	VARCHAR(100),
		DateTimeError	SMALLDATETIME,
		HostName		VARCHAR(75),
		DBName			VARCHAR(75)
	)
	GO

	/*========================== TABLA CURSO ACTIVO - GRUPO 05 ==========================*/
	create table TCursoActivo
	(
		-- Lista de atributos de la tabla Curso_Activo
		Codigo_CursoActivo TCod_Curso not null,
		Grupo VARCHAR(1),
		Nombre VARCHAR(50),
		Tema varchar(50), -- Añadido del Grupo 06
		Tipo VARCHAR(3),
		HorasxSemana int,
		Dias VARCHAR(20),
		Hora VARCHAR(5),
		Periodo VARCHAR(11),
		Año VARCHAR(4),
		-- Definicion de claves
		primary key(Codigo_CursoActivo,Grupo,Periodo,Año)
	)
	GO

	/*========================== TABLA BOLETA  - GRUPO 05 ==========================*/
	create table TBoleta
	( 
		-- Lista de atributos de la tala Boleta
		Codigo_Boleta  TCodBoleta NOT NULL,
		NroSerie	 VARCHAR(10) not null,
		FechaEmision VARCHAR(50) not null,
		Costo   NUMERIC(15,2) CHECK(Costo > 0) ,
		TipoDsto  VARCHAR(15) CHECK (TipoDsto in ('DCTO1','DCTO2','DCTO3','DCTO4','DCTO5')),
		Pago    NUMERIC(15,2) CHECK(Pago > 0),
		Codigo_CursoActivo  VARCHAR(15) Not NULL,
		Grupo VARCHAR(1),--Agregado
		Periodo VARCHAR(11),--Agregado
		Año VARCHAR(4),--agregado
		Codigo_Estudiante TCod_Estudiante,
		Observacion   VARCHAR(50) not null
		-- Definicion de claves
		PRIMARY KEY (Codigo_Boleta),
		FOREIGN KEY (Codigo_Estudiante) REFERENCES TEstudiante(Codigo_Estudiante)
	)
	GO

	/*========================== TABLA MATRICULA  - GRUPO 05 ==========================*/
	CREATE TABLE TMatricula
	( 
		-- Lista de atributos de la tabla Matricula
		CodMatricula  TCodMatricula NOT NULL,
		Anio VARCHAR(4) not null,
		Mes VARCHAR(11) not null,
		Grupo varchar(1), --Agregado
		CodCursoActivo TCod_Curso not null,
		CodBoleta   TCodBoleta not null,
		TipoMatricula VARCHAR(3) not null, --- ATRIBUTO NUEVO
		--notas correspondientes a la matricula
		nota1 float,
		nota2 float,
		nota3 float,
		nota4 float,
		nota5 float,
		nota6 float,
		nota7 float,
		nota8 float,
		nota9 float,
		nota10 float,
		-- Definicion de claves
		PRIMARY KEY (CodMatricula),
		FOREIGN KEY (CodBoleta) REFERENCES TBoleta(Codigo_Boleta),
		FOREIGN KEY (CodCursoActivo,Grupo,Mes,Anio) REFERENCES TCursoActivo(Codigo_CursoActivo,Grupo,Periodo,Año)--Agregado
	 )
	 GO

	/*========================== TABLA CARGA ACADEMICA  - GRUPO 06 ==========================*/
	CREATE TABLE TCargaAcademica
	(
		-- Lista de atributos de la tabla Carga_Academica
		CodCargAcademica INT IDENTITY(1,1) not null,
		CodCursoActivo TCod_Curso,
		Grupo VARCHAR(1),
		CodDocente TCod_Docente,
		Periodo VARCHAR(11),
		Año VARCHAR(4),
		-- Definicion de claves
		PRIMARY KEY(CodCargAcademica),
		FOREIGN KEY(CodCursoActivo,Grupo,Periodo,Año) REFERENCES TCursoActivo(Codigo_CursoActivo,Grupo,Periodo,Año),--Agregado
		FOREIGN KEY(CodDocente)REFERENCES TDocentes
	)
	GO

	/*  ***************************************************************************************** 
		|				FUNCIONES Y PROCEDIMIENTOS ALMACENADOS DE LA BASE DE DATOS				|
		*****************************************************************************************  */
	USE db_BDSistemaMantenimientosCCI
	GO

	/* ================== PROCEDIMIENTOS ALMACENADOS PARA EL MODULO MANTENIMIENTO ESTUDIANTE  - GRUPO 01 ==================== */
	/* ---------------- Funcion para Generar Codigo del Estudiante ---------------*/
	CREATE FUNCTION fnGenerarCodEstudiante()
	RETURNS VARCHAR(6)
	AS
	BEGIN
			-- Declarar variables para generar codigo
			DECLARE @CodNuevo VARCHAR(6), @CodMax VARCHAR(6)
			SET @CodMax = (SELECT MAX(Codigo_Estudiante) FROM TEstudiante)
			SET @CodMax = ISNULL(@CodMax,'A00000')
			SET @CodNuevo = 'A'+RIGHT(RIGHT(@CodMax,4)+10001,4)
			RETURN @CodNuevo
	END;
	GO

	/* ---------------- Procedimiento para Insertar un nuevo Estudiante --------------- */
	CREATE PROCEDURE spInsertarEstudiante	
		@Codigo_Estudiante VARCHAR(6),
		@Apellido_Paterno VARCHAR(40),
		@Apellido_Materno VARCHAR(40),
		@Nombres VARCHAR(20),
		@DNI VARCHAR(20),
		@Sexo VARCHAR(1),
		@Direccion VARCHAR(100),
		@Telefono VARCHAR(10),
		@Email VARCHAR(50),
		@Foto IMAGE
	AS
	BEGIN
		begin try
			begin tran
				-- Insertar estudiante en la tabla de Estudiante
				INSERT INTO TEstudiante
					VALUES (DBO.fnGenerarCodEstudiante(),@Apellido_Paterno,@Apellido_Materno,@Nombres, @DNI, @Sexo, @Direccion, @Telefono, @Email, @Foto)
				commit tran
		end try
		begin catch
				select ERROR_MESSAGE()
				rollback tran
		end catch

	END;
	GO

	/* ---------------- Procedimiento para Eliminar un Estudiante --------------- */
	CREATE PROCEDURE speliminar_estudiante
		@Codigo_Estudiante VARCHAR(6)
	AS
		-- Eliminar estudiante de la tabla
		DELETE FROM TEstudiante
		-- Parametro de comparacion
		WHERE Codigo_Estudiante=@Codigo_Estudiante
	GO

	/* ---------------- Procedimiento para Editar un Estudiante --------------- */
	CREATE PROCEDURE speditar_estudiante
		@Codigo_Estudiante VARCHAR(6),
		@Apellido_Paterno VARCHAR(40),
		@Apellido_Materno VARCHAR(40),
		@Nombres VARCHAR(20),
		@DNI VARCHAR(20),
		@Sexo VARCHAR(1),
		@Direccion VARCHAR(100),
		@Telefono VARCHAR(10),
		@Email VARCHAR(50),
		@Foto IMAGE
	AS
	BEGIN
		begin try
			begin tran
				-- Editar estudiante en la tabla de Estudiante
				UPDATE TEstudiante SET	Apellido_Paterno=@Apellido_Paterno,
										Apellido_Materno=@Apellido_Materno,
										Nombres=@Nombres,
										DNI=@DNI,
										Sexo=@Sexo,
										Direccion=@Direccion,
										Telefono=@Telefono,
										Email=@Email,
										Foto=@Foto
										-- Parametro de comparación
				WHERE Codigo_Estudiante=@Codigo_Estudiante
				commit tran
		end try
		begin catch
				select ERROR_MESSAGE()
				rollback tran
		end catch
	END;
	GO

	/* ---------------- Procedimiento para Buscar un Estudiante por codigo --------------- */
	CREATE PROCEDURE spbuscar_estudiante_codigo
		@codigobuscar VARCHAR(6)
	AS	
		SELECT * FROM TEstudiante
		WHERE (Codigo_Estudiante like @codigobuscar + '%') or (Apellido_Paterno like @codigobuscar + '%')
	GO

	/* ---------------- Procedimiento para Listar Estudiantes --------------- */
	CREATE PROCEDURE spmostrar_estudiante
	AS
		SELECT  TOP 100 * FROM TEstudiante
		ORDER BY Codigo_Estudiante ASC
	GO

	
	/* ================== PROCEDIMIENTOS ALMACENADOS PARA EL MODULO MANTENIMIENTO CURSO - GRUPO 02 ================== */
	/* ---------------- Procedimiento para listar Cursos --------------- */
	CREATE PROCEDURE sp_listar_mCurso
	AS
		SELECT Codigo_Curso, Nombre_Curso, Tipo_Curso, Temas, HorasxSemana FROM TCurso 
		ORDER BY Codigo_Curso ASC
	GO

	/* ---------------- Procedimiento para buscar Curso --------------- */
	CREATE PROCEDURE sp_Buscar_mCurso
		@Nombre VARCHAR(50)
	AS
		SELECT Codigo_Curso, Nombre_Curso, Tipo_Curso, Temas, HorasxSemana FROM TCurso
		WHERE (Codigo_Curso like @Nombre+'%')
		or (Nombre_Curso like @Nombre+'%')
		or (Temas like @Nombre+'%')
		or (Tipo_Curso like @Nombre+'%')
	GO

	/* ---------------- Procedimiento para Mantenimiento Curso --------------- */ --REVISION
	CREATE PROC sp_Mantenimiento_mCurso
		@CodigoCurso VARCHAR(8),
		@Nombre VARCHAR(50),
		@Tipo VARCHAR(5),
		@Temas VARCHAR(50),
		@HorasxSemana int,
		@accion VARCHAR(50) OUTPUT
	AS
	IF(@accion='1')
	BEGIN TRY
	--para probar
		DECLARE @CodigoNuevo VARCHAR(8),@CodigoMax VARCHAR(8)
		SET @CodigoMax=(select max(Codigo_Curso)from TCurso)
		SET @CodigoMax=isnull(@CodigoMax,'IF000')
		SET @CodigoNuevo='IF'+RIGHT(RIGHT(@CodigoMax,3)+11001,3)
		BEGIN TRANSACTION
			-- Se ah retirado los atributos Estado, Grupo y Horario para el insert para la inserción
			INSERT INTO TCurso(Codigo_Curso,Nombre_Curso,Tipo_Curso,Temas,HorasxSemana)
			VALUES(@CodigoNuevo,@Nombre,@Tipo,@Temas,@HorasxSemana) 
		COMMIT TRANSACTION
		SET @accion='Se genero el codigo: '+@CodigoNuevo
	END TRY

	BEGIN CATCH
		--ejecutar si ocurre un error
		PRINT'Error Number : '+CAST(ERROR_NUMBER()AS VARCHAR(10));
		PRINT'Error Message : '+ERROR_MESSAGE();
		PRINT'Error Severity : '+CAST(ERROR_SEVERITY()AS VARCHAR(10));
		PRINT'Error State : '+CAST(ERROR_STATE()AS VARCHAR(10));
		PRINT'Error Line : '+CAST(ERROR_LINE()AS VARCHAR(10));
		PRINT'Error Proc: '+COALESCE(ERROR_PROCEDURE(),'Not within procedure')
		ROLLBACK TRANSACTION;
	END CATCH

	ELSE IF(@accion='2')
	BEGIN TRY
		BEGIN TRANSACTION
		update TCurso SET Nombre_Curso=@Nombre,Tipo_Curso=@Tipo,Temas=@Temas,HorasxSemana=@HorasxSemana WHERE Codigo_Curso=@CodigoCurso
		COMMIT TRANSACTION
		SET @accion='Se modifico el codigo:' + @CodigoCurso
	END TRY
	BEGIN CATCH
		--ejecutar si ocurre un error
		PRINT'Error Number : '+CAST(ERROR_NUMBER()AS VARCHAR(10));
		PRINT'Error Message : '+ERROR_MESSAGE();
		PRINT'Error Severity : '+CAST(ERROR_SEVERITY()AS VARCHAR(10));
		PRINT'Error State : '+CAST(ERROR_STATE()AS VARCHAR(10));
		PRINT'Error Line : '+CAST(ERROR_LINE()AS VARCHAR(10));
		PRINT'Error Proc: '+COALESCE(ERROR_PROCEDURE(),'Not within procedure')
		ROLLBACK TRANSACTION;
	END CATCH
	ELSE IF(@accion='3')
	BEGIN TRY
		BEGIN TRANSACTION
		DELETE FROM TCurso
		WHERE Codigo_Curso=@CodigoCurso
		COMMIT TRANSACTION
		SET @accion='Se borro el codigo: '+@CodigoCurso
	END TRY
	BEGIN CATCH
		--ejecutar si ocurre un error
		PRINT'Error Number : '+CAST(ERROR_NUMBER()AS VARCHAR(10));
		PRINT'Error Message : '+ERROR_MESSAGE();
		PRINT'Error Severity : '+CAST(ERROR_SEVERITY()AS VARCHAR(10));
		PRINT'Error State : '+CAST(ERROR_STATE()AS VARCHAR(10));
		PRINT'Error Line : '+CAST(ERROR_LINE()AS VARCHAR(10));
		PRINT'Error Proc: '+COALESCE(ERROR_PROCEDURE(),'Not within procedure')
		ROLLBACK TRANSACTION;
	END CATCH
	GO


	/* ================== PROCEDIMIENTOS ALMACENADOS PARA EL MODULO MANTENIMEINTO DOCENTE - GRUPO 03 ================== */
	/* ---------------- Función para Generar Codigo Docentes --------------- */
	CREATE FUNCTION GenerarCodDocente()
	RETURNS VARCHAR(6)
	AS
	BEGIN
			-- Declarar variables para generar codigo
			DECLARE @Codigo VARCHAR(6), @CodMax1 VARCHAR(6)
			SET @CodMax1 = (SELECT MAX(Codigo_Docente) FROM TDocentes)
			SET @CodMax1 = ISNULL(@CodMax1,'D00000')
			SET @Codigo = 'D'+RIGHT(RIGHT(@CodMax1,4)+10001,4)
			RETURN @Codigo
	END;
	GO
	
	/* ---------------- Procedimiento para Listar Docentes --------------- */
	Create procedure ListarDocentes
	AS
		-- Mostrar Datos
		select * from TDocentes order by Codigo_Docente ASC;
	GO

	/* ---------------- Procedimiento para Insertar Docentes --------------- */
	CREATE PROCEDURE AgregarDocente 
		@Codigo varchar(6), 
		@Nombre varchar(30), 
		@ApellidoP varchar(20),
		@ApellidoM varchar(20), 
		@TipoDocentes varchar(10), 
		@Direccion varchar(80), 
		@Correo varchar(50), 
		@Celular varchar(9),
		@Sexo varchar(3), 
		@foto image
	AS
	BEGIN TRY
	BEGIN TRAN
		INSERT INTO TDocentes(Codigo_Docente, Nombres, Apellido_Paterno, Apellido_Materno, TipoDocentes, Direccion, Correo, Celular, Sexo, foto) 
		VALUES(DBO.GenerarCodDocente(), @Nombre, @ApellidoP, @ApellidoM, @TipoDocentes, @Direccion, @Correo, @Celular, @Sexo, @foto)
	COMMIT
	END TRY

	BEGIN CATCH
		ROLLBACK
		PRINT ERROR_MESSAGE()
	END CATCH
	GO

	/* ---------------- Procedimiento para Editar Docentes --------------- */
	CREATE PROCEDURE EditarDocente 
		@Codigo varchar(10), 
		@Nombre varchar(30), 
		@ApellidoP varchar(20), 
		@ApellidoM varchar(20), 
		@TipoDocentes varchar(10), 
		@Direccion varchar(80), 
		@Correo varchar(50), 
		@Celular varchar(9), 
		@Sexo varchar(3), 
		@foto image
	AS
	BEGIN TRY
		BEGIN TRAN
			update TDocentes 
			set  Nombres =@Nombre, Apellido_Paterno = @ApellidoP, Apellido_Materno = @ApellidoM, TipoDocentes = @TipoDocentes, Direccion = @Direccion, Correo = @Correo, Celular = @Celular, Sexo = @Sexo, foto = @foto
			where Codigo_Docente like @Codigo +'%'
		COMMIT
	END TRY

	BEGIN CATCH
		ROLLBACK
		PRINT ERROR_MESSAGE()
	END CATCH
	GO

	/* ---------------- Procedimiento para Eliminar Docentes --------------- */
	CREATE PROCEDURE EliminarDocente
		@Codigo varchar(10)
	AS
				delete from TDocentes where Codigo_Docente like @Codigo +'%'
	GO

	/* ---------------- Procedimiento para Buscar Docentes por Codigo --------------- */
	CREATE PROCEDURE BuscarDocente @Codigo varchar(10)
	AS
		select * from TDocentes
		where Codigo_Docente like @Codigo + '%'
	GO


	/* ================== PROCEDIMIENTOS ALMACENADOS PARA EL MODULO ACTIVACION_CURSO  - GRUPO 04 ================== */
/*NUEVOS PROCEDIMIENTOS*/
--RECUPERAR CURSO POR CODIGO
	CREATE PROCEDURE pRecuperarCursoCodigo @Cod_Curso varchar(5)
	AS
	BEGIN
		SELECT Nombre_Curso, Tipo_Curso, Codigo_Curso, Estado, HorasxSemana, Temas 
		FROM TCurso
		WHERE Codigo_Curso = @Cod_Curso
	END
	GO

	--RECUPERAR CURSO NOMBRE
	CREATE procedure pRecuperarCursoNombre 
					@Nombre_Curso varchar(80)
	as
	begin
		SELECT Nombre_Curso, Tipo_Curso, Codigo_Curso, Estado, HorasxSemana, Temas 
		FROM TCurso
		WHERE Nombre_Curso = @Nombre_Curso
	end
	GO


--PROCEDIMEINTO PARA INSERTAR DATOS TABLA TCURSOACTIVO
CREATE PROC pInsertarCursoActivo  
					@Codigo_CursoActivo VARCHAR(5),
					@Grupo			VARCHAR(1),
					@Nombre			VARCHAR(50),
					@Tema			VARCHAR(50),
					@Tipo			VARCHAR(3),
					@HorasxSemana	INT,
					@Dias			VARCHAR(20),
					@Hora			VARCHAR(5),
					@Periodo		VARCHAR(11),
					@Año			VARCHAR(4)
AS
BEGIN
	BEGIN TRY
		INSERT INTO TCursoActivo(Codigo_CursoActivo, Grupo, Nombre, Tema, Tipo, HorasxSemana, Dias, Hora, Periodo, Año) 
				VALUES(@Codigo_CursoActivo, @Grupo, @Nombre, @Tema, @Tipo, @HorasxSemana, @Dias, @Hora, @Periodo, @Año)
	END TRY
	BEGIN CATCH
		ROLLBACK
		PRINT ERROR_MESSAGE()
	END CATCH
END
GO
--ACTUALIZAR ESTADO DEL CURSO EN LA TABLA TCURSO
	CREATE procedure pActulizarEstado @Cod_Curso varchar(5), @Estado varchar(11)
	as
	begin
		BEGIN TRY
			update TCurso
			set Estado = @Estado
			where Codigo_Curso = @Cod_Curso
		END TRY
		BEGIN CATCH
			INSERT INTO TLogErrores(ErrorNumbre,ErrorMessage,ErrorLine,ErrorProcedure,
						DateTimeError,HostName,DBName)
			SELECT	ERROR_NUMBER(),
					ERROR_MESSAGE(),
					ERROR_LINE(),
					ERROR_PROCEDURE(),
					GETDATE(),
					HOST_NAME(),
					DB_NAME()
		END CATCH
	end
	GO

--Eliminar Curso de la tabla TCursoActivo una vez que se desabilite
	CREATE procedure pEliminarCursoDesabilitado @Codigo_CursoActivo varchar(5)
	as
	begin
		BEGIN TRY
			DELETE TCursoActivo
			WHERE Codigo_CursoActivo = @Codigo_CursoActivo
		END TRY
		BEGIN CATCH
			INSERT INTO TLogErrores(ErrorNumbre,ErrorMessage,ErrorLine,ErrorProcedure,
						DateTimeError,HostName,DBName)
			SELECT	ERROR_NUMBER(),
					ERROR_MESSAGE(),
					ERROR_LINE(),
					ERROR_PROCEDURE(),
					GETDATE(),
					HOST_NAME(),
					DB_NAME()
		END CATCH
	end
	GO

--PROCEDIMIENTO PARA LISTAR CURSO
	CREATE procedure pListarCursos @Estado varchar(11)
	as
	begin
		SELECT Codigo_Curso, Nombre_Curso, Estado, HorasxSemana
		FROM TCurso
		WHERE Estado = @Estado
	end
	Go
	/* ================== PROCEDIMIENTOS ALMACENADOS PARA EL MODULO ACTIVACION_CURSO  - GRUPO 05 ================== */
	/* ---------------- Procedimiento para Buscar Estudiante Matriculado --------------- */
	create proc SP_Buscar_EstudianteMatriculado
	@Codigo varchar(50)
	AS
		select*
		from TEstudiante
		where Codigo_Estudiante like @Codigo+'%'
	GO

	/* ---------------- Procedimiento para Detalle de Matricula Estudiante --------------- */
	CREATE PROCEDURE SP_DetalleMatriculaEstudiante
	AS
			SELECT E.Codigo_Estudiante,E.Nombres,E.Apellido_Paterno,E.Apellido_Materno,E.DNI,E.Email,
				B.NroSerie, B.Codigo_Boleta,B.Pago,B.TipoDsto,B.Costo,B.Observacion
				FROM TEstudiante E inner join TBoleta B
				ON  (E.Codigo_Estudiante = B.Codigo_Estudiante)
	GO

	/* ---------------- Procedimiento para Mantenimiento de Estudiante Matriculado --------------- */
	-- Comprobación por el visual
	CREATE PROCEDURE SP_Mantenimiento_EstudianteMatriculado
		@CodEstudiante varchar(12),
		@Apellido_Paterno varchar(40),
		@Apellido_Materno varchar(40),
		@Nombres varchar(40),
		@DNI varchar(8),
		@Sexo VARCHAR(1),
		@Direccion VARCHAR(100),
		@Telefono VARCHAR(10),
		@Email VARCHAR(50),
		@Foto IMAGE,
		@accion varchar(50) output
	AS
	BEGIN
		IF(@accion='1')
			BEGIN TRY
				begin tran
				insert into TEstudiante(Codigo_Estudiante,Apellido_Paterno,Apellido_Materno,Nombres,DNI,Sexo,Direccion,Telefono,Email,Foto)
				values(@CodEstudiante,@Apellido_Paterno,@Apellido_Materno,@Nombres,@DNI,@Sexo,@Direccion,@Telefono,@Email,@Foto)
				set @accion='Se genero el codigo: '+@CodEstudiante
				--insert into TGestioBoleta(Codigo_Estudiante, Apellido_Paterno, Apellido_Materno,DNI)
				commit tran
			END TRY
			BEGIN CATCH
				SELECT ERROR_MESSAGE()
				ROLLBACK TRAN
			END CATCH
		ELSE IF(@accion='2')
			BEGIN TRY
				begin tran
				update TEstudiante set Nombres=@Nombres,Apellido_Paterno=@Apellido_Paterno,Apellido_Materno=@Apellido_Materno,DNI=@DNI,Sexo=@Sexo,Direccion=@Direccion,Telefono=@Telefono,Email=@Email,Foto=@Foto where Codigo_Estudiante=@CodEstudiante
				set @accion='Se modifico el codigo:' + @CodEstudiante
				commit tran
			END TRY
			BEGIN CATCH
				SELECT ERROR_MESSAGE()
				ROLLBACK TRAN
			END CATCH
		ELSE IF(@accion='3')
			BEGIN TRY
				begin tran
				DELETE FROM TEstudiante
				WHERE Codigo_Estudiante=@CodEstudiante
				SET @accion='Se borro el codigo: '+@CodEstudiante
				commit tran
			END TRY
			BEGIN CATCH
				SELECT ERROR_MESSAGE()
				ROLLBACK TRAN
			END CATCH
	END;
	GO

	/* ---------------- Procedimiento para Listar Estudiante Matriculado --------------- */
	CREATE PROCEDURE SP_Listar_EstudianteMatriculado
	AS
			begin tran
			select*
			from TEstudiante 
			order by Codigo_Estudiante
	GO

	/* ---------------- Procedimiento para Agregar Boleta Estudiante --------------- */
	CREATE PROCEDURE SP_AgregarBoletaEstudiante
		@NroBoleta varchar(12),
		@NroSerie varchar(10),
		@FechaEmision varchar(50),
		@Costo numeric,
		@TipoDcto varchar(15) ,
		@Pago numeric ,
		@Grupo VARCHAR(1),--Agregado
		@Periodo VARCHAR(11),--Agregado
		@Año VARCHAR(4),--agregado
		@CodCurso varchar(15),
		@CodEstudiante varchar(12),
		@Observacion varchar(70)
	AS
	BEGIN
		BEGIN TRY
			begin tran
			INSERT INTO TBoleta values (@NroBoleta,@NroSerie,@FechaEmision,@Costo,@TipoDcto,@Pago,@Grupo,@Periodo,@Año,@CodCurso,@CodEstudiante,@Observacion)
			--insert into TGestionBoletas values (@FechaEmision,@Observacion,@NroSerie,@NroBoleta,@Pago)
			commit tran
		END TRY
		BEGIN CATCH
			SELECT ERROR_MESSAGE()
			ROLLBACK TRAN
		END CATCH

	END;
	GO

	/* ---------------- Procedimiento para Mantenimiento Boleta Estudiante --------------- */
	-- Comprobacion por el visual
	CREATE PROCEDURE SP_Mantenimiento_BoletadeMatricula
		@CodBoleta varchar(12),
		@NroSerie varchar(10),
		@FechaEmision varchar(50),
		@Costo numeric(15,2),
		@TipoDsto varchar(15),
		@Pago numeric(15,2),
		@Grupo VARCHAR(1),--Agregado
		@Periodo VARCHAR(11),--Agregado
		@Año VARCHAR(4),--agregado
		@CodCursoActivo varchar(15),
		@CodEstudiante varchar(12),
		@Observacion varchar(50),
		@accion varchar(50) output
	AS
	BEGIN
		IF(@accion='1')
			BEGIN TRY
				begin tran
				insert into TBoleta(Codigo_Boleta,NroSerie,FechaEmision,Costo,TipoDsto,Pago,Grupo,Periodo,Año,Codigo_CursoActivo,Codigo_Estudiante,Observacion)
				values(@CodBoleta,@NroSerie,@FechaEmision,@Costo,@TipoDsto,@Pago,@Grupo,@Periodo,@Año,@CodCursoActivo,@CodEstudiante,@Observacion)
				set @accion='Se genero el codigo: '+ @CodBoleta
				commit tran
			END TRY
			BEGIN CATCH
					SELECT ERROR_MESSAGE()
					ROLLBACK TRAN
			END CATCH
		ELSE IF(@accion='2')
			BEGIN TRY
				begin tran
				update TBoleta set Codigo_Boleta = @CodBoleta,NroSerie = @NroSerie, FechaEmision=@FechaEmision,Costo = @Costo,TipoDsto = @TipoDsto,
				Pago = @Pago, Grupo = @Grupo,Periodo = @Periodo,Año = @Año, Codigo_CursoActivo = @CodCursoActivo,Codigo_Estudiante = @CodEstudiante,Observacion = @Observacion
				where Codigo_Boleta=@CodBoleta
				set @accion='Se modifico el codigo:' + @CodBoleta
				commit tran
			END TRY
			BEGIN CATCH
					SELECT ERROR_MESSAGE()
					ROLLBACK TRAN
			END CATCH
		ELSE IF(@accion='3')
			BEGIN TRY
				begin tran
				DELETE FROM  TBoleta
				WHERE Codigo_Boleta = @CodBoleta
				SET @accion='Se borro el codigo: '+ @CodBoleta
				commit tran
			END TRY
			BEGIN CATCH
				SELECT ERROR_MESSAGE()
				ROLLBACK TRAN
			END CATCH
	END;
	GO

	/* ---------------- Procedimiento para Descuento Matricula Estudiante --------------- */
	CREATE PROCEDURE SP_Mostrar_TipoDescuento
	AS
		SELECT DISTINCT TipoDsto FROM TBoleta
	GO

	/* ---------------- Procedimiento para Curso Activo --------------- */
	CREATE PROCEDURE SP_Mostrar_CursoActivo
	AS
		SELECT Codigo_CursoActivo,Nombre,Grupo,CONCAT(Codigo_CursoActivo,' - ',Nombre,' - ',Grupo) as Codigo FROM TCursoActivo
	GO

	/* ================== PROCEDIMIENTOS ALMACENADOS PARA EL MODULO ASIGNACIÓN-CARGA-DOCENTE - GRUPO 06 ================== */
	/* ---------------- Procedimiento para Seleccion de Curso --------------- */
	create procedure SP_SeleccionCursos
	as
		select * from TCursoActivo
	go

	/* ---------------- Procedimiento para Seleccion de Curso por Categorias --------------- */
	create procedure SP_SeleccionCursosxCategorias
		@Tipo varchar(3),
		@Periodo varchar(11),
		@Año varchar(4)
	as
		select * from TCursoActivo where Tipo=@Tipo and Periodo=@Periodo and Año=@Año
	go

	/* ---------------- Procedimiento para Buscar los cursos activos por todos los campos --------------- */
	create procedure SP_BuscarCursosxTodosLosCampos
	@cadena varchar(50)
	as
		select*
		from TCursoActivo
		where Codigo_CursoActivo like @cadena+'%' or Grupo like @cadena+'%'
		or Nombre like @cadena+'%' or Tema like @cadena+'%' or Grupo like @cadena+'%'
	go

	/* ---------------- Procedimiento para Buscar Cursos sin Carga Todos los campos --------------- */
	create procedure SP_BuscarCursosSinCargaxTodosLosCamposxCategoria
		@Tipo varchar(3),
		@Periodo varchar(11),
		@Año varchar(4),
		@cadena varchar(60)
	as
		select C.Codigo_CursoActivo,C.Grupo,Nombre,Tema,Tipo,HorasxSemana,DescripcionHorario=C.Dias+':'+C.Hora,C.Periodo,C.Año
			from viCursoSinCargaAcademica V inner join TCursoActivo C
			on V.Codigo_CursoActivo=C.Codigo_CursoActivo and C.Grupo=C.Grupo and V.Periodo=C.Periodo and C.Año=V.Año
			where (C.Codigo_CursoActivo like @cadena+'%' or C.Grupo like @cadena+'%'
				or Nombre like @cadena+'%' or Tema like @cadena+'%')and Tipo=@Tipo and C.Periodo=@Periodo and C.Año=@Año
	go

	/* ---------------- Procedimiento para Seleccionar todos los Docentes --------------- */
	create procedure SP_SeleccionDocentes
	as
		select*from TDocentes
	go

	/* ---------------- Procedimiento para Seleccionar Solo Nombre Completo del Docente --------------- */
	create procedure SP_SeleccionDocentes_SoloNombresCompletos
	as
		select Codigo_Docente,Docente=Apellido_Paterno+' '+Apellido_Materno+' '+Nombres from TDocentes
	go

	/* ---------------- Procedimiento para Buscar Docente por Apellido/Nombres --------------- */
	create procedure SP_BuscarDocentesxApellidosNombres
	@cadena varchar(60)
	as
		select Codigo_Docente,Docente=Apellido_Paterno+' '+Apellido_Materno+' '+Nombres
		from TDocentes
		where Nombres like '%'+@cadena+'%' or Apellido_Paterno like '%'+@cadena+'%' or Apellido_Materno like '%'+@cadena+'%'
	go

	/* ---------------- Procedimiento para Mostrar Docentes Disponibles --------------- */
	create procedure SP_MostrarDocentesDisponibles
		@Hora varchar(5),
		@Periodo varchar(11),
		@Año varchar(4),
		@Dias varchar(6)
	as
		select T.Codigo_Docente, Docentes_Disponibles=Apellido_Paterno+' '+Apellido_Materno+' '+Nombres
		from (select Codigo_Docente
			from TDocentes T

		except

		select CodDocente
			from TCargaAcademica CA inner join TCursoActivo C 
			on CA.CodCursoActivo=C.Codigo_CursoActivo and CA.Grupo=C.Grupo and CA.Periodo=C.Periodo and CA.Año=C.Año
			where CA.Periodo=@Periodo and C.Año=@Año and Hora=@Hora and Dias=@Dias)T inner join TDocentes D
			on T.Codigo_Docente=D.Codigo_Docente

	go

	/* ---------------- Procedimiento para Buscar Docentes Disponibles --------------- */
	create procedure SP_BuscarDocentesDisponibles
	@Hora varchar(5),
	@Periodo varchar(11),
	@Año varchar(4),
	@Dias varchar(7),
	@cadena varchar(100)
	as
		select T.Codigo_Docente, Docentes_Disponibles=Apellido_Paterno+' '+Apellido_Materno+' '+Nombres
		from (select Codigo_Docente
			from TDocentes

		except

		select CodDocente
			from TCargaAcademica CA inner join TCursoActivo C 
			on CA.CodCursoActivo=C.Codigo_CursoActivo and CA.Grupo=C.Grupo and CA.Periodo=C.Periodo and CA.Año=C.Año
			where CA.Periodo=@Periodo and C.Año=@Año and Hora=@Hora and Dias=@Dias)T inner join TDocentes D
			on T.Codigo_Docente=D.Codigo_Docente
			where Nombres like '%'+@cadena+'%' or Apellido_Paterno like '%'+@cadena+'%' or Apellido_Materno like '%'+@cadena+'%'
	go

	/* --- Procedimiento para Mostrar todos los docentes(DISPONIBLES y NO DISPONIBLES)para una hora, dia, periodo y año determinado ---*/
	create procedure SP_MostrarDocentesDisponiblesyNoDisponibles
	@Año varchar(4),
	@Periodo varchar(11),
	@Hora varchar(5),
	@Dias varchar(7),
	@cadena varchar(100)
	as
		select* from(select T.Codigo_Docente, Docentes=Apellido_Paterno+' '+Apellido_Materno+' '+Nombres, Estado='SIN CARGA'
		from (select Codigo_Docente
			from TDocentes

		except

		select CodDocente
			from TCargaAcademica CA inner join TCursoActivo C 
			on CA.CodCursoActivo=C.Codigo_CursoActivo and CA.Grupo=C.Grupo and CA.Periodo=C.Periodo and CA.Año=C.Año
			where CA.Periodo=@Periodo and C.Año=@Año and Hora=@Hora and Dias=@Dias)T inner join TDocentes D
			on T.Codigo_Docente=D.Codigo_Docente)RESULTADO 

	UNION
	select T.CodDocente, Docentes_Disponibles=Apellido_Paterno+' '+Apellido_Materno+' '+Nombres,Estado='CON CARGA'
		from(select CodDocente
			from TCargaAcademica CA inner join TCursoActivo C 
			on CA.CodCursoActivo=C.Codigo_CursoActivo and CA.Grupo=C.Grupo and CA.Periodo=C.Periodo and CA.Año=C.Año
			where CA.Periodo=@Periodo and C.Año=@Año and Hora=@Hora and Dias=@Dias)T inner join TDocentes D
			on T.CodDocente=D.Codigo_Docente
	where Nombres like '%'+@cadena+'%' or Apellido_Paterno like '%'+@cadena+'%' or Apellido_Materno like '%'+@cadena+'%'
	order by Codigo_Docente asc
	go

	/* ---------------- Procedimiento para Carga Academica --------------- */
	create procedure SP_SeleccionCargaAcademica
	as
		select*from TCargaAcademica
	go

	/* ---------------- Procedimiento para Seleccion de Carga Academica por Categoria --------------- */
	create procedure SP_SeleccionCargaAcademicaxCategorias
	@Tipo varchar(3),
	@Periodo varchar(11),
	@Año varchar(4)
	as
		select C.Codigo_CursoActivo, C.Nombre, C.Grupo, Descripcion=C.Dias+':'+C.Hora,Docentes=D.Apellido_Paterno+' '+D.Apellido_Materno+' '+D.Nombres,CA.CodDocente
			from TCursoActivo C inner join TCargaAcademica CA
				on (C.Codigo_CursoActivo=CA.CodCursoActivo and C.Grupo=CA.Grupo and C.Periodo=CA.Periodo and C.Año=CA.Año)
				inner join TDocentes D on(CA.CodDocente=D.Codigo_Docente)
			where Tipo=@Tipo and CA.Periodo=@Periodo and CA.Año=@Año
	go

	/* ---------------- Procedimiento PARA BUSCAR CARGA ACADEMICA X TODOS LOS CAMPOS X CATEGORIAS ---------------- */
	create procedure SP_BuscarCargaAcademicaxTodosLosCamposxCategorias
	@Tipo varchar(3),
	@Periodo varchar(11),
	@Año varchar(4),
	@cadena varchar(60)
	as
		select CodCargAcademica, C.Codigo_CursoActivo, C.Nombre, C.Grupo, Descripcion=C.Dias+':'+C.Hora,Docentes=D.Apellido_Paterno+' '+D.Apellido_Materno+' '+D.Nombres,CA.CodDocente
			from TCursoActivo C inner join TCargaAcademica CA
				on (C.Codigo_CursoActivo=CA.CodCursoActivo and C.Grupo=CA.Grupo and C.Periodo=CA.Periodo and C.Año=CA.Año)
				inner join TDocentes D on(CA.CodDocente=D.Codigo_Docente)
			where (C.Codigo_CursoActivo like '%'+@cadena+'%' or C.Nombre like '%'+@cadena+'%'or D.Apellido_Paterno like '%'+@cadena+'%' or D.Nombres like '%'+@cadena+'%' or CA.CodDocente like '%'+@cadena+'%')
			and Tipo=@Tipo and CA.Periodo=@Periodo and CA.Año=@Año
	go

	/*---------------- Procedimiento para Agregar una carga academica ---------------- */
	create procedure SP_AgregarCargaAcademica
		@CodCurso varchar(5),
		@Grupo varchar(1),
		@CodDocente varchar(6),
		@Periodo varchar(11),
		@Año varchar(4)
	as
		insert into TCargaAcademica values (@CodCurso,@Grupo,@CodDocente,@Periodo,@Año)
	go

	/*---------------- Procedimiento para Eliminar una carga academica ---------------- */
	create procedure SP_EliminarCargaAcademica
		@CodCargaAcademica int
	as
		delete from TCargaAcademica where CodCargAcademica=@CodCargaAcademica
	go

	/*---------------- Procedimiento para Actualizar una carga academica ---------------- */
	create procedure SP_ActualizarCargaAcademica
		@CodCargaAcademica int,
		@CodCurso varchar(5),
		@Grupo varchar(1),
		@CodDocente varchar(6),
		@Periodo varchar(11),
		@Año varchar(4)
	as
		update TCargaAcademica 
			set CodDocente=@CodDocente
			where CodCargAcademica=@CodCargaAcademica;
	go

	/*	***************************************************************************************** 
		|						TRIGGERS (DISPARADORES) DE LA BASE DE DATOS						|
		*****************************************************************************************  */
	/* ================== TRIGGERS PARA LA TABLA CURSO - GRUPO 02 ================== */
	/* Triggers para Actualizar Estado*/
	create trigger TActualizar
	on TCurso
	for update
	as
	if update(Estado)
		begin
				print('Actualización correcta del estado')
		end
	else
		begin
			raiserror('Actualización Incorrecta del estado',10, 1)
			rollback transaction
		end;
	go

	/*	***************************************************************************************** 
		|								VISTAS DE LA BASE DE DATOS								|
		*****************************************************************************************  */
	/* ================== VISTAS PARA LA TABLA CARGA ACADEMICA  - GRUPO 06 ================== */
	-- Modulos devuelven tablas 
	/* ---------------- Vistas para curso con Carga --------------- */
	CREATE VIEW viCursosConCargaAcademica
	AS
	select C.Codigo_CursoActivo, C.Nombre, C.Grupo, DescripcionHorario=C.Dias+':'+C.Hora,Docentes=D.Apellido_Paterno+' '+D.Apellido_Materno+' '+D.Nombres,CA.CodDocente, C.Año, C.Periodo
			from TCursoActivo C inner join TCargaAcademica CA
				on (C.Codigo_CursoActivo=CA.CodCursoActivo and C.Grupo=CA.Grupo and C.Periodo=CA.Periodo and C.Año=CA.Año)
				inner join TDocentes D on(CA.CodDocente=D.Codigo_Docente)
	go

	/* ----------------  Vista para Todos los cursos que no tienen carga academica(de todos los meses, grupos, etc*)(tipo no es clave primaria) --------------- */
	CREATE VIEW viCursoSinCargaAcademica
	AS
		select C.Codigo_CursoActivo, C.Grupo, C.Periodo, C.Año
			from TCursoActivo C
		except 
		select T.Codigo_CursoActivo, T.Grupo, T.Periodo, T.Año
			from viCursosConCargaAcademica T 
	go


	/*========================================================================================================*/
	/*= = = = = = = = = = = = = = = = = = = = = = SEGUNDO SPRINT = = = = = = = = = = = = = = = = = = = = = = =*/
	/*========================================================================================================*/
	USE db_BDSistemaMantenimientosCCI
	GO

	/*  ***************************************************************************************** 
		|						CREACION DE LAS TABLAS DEL SISTEMA (2DO SPRINT)					|
		*****************************************************************************************  */
	/*---------------------------------------------------------------------------------------------*/
	/* TABLAS PARA EL MODULO GESTION BOLETAS - NINA HUARDAPUCLLA CARLOS */
	/*========================== TABLA PAQUETE ==========================*/
	CREATE TABLE TPaquete
	(
		Codigo_Paquete INT IDENTITY(1,1),
		--Codigo_curso varchar(5) not null,
		Denominacion VARCHAR(50) not null,
		Nro_Requisitos INT, -- NroRequisitos
		PRIMARY KEY (Codigo_paquete)
	)
	GO

	/*========================== TABLA DETALLE - PAQUETE ==========================*/
	CREATE TABLE TDetalle_Paquete
	(
		Codigo_Paquete int not null,
		Codigo_Curso varchar(5) not null,
		foreign key (Codigo_Paquete) references TPaquete(Codigo_Paquete),
		foreign key (Codigo_Curso) references TCurso(Codigo_Curso)
	)
	GO

	
	/* TABLAS PARA EL MODULO GESTION BOLETAS - HUAMAN PAOLA & ORTEGA ACCENT. */
	/*========================== TABLA GESTION BOLETAS ==========================*/
	create table TGestionBoletas
	(
		ID INT IDENTITY(1,1) NOT NULL,
		IDComprobante AS ('GB'+ RIGHT('0000'+CONVERT(VARCHAR,ID),(4))),
		Fecha DATETIME NOT NULL, -- Tabla Boleta(Fecha Emision)
		Estado VARCHAR(50) NOT NULL, -- Tabla Boleta(Observacion)
		Serie VARCHAR(10) NOT NULL, -- Tabla Boleta(Nro Serie)
		Comprobante VARCHAR(10) NOT NULL, -- Tabla Boleta(Codigo Boleta)
		Descripcion VARCHAR(50) NOT NULL, -- Tabla Boleta(Servicio)
		Doc VARCHAR(10) NOT NULL,-- DNI
		CodAlumno VARCHAR(10) NOT NULL, -- Tabla Estudiante
		ApellidosNombres VARCHAR(50) NOT NULL, -- Tabla Estudiante
		Monto FLOAT NOT NULL, -- Tabla Boleta(Pago)
		primary key (ID)
	);
	GO
	

	/*---------------------------------------------------------------------------------------------*/
	/* TABLAS PARA EL MODULO MATRICULA DAI - HUALVERDE QUISPE BENJAMIN */
	/*========================= Tabla de Alumnos con matriculas Postergadas =====================*/
	create table TMatriculaPostergada
	(
		CodMatriculaPostergada INT IDENTITY(1,1) not null, 
		CodMatricula  TCodMatricula,
		--Talvez ya no seria necesario agregar CodEstudiante, pero si seria bueno poner esto, para facilitar a un grupo encargado
		--De cambio de grupo
		CodEstudiante TCod_Estudiante
		primary key(CodMatriculaPostergada),
		foreign key(CodMatricula)references TMatricula
	)
	GO


	/*---------------------------------------------------------------------------------------------*/
	/* TABLAS PARA EL MODULO MATRICULA DAI - SANCA ZEVALLOS JERY */
	/*========================= Tabla ESTUDIANTE DAI =====================*/
	create table TEstudianteDAI
	( -- lista de atributos
	  CodEstudiante   TCod_Estudiante NOT NULL,
	  Nombre          varchar(40) NOT NULL,
	  ApPaterno       varchar(40) NOT NULL,
	  ApMaterno       varchar(40) NOT NULL,
	  TipoDocumento   varchar(8) NULL,
	  Email           varchar(50) NULL,
	  Sexo            varchar(2) NOT NULL,
	  -- definición de claves
	  PRIMARY KEY (CodEstudiante)
	)
	go

	/*========================= Tabla BOLETA DAI =====================*/
	create table TBoletaDAI
	( -- lista de atributos
	  NroBoleta          TNroBoleta NOT NULL,
	  NroSerie			varchar(10) not null,
	  Costo          varchar(4) ,
	  Pago          varchar(4) ,
	  CodCurso TCod_Curso Not NULL,
	  CodEstudiante       TCod_Estudiante,
	  Observacion   varchar(50) not null
	  -- definicion de claves
	  PRIMARY KEY (NroBoleta),
	  FOREIGN KEY (CodEstudiante) REFERENCES TEstudianteDAI(CodEstudiante)
	)
	go

	/*========================= Tabla CURSO DAI =====================*/
	create table TCursoDAI
	(
		CodCurso TCod_Curso not null,
		Grupo varchar(1),
		Nombre varchar(50),
		Vacantes int,
		primary key(CodCurso)
	)
	go

	/*========================= Tabla MATRICULA DAI =====================*/
	create table TMatriculaDAI
	( -- lista de atributos
	  CodMatricula      TCodMatricula NOT NULL,
	  Periodo			varchar(10) not null,
	  Año				int not null,
	  CodCurso			TCod_Curso not null,
	  NroBoleta         TCodBoleta NOT NULL,
	  PRIMARY KEY (CodMatricula),
	  FOREIGN KEY (NroBoleta) REFERENCES TBoletaDAI(NroBoleta),
	  FOREIGN KEY (CodCurso) REFERENCES TCursoDAI(CodCurso),
	 )
	 GO

	/*========================= Tabla ASIGNACIÓN CURSO =====================*/
	create table TAsignacionCurso
	(
	  Horario varchar(15) not null,
	  Aula varchar(10) not null,
	  CodCurso TCod_Curso not null,
	  Docente varchar(50)not null,
	  foreign key (CodCurso) references TCursoDAI(CodCurso)
	)
	GO

	/*---------------------------------------------------------------------------------------------*/
	/* TABLAS PARA EL MODULO BUSQUEDA E IMRESION DE CERTIFICADOS - GUERRA BELLIDO JHON WALDIR */
/*========================== TABLA CERTIFICADO EMITIDO ==========================*/
	CREATE TABLE TCertificadoEmitido
	(
		NroCertificado	NroCertificado,
		FechaEmision	DATE,
		Tipo			VARCHAR(10),
		Costo			FLOAT,
		CodAlumno		VARCHAR(10),
		Alumno			VARCHAR(30),
		-- Definicion de claves
		PRIMARY KEY (NroCertificado)
	)
	GO

	/*========================== DETALLE CERTIFICADO ==========================*/
	/*REVISION*/
	CREATE TABLE TDetalleCertificado
	(
		NroCertificado NroCertificado,
		Periodo		VARCHAR(15),
		Año			VARCHAR(4),
		Curso		VARCHAR(30),
		NroHoras		INT,
		Denominacion VARCHAR(30), --SI es paquete: OPERADOR ARCGIS, si es curso guardar NOMBRE DEL CURSO: ARCGIS I
		Tema		VARCHAR(30),
		Nota		INT,
		Docente		VARCHAR(30)
		-- Definicion de claves
		FOREIGN KEY (NroCertificado) REFERENCES TCertificadoEmitido(NroCertificado)
	)
	GO


	/*========================== CERTIFICADO IMPRESO ==========================*/
	CREATE TABLE TCertificadoImpreso
	(
		NroCertificado		NroCertificado,
		Alumno				VARCHAR(50),
		Denominacion		VARCHAR(30),
		FechaEmision		DATE,
		NroHoras			INT,
		FOREIGN KEY(NroCertificado) REFERENCES TCertificadoEmitido(NroCertificado)
	)
	GO


	/*========================== DETALLE IMPRESO ==========================*/
	CREATE TABLE TDetalleImpreso
	(
		NroCertificado		NroCertificado,
		Curso				VARCHAR(30),
		Tema				VARCHAR(30),
		Periodo				VARCHAR(15),
		Nota				INT,
		-- Definicion de claves
		FOREIGN KEY(NroCertificado) REFERENCES TCertificadoEmitido(NroCertificado)
	)
	GO

	/*---------------------------------------------------------------------------------------------*/
	/* TABLAS PARA EL MODULO MANTIMIENTO LABORATORIOS - KU ANDRADE ANGELO & DIAZ HUAYLUPO CHRISTIAN */
	/*========================== TABLA LABORATORIO ==========================*/
	CREATE TABLE TLaboratorio
	(
	-- Lista de atributos de la tabla Laboratorio
			CodLaboratorio TCodLaboratorio not null,
			Nombre VARCHAR(20) NOT NULL,
			Capacidad  INT,
			Ubicacion VARCHAR(70) default '--',
			Modalidad VARCHAR(30) check (Modalidad in ('VIRTUAL','PRESENCIAL','SEMIPRESENCIAL')),
			Sala VARCHAR(250) default '--',
			primary key(CodLaboratorio)
	)
	go


	/*---------------------------------------------------------------------------------------------*/
	/* TABLAS PARA EL MODULO MANTIMIENTO TIPO MATRICUA - NUÑEZ HUALLA ALFREDO */
	/* ================================== TMANTENIMIENTOMATRICULA =========================== */
	Create table TMantenimientoMatricula
	(
		CodMMatricula TCodMantenimientoMatricula NOT NULL,
		Descripcion VARCHAR(50) NOT NULL,
		Activo VARCHAR(10) NOT NULL,
		Convenio VARCHAR(10) NOT NULL,
		primary key (CodMMatricula)
	)
	go
	/* ================================== TDETALLE =========================== */
	Create table TDetalles
	(
		CodDetalles TCodDetalles NOT NULL,
		Año varchar(10) NOT NULL,
		Periodo varchar(10) NOT NULL,
		Documento VARCHAR(50) NOT NULL,
		Observaciones VARCHAR(100) NOT NULL,
		CodMMatricula TCodMantenimientoMatricula NOT NULL,
		primary key(CodDetalles),
		FOREIGN KEY (CodMMatricula) REFERENCES TMantenimientoMatricula(CodMMatricula)
	)
	go


	/*---------------------------------------------------------------------------------------------*/
	/* TABLAS PARA EL MODULO REGISTRO ASISTENCIA - HUARHUA JUANA YULIANA */
	CREATE TABLE TCursoAsistencia
	(
	-- Lista de atributos de la tabla Curso
		Codigo_Curso INT PRIMARY KEY,
		Nombre_Curso VARCHAR(50) NOT NULL,
		Grupo VARCHAR(5)	NOT NULL,
		Costo INT,
		DescripHorario VARCHAR(50) NOT NULL,
		CodLabo VARCHAR(50) NOT NULL,
		Docente VARCHAR(50),
		
	)
	GO


	/*  ***************************************************************************************** 
		|		FUNCIONES Y PROCEDIMIENTOS ALMACENADOS DE LA BASE DE DATOS (2DO SPRINT)			|
		*****************************************************************************************  */

	/* ================== PROCEDIMIENTOS ALMACENADOS PARA EL MODULO PAQUETE - NINA H. CARLOS A. ================== */
	/*--------------- Procedimiento para insertar un nuevo paquete ---------------*/
	CREATE PROCEDURE spInsertar_Paquete	
		@Denominacion varchar(50),
		@Nro_Requisitos int
	AS
	BEGIN
		begin try
			begin tran
				-- Insertar paquete en la tabla 
				INSERT INTO TPaquete output inserted.Codigo_Paquete
					VALUES (@Denominacion,@Nro_Requisitos)
				commit tran
		end try
		begin catch
				select ERROR_MESSAGE()
				rollback tran
		end catch

	END;
	GO

	/* ---------------- Procedimiento para Editar un Paquete --------------- */
	CREATE PROCEDURE spEditar_Paquete
	@Codigo_Paquete VARCHAR(6),
	@Denominacion varchar(50),
	@Nro_Requisitos int
	AS
	BEGIN
		begin try
			begin tran
				-- Editar Paquete en la tabla de TPaquete
				UPDATE TPaquete SET	Denominacion=@Denominacion,
									Nro_Requisitos=@Nro_Requisitos								
									-- Parametro de comparación
				WHERE Codigo_Paquete=@Codigo_Paquete
				commit tran
		end try
		begin catch
				select ERROR_MESSAGE()
				rollback tran
		end catch
	END;
	GO

	/* ---------------- Procedimiento para Eliminar un Paquete --------------- */
	CREATE PROCEDURE spEliminar_Paquete
		@Codigo_Paquete VARCHAR(6)
	AS
		-- Eliminar Paquete de la tabla
		DELETE FROM TPaquete
		-- Parametro de comparacion
		WHERE Codigo_Paquete=@Codigo_Paquete
	GO

	/* ---------------- Procedimiento para buscar un Paquete --------------- */	
	CREATE PROCEDURE spBuscar_Paquete
		@Denominacion VARCHAR(50)
	AS
		SELECT * FROM TPaquete
		WHERE Denominacion like @Denominacion+'%'
	GO

	/* ---------------- Procedimiento para listar Paquetes --------------- */
	CREATE PROCEDURE spListar_Paquetes
	AS
		SELECT * FROM TPaquete
		ORDER BY Denominacion ASC
	GO


	/* ================== PROCEDIMIENTOS ALMACENADOS PARA EL MODULO DETALLE_PAQUETE - NINA H. CARLOS A. ================== */
	/* ---------------- Procedimiento para insertar un Detalle_Paquete --------------- */
	CREATE PROCEDURE spInsertar_Detalle_Paquete	
	@Codigo_Paquete int,
	@Codigo_Curso varchar(5)
	AS
	BEGIN
		begin try
			begin tran
				-- Insertar codigo paquete y curso en la tabla 
				INSERT INTO TDetalle_Paquete
					VALUES (@Codigo_Paquete,@Codigo_Curso)
				commit tran
		end try
		begin catch
				select ERROR_MESSAGE()
				rollback tran
		end catch

	END;
	GO

	/* ---------------- Procedimiento para Eliminar un Detalle_Paquete --------------- */
	CREATE PROCEDURE spEliminar_Detalle_Paquete
	@Codigo_Paquete VARCHAR(6)
	AS
		-- Eliminar detalle paquete de la tabla
		DELETE FROM TDetalle_Paquete
		-- Parametro de comparacion
		WHERE Codigo_Paquete=@Codigo_Paquete
	GO

	/*---------------- Procedimiento Listar el contenido de cada paquete ----------------*/
	CREATE PROCEDURE spListar_Detalle_Paquete_especifico
	@Codigo_Paquete varchar(6)
	AS
	begin
		SELECT TC.Codigo_Curso,TC.Nombre_Curso,TC.Tipo_Curso,TC.Temas,TC.HorasxSemana	
			FROM TDetalle_Paquete P inner join TCurso TC 
				on P.Codigo_Curso = TC.Codigo_Curso
			where P.Codigo_Paquete = @Codigo_Paquete
		ORDER BY TC.Nombre_Curso ASC
	end
	GO


	/* ================== PROCEDIMIENTOS ALMACENADOS PARA EL MODULO GESTION BOLETAS - HUAMAN PAOLA Y ORTEGA ACCENT. ================== */
	/*---------------- Procedimiento Listar Gestion Boletas ----------------*/
	Create procedure ListarGestionBoletas
	AS
		select E.Codigo_Estudiante, E.Nombres, E.Apellido_Paterno, E.Apellido_Materno into #TAlumno from TEstudiante E
		select B.Codigo_Boleta as Id, B.FechaEmision, B.Observacion, B.NroSerie, A.Codigo_Estudiante, B.Pago
		from TBoleta B inner join #TAlumno A on B.Codigo_Estudiante = A.Codigo_Estudiante 
	GO

	/*---------------- Procedimiento Editar Gestion Boletas ----------------*/
	CREATE PROCEDURE EditarGestionBoletas
		@Estado varchar(50), 
		@Serie varchar(10), 
		@Comprobante varchar(10), 
		@IDComprobante varchar(10), 
		@Descripcion varchar(50), 
		@Doc varchar(10), 
		@CodAlumno varchar(10), 
		@ApellidosNombres varchar(50), 
		@Monto float
	AS
	BEGIN TRY
		BEGIN TRAN
			update TGestionBoletas 
			set  Estado =@Estado, Serie = @Serie, Comprobante = @Comprobante, Descripcion = @Descripcion, Doc = @Doc, CodAlumno = @CodAlumno, ApellidosNombres = @ApellidosNombres, Monto = @Monto
			where IDComprobante like @IDComprobante +'%'
		COMMIT
	END TRY

	BEGIN CATCH
		ROLLBACK
		PRINT ERROR_MESSAGE()
	END CATCH
	GO

	/*---------------- Procedimiento Buscar IDComprobante ----------------*/
	CREATE PROCEDURE BuscarIDComprobante @IDComprobante varchar(10)
	AS
		select IDComprobante as Id, Fecha, Estado, Serie, Comprobante, Descripcion, Doc, CodAlumno, ApellidosNombres, Monto
			from TGestionBoletas
			where IDComprobante like @IDComprobante +'%'
	GO

	/*---------------- Procedimiento Buscar Descripcion ----------------*/
	CREATE PROCEDURE BuscarDescripcion12 @Descripcion varchar(50)
	AS
		select IDComprobante as Id, Fecha, Estado, Serie, Comprobante, Descripcion, Doc, CodAlumno, ApellidosNombres, Monto
		from TGestionBoletas
		where Descripcion like @Descripcion +'%'
	GO

	/*---------------- Procedimiento Buscar Estado ----------------*/
	CREATE PROCEDURE BuscarEstado @Estado varchar(50)
	AS
		select IDComprobante as Id, Fecha, Estado, Serie, Comprobante, Descripcion, Doc, CodAlumno, ApellidosNombres, Monto
		from TGestionBoletas
		where Estado like @Estado +'%'
	GO

	/*---------------- Procedimiento Buscar Serie ----------------*/
	CREATE PROCEDURE BuscarSerie @Serie varchar(10)
	AS
		select IDComprobante as Id, Fecha, Estado, Serie, Comprobante, Descripcion, Doc, CodAlumno, ApellidosNombres, Monto
		from TGestionBoletas
		where Serie like @Serie +'%'
	GO

	/*---------------- Procedimiento Buscar Comprobante ----------------*/
	CREATE PROCEDURE BuscarComprobante @Comprobante varchar(10)
	AS
		select IDComprobante as Id, Fecha, Estado, Serie, Comprobante, Descripcion, Doc, CodAlumno, ApellidosNombres, Monto
		from TGestionBoletas
		where Comprobante like @Comprobante +'%'
	GO

	/*---------------- Procedimiento Buscar Doc ----------------*/
	CREATE PROCEDURE BuscarDoc @Doc varchar(10)
	AS
		select IDComprobante as Id, Fecha, Estado, Serie, Comprobante, Descripcion, Doc, CodAlumno, ApellidosNombres, Monto
		from TGestionBoletas
		where Doc like @Doc +'%'
	GO

	/*---------------- Procedimiento Buscar Alumno ----------------*/
	CREATE PROCEDURE BuscarCodAlumno @CodAlumno varchar(10)
	AS
		select IDComprobante as Id, Fecha, Estado, Serie, Comprobante, Descripcion, Doc, CodAlumno, ApellidosNombres, Monto
		from TGestionBoletas where CodAlumno like @CodAlumno +'%'
	GO

	/*---------------- Procedimiento Buscar Apellido ----------------*/
	CREATE PROCEDURE BuscarApellidosNombres @ApellidosNombres varchar(50)
	AS
		select IDComprobante as Id, Fecha, Estado, Serie, Comprobante, Descripcion, Doc, CodAlumno, ApellidosNombres, Monto
		from TGestionBoletas
		where ApellidosNombres like @ApellidosNombres +'%'
	GO

	/*---------------- Procedimiento Buscar Fecha/Año ----------------*/
	CREATE PROCEDURE BuscarFechaAño @Año int
	AS
		select IDComprobante as Id, Fecha, Estado, Serie, Comprobante, Descripcion, Doc, CodAlumno, ApellidosNombres, Monto
		from TGestionBoletas
		where YEAR(Fecha) = @Año
	GO

	/*---------------- Procedimiento Buscar Periodo ----------------*/
	CREATE PROCEDURE BuscarPeriodo @Periodo int
	AS
		select IDComprobante as Id, Fecha, Estado, Serie, Comprobante, Descripcion, Doc, CodAlumno, ApellidosNombres, Monto
		from TGestionBoletas
		where Month(Fecha) = @Periodo
	GO

	/*---------------- Procedimiento Transferir ----------------*/
	CREATE PROCEDURE Transferir 
		@Id INT, 
		@CodAlumno VARCHAR(10), 
		@ApellidosNombres VARCHAR(50)
	AS
	BEGIN TRY
	BEGIN TRAN
		update TGestionBoletas
	set CodAlumno = @CodAlumno, ApellidosNombres = @ApellidosNombres
	where Id = @Id

	COMMIT
	END TRY

	BEGIN CATCH
		ROLLBACK
		PRINT ERROR_MESSAGE()
	END CATCH
	GO


	/* ****************** PROCEDIMIENTOS ALMACENADOS PARA EL MODULO MATRICULA DAI - SANCCA JERY ****************** */
	/*---------------- Procedimiento para BUSCAR CURSOS DAI ----------------*/
	create proc sp_Buscar_mCursoDAI
	@Nombre varchar(50)
	as
		select*from TCursoDAI
		where (CodCurso like @Nombre+'%')or (Nombre like @Nombre+'%')
	go

	/*---------------- Procedimiento para LISTAR CURSOS DAI ----------------*/
	create proc sp_listar_mCursoDAI
	as
	select*
		from TCursoDAI
		order by CodCurso
	go

	/*---------------- Procedimiento para LISTAR ESTUDIANTES DAI ----------------*/
	create proc sp_listar_Estudiante
	as
		select*
		from TEstudianteDAI
		order by CodEstudiante
	go

	/*---------------- Procedimiento para BUSCAR ESTUDIANTES DAI ----------------*/
	create proc sp_Buscar_Alumno
	@Nombre varchar(50)
	as
	select*from TEstudianteDAI
	where (CodEstudiante like @Nombre+'%')
			or (Nombre like @Nombre+'%')
			or (ApMaterno like @Nombre+'%')
			or (ApPaterno like @Nombre+'%')
	go

	/*---------------- Procedimiento para INSERTAR ESTUDIANTES DAI ----------------*/
	create proc sp_insertar_Alumno
	@CodEstudiante   TCod_Estudiante,
	@Nombre          varchar(40) , 
	@ApPaterno       varchar(40)  ,
	@ApMaterno       varchar(40),
	@TipoDocumento   varchar(8),
	@Email           varchar(50), 
	@Sexo            varchar(2),
	@accion varchar(50) output
	as
	if(@accion='1')
	begin try
	--para probar
		declare @CodigoNuevo varchar(12),@CodigoMax varchar(12)
		set @CodigoMax=(select max(CodEstudiante)from TEstudianteDAI)
		set @CodigoMax=isnull(@CodigoMax,'18000')
		set @CodigoNuevo='18'+RIGHT(RIGHT(@CodigoMax,3)+11001,3)
		begin transaction
		insert into TEstudianteDAI(CodEstudiante,Nombre,ApPaterno,ApMaterno,TipoDocumento,Email,Sexo)
		values(@CodigoNuevo,@Nombre,@ApPaterno,@ApMaterno,@TipoDocumento, @Email ,@Sexo )
		commit transaction
		set @accion='Se Inserto el codigo: '+@CodigoNuevo
	end try

	begin catch
	--ejecutar si ocurre un error
	PRINT'Error Number : '+CAST(ERROR_NUMBER()AS varchar(10));
	PRINT'Error Message : '+ERROR_MESSAGE();
	PRINT'Error Severity : '+CAST(ERROR_SEVERITY()AS varchar(10));
	PRINT'Error State : '+CAST(ERROR_STATE()AS varchar(10));
	PRINT'Error Line : '+CAST(ERROR_LINE()AS varchar(10));
	PRINT'Error Proc: '+COALESCE(ERROR_PROCEDURE(),'Not within procedure')
	ROLLBACK TRANSACTION;

	end catch
	go

	/*---------------- Procedimiento para LISTAR CURSOS DAI ----------------*/
	create proc sp_listar_DAI
	as
		select C.CodCurso,C.Grupo,A.Horario,A.Aula,C.Nombre,B.Costo,A.Docente,C.Vacantes,Count(B.CodEstudiante)as Inscritos
		from TBoletaDAI B,TCursoDAI C,TAsignacionCurso A
		WHERE (C.CodCurso=B.CodCurso AND A.CodCurso=C.CodCurso )
		GROUP BY  C.CodCurso,C.Grupo,A.Horario,A.Aula,C.Nombre,B.Costo,A.Docente,C.Vacantes
		order by  C.CodCurso
	go

	/*---------------- Procedimiento para LISTAR ALUMNO ----------------*/
	create proc sp_listar_Alumnos
	@CodigoCurso varchar(50)
	as
		select E.CodEstudiante,CONCAT_WS(' ',E.Nombre,E.ApPaterno,E.ApMaterno) AS Nombre,B.Pago,B.Observacion,b.NroBoleta
		from TEstudianteDAI E,TBoletaDAI B
		where (E.CodEstudiante=B.CodEstudiante)AND(B.CodCurso like @CodigoCurso+'%')
	go

	/*---------------- Procedimiento para INSERTAR BOLETA ----------------*/
	create proc sp_insertar_Boleta
	@NroBoleta   TNroBoleta,
	@NroSerie         varchar(10) , 
	@Costo      varchar(4),
	@Pago           varchar(4),
	@CodCurso TCod_Curso,
	@CodEstudiante Tcod_Estudiante,
	@Observacion varchar(50),
	@accion varchar(50) output
	as
	if(@accion='1')
	begin try
	--para probar
		declare @NroSerieNuevo varchar(12),@NroSerieMax varchar(12)
		declare @NroBoletaNuevo TNroBoleta,@NroBoletaMax TNroBoleta
		declare @CostoNuevo varchar(4)
		set @CostoNuevo='10'
		set @NroSerieMax=(select max(NroSerie)from TBoletaDAI)
		set @NroSerieMax=isnull(@NroSerieMax,'100')
		set @NroSerieNuevo='1'+RIGHT(RIGHT(@NroSerieMax,2)+101,2)

		set @NroBoletaMax=(select max(NroBoleta)from TBoletaDAI)
		set @NroBoletaMax=isnull(@NroBoletaMax,'100000')
		set @NroBoletaNuevo='1'+RIGHT(RIGHT(@NroBoletaMax,5)+100001,5)

		begin transaction
		insert into TBoletaDAI(NroBoleta,NroSerie,Costo,Pago,CodCurso,CodEstudiante,Observacion)
		values(@NroBoletaNuevo,@NroSerieNuevo,@CostoNuevo,@Pago,@CodCurso,@CodEstudiante,@Observacion)
		commit transaction
		set @accion='Se Inserto la Boleta : '+@NroBoletaNuevo
	end try

	begin catch
	--ejecutar si ocurre un error
	PRINT'Error Number : '+CAST(ERROR_NUMBER()AS varchar(10));
	PRINT'Error Message : '+ERROR_MESSAGE();
	PRINT'Error Severity : '+CAST(ERROR_SEVERITY()AS varchar(10));
	PRINT'Error State : '+CAST(ERROR_STATE()AS varchar(10));
	PRINT'Error Line : '+CAST(ERROR_LINE()AS varchar(10));
	PRINT'Error Proc: '+COALESCE(ERROR_PROCEDURE(),'Not within procedure')
	ROLLBACK TRANSACTION;
	end catch
	GO

	/*---------------- Procedimiento para LISTAR BOLETA ----------------*/
	create proc sp_listar_Boleta
	as
	select*
	from TBoletaDAI
	order by NroBoleta
	go


	/* ****************** PROCEDIMIENTOS ALMACENADOS PARA EL MODULO BUSQUEDA E IMPRESION CERTIFICADOS - GUERRA BELLIDO JHON ****************** */
	--Seleccionar Rango de Certificados
CREATE PROC pRangoCertificados @LInferior VARCHAR(2), @LSuperior VARCHAR(2), @Año VARCHAR(4)
AS
BEGIN
	SELECT C.NroCertificado, D.NroHoras, C.FechaEmision, C.Costo, C.CodAlumno, C.Alumno, D.Periodo, D.Año, D.Curso, D.Denominacion, D.Nota, D.Tema, C.Tipo
	FROM TCertificadoEmitido C INNER JOIN TDetalleCertificado D
	ON C.NroCertificado = D.NroCertificado
	WHERE C.NroCertificado > @LInferior  and C.NroCertificado < @LSuperior and D.Año = @Año
END
GO

--SELECCIONAR CERTIFICADOS SEGUN LA FECHA
CREATE PROC pRangoCertificadosFecha @LInferior VARCHAR(2), @LSuperior VARCHAR(2), @Año VARCHAR(4), @Fecha DATE
AS
BEGIN
	SELECT C.NroCertificado, D.NroHoras, C.FechaEmision, C.Costo, C.CodAlumno, C.Alumno, D.Periodo, D.Año, D.Curso, D.Denominacion, D.Nota, D.Tema, C.Tipo
	FROM TCertificadoEmitido C INNER JOIN TDetalleCertificado D
	ON C.NroCertificado = D.NroCertificado
	WHERE C.NroCertificado > @LInferior  and C.NroCertificado < @LSuperior and D.Año = @Año and C.FechaEmision = @Fecha
END
GO


--BUSCAR CERTIFICADO EN ESPECIFICO
CREATE PROC pBuscarCertificado @NroCertificado INT
AS
BEGIN
	SELECT C.NroCertificado, D.NroHoras, C.FechaEmision, C.Costo, C.CodAlumno, C.Alumno, D.Periodo, D.Año, D.Curso, D.Denominacion, D.Nota, D.Tema, C.Tipo
	FROM TCertificadoEmitido C INNER JOIN TDetalleCertificado D
	on C.NroCertificado = D.NroCertificado
	WHERE C.NroCertificado = @NroCertificado
END
GO


--PROCEDIMIENTOS PARA INSERTAR VALORES A LA TABLA CERTIFICADO IMPRESO
CREATE PROC pInsertarCertificadoImpreso  
					@NroCertificado	INT,
					@Alumno			VARCHAR(50),
					@Denominacion	VARCHAR(30),
					@FechaEmision	DATE,
					@NroHoras		INT
AS
BEGIN
	BEGIN TRY
		INSERT INTO TCertificadoImpreso(NroCertificado, Alumno, Denominacion, FechaEmision, NroHoras) 
								VALUES(@NroCertificado, @Alumno, @Denominacion, @FechaEmision, @NroHoras)
	END TRY
	BEGIN CATCH
		ROLLBACK
		PRINT ERROR_MESSAGE()
	END CATCH
END
GO


--PROCEDIMIENTOS PARA INSERTAR VALORES A LA TABLA DETALLE IMPRESO
CREATE PROC pInsertarDetalleImpreso 
			@NroCertificado INT,
			@Curso			VARCHAR(30),
			@Tema			VARCHAR(30),
			@Periodo		VARCHAR(15),
			@Nota			INT
AS
BEGIN
	BEGIN TRY
		INSERT INTO TDetalleImpreso(NroCertificado, Curso, Tema, Periodo, Nota) 
							VALUES(@NroCertificado, @Curso, @Tema,@Periodo, @Nota)
	END TRY
	BEGIN CATCH
		ROLLBACK
		PRINT ERROR_MESSAGE()
	END CATCH
END
GO

-- PROCEDIMIENTO PARA MOSTRAR LOS CERTIFICADOS IMPRESOS
--BUSCAR CERTIFICADO EN ESPECIFICO
CREATE PROC pListarCertificadoImpreso
AS
	BEGIN
		SELECT* FROM TCertificadoImpreso
	END
GO

-- PROCEDIMIENTO PARA MOSTRAR EL DETALLE DE IMPRESO
CREATE PROC pListarDetalleImpreso
AS
	BEGIN
		SELECT* FROM TDetalleImpreso
	END
GO

	/* ****************** PROCEDIMIENTOS ALMACENADOS PARA EL MODULO REGISTROI NOTAS - BENJAMIN HUALVERDE ****************** */
	/*---------------- PROCEDIMIENTO PARA MOSTRAR CARGA ACADEMICA DOCENTES 1ER DATAGRIDVIEW ---------------*/
	create procedure SP_MostrarCargaAcademica_Docentes
	@Año varchar(4),
	@Periodo varchar(11),
	@Tipo varchar(3)
	as
	begin
		select CodCursoActivo, T.Grupo, C.Nombre,DescripcionHorario=Dias+':'+Hora,Docente
			from(select CodCursoActivo,Grupo,Docente=Apellido_Paterno+' '+Apellido_Materno+ ' '+Nombres,Periodo,Año
					from TCargaAcademica T1 inner join TDocentes T2 on T1.CodDocente=T2.Codigo_Docente)T 
				inner join TCursoActivo C on T.CodCursoActivo=C.Codigo_CursoActivo and T.Periodo=C.Periodo and T.Año=C.Año and T.Grupo=C.Grupo
				where T.Periodo=@Periodo and T.Año=@Año and Tipo=@Tipo
	end
	go

	/*---------------- PROCEDIMIENTO PARA Buscar CargaAcademica_Docentes por Codigo de Curso ---------------*/
	create procedure SP_MostrarCargaAcademica_Docentes_BuscarxCodigoCurso
	@Año varchar(4),
	@Periodo varchar(11),
	@Tipo varchar(3),
	@cadena varchar(20)
	as
		select CodCursoActivo, T.Grupo, C.Nombre,DescripcionHorario=Dias+':'+Hora,Docente
			from(select CodCursoActivo,Grupo,Docente=Apellido_Paterno+' '+Apellido_Materno+ ' '+Nombres,Periodo,Año
					from TCargaAcademica T1 inner join TDocentes T2 on T1.CodDocente=T2.Codigo_Docente)T 
				inner join TCursoActivo C on T.CodCursoActivo=C.Codigo_CursoActivo and T.Periodo=C.Periodo and T.Año=C.Año and T.Grupo=C.Grupo
				where T.Periodo=@Periodo and T.Año=@Año and Tipo=@Tipo and CodCursoActivo like @cadena+'%'
	go

	/*---------------- PROCEDIMIENTO PARA Buscar CargaAcademica_Docentes por Nombre de asignatura ---------------*/
	create procedure SP_MostrarCargaAcademica_Docentes_BuscarxNombreAsignatura
	@Año varchar(4),
	@Periodo varchar(11),
	@Tipo varchar(3),
	@cadena varchar(70)
	as
		select CodCursoActivo, T.Grupo, C.Nombre,DescripcionHorario=Dias+':'+Hora,Docente
			from(select CodCursoActivo,Grupo,Docente=Apellido_Paterno+' '+Apellido_Materno+ ' '+Nombres,Periodo,Año
					from TCargaAcademica T1 inner join TDocentes T2 on T1.CodDocente=T2.Codigo_Docente)T 
				inner join TCursoActivo C on T.CodCursoActivo=C.Codigo_CursoActivo and T.Periodo=C.Periodo and T.Año=C.Año and T.Grupo=C.Grupo
				where T.Periodo=@Periodo and T.Año=@Año and Tipo=@Tipo and C.Nombre like @cadena+'%'
	go

	/*---------------- PROCEDIMIENTO PARA Buscar CargaAcademica_Docentes por Codigo de Curso ---------------*/
	create procedure SP_MostrarCargaAcademica_Docentes_BuscarxDocente
	@Año varchar(4),
	@Periodo varchar(11),
	@Tipo varchar(3),
	@cadena varchar(20)
	as
		select CodCursoActivo, T.Grupo, C.Nombre,DescripcionHorario=Dias+':'+Hora,Docente
			from(select CodCursoActivo,Grupo,Docente=Apellido_Paterno+' '+Apellido_Materno+ ' '+Nombres,Periodo,Año
					from TCargaAcademica T1 inner join TDocentes T2 on T1.CodDocente=T2.Codigo_Docente)T 
				inner join TCursoActivo C on T.CodCursoActivo=C.Codigo_CursoActivo and T.Periodo=C.Periodo and T.Año=C.Año and T.Grupo=C.Grupo
				where T.Periodo=@Periodo and T.Año=@Año and Tipo=@Tipo and Docente like @cadena+'%'
	go

	/*---------------- PROCEDIMIENTO PARA MOSTRAR NOTAS ALUMNOS 2DO DATAGRIDVIEW ---------------*/
	create procedure SP_MostrarNotasAlumnos
	@CodCurso varchar(5),
	@Grupo varchar(1),
	@Año varchar(4),
	@Periodo varchar(11)
	as
		select CodMatricula, R.Codigo_Estudiante,Alumnos=E.Apellido_Paterno+' '+E.Apellido_Materno+' '+Nombres,nota1,nota2,nota3,nota4,nota5,nota6,nota7,nota8,nota9,nota10
			from(select CodMatricula,Anio,Mes,M.Grupo,M.CodCursoActivo,M.CodBoleta,Codigo_Estudiante,nota1,nota2,nota3,nota4,nota5,nota6,nota7,nota8,nota9,nota10 
						from TMatricula M inner join TBoleta B on M.CodBoleta=B.Codigo_Boleta
						where M.Anio=@Año and M.Mes=@Periodo and M.CodCursoActivo=@CodCurso and M.Grupo=@Grupo)R
			inner join TEstudiante E on R.Codigo_Estudiante=E.Codigo_Estudiante
	go

	/*---------------- PROCEDIMIENTO PARA Buscar alumno por Codigo ---------------*/
	create procedure SP_MostrarNotasAlumnos_BuscarxCodigo
	@CodCurso varchar(5),
	@Grupo varchar(1),
	@Año varchar(4),
	@Periodo varchar(11),
	@cadena varchar(20)
	as
		select CodMatricula, R.Codigo_Estudiante,Alumnos=E.Apellido_Paterno+' '+E.Apellido_Materno+' '+Nombres,nota1,nota2,nota3,nota4,nota5,nota6,nota7,nota8,nota9,nota10
			from(select CodMatricula,Anio,Mes,M.Grupo,M.CodCursoActivo,M.CodBoleta,Codigo_Estudiante,nota1,nota2,nota3,nota4,nota5,nota6,nota7,nota8,nota9,nota10 
						from TMatricula M inner join TBoleta B on M.CodBoleta=B.Codigo_Boleta
						where M.Anio=@Año and M.Mes=@Periodo and M.CodCursoActivo=@CodCurso and M.Grupo=@Grupo)R
			inner join TEstudiante E on R.Codigo_Estudiante=E.Codigo_Estudiante
			where R.Codigo_Estudiante like @cadena+'%'
	go

	/*---------------- PROCEDIMIENTO PARA Buscar alumno por  Apellidos y Nombre ---------------*/
	create procedure SP_MostrarNotasAlumnos_BuscarxApellidosNombres
	@CodCurso varchar(5),
	@Grupo varchar(1),
	@Año varchar(4),
	@Periodo varchar(11),
	@cadena varchar(20)
	as
		select CodMatricula, R.Codigo_Estudiante,Alumnos=E.Apellido_Paterno+' '+E.Apellido_Materno+' '+Nombres,nota1,nota2,nota3,nota4,nota5,nota6,nota7,nota8,nota9,nota10
			from(select CodMatricula,Anio,Mes,M.Grupo,M.CodCursoActivo,M.CodBoleta,Codigo_Estudiante,nota1,nota2,nota3,nota4,nota5,nota6,nota7,nota8,nota9,nota10 
						from TMatricula M inner join TBoleta B on M.CodBoleta=B.Codigo_Boleta
						where M.Anio=@Año and M.Mes=@Periodo and M.CodCursoActivo=@CodCurso and M.Grupo=@Grupo)R
			inner join TEstudiante E on R.Codigo_Estudiante=E.Codigo_Estudiante
			where E.Apellido_Paterno like @cadena+'%' or E.Apellido_Materno like @cadena+'%' or E.Nombres like @cadena+'%'
	go

	/*----------------()()()() PROCEDIMIENTOS PARA MATRICULA POSTERGADA ()()()()---------------*/
	/*---------------- PROCEDIMIENTO PARA INSERTAR UNA MATRICULA POSTERGADA --------------*/
	create procedure SP_InsertarMatriculaPostergada
	@CodMatricula varchar(8),
	@CodEstudiante varchar(6)
	AS
	BEGIN
		begin try
			begin tran
				-- Insertar registro en la tabla Matricula Postergada 
				INSERT INTO TMatriculaPostergada VALUES (@CodMatricula,@CodEstudiante)
				commit tran
		end try
		begin catch
				select ERROR_MESSAGE()
				rollback tran
		end catch

	END;
	GO

	/*---------------- PROCEDIMIENTO PARA INSERTAR MATRICULA(Como se agregaron otros atributos) --------------*/
	create procedure SP_InsertarMatricula
	@CodMatricula varchar(8),
	@Año varchar(4),
	@Periodo varchar(11),
	@Grupo varchar(1),
	@CodCursoActivo varchar(5),
	@CodBoleta varchar(12),
	@TipoMatricula varchar(3)
	AS
	BEGIN
		begin try
			begin tran
				-- Insertar registro en la tabla Matricula SIN LAS NOTAS
				insert into TMatricula(CodMatricula,Anio,Mes,Grupo,CodCursoActivo,CodBoleta,TipoMatricula) values(@CodMatricula,@Año,@Periodo,@Grupo,@CodCursoActivo,@CodBoleta,@TipoMatricula)
				commit tran
		end try
		begin catch
				select ERROR_MESSAGE()
				rollback tran
		end catch

	END;
	GO

	/*---------------- PROCEDIMIENTO PARA CREAR LOS REGISTROS DE NOTAS --------------*/
	create procedure SP_ObtenerCursosPaquete -- donde @CodCurso puede ser @CodCursoActivo
	@CodCurso varchar(5)
	as
	select Codigo_Paquete,P.Codigo_Curso,Nombre_Curso 
		from TDetalle_Paquete P inner join TCurso C on P.Codigo_Curso=C.Codigo_Curso 
		where Codigo_Paquete=@CodCurso
	go

	/*---------------- PROCEDIMIENTO PARA CREAR REAR REGISTRO DE NOTA("INICIALIZAR TODAS LAS COLMNAS CON EL VALOR DE CERO)--------------*/
	create procedure SP_CrearRegistroDeNotas
	@CodMatricula varchar(8),
	@nota1 float,
	@nota2 float,
	@nota3 float,
	@nota4 float,
	@nota5 float,
	@nota6 float,
	@nota7 float,
	@nota8 float,
	@nota9 float,
	@nota10 float

	AS
	BEGIN
		begin try
			begin tran
				-- Editar estudiante en la tabla de Estudiante
				UPDATE TMatricula SET	nota1=@nota1,
										nota2=@nota2,
										nota3=@nota3,
										nota4=@nota4,
										nota5=@nota5,
										nota6=@nota6,
										nota7=@nota7,
										nota8=@nota8,
										nota9=@nota9,
										nota10=@nota10
										-- Parametro de comparación
				WHERE CodMatricula=@CodMatricula
				commit tran
		end try
		begin catch
				select ERROR_MESSAGE()
				rollback tran
		end catch
	END;
	GO

	/*---------------- PROCEDIMIENTO PARA LIMPIAR REGISTRO DE NOTAS --------------*/
	create procedure SP_LimpiarRegistroDeNotas
	@CodMatricula varchar(8)
	AS
	BEGIN
		begin try
			begin tran
				-- Editar estudiante en la tabla de Estudiante
				UPDATE TMatricula SET	nota1=null,
										nota2=null,
										nota3=null,
										nota4=null,
										nota5=null,
										nota6=null,
										nota7=null,
										nota8=null,
										nota9=null,
										nota10=null
										-- Parametro de comparación
				WHERE CodMatricula=@CodMatricula
				commit tran
		end try
		begin catch
				select ERROR_MESSAGE()
				rollback tran
		end catch
	END;
	GO


	/* ****************** PROCEDIMIENTOS ALMACENADOS PARA EL MODULO MATRICULA CONVENIO CCI - IVAN SUMIRE ****************** */
	/*---------------- PROCEDIMIENTO PARA BUSCAR ESTUDIANTE MATRICULADO---------------*/
	create proc SP_Buscar_EstudianteMatriculadoConvenio
	@Codigo varchar(50)
	AS
	BEGIN TRY
		select*
		from TEstudiante
		where Codigo_Estudiante like @Codigo+'%'
	END TRY
	BEGIN CATCH
		SELECT ERROR_MESSAGE()
		ROLLBACK TRAN
	END CATCH
	GO

	/*---------------- PROCEDIMIENTO PARA MANTENIMIENTO DE ESTUDIANTE MATRICULADO ---------------*/
	CREATE PROCEDURE SP_Mantenimiento_EstudianteMatriculadoConvenio
	@CodEstudiante varchar(12),
	@Nombre varchar(40),
	@AppPaterno varchar(40),
	@AppMaterno varchar(40),
	@DNI varchar(8),
	@Email varchar(50),
	@accion varchar(50) output
	AS
	BEGIN
		IF(@accion='1')
			BEGIN TRY
				BEGIN TRANSACTION
				insert into TEstudiante(Codigo_Estudiante,Nombres,Apellido_Paterno,Apellido_Materno,DNI,Email)
				values(@CodEstudiante,@Nombre,@AppPaterno,@AppMaterno,@DNI,@Email)
				COMMIT TRANSACTION
				set @accion='Se genero el codigo: '+@CodEstudiante
			END TRY
			BEGIN CATCH
				SELECT ERROR_MESSAGE()
				ROLLBACK TRAN
			END CATCH
		ELSE IF(@accion='2')
			BEGIN TRY
				BEGIN TRANSACTION
				update TEstudiante set Nombres=@Nombre,Apellido_Paterno=@AppPaterno,Apellido_Materno=@AppMaterno,DNI=@DNI,Email=@Email where Codigo_Estudiante=@CodEstudiante
				COMMIT TRANSACTION
				set @accion='Se modifico el codigo:' + @CodEstudiante
			END TRY
			BEGIN CATCH
				SELECT ERROR_MESSAGE()
				ROLLBACK TRAN
			END CATCH
		ELSE IF(@accion='3')
			BEGIN TRY
				BEGIN TRANSACTION
				DELETE FROM TEstudiante
				WHERE Codigo_Estudiante=@CodEstudiante
				COMMIT TRANSACTION
				SET @accion='Se borro el codigo: '+@CodEstudiante
			END TRY
			BEGIN CATCH
				SELECT ERROR_MESSAGE()
				ROLLBACK TRAN
			END CATCH
	END;
	GO

	/*---------------- PROCEDIMIENTO ALMACENADO PARA MANTENIMIENTO DE BOLETA DE ESTUDIANTE ---------------*/
	CREATE PROCEDURE SP_Mantenimiento_BoletadeMatriculaConvenio
	  @CodBoleta varchar(12),
	  @NroSerie varchar(10),
	  @FechaEmision varchar(50),
	  @Costo numeric(15,2),
	  @TipoDsto varchar(15),
	  @Pago numeric(15,2),
	  @Codigo_CursoActivo varchar(15),
	  @CodEstudiante varchar(12),
	  @Observacion varchar(50),
	  @accion varchar(50) output
	AS
	IF(@accion='1')
	BEGIN TRY
		--para probar
			BEGIN TRANSACTION
			INSERT INTO TBoleta(Codigo_Boleta,NroSerie,FechaEmision,Costo,TipoDsto,Pago,Codigo_CursoActivo,Codigo_Estudiante,Observacion)
			VALUES(@CodBoleta,@NroSerie,@FechaEmision,@Costo,@TipoDsto,@Pago,@Codigo_CursoActivo,@CodEstudiante,@Observacion)
			COMMIT TRANSACTION
			SET @accion='Se genero el codigo: '+@CodBoleta
	END TRY
	BEGIN CATCH
			--ejecutar si ocurre un error
			PRINT'Error Number : '+CAST(ERROR_NUMBER()AS VARCHAR(10));
			PRINT'Error Message : '+ERROR_MESSAGE();
			PRINT'Error Severity : '+CAST(ERROR_SEVERITY()AS VARCHAR(10));
			PRINT'Error State : '+CAST(ERROR_STATE()AS VARCHAR(10));
			PRINT'Error Line : '+CAST(ERROR_LINE()AS VARCHAR(10));
			PRINT'Error Proc: '+COALESCE(ERROR_PROCEDURE(),'Not within procedure')
			ROLLBACK TRANSACTION;
	END CATCH
	ELSE IF(@accion='2')
	BEGIN TRY
			BEGIN TRANSACTION
			update TBoleta set Codigo_Boleta = @CodBoleta,NroSerie = @NroSerie, FechaEmision=@FechaEmision,Costo = @Costo,TipoDsto = @TipoDsto,
			Pago = @Pago,Codigo_CursoActivo = @Codigo_CursoActivo,Codigo_Estudiante = @CodEstudiante,Observacion = @Observacion where Codigo_Boleta=@CodBoleta
			COMMIT TRANSACTION
			set @accion='Se modifico el codigo:' + @CodBoleta
	END TRY
	BEGIN CATCH
			--ejecutar si ocurre un error
			PRINT'Error Number : '+CAST(ERROR_NUMBER()AS VARCHAR(10));
			PRINT'Error Message : '+ERROR_MESSAGE();
			PRINT'Error Severity : '+CAST(ERROR_SEVERITY()AS VARCHAR(10));
			PRINT'Error State : '+CAST(ERROR_STATE()AS VARCHAR(10));
			PRINT'Error Line : '+CAST(ERROR_LINE()AS VARCHAR(10));
			PRINT'Error Proc: '+COALESCE(ERROR_PROCEDURE(),'Not within procedure')
			ROLLBACK TRANSACTION;
	END CATCH
	ELSE IF(@accion='3')
	BEGIN TRY
			BEGIN TRANSACTION
			DELETE FROM TBoleta
			WHERE Codigo_Boleta = @CodBoleta
			COMMIT TRANSACTION
			SET @accion='Se borro el codigo: '+ @CodBoleta
	END TRY
	BEGIN CATCH
			--ejecutar si ocurre un error
			PRINT'Error Number : '+CAST(ERROR_NUMBER()AS VARCHAR(10));
			PRINT'Error Message : '+ERROR_MESSAGE();
			PRINT'Error Severity : '+CAST(ERROR_SEVERITY()AS VARCHAR(10));
			PRINT'Error State : '+CAST(ERROR_STATE()AS VARCHAR(10));
			PRINT'Error Line : '+CAST(ERROR_LINE()AS VARCHAR(10));
			PRINT'Error Proc: '+COALESCE(ERROR_PROCEDURE(),'Not within procedure')
			ROLLBACK TRANSACTION;
	END CATCH
	GO

	/*---------------- PROCEDIMIENTO ALMACENADO PARA MOSTRAR "CURSO ACTIVO" ---------------*/
	CREATE PROCEDURE SP_Mostrar_CursoActivoConvenio
	AS
	BEGIN 
	BEGIN TRY 
		begin tran
		SELECT Codigo_CursoActivo,Nombre,(Codigo_CursoActivo) as codigo FROM TCursoActivo
		commit tran
	END TRY
	BEGIN CATCH
		SELECT ERROR_MESSAGE()
		ROLLBACK TRAN
	END CATCH
	END;
	GO

	/*---------------- PROCEDIMIENTO ALMACENADO PARA MOSTRAR CURSOS CON LA CANTIDAD DE ALUMNOS CONVENIO  MATRICULADOS ---------------*/
	CREATE PROCEDURE SP_DetalleMatriculaCurso
	AS
	BEGIN
		BEGIN TRY
			SELECT  DISTINCT B.Codigo_CursoActivo,B.Nombre,B.Grupo,E.Costo,C.Inscritos,B.Vacantes
				FROM TBoleta E inner join TCursoActivo B
				ON  (E.Codigo_CursoActivo = B.Codigo_CursoActivo) inner join dbo.fnALUMNOS_MATRICULADOS() C ON (B.Codigo_CursoActivo=C.Codigo_CursoActivo)
		END TRY
		BEGIN CATCH
			SELECT ERROR_MESSAGE()
			ROLLBACK TRAN
		END CATCH
	END;
	GO

	/*------------------- FUNCION PARA DETERMINAR CANTIDAD DE ALUMNOS A CADA CURSO -------------------------*/
	CREATE FUNCTION fnALUMNOS_MATRICULADOS_Convenio()
	RETURNS TABLE
	AS
	RETURN (SELECT B.Codigo_CursoActivo,count(E.Codigo_Estudiante) as Inscritos
				FROM TBoleta E inner join TCursoActivo B
				ON  (E.Codigo_CursoActivo = B.Codigo_CursoActivo) inner join TMatricula C ON (C.CodBoleta=E.Codigo_Boleta)
				where C.TipoMatricula = 'CVN' 
				Group by B.Codigo_CursoActivo)
	go

	/*------------------- PROCEDIMIENTO  PARA MOSTRAR DATOS DE ALUMNOS CONVENIO DE UN DETERMINADO CURSO -------------------------*/
	CREATE PROCEDURE SP_Detalle_Matricula_Estudiante_PagoConvenio
	AS
	BEGIN
		BEGIN TRY
			SELECT E.Codigo_Estudiante,E.Nombres,E.Apellido_Paterno,E.Apellido_Materno,E.DNI,E.Email,B.Codigo_Boleta,B.NroSerie,B.TipoDsto,B.Costo,B.Pago,B.Observacion
				FROM TEstudiante E inner join TBoleta B
				ON  (E.Codigo_Estudiante = B.Codigo_Estudiante) Inner join TMatricula C ON ( C.CodBoleta=B.Codigo_Boleta)
				Where C.TipoMatricula='CVN'
		END TRY
		BEGIN CATCH
			SELECT ERROR_MESSAGE()
			ROLLBACK TRAN
		END CATCH
	END;
	GO

	/*------------------- PROCEDIMIENTO  PARA MOSTRAR DATOS DE ALUMNOS CONVENIO -------------------------*/
	CREATE PROCEDURE SP_Detalle_Alumnos_MatriculadosConvenio 
	@CodCursoActivo varchar(15)
	AS
	BEGIN
		BEGIN TRY
			SELECT E.Codigo_Estudiante,E.Nombres,E.Apellido_Paterno,E.Apellido_Materno,E.DNI,E.Email,B.Codigo_Boleta,B.NroSerie,B.TipoDsto,B.Costo,B.Pago,B.Observacion
				FROM TEstudiante E inner join TBoleta B
				ON  (E.Codigo_Estudiante = B.Codigo_Estudiante) Inner join TMatricula C ON ( C.CodBoleta=B.Codigo_Boleta)
				Where C.TipoMatricula='CVN' and  B.Codigo_CursoActivo=@CodCursoActivo
		END TRY
		BEGIN CATCH
			SELECT ERROR_MESSAGE()
			ROLLBACK TRAN
		END CATCH
	END;
	GO

	/*------------------- PROCEDIMIENTO  PARA MANTENIMIENTO DE MATRICULA  -------------------------*/
	CREATE PROCEDURE SP_InsertarDatosMatriculaConvenio
	@CodMatricula varchar(12),
	@Anio varchar(4),
	@Mes varchar(10),
	@TipoMatricula varchar(10),
	@Cod_CurActivo varchar(8),
	@CodBoleta varchar(10),
	@accion varchar(50) output
	AS
	BEGIN
		IF(@accion='1')
			BEGIN TRY
				BEGIN TRANSACTION
				insert into TMatricula(CodMatricula,Anio, Mes,CodCursoActivo,CodBoleta)
				values(@CodMatricula,@Anio, @Mes,@Cod_CurActivo,@CodBoleta)
				COMMIT TRANSACTION
				set @accion='Se genero el codigo: '+@CodMatricula
			END TRY
			BEGIN CATCH
				SELECT ERROR_MESSAGE()
				ROLLBACK TRAN
			END CATCH
	END;
	GO


	/* ****************** PROCEDIMIENTOS ALMACENADOS PARA EL MODULO MANTENIMIENTO LABORATORIO - ANGELO KU ****************** */
	/*------------------- PROCEDIMIENTO  PARA  MANTENIMIENTO LABORATORIO  -------------------------*/
	CREATE PROCEDURE SP_Mantenimiento_Laboratorio
		@CodLaboratorio VARCHAR(6),
		@Nombre VARCHAR(20),
	    @Capacidad int,
		@Ubicacion varchar (70),
		@Modalidad varchar (30),
		@Sala varchar (250),
		@Accion varchar(50) output
	AS
	BEGIN
		IF(@Accion='1')
			BEGIN TRY
				begin tran
				insert into TLaboratorio(CodLaboratorio,Nombre,Capacidad,Ubicacion, Modalidad, Sala)
				values(@CodLaboratorio,@Nombre,@Capacidad,@Ubicacion, @Modalidad, @Sala)
				set @Accion='El codigo ha sido generado: ' + @CodLaboratorio
				commit tran
			END TRY
			BEGIN CATCH
				SELECT ERROR_MESSAGE()
				ROLLBACK TRAN
			END CATCH
		ELSE IF(@Accion='2')
			BEGIN TRY
				begin tran
				update TLaboratorio set Nombre = @Nombre,Capacidad = @Capacidad,Ubicacion = @Ubicacion,
				                        Modalidad = @Modalidad, Sala = @Sala
				where CodLaboratorio=@CodLaboratorio
				set @Accion='El codigo ha sido modificado:' + @CodLaboratorio
				commit tran
			END TRY
			BEGIN CATCH
				SELECT ERROR_MESSAGE()
				ROLLBACK TRAN
			END CATCH
		ELSE IF(@Accion='3')
			BEGIN TRY
				begin tran
				DELETE FROM TLaboratorio
				WHERE CodLaboratorio = @CodLaboratorio
				SET @Accion='El codigo ha sido eliminado: ' + @CodLaboratorio
				commit tran
			END TRY
			BEGIN CATCH
				SELECT ERROR_MESSAGE()
				ROLLBACK TRAN
			END CATCH
	END;
	GO

	/*------------------- PROCEDIMIENTO  PARA  Listar laboratorios  -------------------------*/
	CREATE PROCEDURE SP_Listar_Laboratorios
	AS
		select*
		from TLaboratorio 
		order by CodLaboratorio
	GO

	/*------------------- PROCEDIMIENTO  PARA  buscar laboratorios por codigo -------------------------*/
	CREATE PROCEDURE SP_Buscar_LaboratorioxCod @Codigo varchar(8)
	AS
		select * from TLaboratorio
		where CodLaboratorio like @Codigo + '%'	
	GO

	/*------------------- PROCEDIMIENTO  PARA  buscar laboratorios por nombre -------------------------*/
	CREATE PROCEDURE SP_Buscar_LaboratorioxNomb @Nombre varchar(20)
	AS
		select * from TLaboratorio
		where Nombre like @Nombre + '%'	
	GO


	/* ****************** PROCEDIMIENTOS ALMACENADOS PARA EL MODULO MANTENIMIENTO TIPO MATRICULA - NUÑEZ HUALLA ALFREDO ****************** */
	/*------------------- PROCEDIMIENTO  PARA  Mostrar tipo matricula -------------------------*/
	Create procedure MostrarMantenimientoTipoMatricula
	AS
	select *
		from TMantenimientoMatricula
	GO

	/*------------------- PROCEDIMIENTO  PARA  Detalles matricula -------------------------*/
	Create procedure MostrarDetalles 
	@CodMMatricula varchar(12)
	AS
	SELECT *
		FROM TDetalles
		where CodMMatricula = @CodMMatricula
	GO

	/*------------------- PROCEDIMIENTO  PARA  Agregar un tipo matricula -------------------------*/
	CREATE PROCEDURE AgregarTipoMatricula
		@CodMMatricula varchar(12), 
		@Descripcion varchar(50), 
		@Activo varchar(10),
		@Convenio varchar(10) 
	AS
	BEGIN TRY
	BEGIN TRAN

		INSERT INTO TMantenimientoMatricula(CodMMatricula, Descripcion,Activo, Convenio) 
		VALUES(@CodMMatricula, @Descripcion, @Activo, @Convenio)
	COMMIT
	END TRY

	BEGIN CATCH
		ROLLBACK
		PRINT ERROR_MESSAGE()
	END CATCH
    GO

	/*------------------- FUNCION PARA  Agregar un tipo matricula -------------------------*/
	CREATE FUNCTION GenerarCodDetalles()
	RETURNS VARCHAR(6)
	AS
	BEGIN
			-- Declarar variables para generar codigo
			DECLARE @CodDetalles VARCHAR(6), @CodMax1 VARCHAR(6)
			SET @CodMax1 = (SELECT MAX(CodDetalles) FROM TDetalles)
			SET @CodMax1 = ISNULL(@CodMax1,'T00000')
			SET @CodDetalles = 'T'+RIGHT(RIGHT(@CodMax1,4)+10001,4)
			RETURN @CodDetalles
	END;
	GO

	/*------------------- PROCEDIMEINTO PARA  Agregar detalles un tipo matricula -------------------------*/
	CREATE PROCEDURE AgregarDetalles
		@CodMMatricula varchar(12),
		@CodDetalles varchar(6),
		@Año varchar(10),
		@Periodo varchar(10),
		@Documento varchar(50),
		@Observaciones varchar(100) 
	AS
	BEGIN TRY
	BEGIN TRAN
		
		INSERT INTO TDetalles
		VALUES(DBO.GenerarCodDetalles(), @Año,@Periodo, @Documento, @Observaciones, @CodMMatricula)
	COMMIT
	END TRY

	BEGIN CATCH
		ROLLBACK
		PRINT ERROR_MESSAGE()
	END CATCH
	GO

	/*------------------- PROCEDIMIENTO PARA  Editar tipo matricula -------------------------*/
	CREATE PROCEDURE EditarTipoMatricula
		@CodMatricula varchar(12), 
		@Descripcion varchar(50), 
		@Activo varchar(10),
		@Convenio varchar(10) 
	AS
	BEGIN TRY
		BEGIN TRAN
			update TMantenimientoMatricula
			set  CodMMatricula =@CodMatricula, Descripcion = @Descripcion, Activo = @Activo, Convenio = @Convenio
			where CodMMatricula like @CodMatricula +'%'
		COMMIT
	END TRY

	BEGIN CATCH
		ROLLBACK
		PRINT ERROR_MESSAGE()
	END CATCH
	GO

	/*------------------- PROCEDIMIENTO PARA  Editar Detalles tipo matricula -------------------------*/
	CREATE PROCEDURE EditarDetalles
		-- @CodMMatricula varchar(12),
		@CodDetalles varchar(6),
		@Año varchar(10),
		@Periodo varchar(10),
		@Documento varchar(50),
		@Observaciones varchar(100) 
	AS
	BEGIN TRY
		BEGIN TRAN
			update TDetalles
			set  Año =@Año,Periodo=@Periodo, Documento = @Documento, Observaciones = @Observaciones
			where CodDetalles like @CodDetalles +'%'
		COMMIT
	END TRY

	BEGIN CATCH
		ROLLBACK
		PRINT ERROR_MESSAGE()
	END CATCH
	GO

	/*------------------- PROCEDIMIENTO PARA  Eliminar tipo Mantenimiento matricula -------------------------*/
	CREATE PROCEDURE EliminarTipoMatricula
		@CodMMatricula varchar(12)
	AS
		BEGIN TRY
			BEGIN TRAN
				delete from TMantenimientoMatricula where CodMMatricula like @CodMMatricula +'%'
			COMMIT
		END TRY
		BEGIN CATCH
			ROLLBACK
			PRINT ERROR_MESSAGE()
		END CATCH
	GO

	/*------------------- PROCEDIMIENTO PARA  Eliminar Detalles x Matricula -------------------------*/
	CREATE PROCEDURE EliminarDetallesXCodMMatricula
		@CodMMatricula varchar(12)
	AS
		BEGIN TRY
			BEGIN TRAN
				delete from TDetalles where CodMMatricula = @CodMMatricula
			COMMIT
		END TRY
		BEGIN CATCH
			ROLLBACK
			PRINT ERROR_MESSAGE()
		END CATCH
	GO

	/*------------------- PROCEDIMIENTO PARA  Eliminar Detalles Matricula -------------------------*/
	CREATE PROCEDURE EliminarDetalles
		@CodDetalles varchar(6)
	AS
		BEGIN TRY
			BEGIN TRAN
				delete from TDetalles where CodDetalles = @CodDetalles
			COMMIT
		END TRY
		BEGIN CATCH
			ROLLBACK
			PRINT ERROR_MESSAGE()
		END CATCH
	GO

	/*------------------- PROCEDIMIENTO PARA  BUSCAR POR DESCRIPCION -------------------------*/
	CREATE PROCEDURE BuscarDescripcion 
	@Descripcion varchar(50)
	AS
	BEGIN TRY
		BEGIN TRAN
		select * from TMantenimientoMatricula                 
		where Descripcion like @Descripcion + '%'
	COMMIT
	END TRY

	BEGIN CATCH
		ROLLBACK
		PRINT ERROR_MESSAGE()
	END CATCH
	GO

	/*------------------- PROCEDIMIENTO PARA  BUSCAR POR CODIGO -------------------------*/
	CREATE PROCEDURE BuscarCodigo 
		@CodMMatricula varchar(12)
	AS
	BEGIN TRY
		BEGIN TRAN
		select * from TMantenimientoMatricula
		where CodMMatricula like @CodMMatricula + '%'
	COMMIT
	END TRY

	BEGIN CATCH
		ROLLBACK
		PRINT ERROR_MESSAGE()
	END CATCH
	GO

	/*------------------- PROCEDIMIENTO PARA  MOSTRAR DETALLES x CODIGO MATRICULA -------------------------*/
	Create procedure MostrarDetallesXCodMMatricula
	@CodMMatricula varchar(12)
	AS
		SELECT Año,Periodo,Documento, Observaciones, CodDetalles as Id
		FROM TDetalles
		WHERE CodMMatricula = @CodMMatricula
	GO

	/*------------------- PROCEDIMIENTO PARA  ELIMINAR DETALLES x CODIGO MATRICULA -------------------------*/
	CREATE PROCEDURE EliminarTodoDetallesXCodMMatricula
	@CodMMatricula varchar(12)
	AS
		delete from TDetalles where CodMMatricula = @CodMMatricula
	
	GO

	/*------------------- PROCEDIMIENTO PARA  ELIMINAR CODIGO MATRICULA -------------------------*/
	CREATE PROCEDURE EliminarCodMMatriculaX1
	@CodMMatricula varchar(12)
	AS
		delete from TMantenimientoMatricula where CodMMatricula = @CodMMatricula
	
	GO


	/* ****************** PROCEDIMIENTOS ALMACENADOS PARA EL MODULO REGISTRO ASISTENCIA - JUANA YULIANA****************** */
	/*------------- PROCEDIMIENTO PARA LISTAR CURSOS ---------------------------*/
	CREATE PROCEDURE ListarCurso
	AS
		SELECT * 
			FROM TCursoAsistencia
	go

	/*------------- PROCEDIMIENTO PARA BUSCAR NOMBRE CURSO ---------------------------*/
	CREATE PROCEDURE BuscarNombreCurso
	@Codigo varchar(50)
	AS
	BEGIN TRY
		BEGIN TRAN
		select * from TCursoAsistencia
		where Nombre_Curso  like @Codigo + '%'
	COMMIT
	END TRY

	BEGIN CATCH
		ROLLBACK
		PRINT ERROR_MESSAGE()
	END CATCH
	GO