Imports System.Data.SqlClient
Imports Telerik.Reporting
Imports Telerik.Reporting.Processing
Imports Telerik.Reporting.ReportParameter
Imports Telerik.WinControls

''' <summary>
''' Formulario Reportes
''' 
''' @Versión 1.0
''' @Jorge Monroy/Rodrigo Mendoza
''' @05/04/2017
''' @PROSIS, Proyectos y Sistemas Informaticos S.A. de C.V.
''' </summary>

Public Class Reportes

#Region "Variables"

    Dim valorD As String
    Dim numC As String
    Dim CR As String
    Dim ET As String
    Dim AG As String
    Dim AL As String
    Dim FO As String
    Dim HI As String
    Dim HF As String
    Dim NumBolsa As String
    Dim idT As Integer

    Dim I_EfectivoMNE As String
    Dim N_BoletosGEE As String
    Dim I_BoletosGGE As String
    Dim N_BoletosGEM As String
    Dim I_EfectivoMNM As String
    Dim N_EventosE As String
    Dim S_Entregado As String
    Dim S_BoletosE As String
    Dim I_EfectivoMN_D As String
    Dim N_EfectivoMN_D As String
    Dim I_BoletosRPA_E As String
    Dim N_BoletosRPA_E As String
    Dim I_BoletosRPA_M As String
    Dim N_BoletosRPA_M As String
    Dim I_BoletosRPA_D As String
    Dim N_BoletosRPA_D As String
    Dim I_IAVE_E As String
    Dim N_IAVE_E As String
    Dim I_IAVE_M As String
    Dim N_IAVE_M As String
    Dim I_TDC_E As String
    Dim N_TDC_E As String
    Dim I_TDC_M As String
    Dim N_TDC_M As String
    Dim I_TDD_E As String
    Dim N_TDD_E As String
    Dim I_TDD_M As String
    Dim N_TDD_M As String
    Dim I_VSC_E As String
    Dim N_VSC_E As String
    Dim I_VSC_M As String
    Dim N_VSC_M As String
    Dim I_RSP_E As String
    Dim N_RSP_E As String
    Dim I_RSP_M As String
    Dim N_RSP_M As String
    Dim I_Total_E As String
    Dim N_Total_E As String
    Dim I_Total_M As String
    Dim N_Total_M As String
    Dim I_Total_D As String
    Dim N_Total_D As String
    Dim I_DLLS_E As String
    Dim I_BoletosDLLS_E As String
    Dim N_BoletosDLLS_E As String
    Dim I_SubtotalDLLS As String
    Dim N_SubtotalDLLS As String
    Dim I_SubtotalDLLS_M As String
    Dim N_SubtotalDLLS_M As String
    Dim I_SubtotalDLLS_D As String
    Dim N_SubtotalDLLS_D As String
    Dim I_Reclasificados As String
    Dim N_Reclasificados As String
    Dim I_DE As String
    Dim N_DE As String
    Dim I_Contra_MN As String
    Dim I_Contra_DLLS As String
    Dim I_Entregar_MN As String
    Dim I_Entregar_DLLS As String
    Dim I_Deposito_MN As String
    Dim I_Deposito_DLLS As String

    Dim Folio_IR1 As String
    Dim Folio_FR1 As String
    Dim Folio_CR1 As String
    Dim Folio_IR2 As String
    Dim Folio_FR2 As String
    Dim Folio_CR2 As String
    Dim Folio_IR3 As String
    Dim Folio_FR3 As String
    Dim Folio_CR3 As String
    Dim Folios_TR1 As String
    Dim Folios_TR2 As String
    Dim Folios_TR3 As String
    Dim Folios_NR1 As String
    Dim Folios_NR2 As String
    Dim Folios_NR3 As String
    Dim Folio_IECT As String
    Dim Folio_FECT As String
    Dim Folios_TECT As String
    Dim Folios_CECT As String
    Dim Folios_NECT As String
    Dim Evento_IECT As String
    Dim Evento_FECT As String
    Dim Eventos_TECT As String
    Dim Eventos_CECT As String
    Dim Eventos_NECT As String

    Dim Deposito_MN As String
    Dim Deposito_DLLS As String

    '***** Formas de Pago
    Dim idEfectivo As Integer = 1
    Dim idTarjetaCredito As Integer = 12
    Dim idIAVE As Integer = 15
    Dim idResidente As Integer = 10
    Dim idVSC As Integer = 27
    Dim idEludido As Integer = 13
    Dim idEfectivoDlls As Integer = 0   '<----- Verificar
    Dim idResidentesPA As Integer = 71
    Dim idTarjetaDebito As Integer = 14

    'Hora inicio y fin
    Dim Hinicio As TimeSpan
    Dim Hfin As TimeSpan

    Dim HoraAbrio As TimeSpan   '<--- Para turno
    Dim HoraCerro As TimeSpan   '<--- Para turno

    'Conteo de carriles abiertos y cerrados
    Dim ListaCarriles As New List(Of String)
    Dim ListaBolsas As New List(Of Integer)
    Dim ListaNumCarril As New List(Of String)
    Dim ListaNumPlazas As New List(Of Integer)
    Dim Abiertos As Integer = 0
    Dim Cerrados As Integer = 0

    Dim NumA As Integer = 0

#End Region

    Private Sub Reportes_Load(sender As Object, e As EventArgs) Handles MyBase.Load

#Region "Selección de reporte"

        Select Case SeleccionReporte
            Case 1
                LiquidacionCarril()
            Case 2
                LiquidacionDeTurno()
            Case 3
                LiquidacionDeDiaCaseta()
            Case 4
                LiquidacionCarrilesCerrados()
        End Select

#End Region

    End Sub

    'Se contruye cada reporte por separado
#Region "Reportes"

    Private Sub LiquidacionCarril()

        EncabezadoGenaral()
        LlenarTablaMarcado()
        LlenarTablaVerificado()
        LlenarObservaciones()
        LlenarFirmas()

		LlenarTarifas()
		LlenarComparativo()

		ReporteTurno.SendToBack()
        ReporteDia.SendToBack()
        ReporteCarrilCerrado.SendToBack()
        ReporteCarril.BringToFront()
        ComparativoTurno.SendToBack()
        ComparativoDia.SendToBack()
        ComparativoCarrilCerrado.SendToBack()
        ComparativoCajero.BringToFront()

        ReporteCarril.RefreshReport()
        ComparativoCajero.RefreshReport()

    End Sub

    Private Sub LiquidacionDeTurno()

        'TraerHoras(idTurnoR)
        EncabezadoGenaral()
        LlenarTablaMarcado()
        LlenarTablaVerificado()
        LlenarObservaciones()
        LlenarFirmas()

        LlenarTarifas()
        LlenarComparativo()

        ReporteCarril.SendToBack()
        ReporteDia.SendToBack()
        ReporteCarrilCerrado.SendToBack()
        ReporteTurno.BringToFront()
        ComparativoCajero.SendToBack()
        ComparativoDia.SendToBack()
        ComparativoCarrilCerrado.SendToBack()
        ComparativoTurno.BringToFront()

        ReporteTurno.RefreshReport()
        ComparativoTurno.RefreshReport()

    End Sub

    Private Sub LiquidacionDeDiaCaseta()

        EncabezadoGenaral()
        LlenarTablaMarcado()
        LlenarTablaVerificado()
        LlenarObservaciones()
        LlenarFirmas()

        LlenarTarifas()
        LlenarComparativo()

        ReporteCarril.SendToBack()
        ReporteTurno.SendToBack()
        ReporteCarrilCerrado.SendToBack()
        ReporteDia.BringToFront()
        ComparativoCajero.SendToBack()
        ComparativoTurno.SendToBack()
        ComparativoCarrilCerrado.SendToBack()
        ComparativoDia.BringToFront()

        ReporteDia.RefreshReport()
        ComparativoDia.RefreshReport()

    End Sub

    Private Sub LiquidacionCarrilesCerrados()

        EncabezadoGenaral() 
        LlenarTablaMarcado()
        LlenarTablaVerificado()
        LlenarObservaciones()
        LlenarFirmas()

        LlenarTarifas()
        LlenarComparativo()

        ReporteCarril.SendToBack()
        ReporteTurno.SendToBack()
        ReporteDia.SendToBack()
        ReporteCarrilCerrado.BringToFront()
        ComparativoCajero.SendToBack()
        ComparativoTurno.SendToBack()
        ComparativoDia.SendToBack()
        ComparativoCarrilCerrado.BringToFront()

        ReporteCarrilCerrado.RefreshReport()
        ComparativoCarrilCerrado.RefreshReport()

    End Sub

#End Region

    'Encabezado de todos los reportes (Liquidación y Comparativo)
    Private Sub EncabezadoGenaral()

        'Fecha
        Dim FechaOperacion As New Telerik.Reporting.Parameter()
        FechaOperacion.Name = "FechaOperacion"
        FechaOperacion.Value = FechaOperacionR

        Select Case SeleccionReporte
            Case 1  'Cajero/Receptor
                'Plaza
                Dim Plaza As New Telerik.Reporting.Parameter()
                Plaza.Name = "Plaza"
                Plaza.Value = ConsultarPlaza(idPlazaR) '<---- Regresa el número y nombre de la plaza

                'Delegación
                Dim Delegacion As New Telerik.Reporting.Parameter()
                Delegacion.Name = "Delegacion"
                Delegacion.Value = ConsultarDelegacion(idPlazaR)

                'Bolsa (No. de Control)
                Dim Bolsa As New Telerik.Reporting.Parameter()
                Bolsa.Name = "Bolsa"
                Bolsa.Value = ConsultarBolsa(NumDeclaracion)

                'Carril
                Dim Carril As New Telerik.Reporting.Parameter()
                Carril.Name = "Carril"
                Carril.Value = CarrilR

                'Hora de Apertura
                Dim HoraApertura As New Telerik.Reporting.Parameter()
                HoraApertura.Name = "HoraApertura"
                HoraApertura.Value = (ConsultarHoraInicio(NumDeclaracion)).ToString()

                'Hora de Cierre
                Dim HoraCierre As New Telerik.Reporting.Parameter()
                HoraCierre.Name = "HoraCierre"
                HoraCierre.Value = (ConsultarHoraFinal(NumDeclaracion)).ToString()

                'Turno
                Dim Turno As New Telerik.Reporting.Parameter()
                Turno.Name = "Turno"
                Turno.Value = ConsultarTurno(idTurnoR)

                ReporteCarril.ReportSource.Parameters.Add(FechaOperacion)
                ReporteCarril.ReportSource.Parameters.Add(Plaza)
                ReporteCarril.ReportSource.Parameters.Add(Delegacion)
                ReporteCarril.ReportSource.Parameters.Add(Turno)
                ReporteCarril.ReportSource.Parameters.Add(Bolsa)
                ReporteCarril.ReportSource.Parameters.Add(HoraApertura)
                ReporteCarril.ReportSource.Parameters.Add(HoraCierre)
                ReporteCarril.ReportSource.Parameters.Add(Carril)

                ComparativoCajero.ReportSource.Parameters.Add(FechaOperacion)
                ComparativoCajero.ReportSource.Parameters.Add(Plaza)
                ComparativoCajero.ReportSource.Parameters.Add(Delegacion)
                ComparativoCajero.ReportSource.Parameters.Add(Turno)
                ComparativoCajero.ReportSource.Parameters.Add(Bolsa)
                ComparativoCajero.ReportSource.Parameters.Add(HoraApertura)
                ComparativoCajero.ReportSource.Parameters.Add(HoraCierre)
                ComparativoCajero.ReportSource.Parameters.Add(Carril)

            Case 2  'Turno/Carril
                ContarCarriles()

                'Plaza
                Dim Plaza As New Telerik.Reporting.Parameter()
                Plaza.Name = "Plaza"
                Plaza.Value = NombrePlaza

                'Delegación
                Dim Delegacion As New Telerik.Reporting.Parameter()
                Delegacion.Name = "Delegacion"
                Delegacion.Value = ConsultarDelegacion(IdPlazaUno)

                'Turno
                Dim Turno As New Telerik.Reporting.Parameter()
                Turno.Name = "Turno"
                Turno.Value = ConsultarTurno(idTurnoR)

                'Carriles Abiertos
                Dim C_Abiertos As New Telerik.Reporting.Parameter()
                C_Abiertos.Name = "C_Abiertos"
                C_Abiertos.Value = Abiertos.ToString()

                'Carriles Cerrados
                Dim C_Cerrados As New Telerik.Reporting.Parameter()
                C_Cerrados.Name = "C_Cerrados"
                C_Cerrados.Value = Cerrados.ToString()

                ReporteTurno.ReportSource.Parameters.Add(FechaOperacion)
                ReporteTurno.ReportSource.Parameters.Add(Plaza)
                ReporteTurno.ReportSource.Parameters.Add(Delegacion)
                ReporteTurno.ReportSource.Parameters.Add(Turno)
                ReporteTurno.ReportSource.Parameters.Add(C_Abiertos)
                ReporteTurno.ReportSource.Parameters.Add(C_Cerrados)

                ComparativoTurno.ReportSource.Parameters.Add(FechaOperacion)
                ComparativoTurno.ReportSource.Parameters.Add(Plaza)
                ComparativoTurno.ReportSource.Parameters.Add(Delegacion)
                ComparativoTurno.ReportSource.Parameters.Add(Turno)
                ComparativoTurno.ReportSource.Parameters.Add(C_Abiertos)

            Case 3  'Día/Caseta
                'Plaza
                Dim Plaza As New Telerik.Reporting.Parameter()
                Plaza.Name = "Plaza"
                Plaza.Value = NombrePlaza

                'Delegación
                Dim Delegacion As New Telerik.Reporting.Parameter()
                Delegacion.Name = "Delegacion"
                Delegacion.Value = ConsultarDelegacion(IdPlazaUno)

                ReporteDia.ReportSource.Parameters.Add(FechaOperacion)
                ReporteDia.ReportSource.Parameters.Add(Plaza)
                ReporteDia.ReportSource.Parameters.Add(Delegacion)

                ComparativoDia.ReportSource.Parameters.Add(FechaOperacion)
                ComparativoDia.ReportSource.Parameters.Add(Plaza)
                ComparativoDia.ReportSource.Parameters.Add(Delegacion)

            Case 4

                'Plaza
                Dim Plaza As New Telerik.Reporting.Parameter()
                Plaza.Name = "Plaza"

                'Delegación
                Dim Delegacion As New Telerik.Reporting.Parameter()
                Delegacion.Name = "Delegacion"

                If CarrilR.Contains("A") Then
                    Plaza.Value = ConsultarPlaza(IdPlazaUno) '<---- Regresa el número y nombre de la plaza
                    Delegacion.Value = ConsultarDelegacion(IdPlazaUno) '<---- Regresa el número y nombre de la plaza
                Else
                    Plaza.Value = ConsultarPlaza(IdPlazaDos)
                    Delegacion.Value = ConsultarDelegacion(IdPlazaDos)
                End If

                'Bolsa (No. de Control)
                Dim Bolsa As New Telerik.Reporting.Parameter()
                Bolsa.Name = "Bolsa"
                Bolsa.Value = CarrilR + CC_Turno.ToString() + ((Date.Now.TimeOfDay().ToString()).Replace(":", "")).Split(".")(0)

                'Carril
                Dim Carril As New Telerik.Reporting.Parameter()
                Carril.Name = "Carril"
                Carril.Value = CarrilR

                Dim H_A As String
                Dim H_C As String

                Select Case CC_Turno
                    Case 1
                        H_A = "22:00:00"
                        H_C = "06:00:00"
                    Case 2
                        H_A = "06:00:00"
                        H_C = "14:00:00"
                    Case 3
                        H_A = "14:00:00"
                        H_C = "22:00:00"
                End Select

                'Hora de Apertura
                Dim HoraApertura As New Telerik.Reporting.Parameter()
                HoraApertura.Name = "HoraApertura"
                HoraApertura.Value = H_A

                'Hora de Cierre
                Dim HoraCierre As New Telerik.Reporting.Parameter()
                HoraCierre.Name = "HoraCierre"
                HoraCierre.Value = H_C

                'Turno
                Dim Turno As New Telerik.Reporting.Parameter()
                Turno.Name = "Turno"
                Turno.Value = ConsultarTurno(CC_Turno)

                ReporteCarrilCerrado.ReportSource.Parameters.Add(FechaOperacion)
                ReporteCarrilCerrado.ReportSource.Parameters.Add(Plaza)
                ReporteCarrilCerrado.ReportSource.Parameters.Add(Delegacion)
                ReporteCarrilCerrado.ReportSource.Parameters.Add(Turno)
                ReporteCarrilCerrado.ReportSource.Parameters.Add(Bolsa)
                ReporteCarrilCerrado.ReportSource.Parameters.Add(HoraApertura)
                ReporteCarrilCerrado.ReportSource.Parameters.Add(HoraCierre)
                ReporteCarrilCerrado.ReportSource.Parameters.Add(Carril)

                ComparativoCarrilCerrado.ReportSource.Parameters.Add(FechaOperacion)
                ComparativoCarrilCerrado.ReportSource.Parameters.Add(Plaza)
                ComparativoCarrilCerrado.ReportSource.Parameters.Add(Delegacion)
                ComparativoCarrilCerrado.ReportSource.Parameters.Add(Turno)
                ComparativoCarrilCerrado.ReportSource.Parameters.Add(Bolsa)
                ComparativoCarrilCerrado.ReportSource.Parameters.Add(HoraApertura)
                ComparativoCarrilCerrado.ReportSource.Parameters.Add(HoraCierre)
                ComparativoCarrilCerrado.ReportSource.Parameters.Add(Carril)

        End Select

    End Sub

	Private Sub LlenarTablaMarcado()

        '***** Declaración de parametros

        'Importe Efectivo Moneda Nacional
        Dim EfectivoMN_IM As New Telerik.Reporting.Parameter()
		EfectivoMN_IM.Name = "EfectivoMN_IM"

		'Cantidad Efectivo Moneda Nacional
		Dim EfectivoMN_CM As New Telerik.Reporting.Parameter()
		EfectivoMN_CM.Name = "EfectivoMN_CM"

		'Importe Residente Pago Inmediato
		Dim RPI_IM As New Telerik.Reporting.Parameter()
		RPI_IM.Name = "RPI_IM"

		'Cantidad Residente Pago Inmediato
		Dim RPI_CM As New Telerik.Reporting.Parameter()
		RPI_CM.Name = "RPI_CM"

		'Importe IAVE
		Dim IAVE_IM As New Telerik.Reporting.Parameter()
		IAVE_IM.Name = "IAVE_IM"

		'Cantidad IAVE
		Dim IAVE_CM As New Telerik.Reporting.Parameter()
		IAVE_CM.Name = "IAVE_CM"

		'Importe TDC
		Dim TDC_IM As New Telerik.Reporting.Parameter()
		TDC_IM.Name = "TDC_IM"

		'Cantidad TDC
		Dim TDC_CM As New Telerik.Reporting.Parameter()
		TDC_CM.Name = "TDC_CM"
		'Importe TDD
		Dim TDD_IM As New Telerik.Reporting.Parameter()
		TDD_IM.Name = "TDD_IM"

		'Cantidad TDD
		Dim TDD_CM As New Telerik.Reporting.Parameter()
		TDD_CM.Name = "TDD_CM"

		'Importe VSC
		Dim VSC_IM As New Telerik.Reporting.Parameter()
		VSC_IM.Name = "VSC_IM"

		'Cantidad VSC
		Dim VSC_CM As New Telerik.Reporting.Parameter()
		VSC_CM.Name = "VSC_CM"

		'Importe RSP
		Dim RSP_IM As New Telerik.Reporting.Parameter()
		RSP_IM.Name = "RSP_IM"

		'Cantidad RSP
		Dim RSP_CM As New Telerik.Reporting.Parameter()
        RSP_CM.Name = "RSP_CM"

        'Importe Eludido
        Dim Eludido_IM As New Telerik.Reporting.Parameter()
        Eludido_IM.Name = "Eludido_IM"

        'Cantidad Eludido
        Dim Eludido_CM As New Telerik.Reporting.Parameter()
        Eludido_CM.Name = "Eludido_CM"

        'Importe Reclasificados
        Dim Reclasificados_IM As New Telerik.Reporting.Parameter()
		Reclasificados_IM.Name = "Reclasificados_IM"

		'Cantidad Reclasificados
		Dim Reclasificados_CM As New Telerik.Reporting.Parameter()
		Reclasificados_CM.Name = "Reclasificados_CM"

		'Importe Discrepancias
		Dim Discrepancias_IM As New Telerik.Reporting.Parameter()
		Discrepancias_IM.Name = "Discrepancias_IM"

		'Cantidad Discrepancias
		Dim Discrepancias_CM As New Telerik.Reporting.Parameter()
        Discrepancias_CM.Name = "Discrepancias_CM"

        'Cantidad Discrepancias
        Dim Boletos_CM As New Telerik.Reporting.Parameter()
        Boletos_CM.Name = "Boletos_CM"

        '***** Asignación de valores segun el reporte seleccionado

        Select Case SeleccionReporte
			Case 1

#Region "Reporte de Cajero-Receptor"

                EfectivoMN_IM.Value = (ObtenerEntregado(NumDeclaracion)).ToString("##,##0.00")
                EfectivoMN_CM.Value = (ContarMarcado(NumDeclaracion, Efectivo)).ToString()
                RPI_IM.Value = (SumarMarcado(NumDeclaracion, Residente)).ToString("##,##0.00")
				RPI_CM.Value = (ContarMarcado(NumDeclaracion, Residente)).ToString()
				IAVE_IM.Value = (SumarMarcado(NumDeclaracion, IAVE)).ToString("##,##0.00")
				IAVE_CM.Value = (ContarMarcado(NumDeclaracion, IAVE)).ToString()
				TDC_IM.Value = (SumarMarcado(NumDeclaracion, TDC)).ToString("##,##0.00")
				TDC_CM.Value = (ContarMarcado(NumDeclaracion, TDC)).ToString()
				TDD_IM.Value = (SumarMarcado(NumDeclaracion, TDD)).ToString("##,##0.00")
				TDD_CM.Value = (ContarMarcado(NumDeclaracion, TDD)).ToString()
				VSC_IM.Value = (SumarMarcado(NumDeclaracion, VSC)).ToString("##,##0.00")
				VSC_CM.Value = (ContarMarcado(NumDeclaracion, VSC)).ToString()
				RSP_IM.Value = (SumarMarcado(NumDeclaracion, RSP)).ToString("##,##0.00")
                RSP_CM.Value = (ContarMarcado(NumDeclaracion, RSP)).ToString()
                Eludido_IM.Value = (SumarMarcado(NumDeclaracion, Violacion)).ToString("##,##0.00")
                Eludido_CM.Value = (ContarMarcado(NumDeclaracion, Violacion)).ToString()
                Reclasificados_IM.Value = (SumarSecuencias(NumDeclaracion, Reclasificados)).ToString("##,##0.00")
				Reclasificados_CM.Value = (ContarSecuencias(NumDeclaracion, Reclasificados)).ToString()
				Discrepancias_IM.Value = (SumarPaso(NumDeclaracion, Discrepancias)).ToString("##,##0.00")
                Discrepancias_CM.Value = (ContarPaso(NumDeclaracion, Discrepancias)).ToString()
                Boletos_CM.Value = (ContarBoletos(NumDeclaracion)).ToString()

                ReporteCarril.ReportSource.Parameters.Add(EfectivoMN_IM)
                ReporteCarril.ReportSource.Parameters.Add(EfectivoMN_CM)
                ReporteCarril.ReportSource.Parameters.Add(RPI_IM)
                ReporteCarril.ReportSource.Parameters.Add(RPI_CM)
                ReporteCarril.ReportSource.Parameters.Add(IAVE_IM)
                ReporteCarril.ReportSource.Parameters.Add(IAVE_CM)
                ReporteCarril.ReportSource.Parameters.Add(TDC_IM)
                ReporteCarril.ReportSource.Parameters.Add(TDC_CM)
                ReporteCarril.ReportSource.Parameters.Add(TDD_IM)
                ReporteCarril.ReportSource.Parameters.Add(TDD_CM)
                ReporteCarril.ReportSource.Parameters.Add(VSC_IM)
                ReporteCarril.ReportSource.Parameters.Add(VSC_CM)
                ReporteCarril.ReportSource.Parameters.Add(RSP_IM)
                ReporteCarril.ReportSource.Parameters.Add(RSP_CM)
                ReporteCarril.ReportSource.Parameters.Add(Eludido_IM)
                ReporteCarril.ReportSource.Parameters.Add(Eludido_CM)
                ReporteCarril.ReportSource.Parameters.Add(Reclasificados_IM)
                ReporteCarril.ReportSource.Parameters.Add(Reclasificados_CM)
                ReporteCarril.ReportSource.Parameters.Add(Discrepancias_IM)
                ReporteCarril.ReportSource.Parameters.Add(Discrepancias_CM)
                ReporteCarril.ReportSource.Parameters.Add(Boletos_CM)

#End Region

            Case 2

#Region "Reporte de Turno/Carriles"

                EfectivoMN_IM.Value = (ObtenerEntregadoTurno(idTurnoR)).ToString()
                EfectivoMN_CM.Value = (ContarMarcadoTurno(Efectivo)).ToString()
                RPI_IM.Value = (SumarMarcadoTurno(Residente)).ToString("##,##0.00")
                RPI_CM.Value = (ContarMarcadoTurno(Residente)).ToString()
                IAVE_IM.Value = (SumarMarcadoTurno(IAVE)).ToString("##,##0.00")
                IAVE_CM.Value = (ContarMarcadoTurno(IAVE)).ToString()
                TDC_IM.Value = (SumarMarcadoTurno(TDC)).ToString("##,##0.00")
                TDC_CM.Value = (ContarMarcadoTurno(TDC)).ToString()
                TDD_IM.Value = (SumarMarcadoTurno(TDD)).ToString("##,##0.00")
                TDD_CM.Value = (ContarMarcadoTurno(TDD)).ToString()
                VSC_IM.Value = (SumarMarcadoTurno(VSC)).ToString("##,##0.00")
                VSC_CM.Value = (ContarMarcadoTurno(VSC)).ToString()
                RSP_IM.Value = (SumarMarcadoTurno(RSP)).ToString("##,##0.00")
                RSP_CM.Value = (ContarMarcadoTurno(RSP)).ToString()
                Eludido_IM.Value = (SumarMarcadoTurno(Violacion)).ToString("##,##0.00")
                Eludido_CM.Value = (ContarMarcadoTurno(Violacion)).ToString()
                Reclasificados_IM.Value = (SumarSecuenciasTurno(Reclasificados)).ToString("##,##0.00")
                Reclasificados_CM.Value = (ContarSecuenciasTurno(Reclasificados)).ToString()
                Discrepancias_IM.Value = (SumarPasoTurno(Discrepancias)).ToString("##,##0.00")
                Discrepancias_CM.Value = (ContarPasoTurno(Discrepancias)).ToString()
                Boletos_CM.Value = (ContarBoletosTurno()).ToString()

                ReporteTurno.ReportSource.Parameters.Add(EfectivoMN_IM)
				ReporteTurno.ReportSource.Parameters.Add(EfectivoMN_CM)
				ReporteTurno.ReportSource.Parameters.Add(RPI_IM)
				ReporteTurno.ReportSource.Parameters.Add(RPI_CM)
				ReporteTurno.ReportSource.Parameters.Add(IAVE_IM)
				ReporteTurno.ReportSource.Parameters.Add(IAVE_CM)
				ReporteTurno.ReportSource.Parameters.Add(TDC_IM)
				ReporteTurno.ReportSource.Parameters.Add(TDC_CM)
				ReporteTurno.ReportSource.Parameters.Add(TDD_IM)
				ReporteTurno.ReportSource.Parameters.Add(TDD_CM)
				ReporteTurno.ReportSource.Parameters.Add(VSC_IM)
				ReporteTurno.ReportSource.Parameters.Add(VSC_CM)
				ReporteTurno.ReportSource.Parameters.Add(RSP_IM)
                ReporteTurno.ReportSource.Parameters.Add(RSP_CM)
                ReporteTurno.ReportSource.Parameters.Add(Eludido_IM)
                ReporteTurno.ReportSource.Parameters.Add(Eludido_CM)
                ReporteTurno.ReportSource.Parameters.Add(Reclasificados_IM)
                ReporteTurno.ReportSource.Parameters.Add(Reclasificados_CM)
                ReporteTurno.ReportSource.Parameters.Add(Discrepancias_IM)
                ReporteTurno.ReportSource.Parameters.Add(Discrepancias_CM)
                ReporteTurno.ReportSource.Parameters.Add(Boletos_CM)

#End Region

            Case 3

#Region "Reporte de Día/Caseta"

                EfectivoMN_IM.Value = (SumarMarcadoDia(Efectivo)).ToString("##,##0.00")
                EfectivoMN_CM.Value = (ContarMarcadoDia(Efectivo)).ToString()
                RPI_IM.Value = (SumarMarcadoDia(Residente)).ToString("##,##0.00")
                RPI_CM.Value = (ContarMarcadoDia(Residente)).ToString()
                IAVE_IM.Value = (SumarMarcadoDia(IAVE)).ToString("##,##0.00")
                IAVE_CM.Value = (ContarMarcadoDia(IAVE)).ToString()
                TDC_IM.Value = (SumarMarcadoDia(TDC)).ToString("##,##0.00")
                TDC_CM.Value = (ContarMarcadoDia(TDC)).ToString()
                TDD_IM.Value = (SumarMarcadoDia(TDD)).ToString("##,##0.00")
                TDD_CM.Value = (ContarMarcadoDia(TDD)).ToString()
                VSC_IM.Value = (SumarMarcadoDia(VSC)).ToString("##,##0.00")
                VSC_CM.Value = (ContarMarcadoDia(VSC)).ToString()
                RSP_IM.Value = (SumarMarcadoDia(RSP)).ToString("##,##0.00")
                RSP_CM.Value = (ContarMarcadoDia(RSP)).ToString()
                Eludido_IM.Value = (SumarMarcadoDia(Violacion)).ToString("##,##0.00")
                Eludido_CM.Value = (ContarMarcadoDia(Violacion)).ToString()
                Reclasificados_IM.Value = (SumarSecuenciasDia(Reclasificados)).ToString("##,##0.00")
                Reclasificados_CM.Value = (ContarSecuenciasDia(Reclasificados)).ToString()
                Discrepancias_IM.Value = (SumarPasoDia(Discrepancias)).ToString("##,##0.00")
                Discrepancias_CM.Value = (ContarPasoDia(Discrepancias)).ToString()
                Boletos_CM.Value = (ContarBoletosDia()).ToString()

                ReporteDia.ReportSource.Parameters.Add(EfectivoMN_IM)
				ReporteDia.ReportSource.Parameters.Add(EfectivoMN_CM)
				ReporteDia.ReportSource.Parameters.Add(RPI_IM)
				ReporteDia.ReportSource.Parameters.Add(RPI_CM)
				ReporteDia.ReportSource.Parameters.Add(IAVE_IM)
				ReporteDia.ReportSource.Parameters.Add(IAVE_CM)
				ReporteDia.ReportSource.Parameters.Add(TDC_IM)
				ReporteDia.ReportSource.Parameters.Add(TDC_CM)
				ReporteDia.ReportSource.Parameters.Add(TDD_IM)
				ReporteDia.ReportSource.Parameters.Add(TDD_CM)
				ReporteDia.ReportSource.Parameters.Add(VSC_IM)
				ReporteDia.ReportSource.Parameters.Add(VSC_CM)
				ReporteDia.ReportSource.Parameters.Add(RSP_IM)
                ReporteDia.ReportSource.Parameters.Add(RSP_CM)
                ReporteDia.ReportSource.Parameters.Add(Eludido_IM)
                ReporteDia.ReportSource.Parameters.Add(Eludido_CM)
                ReporteDia.ReportSource.Parameters.Add(Reclasificados_IM)
                ReporteDia.ReportSource.Parameters.Add(Reclasificados_CM)
                ReporteDia.ReportSource.Parameters.Add(Discrepancias_IM)
                ReporteDia.ReportSource.Parameters.Add(Discrepancias_CM)
                ReporteDia.ReportSource.Parameters.Add(Boletos_CM)

#End Region

            Case 4

#Region "Reporte de Carriles Cerrados"

                EfectivoMN_IM.Value = (SumarMarcado_CC(CC_Turno, Efectivo)).ToString("##,##0.00")
                EfectivoMN_CM.Value = (ContarMarcado_CC(CC_Turno, Efectivo)).ToString()
                RPI_IM.Value = (SumarMarcado_CC(CC_Turno, Residente)).ToString("##,##0.00")
                RPI_CM.Value = (ContarMarcado_CC(CC_Turno, Residente)).ToString()
                IAVE_IM.Value = (SumarMarcado_CC(CC_Turno, IAVE)).ToString("##,##0.00")
                IAVE_CM.Value = (ContarMarcado_CC(CC_Turno, IAVE)).ToString()
                TDC_IM.Value = (SumarMarcado_CC(CC_Turno, TDC)).ToString("##,##0.00")
                TDC_CM.Value = (ContarMarcado_CC(CC_Turno, TDC)).ToString()
                TDD_IM.Value = (SumarMarcado_CC(CC_Turno, TDD)).ToString("##,##0.00")
                TDD_CM.Value = (ContarMarcado_CC(CC_Turno, TDD)).ToString()
                VSC_IM.Value = (SumarMarcado_CC(CC_Turno, VSC)).ToString("##,##0.00")
                VSC_CM.Value = (ContarMarcado_CC(CC_Turno, VSC)).ToString()
                RSP_IM.Value = (SumarMarcado_CC(CC_Turno, RSP)).ToString("##,##0.00")
                RSP_CM.Value = (ContarMarcado_CC(CC_Turno, RSP)).ToString()
                Eludido_IM.Value = (SumarMarcado_CC(CC_Turno, Violacion)).ToString("##,##0.00")
                Eludido_CM.Value = (ContarMarcado_CC(CC_Turno, Violacion)).ToString()
                Reclasificados_IM.Value = "0.00"
                Reclasificados_CM.Value = "0"
                Discrepancias_IM.Value = "0.00"
                Discrepancias_CM.Value = "0"
                Boletos_CM.Value = "0"

                ReporteCarrilCerrado.ReportSource.Parameters.Add(EfectivoMN_IM)
                ReporteCarrilCerrado.ReportSource.Parameters.Add(EfectivoMN_CM)
                ReporteCarrilCerrado.ReportSource.Parameters.Add(RPI_IM)
                ReporteCarrilCerrado.ReportSource.Parameters.Add(RPI_CM)
                ReporteCarrilCerrado.ReportSource.Parameters.Add(IAVE_IM)
                ReporteCarrilCerrado.ReportSource.Parameters.Add(IAVE_CM)
                ReporteCarrilCerrado.ReportSource.Parameters.Add(TDC_IM)
                ReporteCarrilCerrado.ReportSource.Parameters.Add(TDC_CM)
                ReporteCarrilCerrado.ReportSource.Parameters.Add(TDD_IM)
                ReporteCarrilCerrado.ReportSource.Parameters.Add(TDD_CM)
                ReporteCarrilCerrado.ReportSource.Parameters.Add(VSC_IM)
                ReporteCarrilCerrado.ReportSource.Parameters.Add(VSC_CM)
                ReporteCarrilCerrado.ReportSource.Parameters.Add(RSP_IM)
                ReporteCarrilCerrado.ReportSource.Parameters.Add(RSP_CM)
                ReporteCarrilCerrado.ReportSource.Parameters.Add(Eludido_IM)
                ReporteCarrilCerrado.ReportSource.Parameters.Add(Eludido_CM)
                ReporteCarrilCerrado.ReportSource.Parameters.Add(Reclasificados_IM)
                ReporteCarrilCerrado.ReportSource.Parameters.Add(Reclasificados_CM)
                ReporteCarrilCerrado.ReportSource.Parameters.Add(Discrepancias_IM)
                ReporteCarrilCerrado.ReportSource.Parameters.Add(Discrepancias_CM)
                ReporteCarrilCerrado.ReportSource.Parameters.Add(Boletos_CM)

#End Region

        End Select

	End Sub

	Private Sub LlenarTablaVerificado()

		'***** Declaración de parametros

		'Importe Efectivo Moneda Nacional
		Dim EfectivoMN_IV As New Telerik.Reporting.Parameter()
		EfectivoMN_IV.Name = "EfectivoMN_IV"

		'Cantidad Efectivo Moneda Nacional
		Dim EfectivoMN_CV As New Telerik.Reporting.Parameter()
		EfectivoMN_CV.Name = "EfectivoMN_CV"

		'Importe Residente Pago inmediato
		Dim RPI_IV As New Telerik.Reporting.Parameter()
		RPI_IV.Name = "RPI_IV"

		'Cantidad Residente Pago Inmediato
		Dim RPI_CV As New Telerik.Reporting.Parameter()
		RPI_CV.Name = "RPI_CV"

		'Importe IAVE
		Dim IAVE_IV As New Telerik.Reporting.Parameter()
		IAVE_IV.Name = "IAVE_IV"

		'Cantidad IAVE
		Dim IAVE_CV As New Telerik.Reporting.Parameter()
		IAVE_CV.Name = "IAVE_CV"

		'Importe TDC
		Dim TDC_IV As New Telerik.Reporting.Parameter()
		TDC_IV.Name = "TDC_IV"

		'Cantidad TDC
		Dim TDC_CV As New Telerik.Reporting.Parameter()
		TDC_CV.Name = "TDC_CV"

		'Importe TDD
		Dim TDD_IV As New Telerik.Reporting.Parameter()
		TDD_IV.Name = "TDD_IV"

		'Cantidad TDD
		Dim TDD_CV As New Telerik.Reporting.Parameter()
		TDD_CV.Name = "TDD_CV"

		'Importe VSC
		Dim VSC_IV As New Telerik.Reporting.Parameter()
		VSC_IV.Name = "VSC_IV"

		'Cantidad VSC
		Dim VSC_CV As New Telerik.Reporting.Parameter()
		VSC_CV.Name = "VSC_CV"

		'Importe RSP
		Dim RSP_IV As New Telerik.Reporting.Parameter()
		RSP_IV.Name = "RSP_IV"

		'Cantidad RSP
		Dim RSP_CV As New Telerik.Reporting.Parameter()
        RSP_CV.Name = "RSP_CV"

        'Importe Eludido
        Dim Eludido_IV As New Telerik.Reporting.Parameter()
        Eludido_IV.Name = "Eludido_IV"

        'Cantidad Eludido
        Dim Eludido_CV As New Telerik.Reporting.Parameter()
        Eludido_CV.Name = "Eludido_CV"

        'Importe Discrepancias
        Dim Discrepancias_IV As New Telerik.Reporting.Parameter()
		Discrepancias_IV.Name = "Discrepancias_IV"

		'Cantidad Discrepancias
		Dim Discrepancias_CV As New Telerik.Reporting.Parameter()
		Discrepancias_CV.Name = "Discrepancias_CV"

		'***** Asignación de valores segun el reporte seleccionado

		Select Case SeleccionReporte
			Case 1

#Region "Reporte de Cajero-Receptor"

				EfectivoMN_IV.Value = (SumarVerificado(NumDeclaracion, Efectivo)).ToString("##,##0.00")
				EfectivoMN_CV.Value = (ContarVerificado(NumDeclaracion, Efectivo)).ToString()
				RPI_IV.Value = (SumarVerificado(NumDeclaracion, Residente)).ToString("##,##0.00")
				RPI_CV.Value = (ContarVerificado(NumDeclaracion, Residente)).ToString()
				IAVE_IV.Value = (SumarVerificado(NumDeclaracion, IAVE)).ToString("##,##0.00")
				IAVE_CV.Value = (ContarVerificado(NumDeclaracion, IAVE)).ToString()
				TDC_IV.Value = (SumarVerificado(NumDeclaracion, TDC)).ToString("##,##0.00")
				TDC_CV.Value = (ContarVerificado(NumDeclaracion, TDC)).ToString()
				TDD_IV.Value = (SumarVerificado(NumDeclaracion, TDD)).ToString("##,##0.00")
				TDD_CV.Value = (ContarVerificado(NumDeclaracion, TDD)).ToString()
				VSC_IV.Value = (SumarVerificado(NumDeclaracion, VSC)).ToString("##,##0.00")
				VSC_CV.Value = (ContarVerificado(NumDeclaracion, VSC)).ToString()
				RSP_IV.Value = (SumarVerificado(NumDeclaracion, RSP)).ToString("##,##0.00")
                RSP_CV.Value = (ContarVerificado(NumDeclaracion, RSP)).ToString()
                Eludido_IV.Value = (SumarVerificado(NumDeclaracion, Violacion)).ToString("##,##0.00")
                Eludido_CV.Value = (ContarVerificado(NumDeclaracion, Violacion)).ToString()
                Discrepancias_IV.Value = (SumarPaso(NumDeclaracion, Discrepancias)).ToString("##,##0.00")
				Discrepancias_CV.Value = (ContarPaso(NumDeclaracion, Discrepancias)).ToString()

				ReporteCarril.ReportSource.Parameters.Add(EfectivoMN_IV)
				ReporteCarril.ReportSource.Parameters.Add(EfectivoMN_CV)
				ReporteCarril.ReportSource.Parameters.Add(RPI_IV)
				ReporteCarril.ReportSource.Parameters.Add(RPI_CV)
				ReporteCarril.ReportSource.Parameters.Add(IAVE_IV)
				ReporteCarril.ReportSource.Parameters.Add(IAVE_CV)
				ReporteCarril.ReportSource.Parameters.Add(TDC_IV)
				ReporteCarril.ReportSource.Parameters.Add(TDC_CV)
				ReporteCarril.ReportSource.Parameters.Add(TDD_IV)
				ReporteCarril.ReportSource.Parameters.Add(TDD_CV)
				ReporteCarril.ReportSource.Parameters.Add(VSC_IV)
				ReporteCarril.ReportSource.Parameters.Add(VSC_CV)
				ReporteCarril.ReportSource.Parameters.Add(RSP_IV)
                ReporteCarril.ReportSource.Parameters.Add(RSP_CV)
                ReporteCarril.ReportSource.Parameters.Add(Eludido_IV)
                ReporteCarril.ReportSource.Parameters.Add(Eludido_CV)
                ReporteCarril.ReportSource.Parameters.Add(Discrepancias_IV)
				ReporteCarril.ReportSource.Parameters.Add(Discrepancias_CV)

#End Region

			Case 2

#Region "Reporte de Turno/Carriles"

                EfectivoMN_IV.Value = (SumarVerificadoTurno(Efectivo)).ToString("##,##0.00")
                EfectivoMN_CV.Value = (ContarVerificadoTurno(Efectivo)).ToString()
                RPI_IV.Value = (SumarVerificadoTurno(Residente)).ToString("##,##0.00")
                RPI_CV.Value = (ContarVerificadoTurno(Residente)).ToString()
                IAVE_IV.Value = (SumarVerificadoTurno(IAVE)).ToString("##,##0.00")
                IAVE_CV.Value = (ContarVerificadoTurno(IAVE)).ToString()
                TDC_IV.Value = (SumarVerificadoTurno(TDC)).ToString("##,##0.00")
                TDC_CV.Value = (ContarVerificadoTurno(TDC)).ToString()
                TDD_IV.Value = (SumarVerificadoTurno(TDD)).ToString("##,##0.00")
                TDD_CV.Value = (ContarVerificadoTurno(TDD)).ToString()
                VSC_IV.Value = (SumarVerificadoTurno(VSC)).ToString("##,##0.00")
                VSC_CV.Value = (ContarVerificadoTurno(VSC)).ToString()
                RSP_IV.Value = (SumarVerificadoTurno(RSP)).ToString("##,##0.00")
                RSP_CV.Value = (ContarVerificadoTurno(RSP)).ToString()
                Eludido_IV.Value = (SumarVerificadoTurno(Violacion)).ToString("##,##0.00")
                Eludido_CV.Value = (ContarVerificadoTurno(Violacion)).ToString()

                ReporteTurno.ReportSource.Parameters.Add(EfectivoMN_IV)
				ReporteTurno.ReportSource.Parameters.Add(EfectivoMN_CV)
				ReporteTurno.ReportSource.Parameters.Add(RPI_IV)
				ReporteTurno.ReportSource.Parameters.Add(RPI_CV)
				ReporteTurno.ReportSource.Parameters.Add(IAVE_IV)
				ReporteTurno.ReportSource.Parameters.Add(IAVE_CV)
				ReporteTurno.ReportSource.Parameters.Add(TDC_IV)
				ReporteTurno.ReportSource.Parameters.Add(TDC_CV)
				ReporteTurno.ReportSource.Parameters.Add(TDD_IV)
				ReporteTurno.ReportSource.Parameters.Add(TDD_CV)
				ReporteTurno.ReportSource.Parameters.Add(VSC_IV)
				ReporteTurno.ReportSource.Parameters.Add(VSC_CV)
				ReporteTurno.ReportSource.Parameters.Add(RSP_IV)
                ReporteTurno.ReportSource.Parameters.Add(RSP_CV)
                ReporteTurno.ReportSource.Parameters.Add(Eludido_IV)
                ReporteTurno.ReportSource.Parameters.Add(Eludido_CV)

#End Region

            Case 3

#Region "Reporde de Día/Caseta"

                EfectivoMN_IV.Value = (SumarVerificadoDia(Efectivo)).ToString("##,##0.00")
                EfectivoMN_CV.Value = (ContarVerificadoDia(Efectivo)).ToString()
                RPI_IV.Value = (SumarVerificadoDia(Residente)).ToString("##,##0.00")
                RPI_CV.Value = (ContarVerificadoDia(Residente)).ToString()
                IAVE_IV.Value = (SumarVerificadoDia(IAVE)).ToString("##,##0.00")
                IAVE_CV.Value = (ContarVerificadoDia(IAVE)).ToString()
                TDC_IV.Value = (SumarVerificadoDia(TDC)).ToString("##,##0.00")
                TDC_CV.Value = (ContarVerificadoDia(TDC)).ToString()
                TDD_IV.Value = (SumarVerificadoDia(TDD)).ToString("##,##0.00")
                TDD_CV.Value = (ContarVerificadoDia(TDD)).ToString()
                VSC_IV.Value = (SumarVerificadoDia(VSC)).ToString("##,##0.00")
                VSC_CV.Value = (ContarVerificadoDia(VSC)).ToString()
                RSP_IV.Value = (SumarVerificadoDia(RSP)).ToString("##,##0.00")
                RSP_CV.Value = (ContarVerificadoDia(RSP)).ToString()
                Eludido_IV.Value = (SumarVerificadoDia(Violacion)).ToString("##,##0.00")
                Eludido_CV.Value = (ContarVerificadoDia(Violacion)).ToString()

                ReporteDia.ReportSource.Parameters.Add(EfectivoMN_IV)
				ReporteDia.ReportSource.Parameters.Add(EfectivoMN_CV)
				ReporteDia.ReportSource.Parameters.Add(RPI_IV)
				ReporteDia.ReportSource.Parameters.Add(RPI_CV)
				ReporteDia.ReportSource.Parameters.Add(IAVE_IV)
				ReporteDia.ReportSource.Parameters.Add(IAVE_CV)
				ReporteDia.ReportSource.Parameters.Add(TDC_IV)
				ReporteDia.ReportSource.Parameters.Add(TDC_CV)
				ReporteDia.ReportSource.Parameters.Add(TDD_IV)
				ReporteDia.ReportSource.Parameters.Add(TDD_CV)
				ReporteDia.ReportSource.Parameters.Add(VSC_IV)
				ReporteDia.ReportSource.Parameters.Add(VSC_CV)
				ReporteDia.ReportSource.Parameters.Add(RSP_IV)
                ReporteDia.ReportSource.Parameters.Add(RSP_CV)
                ReporteDia.ReportSource.Parameters.Add(Eludido_IV)
                ReporteDia.ReportSource.Parameters.Add(Eludido_CV)

#End Region

            Case 4

#Region "Reporte de Carriles Cerrados"

                EfectivoMN_IV.Value = (SumarVerificado_CC(CC_Turno, Efectivo)).ToString("##,##0.00")
                EfectivoMN_CV.Value = (ContarVerificado_CC(CC_Turno, Efectivo)).ToString()
                RPI_IV.Value = (SumarVerificado_CC(CC_Turno, Residente)).ToString("##,##0.00")
                RPI_CV.Value = (ContarVerificado_CC(CC_Turno, Residente)).ToString()
                IAVE_IV.Value = (SumarVerificado_CC(CC_Turno, IAVE)).ToString("##,##0.00")
                IAVE_CV.Value = (ContarVerificado_CC(CC_Turno, IAVE)).ToString()
                TDC_IV.Value = (SumarVerificado_CC(CC_Turno, TDC)).ToString("##,##0.00")
                TDC_CV.Value = (ContarVerificado_CC(CC_Turno, TDC)).ToString()
                TDD_IV.Value = (SumarVerificado_CC(CC_Turno, TDD)).ToString("##,##0.00")
                TDD_CV.Value = (ContarVerificado_CC(CC_Turno, TDD)).ToString()

                VSC_IV.Value = (SumarVerificado_CC(CC_Turno, VSC)).ToString("##,##0.00")
                VSC_CV.Value = (ContarVerificado_CC(CC_Turno, VSC)).ToString()
                RSP_IV.Value = (SumarVerificado_CC(CC_Turno, RSP)).ToString("##,##0.00")
                RSP_CV.Value = (ContarVerificado_CC(CC_Turno, RSP)).ToString()
                Eludido_IV.Value = (SumarVerificado_CC(CC_Turno, Violacion)).ToString("##,##0.00")
                Eludido_CV.Value = (ContarVerificado_CC(CC_Turno, Violacion)).ToString()
                Discrepancias_IV.Value = "0.00"
                Discrepancias_CV.Value = "0"

                ReporteCarrilCerrado.ReportSource.Parameters.Add(EfectivoMN_IV)
                ReporteCarrilCerrado.ReportSource.Parameters.Add(EfectivoMN_CV)
                ReporteCarrilCerrado.ReportSource.Parameters.Add(RPI_IV)
                ReporteCarrilCerrado.ReportSource.Parameters.Add(RPI_CV)
                ReporteCarrilCerrado.ReportSource.Parameters.Add(IAVE_IV)
                ReporteCarrilCerrado.ReportSource.Parameters.Add(IAVE_CV)
                ReporteCarrilCerrado.ReportSource.Parameters.Add(TDC_IV)
                ReporteCarrilCerrado.ReportSource.Parameters.Add(TDC_CV)
                ReporteCarrilCerrado.ReportSource.Parameters.Add(TDD_IV)
                ReporteCarrilCerrado.ReportSource.Parameters.Add(TDD_CV)
                ReporteCarrilCerrado.ReportSource.Parameters.Add(VSC_IV)
                ReporteCarrilCerrado.ReportSource.Parameters.Add(VSC_CV)
                ReporteCarrilCerrado.ReportSource.Parameters.Add(RSP_IV)
                ReporteCarrilCerrado.ReportSource.Parameters.Add(RSP_CV)
                ReporteCarrilCerrado.ReportSource.Parameters.Add(Eludido_IV)
                ReporteCarrilCerrado.ReportSource.Parameters.Add(Eludido_CV)
                ReporteCarrilCerrado.ReportSource.Parameters.Add(Discrepancias_IV)
                ReporteCarrilCerrado.ReportSource.Parameters.Add(Discrepancias_CV)

#End Region

        End Select

	End Sub

	Private Sub LlenarObservaciones()

        'Observaciones linea 1
        Dim Linea1 As New Telerik.Reporting.Parameter()
        Linea1.Name = "Linea1"
        Linea1.Value = PrimeraLinea.ToUpper()

        'Observaciones linea 2
        Dim Linea2 As New Telerik.Reporting.Parameter()
        Linea2.Name = "Linea2"
        Linea2.Value = SegundaLinea.ToUpper()

        'Observaciones linea 3
        Dim Linea3 As New Telerik.Reporting.Parameter()
        Linea3.Name = "Linea3"
        Linea3.Value = TerceraLinea.ToUpper()

        Select Case SeleccionReporte
            Case 1
                ReporteCarril.ReportSource.Parameters.Add(Linea1)
                ReporteCarril.ReportSource.Parameters.Add(Linea2)
                ReporteCarril.ReportSource.Parameters.Add(Linea3)
            Case 2
                ReporteTurno.ReportSource.Parameters.Add(Linea1)
                ReporteTurno.ReportSource.Parameters.Add(Linea2)
                ReporteTurno.ReportSource.Parameters.Add(Linea3)
            Case 3
                ReporteDia.ReportSource.Parameters.Add(Linea1)
                ReporteDia.ReportSource.Parameters.Add(Linea2)
                ReporteDia.ReportSource.Parameters.Add(Linea3)
            Case 4
                ReporteCarrilCerrado.ReportSource.Parameters.Add(Linea1)
                ReporteCarrilCerrado.ReportSource.Parameters.Add(Linea2)
                ReporteCarrilCerrado.ReportSource.Parameters.Add(Linea3)
        End Select

    End Sub

    Private Sub LlenarFirmas()

        'Número y nombre del Analista Liquidador
        Dim Analista As New Telerik.Reporting.Parameter()
        Analista.Name = "Analista"
        Analista.Value = ConsultarAnalista(NoEmpleado)

        'Número y nombre del Administrador de la Plaza
        Dim Administrador As New Telerik.Reporting.Parameter()
        Administrador.Name = "Administrador"
        Administrador.Value = NoNomAdministrador

        'Número y nombre del Encargado de Turno
        Dim Encargado As New Telerik.Reporting.Parameter()
        Encargado.Name = "Encargado"
        Encargado.Value = NoNomEncargado

        Select Case SeleccionReporte
            Case 1
                'Número y nombre del Cajero
                Dim Cajero As New Telerik.Reporting.Parameter()
                Cajero.Name = "Cajero"
                Cajero.Value = ConsultarCajero(NumDeclaracion)

                ReporteCarril.ReportSource.Parameters.Add(Analista)
                ReporteCarril.ReportSource.Parameters.Add(Administrador)
                ReporteCarril.ReportSource.Parameters.Add(Encargado)
                ReporteCarril.ReportSource.Parameters.Add(Cajero)

                ComparativoCajero.ReportSource.Parameters.Add(Cajero)

            Case 2
                ReporteTurno.ReportSource.Parameters.Add(Analista)
                ReporteTurno.ReportSource.Parameters.Add(Administrador)
                ReporteTurno.ReportSource.Parameters.Add(Encargado)
            Case 3
                ReporteDia.ReportSource.Parameters.Add(Analista)
                ReporteDia.ReportSource.Parameters.Add(Administrador)
                ReporteDia.ReportSource.Parameters.Add(Encargado)
            Case 4
                Dim Cajero As New Telerik.Reporting.Parameter()
                Cajero.Name = "Cajero"
                Cajero.Value = NoNomEncargado

                ReporteCarrilCerrado.ReportSource.Parameters.Add(Analista)
                ReporteCarrilCerrado.ReportSource.Parameters.Add(Administrador)
                ReporteCarrilCerrado.ReportSource.Parameters.Add(Encargado)
                ReporteCarrilCerrado.ReportSource.Parameters.Add(Cajero)

                ComparativoCarrilCerrado.ReportSource.Parameters.Add(Cajero)
        End Select

    End Sub

	Private Sub LlenarTarifas()

		Dim T_A01 As New Telerik.Reporting.Parameter()
		T_A01.Name = "T_A01"
		T_A01.Value = (ConsultarTarifas(idPlazaR, T01A)).ToString("##,##0.00")

		Dim T_M01 As New Telerik.Reporting.Parameter()
		T_M01.Name = "T_M01"
		T_M01.Value = (ConsultarTarifas(idPlazaR, T01M)).ToString("##,##0.00")

		Dim T_B02 As New Telerik.Reporting.Parameter()
		T_B02.Name = "T_B02"
		T_B02.Value = (ConsultarTarifas(idPlazaR, T02B)).ToString("##,##0.00")

		Dim T_B03 As New Telerik.Reporting.Parameter()
		T_B03.Name = "T_B03"
		T_B03.Value = (ConsultarTarifas(idPlazaR, T03B)).ToString("##,##0.00")

		Dim T_B04 As New Telerik.Reporting.Parameter()
		T_B04.Name = "T_B04"
		T_B04.Value = (ConsultarTarifas(idPlazaR, T04B)).ToString("##,##0.00")

		Dim T_C02 As New Telerik.Reporting.Parameter()
		T_C02.Name = "T_C02"
		T_C02.Value = (ConsultarTarifas(idPlazaR, T02C)).ToString("##,##0.00")

		Dim T_C03 As New Telerik.Reporting.Parameter()
		T_C03.Name = "T_C03"
		T_C03.Value = (ConsultarTarifas(idPlazaR, T03C)).ToString("##,##0.00")

		Dim T_C04 As New Telerik.Reporting.Parameter()
		T_C04.Name = "T_C04"
		T_C04.Value = (ConsultarTarifas(idPlazaR, T04C)).ToString("##,##0.00")

		Dim T_C05 As New Telerik.Reporting.Parameter()
		T_C05.Name = "T_C05"
		T_C05.Value = (ConsultarTarifas(idPlazaR, T05C)).ToString("##,##0.00")

		Dim T_C06 As New Telerik.Reporting.Parameter()
		T_C06.Name = "T_C06"
		T_C06.Value = (ConsultarTarifas(idPlazaR, T06C)).ToString("##,##0.00")

		Dim T_C07 As New Telerik.Reporting.Parameter()
		T_C07.Name = "T_C07"
		T_C07.Value = (ConsultarTarifas(idPlazaR, T07C)).ToString("##,##0.00")

		Dim T_C08 As New Telerik.Reporting.Parameter()
		T_C08.Name = "T_C08"
		T_C08.Value = (ConsultarTarifas(idPlazaR, T08C)).ToString("##,##0.00")

		Dim T_C09 As New Telerik.Reporting.Parameter()
		T_C09.Name = "T_C09"
		T_C09.Value = (ConsultarTarifas(idPlazaR, T09C)).ToString("##,##0.00")

		Dim T_EE1 As New Telerik.Reporting.Parameter()
		T_EE1.Name = "T_EE1"
        T_EE1.Value = (ConsultarTarifas(idPlazaR, T01LnnA)).ToString("##,##0.00")

        Dim T_EE2 As New Telerik.Reporting.Parameter()
		T_EE2.Name = "T_EE2"
        T_EE2.Value = (ConsultarTarifas(idPlazaR, T09PnnC)).ToString("##,##0.00")

        Select Case SeleccionReporte
            Case 1
                ComparativoCajero.ReportSource.Parameters.Add(T_A01)
                ComparativoCajero.ReportSource.Parameters.Add(T_M01)
                ComparativoCajero.ReportSource.Parameters.Add(T_B02)
                ComparativoCajero.ReportSource.Parameters.Add(T_B03)
                ComparativoCajero.ReportSource.Parameters.Add(T_B04)
                ComparativoCajero.ReportSource.Parameters.Add(T_C02)
                ComparativoCajero.ReportSource.Parameters.Add(T_C03)
                ComparativoCajero.ReportSource.Parameters.Add(T_C04)
                ComparativoCajero.ReportSource.Parameters.Add(T_C05)
                ComparativoCajero.ReportSource.Parameters.Add(T_C06)
                ComparativoCajero.ReportSource.Parameters.Add(T_C07)
                ComparativoCajero.ReportSource.Parameters.Add(T_C08)
                ComparativoCajero.ReportSource.Parameters.Add(T_C09)
                ComparativoCajero.ReportSource.Parameters.Add(T_EE1)
                ComparativoCajero.ReportSource.Parameters.Add(T_EE2)
            Case 2
                ComparativoTurno.ReportSource.Parameters.Add(T_A01)
                ComparativoTurno.ReportSource.Parameters.Add(T_M01)
                ComparativoTurno.ReportSource.Parameters.Add(T_B02)
                ComparativoTurno.ReportSource.Parameters.Add(T_B03)
                ComparativoTurno.ReportSource.Parameters.Add(T_B04)
                ComparativoTurno.ReportSource.Parameters.Add(T_C02)
                ComparativoTurno.ReportSource.Parameters.Add(T_C03)
                ComparativoTurno.ReportSource.Parameters.Add(T_C04)
                ComparativoTurno.ReportSource.Parameters.Add(T_C05)
                ComparativoTurno.ReportSource.Parameters.Add(T_C06)
                ComparativoTurno.ReportSource.Parameters.Add(T_C07)
                ComparativoTurno.ReportSource.Parameters.Add(T_C08)
                ComparativoTurno.ReportSource.Parameters.Add(T_C09)
                ComparativoTurno.ReportSource.Parameters.Add(T_EE1)
                ComparativoTurno.ReportSource.Parameters.Add(T_EE2)
            Case 3
                ComparativoDia.ReportSource.Parameters.Add(T_A01)
                ComparativoDia.ReportSource.Parameters.Add(T_M01)
                ComparativoDia.ReportSource.Parameters.Add(T_B02)
                ComparativoDia.ReportSource.Parameters.Add(T_B03)
                ComparativoDia.ReportSource.Parameters.Add(T_B04)
                ComparativoDia.ReportSource.Parameters.Add(T_C02)
                ComparativoDia.ReportSource.Parameters.Add(T_C03)
                ComparativoDia.ReportSource.Parameters.Add(T_C04)
                ComparativoDia.ReportSource.Parameters.Add(T_C05)
                ComparativoDia.ReportSource.Parameters.Add(T_C06)
                ComparativoDia.ReportSource.Parameters.Add(T_C07)
                ComparativoDia.ReportSource.Parameters.Add(T_C08)
                ComparativoDia.ReportSource.Parameters.Add(T_C09)
                ComparativoDia.ReportSource.Parameters.Add(T_EE1)
                ComparativoDia.ReportSource.Parameters.Add(T_EE2)
            Case 4
                ComparativoCarrilCerrado.ReportSource.Parameters.Add(T_A01)
                ComparativoCarrilCerrado.ReportSource.Parameters.Add(T_M01)
                ComparativoCarrilCerrado.ReportSource.Parameters.Add(T_B02)
                ComparativoCarrilCerrado.ReportSource.Parameters.Add(T_B03)
                ComparativoCarrilCerrado.ReportSource.Parameters.Add(T_B04)
                ComparativoCarrilCerrado.ReportSource.Parameters.Add(T_C02)
                ComparativoCarrilCerrado.ReportSource.Parameters.Add(T_C03)
                ComparativoCarrilCerrado.ReportSource.Parameters.Add(T_C04)
                ComparativoCarrilCerrado.ReportSource.Parameters.Add(T_C05)
                ComparativoCarrilCerrado.ReportSource.Parameters.Add(T_C06)
                ComparativoCarrilCerrado.ReportSource.Parameters.Add(T_C07)
                ComparativoCarrilCerrado.ReportSource.Parameters.Add(T_C08)
                ComparativoCarrilCerrado.ReportSource.Parameters.Add(T_C09)
                ComparativoCarrilCerrado.ReportSource.Parameters.Add(T_EE1)
                ComparativoCarrilCerrado.ReportSource.Parameters.Add(T_EE2)
        End Select

    End Sub

    Private Sub LlenarComparativo()

        '***** Declaración de parametros

#Region "Efectivo"

        Dim A01_E As New Telerik.Reporting.Parameter()
        A01_E.Name = "A01_E"

        Dim M01_E As New Telerik.Reporting.Parameter()
        M01_E.Name = "M01_E"

        Dim B02_E As New Telerik.Reporting.Parameter()
        B02_E.Name = "B02_E"

        Dim B03_E As New Telerik.Reporting.Parameter()
        B03_E.Name = "B03_E"

        Dim B04_E As New Telerik.Reporting.Parameter()
        B04_E.Name = "B04_E"

        Dim C02_E As New Telerik.Reporting.Parameter()
        C02_E.Name = "C02_E"

        Dim C03_E As New Telerik.Reporting.Parameter()
        C03_E.Name = "C03_E"

        Dim C04_E As New Telerik.Reporting.Parameter()
        C04_E.Name = "C04_E"

        Dim C05_E As New Telerik.Reporting.Parameter()
        C05_E.Name = "C05_E"

        Dim C06_E As New Telerik.Reporting.Parameter()
        C06_E.Name = "C06_E"

        Dim C07_E As New Telerik.Reporting.Parameter()
        C07_E.Name = "C07_E"

        Dim C08_E As New Telerik.Reporting.Parameter()
        C08_E.Name = "C08_E"

        Dim C09_E As New Telerik.Reporting.Parameter()
        C09_E.Name = "C09_E"

        Dim EE1_E As New Telerik.Reporting.Parameter()
        EE1_E.Name = "EE1_E"

        Dim EE2_E As New Telerik.Reporting.Parameter()
        EE2_E.Name = "EE2_E"

#End Region

#Region "RPI"

        Dim A01_RPI As New Telerik.Reporting.Parameter()
        A01_RPI.Name = "A01_RPI"

        Dim M01_RPI As New Telerik.Reporting.Parameter()
        M01_RPI.Name = "M01_RPI"

        Dim B02_RPI As New Telerik.Reporting.Parameter()
        B02_RPI.Name = "B02_RPI"

        Dim B03_RPI As New Telerik.Reporting.Parameter()
        B03_RPI.Name = "B03_RPI"

        Dim B04_RPI As New Telerik.Reporting.Parameter()
        B04_RPI.Name = "B04_RPI"

        Dim C02_RPI As New Telerik.Reporting.Parameter()
        C02_RPI.Name = "C02_RPI"

        Dim C03_RPI As New Telerik.Reporting.Parameter()
        C03_RPI.Name = "C03_RPI"

        Dim C04_RPI As New Telerik.Reporting.Parameter()
        C04_RPI.Name = "C04_RPI"

        Dim C05_RPI As New Telerik.Reporting.Parameter()
        C05_RPI.Name = "C05_RPI"

        Dim C06_RPI As New Telerik.Reporting.Parameter()
        C06_RPI.Name = "C06_RPI"

        Dim C07_RPI As New Telerik.Reporting.Parameter()
        C07_RPI.Name = "C07_RPI"

        Dim C08_RPI As New Telerik.Reporting.Parameter()
        C08_RPI.Name = "C08_RPI"

        Dim C09_RPI As New Telerik.Reporting.Parameter()
        C09_RPI.Name = "C09_RPI"

        Dim EE1_RPI As New Telerik.Reporting.Parameter()
        EE1_RPI.Name = "EE1_RPI"

        Dim EE2_RPI As New Telerik.Reporting.Parameter()
        EE2_RPI.Name = "EE2_RPI"

#End Region

#Region "IAVE"

        Dim A01_IAVE As New Telerik.Reporting.Parameter()
        A01_IAVE.Name = "A01_IAVE"

        Dim M01_IAVE As New Telerik.Reporting.Parameter()
        M01_IAVE.Name = "M01_IAVE"

        Dim B02_IAVE As New Telerik.Reporting.Parameter()
        B02_IAVE.Name = "B02_IAVE"

        Dim B03_IAVE As New Telerik.Reporting.Parameter()
        B03_IAVE.Name = "B03_IAVE"

        Dim B04_IAVE As New Telerik.Reporting.Parameter()
        B04_IAVE.Name = "B04_IAVE"

        Dim C02_IAVE As New Telerik.Reporting.Parameter()
        C02_IAVE.Name = "C02_IAVE"

        Dim C03_IAVE As New Telerik.Reporting.Parameter()
        C03_IAVE.Name = "C03_IAVE"

        Dim C04_IAVE As New Telerik.Reporting.Parameter()
        C04_IAVE.Name = "C04_IAVE"

        Dim C05_IAVE As New Telerik.Reporting.Parameter()
        C05_IAVE.Name = "C05_IAVE"

        Dim C06_IAVE As New Telerik.Reporting.Parameter()
        C06_IAVE.Name = "C06_IAVE"

        Dim C07_IAVE As New Telerik.Reporting.Parameter()
        C07_IAVE.Name = "C07_IAVE"

        Dim C08_IAVE As New Telerik.Reporting.Parameter()
        C08_IAVE.Name = "C08_IAVE"

        Dim C09_IAVE As New Telerik.Reporting.Parameter()
        C09_IAVE.Name = "C09_IAVE"

        Dim EE1_IAVE As New Telerik.Reporting.Parameter()
        EE1_IAVE.Name = "EE1_IAVE"

        Dim EE2_IAVE As New Telerik.Reporting.Parameter()
        EE2_IAVE.Name = "EE2_IAVE"

#End Region

#Region "Tarjeta de Credito"

        Dim A01_TDC As New Telerik.Reporting.Parameter()
        A01_TDC.Name = "A01_TDC"

        Dim M01_TDC As New Telerik.Reporting.Parameter()
        M01_TDC.Name = "M01_TDC"

        Dim B02_TDC As New Telerik.Reporting.Parameter()
        B02_TDC.Name = "B02_TDC"

        Dim B03_TDC As New Telerik.Reporting.Parameter()
        B03_TDC.Name = "B03_TDC"

        Dim B04_TDC As New Telerik.Reporting.Parameter()
        B04_TDC.Name = "B04_TDC"

        Dim C02_TDC As New Telerik.Reporting.Parameter()
        C02_TDC.Name = "C02_TDC"

        Dim C03_TDC As New Telerik.Reporting.Parameter()
        C03_TDC.Name = "C03_TDC"

        Dim C04_TDC As New Telerik.Reporting.Parameter()
        C04_TDC.Name = "C04_TDC"

        Dim C05_TDC As New Telerik.Reporting.Parameter()
        C05_TDC.Name = "C05_TDC"

        Dim C06_TDC As New Telerik.Reporting.Parameter()
        C06_TDC.Name = "C06_TDC"

        Dim C07_TDC As New Telerik.Reporting.Parameter()
        C07_TDC.Name = "C07_TDC"

        Dim C08_TDC As New Telerik.Reporting.Parameter()
        C08_TDC.Name = "C08_TDC"

        Dim C09_TDC As New Telerik.Reporting.Parameter()
        C09_TDC.Name = "C09_TDC"

        Dim EE1_TDC As New Telerik.Reporting.Parameter()
        EE1_TDC.Name = "EE1_TDC"

        Dim EE2_TDC As New Telerik.Reporting.Parameter()
        EE2_TDC.Name = "EE2_TDC"

#End Region

#Region "Tarjeta de Debito"

        Dim A01_TDD As New Telerik.Reporting.Parameter()
        A01_TDD.Name = "A01_TDD"

        Dim M01_TDD As New Telerik.Reporting.Parameter()
        M01_TDD.Name = "M01_TDD"

        Dim B02_TDD As New Telerik.Reporting.Parameter()
        B02_TDD.Name = "B02_TDD"

        Dim B03_TDD As New Telerik.Reporting.Parameter()
        B03_TDD.Name = "B03_TDD"

        Dim B04_TDD As New Telerik.Reporting.Parameter()
        B04_TDD.Name = "B04_TDD"

        Dim C02_TDD As New Telerik.Reporting.Parameter()
        C02_TDD.Name = "C02_TDD"

        Dim C03_TDD As New Telerik.Reporting.Parameter()
        C03_TDD.Name = "C03_TDD"

        Dim C04_TDD As New Telerik.Reporting.Parameter()
        C04_TDD.Name = "C04_TDD"

        Dim C05_TDD As New Telerik.Reporting.Parameter()
        C05_TDD.Name = "C05_TDD"

        Dim C06_TDD As New Telerik.Reporting.Parameter()
        C06_TDD.Name = "C06_TDD"

        Dim C07_TDD As New Telerik.Reporting.Parameter()
        C07_TDD.Name = "C07_TDD"

        Dim C08_TDD As New Telerik.Reporting.Parameter()
        C08_TDD.Name = "C08_TDD"

        Dim C09_TDD As New Telerik.Reporting.Parameter()
        C09_TDD.Name = "C09_TDD"

        Dim EE1_TDD As New Telerik.Reporting.Parameter()
        EE1_TDD.Name = "EE1_TDD"

        Dim EE2_TDD As New Telerik.Reporting.Parameter()
        EE2_TDD.Name = "EE2_TDD"

#End Region

#Region "vsc"

        Dim A01_VSC As New Telerik.Reporting.Parameter()
        A01_VSC.Name = "A01_VSC"

        Dim M01_VSC As New Telerik.Reporting.Parameter()
        M01_VSC.Name = "M01_VSC"

        Dim B02_VSC As New Telerik.Reporting.Parameter()
        B02_VSC.Name = "B02_VSC"

        Dim B03_VSC As New Telerik.Reporting.Parameter()
        B03_VSC.Name = "B03_VSC"

        Dim B04_VSC As New Telerik.Reporting.Parameter()
        B04_VSC.Name = "B04_VSC"

        Dim C02_VSC As New Telerik.Reporting.Parameter()
        C02_VSC.Name = "C02_VSC"

        Dim C03_VSC As New Telerik.Reporting.Parameter()
        C03_VSC.Name = "C03_VSC"

        Dim C04_VSC As New Telerik.Reporting.Parameter()
        C04_VSC.Name = "C04_VSC"

        Dim C05_VSC As New Telerik.Reporting.Parameter()
        C05_VSC.Name = "C05_VSC"

        Dim C06_VSC As New Telerik.Reporting.Parameter()
        C06_VSC.Name = "C06_VSC"

        Dim C07_VSC As New Telerik.Reporting.Parameter()
        C07_VSC.Name = "C07_VSC"

        Dim C08_VSC As New Telerik.Reporting.Parameter()
        C08_VSC.Name = "C08_VSC"

        Dim C09_VSC As New Telerik.Reporting.Parameter()
        C09_VSC.Name = "C09_VSC"

        Dim EE1_VSC As New Telerik.Reporting.Parameter()
        EE1_VSC.Name = "EE1_VSC"

        Dim EE2_VSC As New Telerik.Reporting.Parameter()
        EE2_VSC.Name = "EE2_VSC"

#End Region

#Region "Eludidos"

        Dim A01_Eludidos As New Telerik.Reporting.Parameter()
        A01_Eludidos.Name = "A01_Eludidos"

        Dim M01_Eludidos As New Telerik.Reporting.Parameter()
        M01_Eludidos.Name = "M01_Eludidos"

        Dim B02_Eludidos As New Telerik.Reporting.Parameter()
        B02_Eludidos.Name = "B02_Eludidos"

        Dim B03_Eludidos As New Telerik.Reporting.Parameter()
        B03_Eludidos.Name = "B03_Eludidos"

        Dim B04_Eludidos As New Telerik.Reporting.Parameter()
        B04_Eludidos.Name = "B04_Eludidos"

        Dim C02_Eludidos As New Telerik.Reporting.Parameter()
        C02_Eludidos.Name = "C02_Eludidos"

        Dim C03_Eludidos As New Telerik.Reporting.Parameter()
        C03_Eludidos.Name = "C03_Eludidos"

        Dim C04_Eludidos As New Telerik.Reporting.Parameter()
        C04_Eludidos.Name = "C04_Eludidos"

        Dim C05_Eludidos As New Telerik.Reporting.Parameter()
        C05_Eludidos.Name = "C05_Eludidos"

        Dim C06_Eludidos As New Telerik.Reporting.Parameter()
        C06_Eludidos.Name = "C06_Eludidos"

        Dim C07_Eludidos As New Telerik.Reporting.Parameter()
        C07_Eludidos.Name = "C07_Eludidos"

        Dim C08_Eludidos As New Telerik.Reporting.Parameter()
        C08_Eludidos.Name = "C08_Eludidos"

        Dim C09_Eludidos As New Telerik.Reporting.Parameter()
        C09_Eludidos.Name = "C09_Eludidos"

        Dim EE1_Eludidos As New Telerik.Reporting.Parameter()
        EE1_Eludidos.Name = "EE1_Eludidos"

        Dim EE2_Eludidos As New Telerik.Reporting.Parameter()
        EE2_Eludidos.Name = "EE2_Eludidos"

#End Region

#Region "Reclasificados"

        Dim A01_Rec As New Telerik.Reporting.Parameter()
        A01_Rec.Name = "A01_Rec"

        Dim M01_Rec As New Telerik.Reporting.Parameter()
        M01_Rec.Name = "M01_Rec"

        Dim B02_Rec As New Telerik.Reporting.Parameter()
        B02_Rec.Name = "B02_Rec"

        Dim B03_Rec As New Telerik.Reporting.Parameter()
        B03_Rec.Name = "B03_Rec"

        Dim B04_Rec As New Telerik.Reporting.Parameter()
        B04_Rec.Name = "B04_Rec"

        Dim C02_Rec As New Telerik.Reporting.Parameter()
        C02_Rec.Name = "C02_Rec"

        Dim C03_Rec As New Telerik.Reporting.Parameter()
        C03_Rec.Name = "C03_Rec"

        Dim C04_Rec As New Telerik.Reporting.Parameter()
        C04_Rec.Name = "C04_Rec"

        Dim C05_Rec As New Telerik.Reporting.Parameter()
        C05_Rec.Name = "C05_Rec"

        Dim C06_Rec As New Telerik.Reporting.Parameter()
        C06_Rec.Name = "C06_Rec"

        Dim C07_Rec As New Telerik.Reporting.Parameter()
        C07_Rec.Name = "C07_Rec"

        Dim C08_Rec As New Telerik.Reporting.Parameter()
        C08_Rec.Name = "C08_Rec"

        Dim C09_Rec As New Telerik.Reporting.Parameter()
        C09_Rec.Name = "C09_Rec"

        Dim EE1_Rec As New Telerik.Reporting.Parameter()
        EE1_Rec.Name = "EE1_Rec"

        Dim EE2_Rec As New Telerik.Reporting.Parameter()
        EE2_Rec.Name = "EE2_Rec"

#End Region

        '***** Asignación de valores segun el reporte seleccionado

        Select Case SeleccionReporte
            Case 1

#Region "Efectivo"

                A01_E.Value = (ContarNormales(NumDeclaracion, Efectivo)).ToString()
                M01_E.Value = (ContarVehiculos(NumDeclaracion, T01M, Efectivo)).ToString()
                B02_E.Value = (ContarVehiculos(NumDeclaracion, T02B, Efectivo)).ToString()
                B03_E.Value = (ContarVehiculos(NumDeclaracion, T03B, Efectivo)).ToString()
                B04_E.Value = (ContarVehiculos(NumDeclaracion, T04B, Efectivo)).ToString()
                C02_E.Value = (ContarVehiculos(NumDeclaracion, T02C, Efectivo)).ToString()
                C03_E.Value = (ContarVehiculos(NumDeclaracion, T03C, Efectivo)).ToString()
                C04_E.Value = (ContarVehiculos(NumDeclaracion, T04C, Efectivo)).ToString()
                C05_E.Value = (ContarVehiculos(NumDeclaracion, T05C, Efectivo)).ToString()
                C06_E.Value = (ContarVehiculos(NumDeclaracion, T06C, Efectivo)).ToString()
                C07_E.Value = (ContarVehiculos(NumDeclaracion, T07C, Efectivo)).ToString()
                C08_E.Value = (ContarVehiculos(NumDeclaracion, T08C, Efectivo)).ToString()
                C09_E.Value = (ContarVehiculos(NumDeclaracion, T09C, Efectivo)).ToString()
                EE1_E.Value = (ContarVehiculos(NumDeclaracion, TL01A, Efectivo) + (ContarVehiculos(NumDeclaracion, TL02A, Efectivo) * 2) + SumarEjes(NumDeclaracion, T01LnnA, Efectivo)).ToString()
                EE2_E.Value = (SumarEjes(NumDeclaracion, T09PnnC, Efectivo)).ToString()

                ComparativoCajero.ReportSource.Parameters.Add(A01_E)
                ComparativoCajero.ReportSource.Parameters.Add(M01_E)
                ComparativoCajero.ReportSource.Parameters.Add(B02_E)
                ComparativoCajero.ReportSource.Parameters.Add(B03_E)
                ComparativoCajero.ReportSource.Parameters.Add(B04_E)
                ComparativoCajero.ReportSource.Parameters.Add(C02_E)
                ComparativoCajero.ReportSource.Parameters.Add(C03_E)
                ComparativoCajero.ReportSource.Parameters.Add(C04_E)
                ComparativoCajero.ReportSource.Parameters.Add(C05_E)
                ComparativoCajero.ReportSource.Parameters.Add(C06_E)
                ComparativoCajero.ReportSource.Parameters.Add(C07_E)
                ComparativoCajero.ReportSource.Parameters.Add(C08_E)
                ComparativoCajero.ReportSource.Parameters.Add(C09_E)
                ComparativoCajero.ReportSource.Parameters.Add(EE1_E)
                ComparativoCajero.ReportSource.Parameters.Add(EE2_E)

#End Region

#Region "RPI"

                A01_RPI.Value = (ContarNormales(NumDeclaracion, Residente)).ToString()
                M01_RPI.Value = (ContarVehiculos(NumDeclaracion, T01M, Residente)).ToString()
                B02_RPI.Value = (ContarVehiculos(NumDeclaracion, T02B, Residente)).ToString()
                B03_RPI.Value = (ContarVehiculos(NumDeclaracion, T03B, Residente)).ToString()
                B04_RPI.Value = (ContarVehiculos(NumDeclaracion, T04B, Residente)).ToString()
                C02_RPI.Value = (ContarVehiculos(NumDeclaracion, T02C, Residente)).ToString()
                C03_RPI.Value = (ContarVehiculos(NumDeclaracion, T03C, Residente)).ToString()
                C04_RPI.Value = (ContarVehiculos(NumDeclaracion, T04C, Residente)).ToString()
                C05_RPI.Value = (ContarVehiculos(NumDeclaracion, T05C, Residente)).ToString()
                C06_RPI.Value = (ContarVehiculos(NumDeclaracion, T06C, Residente)).ToString()
                C07_RPI.Value = (ContarVehiculos(NumDeclaracion, T07C, Residente)).ToString()
                C08_RPI.Value = (ContarVehiculos(NumDeclaracion, T08C, Residente)).ToString()
                C09_RPI.Value = (ContarVehiculos(NumDeclaracion, T09C, Residente)).ToString()
                EE1_RPI.Value = (ContarVehiculos(NumDeclaracion, TL01A, Residente) + (ContarVehiculos(NumDeclaracion, TL02A, Residente) * 2) + SumarEjes(NumDeclaracion, T01LnnA, Residente)).ToString()
                EE2_RPI.Value = (SumarEjes(NumDeclaracion, T09PnnC, Residente)).ToString()

                ComparativoCajero.ReportSource.Parameters.Add(A01_RPI)
                ComparativoCajero.ReportSource.Parameters.Add(M01_RPI)
                ComparativoCajero.ReportSource.Parameters.Add(B02_RPI)
                ComparativoCajero.ReportSource.Parameters.Add(B03_RPI)
                ComparativoCajero.ReportSource.Parameters.Add(B04_RPI)
                ComparativoCajero.ReportSource.Parameters.Add(C02_RPI)
                ComparativoCajero.ReportSource.Parameters.Add(C03_RPI)
                ComparativoCajero.ReportSource.Parameters.Add(C04_RPI)
                ComparativoCajero.ReportSource.Parameters.Add(C05_RPI)
                ComparativoCajero.ReportSource.Parameters.Add(C06_RPI)
                ComparativoCajero.ReportSource.Parameters.Add(C07_RPI)
                ComparativoCajero.ReportSource.Parameters.Add(C08_RPI)
                ComparativoCajero.ReportSource.Parameters.Add(C09_RPI)
                ComparativoCajero.ReportSource.Parameters.Add(EE1_RPI)
                ComparativoCajero.ReportSource.Parameters.Add(EE2_RPI)

#End Region

#Region "IAVE"

                A01_IAVE.Value = (ContarNormales(NumDeclaracion, IAVE)).ToString()
                M01_IAVE.Value = (ContarVehiculos(NumDeclaracion, T01M, IAVE)).ToString()
                B02_IAVE.Value = (ContarVehiculos(NumDeclaracion, T02B, IAVE)).ToString()
                B03_IAVE.Value = (ContarVehiculos(NumDeclaracion, T03B, IAVE)).ToString()
                B04_IAVE.Value = (ContarVehiculos(NumDeclaracion, T04B, IAVE)).ToString()
                C02_IAVE.Value = (ContarVehiculos(NumDeclaracion, T02C, IAVE)).ToString()
                C03_IAVE.Value = (ContarVehiculos(NumDeclaracion, T03C, IAVE)).ToString()
                C04_IAVE.Value = (ContarVehiculos(NumDeclaracion, T04C, IAVE)).ToString()
                C05_IAVE.Value = (ContarVehiculos(NumDeclaracion, T05C, IAVE)).ToString()
                C06_IAVE.Value = (ContarVehiculos(NumDeclaracion, T06C, IAVE)).ToString()
                C07_IAVE.Value = (ContarVehiculos(NumDeclaracion, T07C, IAVE)).ToString()
                C08_IAVE.Value = (ContarVehiculos(NumDeclaracion, T08C, IAVE)).ToString()
                C09_IAVE.Value = (ContarVehiculos(NumDeclaracion, T09C, IAVE)).ToString()
                EE1_IAVE.Value = (ContarVehiculos(NumDeclaracion, TL01A, IAVE) + (ContarVehiculos(NumDeclaracion, TL02A, IAVE) * 2) + SumarEjes(NumDeclaracion, T01LnnA, IAVE)).ToString()
                EE2_IAVE.Value = (SumarEjes(NumDeclaracion, T09PnnC, IAVE)).ToString()

                ComparativoCajero.ReportSource.Parameters.Add(A01_IAVE)
                ComparativoCajero.ReportSource.Parameters.Add(M01_IAVE)
                ComparativoCajero.ReportSource.Parameters.Add(B02_IAVE)
                ComparativoCajero.ReportSource.Parameters.Add(B03_IAVE)
                ComparativoCajero.ReportSource.Parameters.Add(B04_IAVE)
                ComparativoCajero.ReportSource.Parameters.Add(C02_IAVE)
                ComparativoCajero.ReportSource.Parameters.Add(C03_IAVE)
                ComparativoCajero.ReportSource.Parameters.Add(C04_IAVE)
                ComparativoCajero.ReportSource.Parameters.Add(C05_IAVE)
                ComparativoCajero.ReportSource.Parameters.Add(C06_IAVE)
                ComparativoCajero.ReportSource.Parameters.Add(C07_IAVE)
                ComparativoCajero.ReportSource.Parameters.Add(C08_IAVE)
                ComparativoCajero.ReportSource.Parameters.Add(C09_IAVE)
                ComparativoCajero.ReportSource.Parameters.Add(EE1_IAVE)
                ComparativoCajero.ReportSource.Parameters.Add(EE2_IAVE)

#End Region

#Region "Tarjeta de Credito"

                A01_TDC.Value = (ContarNormales(NumDeclaracion, TDC)).ToString()
                M01_TDC.Value = (ContarVehiculos(NumDeclaracion, T01M, TDC)).ToString()
                B02_TDC.Value = (ContarVehiculos(NumDeclaracion, T02B, TDC)).ToString()
                B03_TDC.Value = (ContarVehiculos(NumDeclaracion, T03B, TDC)).ToString()
                B04_TDC.Value = (ContarVehiculos(NumDeclaracion, T04B, TDC)).ToString()
                C02_TDC.Value = (ContarVehiculos(NumDeclaracion, T02C, TDC)).ToString()
                C03_TDC.Value = (ContarVehiculos(NumDeclaracion, T03C, TDC)).ToString()
                C04_TDC.Value = (ContarVehiculos(NumDeclaracion, T04C, TDC)).ToString()
                C05_TDC.Value = (ContarVehiculos(NumDeclaracion, T05C, TDC)).ToString()
                C06_TDC.Value = (ContarVehiculos(NumDeclaracion, T06C, TDC)).ToString()
                C07_TDC.Value = (ContarVehiculos(NumDeclaracion, T07C, TDC)).ToString()
                C08_TDC.Value = (ContarVehiculos(NumDeclaracion, T08C, TDC)).ToString()
                C09_TDC.Value = (ContarVehiculos(NumDeclaracion, T09C, TDC)).ToString()
                EE1_TDC.Value = (ContarVehiculos(NumDeclaracion, TL01A, TDC) + (ContarVehiculos(NumDeclaracion, TL02A, TDC) * 2) + SumarEjes(NumDeclaracion, T01LnnA, TDC)).ToString()
                EE2_TDC.Value = (SumarEjes(NumDeclaracion, T09PnnC, TDC)).ToString()

                ComparativoCajero.ReportSource.Parameters.Add(A01_TDC)
                ComparativoCajero.ReportSource.Parameters.Add(M01_TDC)
                ComparativoCajero.ReportSource.Parameters.Add(B02_TDC)
                ComparativoCajero.ReportSource.Parameters.Add(B03_TDC)
                ComparativoCajero.ReportSource.Parameters.Add(B04_TDC)
                ComparativoCajero.ReportSource.Parameters.Add(C02_TDC)
                ComparativoCajero.ReportSource.Parameters.Add(C03_TDC)
                ComparativoCajero.ReportSource.Parameters.Add(C04_TDC)
                ComparativoCajero.ReportSource.Parameters.Add(C05_TDC)
                ComparativoCajero.ReportSource.Parameters.Add(C06_TDC)
                ComparativoCajero.ReportSource.Parameters.Add(C07_TDC)
                ComparativoCajero.ReportSource.Parameters.Add(C08_TDC)
                ComparativoCajero.ReportSource.Parameters.Add(C09_TDC)
                ComparativoCajero.ReportSource.Parameters.Add(EE1_TDC)
                ComparativoCajero.ReportSource.Parameters.Add(EE2_TDC)

#End Region

#Region "Tarjeta de Debito"

                A01_TDD.Value = (ContarNormales(NumDeclaracion, TDD)).ToString()
                M01_TDD.Value = (ContarVehiculos(NumDeclaracion, T01M, TDD)).ToString()
                B02_TDD.Value = (ContarVehiculos(NumDeclaracion, T02B, TDD)).ToString()
                B03_TDD.Value = (ContarVehiculos(NumDeclaracion, T03B, TDD)).ToString()
                B04_TDD.Value = (ContarVehiculos(NumDeclaracion, T04B, TDD)).ToString()
                C02_TDD.Value = (ContarVehiculos(NumDeclaracion, T02C, TDD)).ToString()
                C03_TDD.Value = (ContarVehiculos(NumDeclaracion, T03C, TDD)).ToString()
                C04_TDD.Value = (ContarVehiculos(NumDeclaracion, T04C, TDD)).ToString()
                C05_TDD.Value = (ContarVehiculos(NumDeclaracion, T05C, TDD)).ToString()
                C06_TDD.Value = (ContarVehiculos(NumDeclaracion, T06C, TDD)).ToString()
                C07_TDD.Value = (ContarVehiculos(NumDeclaracion, T07C, TDD)).ToString()
                C08_TDD.Value = (ContarVehiculos(NumDeclaracion, T08C, TDD)).ToString()
                C09_TDD.Value = (ContarVehiculos(NumDeclaracion, T09C, TDD)).ToString()
                EE1_TDD.Value = (ContarVehiculos(NumDeclaracion, TL01A, TDD) + (ContarVehiculos(NumDeclaracion, TL02A, TDD) * 2) + SumarEjes(NumDeclaracion, T01LnnA, TDD)).ToString()
                EE2_TDD.Value = (SumarEjes(NumDeclaracion, T09PnnC, TDD)).ToString()

                ComparativoCajero.ReportSource.Parameters.Add(A01_TDD)
                ComparativoCajero.ReportSource.Parameters.Add(M01_TDD)
                ComparativoCajero.ReportSource.Parameters.Add(B02_TDD)
                ComparativoCajero.ReportSource.Parameters.Add(B03_TDD)
                ComparativoCajero.ReportSource.Parameters.Add(B04_TDD)
                ComparativoCajero.ReportSource.Parameters.Add(C02_TDD)
                ComparativoCajero.ReportSource.Parameters.Add(C03_TDD)
                ComparativoCajero.ReportSource.Parameters.Add(C04_TDD)
                ComparativoCajero.ReportSource.Parameters.Add(C05_TDD)
                ComparativoCajero.ReportSource.Parameters.Add(C06_TDD)
                ComparativoCajero.ReportSource.Parameters.Add(C07_TDD)
                ComparativoCajero.ReportSource.Parameters.Add(C08_TDD)
                ComparativoCajero.ReportSource.Parameters.Add(C09_TDD)
                ComparativoCajero.ReportSource.Parameters.Add(EE1_TDD)
                ComparativoCajero.ReportSource.Parameters.Add(EE2_TDD)

#End Region

#Region "VSC"

                A01_VSC.Value = (ContarNormales(NumDeclaracion, VSC)).ToString()
                M01_VSC.Value = (ContarVehiculos(NumDeclaracion, T01M, VSC)).ToString()
                B02_VSC.Value = (ContarVehiculos(NumDeclaracion, T02B, VSC)).ToString()
                B03_VSC.Value = (ContarVehiculos(NumDeclaracion, T03B, VSC)).ToString()
                B04_VSC.Value = (ContarVehiculos(NumDeclaracion, T04B, VSC)).ToString()
                C02_VSC.Value = (ContarVehiculos(NumDeclaracion, T02C, VSC)).ToString()
                C03_VSC.Value = (ContarVehiculos(NumDeclaracion, T03C, VSC)).ToString()
                C04_VSC.Value = (ContarVehiculos(NumDeclaracion, T04C, VSC)).ToString()
                C05_VSC.Value = (ContarVehiculos(NumDeclaracion, T05C, VSC)).ToString()
                C06_VSC.Value = (ContarVehiculos(NumDeclaracion, T06C, VSC)).ToString()
                C07_VSC.Value = (ContarVehiculos(NumDeclaracion, T07C, VSC)).ToString()
                C08_VSC.Value = (ContarVehiculos(NumDeclaracion, T08C, VSC)).ToString()
                C09_VSC.Value = (ContarVehiculos(NumDeclaracion, T09C, VSC)).ToString()
                EE1_VSC.Value = (ContarVehiculos(NumDeclaracion, TL01A, VSC) + (ContarVehiculos(NumDeclaracion, TL02A, VSC) * 2) + SumarEjes(NumDeclaracion, T01LnnA, VSC)).ToString()
                EE2_VSC.Value = (SumarEjes(NumDeclaracion, T09PnnC, VSC)).ToString()

                ComparativoCajero.ReportSource.Parameters.Add(A01_VSC)
                ComparativoCajero.ReportSource.Parameters.Add(M01_VSC)
                ComparativoCajero.ReportSource.Parameters.Add(B02_VSC)
                ComparativoCajero.ReportSource.Parameters.Add(B03_VSC)
                ComparativoCajero.ReportSource.Parameters.Add(B04_VSC)
                ComparativoCajero.ReportSource.Parameters.Add(C02_VSC)
                ComparativoCajero.ReportSource.Parameters.Add(C03_VSC)
                ComparativoCajero.ReportSource.Parameters.Add(C04_VSC)
                ComparativoCajero.ReportSource.Parameters.Add(C05_VSC)
                ComparativoCajero.ReportSource.Parameters.Add(C06_VSC)
                ComparativoCajero.ReportSource.Parameters.Add(C07_VSC)
                ComparativoCajero.ReportSource.Parameters.Add(C08_VSC)
                ComparativoCajero.ReportSource.Parameters.Add(C09_VSC)
                ComparativoCajero.ReportSource.Parameters.Add(EE1_VSC)
                ComparativoCajero.ReportSource.Parameters.Add(EE2_VSC)

#End Region

#Region "Eludidos"

                A01_Eludidos.Value = (ContarNormales(NumDeclaracion, Violacion)).ToString()
                M01_Eludidos.Value = (ContarVehiculos(NumDeclaracion, T01M, Violacion)).ToString()
                B02_Eludidos.Value = (ContarVehiculos(NumDeclaracion, T02B, Violacion)).ToString()
                B03_Eludidos.Value = (ContarVehiculos(NumDeclaracion, T03B, Violacion)).ToString()
                B04_Eludidos.Value = (ContarVehiculos(NumDeclaracion, T04B, Violacion)).ToString()
                C02_Eludidos.Value = (ContarVehiculos(NumDeclaracion, T02C, Violacion)).ToString()
                C03_Eludidos.Value = (ContarVehiculos(NumDeclaracion, T03C, Violacion)).ToString()
                C04_Eludidos.Value = (ContarVehiculos(NumDeclaracion, T04C, Violacion)).ToString()
                C05_Eludidos.Value = (ContarVehiculos(NumDeclaracion, T05C, Violacion)).ToString()
                C06_Eludidos.Value = (ContarVehiculos(NumDeclaracion, T06C, Violacion)).ToString()
                C07_Eludidos.Value = (ContarVehiculos(NumDeclaracion, T07C, Violacion)).ToString()
                C08_Eludidos.Value = (ContarVehiculos(NumDeclaracion, T08C, Violacion)).ToString()
                C09_Eludidos.Value = (ContarVehiculos(NumDeclaracion, T09C, Violacion)).ToString()
                EE1_Eludidos.Value = (ContarVehiculos(NumDeclaracion, TL01A, Violacion) + (ContarVehiculos(NumDeclaracion, TL02A, Violacion) * 2) + SumarEjes(NumDeclaracion, T01LnnA, Violacion)).ToString()
                EE2_Eludidos.Value = (SumarEjes(NumDeclaracion, T09PnnC, Violacion)).ToString()

                ComparativoCajero.ReportSource.Parameters.Add(A01_Eludidos)
                ComparativoCajero.ReportSource.Parameters.Add(M01_Eludidos)
                ComparativoCajero.ReportSource.Parameters.Add(B02_Eludidos)
                ComparativoCajero.ReportSource.Parameters.Add(B03_Eludidos)
                ComparativoCajero.ReportSource.Parameters.Add(B04_Eludidos)
                ComparativoCajero.ReportSource.Parameters.Add(C02_Eludidos)
                ComparativoCajero.ReportSource.Parameters.Add(C03_Eludidos)
                ComparativoCajero.ReportSource.Parameters.Add(C04_Eludidos)
                ComparativoCajero.ReportSource.Parameters.Add(C05_Eludidos)
                ComparativoCajero.ReportSource.Parameters.Add(C06_Eludidos)
                ComparativoCajero.ReportSource.Parameters.Add(C07_Eludidos)
                ComparativoCajero.ReportSource.Parameters.Add(C08_Eludidos)
                ComparativoCajero.ReportSource.Parameters.Add(C09_Eludidos)
                ComparativoCajero.ReportSource.Parameters.Add(EE1_Eludidos)
                ComparativoCajero.ReportSource.Parameters.Add(EE2_Eludidos)

#End Region

#Region "Reclasificados"

                A01_Rec.Value = (ContarSecuenciasTV(NumDeclaracion, Reclasificados, T01A)).ToString()
                M01_Rec.Value = (ContarSecuenciasTV(NumDeclaracion, Reclasificados, T01M)).ToString()
                B02_Rec.Value = (ContarSecuenciasTV(NumDeclaracion, Reclasificados, T02B)).ToString()
                B03_Rec.Value = (ContarSecuenciasTV(NumDeclaracion, Reclasificados, T03B)).ToString()
                B04_Rec.Value = (ContarSecuenciasTV(NumDeclaracion, Reclasificados, T04B)).ToString()
                C02_Rec.Value = (ContarSecuenciasTV(NumDeclaracion, Reclasificados, T02C)).ToString()
                C03_Rec.Value = (ContarSecuenciasTV(NumDeclaracion, Reclasificados, T03C)).ToString()
                C04_Rec.Value = (ContarSecuenciasTV(NumDeclaracion, Reclasificados, T04C)).ToString()
                C05_Rec.Value = (ContarSecuenciasTV(NumDeclaracion, Reclasificados, T05C)).ToString()
                C06_Rec.Value = (ContarSecuenciasTV(NumDeclaracion, Reclasificados, T06C)).ToString()
                C07_Rec.Value = (ContarSecuenciasTV(NumDeclaracion, Reclasificados, T07C)).ToString()
                C08_Rec.Value = (ContarSecuenciasTV(NumDeclaracion, Reclasificados, T08C)).ToString()
                C09_Rec.Value = (ContarSecuenciasTV(NumDeclaracion, Reclasificados, T09C)).ToString()
                EE1_Rec.Value = (ContarSecuenciasTV(NumDeclaracion, Reclasificados, T09C)).ToString()
                EE2_Rec.Value = (ContarSecuenciasTV(NumDeclaracion, Reclasificados, T09C)).ToString()

                ComparativoCajero.ReportSource.Parameters.Add(A01_Rec)
                ComparativoCajero.ReportSource.Parameters.Add(M01_Rec)
                ComparativoCajero.ReportSource.Parameters.Add(B02_Rec)
                ComparativoCajero.ReportSource.Parameters.Add(B03_Rec)
                ComparativoCajero.ReportSource.Parameters.Add(B04_Rec)
                ComparativoCajero.ReportSource.Parameters.Add(C02_Rec)
                ComparativoCajero.ReportSource.Parameters.Add(C03_Rec)
                ComparativoCajero.ReportSource.Parameters.Add(C04_Rec)
                ComparativoCajero.ReportSource.Parameters.Add(C05_Rec)
                ComparativoCajero.ReportSource.Parameters.Add(C06_Rec)
                ComparativoCajero.ReportSource.Parameters.Add(C07_Rec)
                ComparativoCajero.ReportSource.Parameters.Add(C08_Rec)
                ComparativoCajero.ReportSource.Parameters.Add(C09_Rec)
                ComparativoCajero.ReportSource.Parameters.Add(EE1_Rec)
                ComparativoCajero.ReportSource.Parameters.Add(EE2_Rec)

#End Region

            Case 2

#Region "Efectivo"

                A01_E.Value = (ContarNormalesTurno(Efectivo)).ToString()
                M01_E.Value = (ContarVehiculosTurnoC(T01M, Efectivo)).ToString()
                B02_E.Value = (ContarVehiculosTurnoC(T02B, Efectivo)).ToString()
                B03_E.Value = (ContarVehiculosTurnoC(T03B, Efectivo)).ToString()
                B04_E.Value = (ContarVehiculosTurnoC(T04B, Efectivo)).ToString()
                C02_E.Value = (ContarVehiculosTurnoC(T02C, Efectivo)).ToString()
                C03_E.Value = (ContarVehiculosTurnoC(T03C, Efectivo)).ToString()
                C04_E.Value = (ContarVehiculosTurnoC(T04C, Efectivo)).ToString()
                C05_E.Value = (ContarVehiculosTurnoC(T05C, Efectivo)).ToString()
                C06_E.Value = (ContarVehiculosTurnoC(T06C, Efectivo)).ToString()
                C07_E.Value = (ContarVehiculosTurnoC(T07C, Efectivo)).ToString()
                C08_E.Value = (ContarVehiculosTurnoC(T08C, Efectivo)).ToString()
                C09_E.Value = (ContarVehiculosTurnoC(T09C, Efectivo)).ToString()
                EE1_E.Value = (ContarVehiculosTurnoC(TL01A, Efectivo) + (ContarVehiculosTurnoC(TL02A, Efectivo) * 2) + SumarEjesTurno(T01LnnA, Efectivo)).ToString()
                EE2_E.Value = (SumarEjesTurno(T09PnnC, Efectivo)).ToString()

                ComparativoTurno.ReportSource.Parameters.Add(A01_E)
                ComparativoTurno.ReportSource.Parameters.Add(M01_E)
                ComparativoTurno.ReportSource.Parameters.Add(B02_E)
                ComparativoTurno.ReportSource.Parameters.Add(B03_E)
                ComparativoTurno.ReportSource.Parameters.Add(B04_E)
                ComparativoTurno.ReportSource.Parameters.Add(C02_E)
                ComparativoTurno.ReportSource.Parameters.Add(C03_E)
                ComparativoTurno.ReportSource.Parameters.Add(C04_E)
                ComparativoTurno.ReportSource.Parameters.Add(C05_E)
                ComparativoTurno.ReportSource.Parameters.Add(C06_E)
                ComparativoTurno.ReportSource.Parameters.Add(C07_E)
                ComparativoTurno.ReportSource.Parameters.Add(C08_E)
                ComparativoTurno.ReportSource.Parameters.Add(C09_E)
                ComparativoTurno.ReportSource.Parameters.Add(EE1_E)
                ComparativoTurno.ReportSource.Parameters.Add(EE2_E)

#End Region

#Region "RPI"

                A01_RPI.Value = (ContarNormalesTurno(Residente)).ToString()
                M01_RPI.Value = (ContarVehiculosTurnoC(T01M, Residente)).ToString()
                B02_RPI.Value = (ContarVehiculosTurnoC(T02B, Residente)).ToString()
                B03_RPI.Value = (ContarVehiculosTurnoC(T03B, Residente)).ToString()
                B04_RPI.Value = (ContarVehiculosTurnoC(T04B, Residente)).ToString()
                C02_RPI.Value = (ContarVehiculosTurnoC(T02C, Residente)).ToString()
                C03_RPI.Value = (ContarVehiculosTurnoC(T03C, Residente)).ToString()
                C04_RPI.Value = (ContarVehiculosTurnoC(T04C, Residente)).ToString()
                C05_RPI.Value = (ContarVehiculosTurnoC(T05C, Residente)).ToString()
                C06_RPI.Value = (ContarVehiculosTurnoC(T06C, Residente)).ToString()
                C07_RPI.Value = (ContarVehiculosTurnoC(T07C, Residente)).ToString()
                C08_RPI.Value = (ContarVehiculosTurnoC(T08C, Residente)).ToString()
                C09_RPI.Value = (ContarVehiculosTurnoC(T09C, Residente)).ToString()
                EE1_RPI.Value = (ContarVehiculosTurnoC(TL01A, Residente) + (ContarVehiculosTurnoC(TL02A, Residente) * 2) + SumarEjesTurno(T01LnnA, Residente)).ToString()
                EE2_RPI.Value = (SumarEjesTurno(T09PnnC, Residente)).ToString()

                ComparativoTurno.ReportSource.Parameters.Add(A01_RPI)
                ComparativoTurno.ReportSource.Parameters.Add(M01_RPI)
                ComparativoTurno.ReportSource.Parameters.Add(B02_RPI)
                ComparativoTurno.ReportSource.Parameters.Add(B03_RPI)
                ComparativoTurno.ReportSource.Parameters.Add(B04_RPI)
                ComparativoTurno.ReportSource.Parameters.Add(C02_RPI)
                ComparativoTurno.ReportSource.Parameters.Add(C03_RPI)
                ComparativoTurno.ReportSource.Parameters.Add(C04_RPI)
                ComparativoTurno.ReportSource.Parameters.Add(C05_RPI)
                ComparativoTurno.ReportSource.Parameters.Add(C06_RPI)
                ComparativoTurno.ReportSource.Parameters.Add(C07_RPI)
                ComparativoTurno.ReportSource.Parameters.Add(C08_RPI)
                ComparativoTurno.ReportSource.Parameters.Add(C09_RPI)
                ComparativoTurno.ReportSource.Parameters.Add(EE1_RPI)
                ComparativoTurno.ReportSource.Parameters.Add(EE2_RPI)

#End Region

#Region "IAVE"

                A01_IAVE.Value = (ContarNormalesTurno(IAVE)).ToString()
                M01_IAVE.Value = (ContarVehiculosTurnoC(T01M, IAVE)).ToString()
                B02_IAVE.Value = (ContarVehiculosTurnoC(T02B, IAVE)).ToString()
                B03_IAVE.Value = (ContarVehiculosTurnoC(T03B, IAVE)).ToString()
                B04_IAVE.Value = (ContarVehiculosTurnoC(T04B, IAVE)).ToString()
                C02_IAVE.Value = (ContarVehiculosTurnoC(T02C, IAVE)).ToString()
                C03_IAVE.Value = (ContarVehiculosTurnoC(T03C, IAVE)).ToString()
                C04_IAVE.Value = (ContarVehiculosTurnoC(T04C, IAVE)).ToString()
                C05_IAVE.Value = (ContarVehiculosTurnoC(T05C, IAVE)).ToString()
                C06_IAVE.Value = (ContarVehiculosTurnoC(T06C, IAVE)).ToString()
                C07_IAVE.Value = (ContarVehiculosTurnoC(T07C, IAVE)).ToString()
                C08_IAVE.Value = (ContarVehiculosTurnoC(T08C, IAVE)).ToString()
                C09_IAVE.Value = (ContarVehiculosTurnoC(T09C, IAVE)).ToString()
                EE1_IAVE.Value = (ContarVehiculosTurnoC(TL01A, IAVE) + (ContarVehiculosTurnoC(TL02A, IAVE) * 2) + SumarEjesTurno(T01LnnA, IAVE)).ToString()
                EE2_IAVE.Value = (SumarEjesTurno(T09PnnC, IAVE)).ToString()

                ComparativoTurno.ReportSource.Parameters.Add(A01_IAVE)
                ComparativoTurno.ReportSource.Parameters.Add(M01_IAVE)
                ComparativoTurno.ReportSource.Parameters.Add(B02_IAVE)
                ComparativoTurno.ReportSource.Parameters.Add(B03_IAVE)
                ComparativoTurno.ReportSource.Parameters.Add(B04_IAVE)
                ComparativoTurno.ReportSource.Parameters.Add(C02_IAVE)
                ComparativoTurno.ReportSource.Parameters.Add(C03_IAVE)
                ComparativoTurno.ReportSource.Parameters.Add(C04_IAVE)
                ComparativoTurno.ReportSource.Parameters.Add(C05_IAVE)
                ComparativoTurno.ReportSource.Parameters.Add(C06_IAVE)
                ComparativoTurno.ReportSource.Parameters.Add(C07_IAVE)
                ComparativoTurno.ReportSource.Parameters.Add(C08_IAVE)
                ComparativoTurno.ReportSource.Parameters.Add(C09_IAVE)
                ComparativoTurno.ReportSource.Parameters.Add(EE1_IAVE)
                ComparativoTurno.ReportSource.Parameters.Add(EE2_IAVE)

#End Region

#Region "Tarjeta de Credito"

                A01_TDC.Value = (ContarNormalesTurno(TDC)).ToString()
                M01_TDC.Value = (ContarVehiculosTurnoC(T01M, TDC)).ToString()
                B02_TDC.Value = (ContarVehiculosTurnoC(T02B, TDC)).ToString()
                B03_TDC.Value = (ContarVehiculosTurnoC(T03B, TDC)).ToString()
                B04_TDC.Value = (ContarVehiculosTurnoC(T04B, TDC)).ToString()
                C02_TDC.Value = (ContarVehiculosTurnoC(T02C, TDC)).ToString()
                C03_TDC.Value = (ContarVehiculosTurnoC(T03C, TDC)).ToString()
                C04_TDC.Value = (ContarVehiculosTurnoC(T04C, TDC)).ToString()
                C05_TDC.Value = (ContarVehiculosTurnoC(T05C, TDC)).ToString()
                C06_TDC.Value = (ContarVehiculosTurnoC(T06C, TDC)).ToString()
                C07_TDC.Value = (ContarVehiculosTurnoC(T07C, TDC)).ToString()
                C08_TDC.Value = (ContarVehiculosTurnoC(T08C, TDC)).ToString()
                C09_TDC.Value = (ContarVehiculosTurnoC(T09C, TDC)).ToString()
                EE1_TDC.Value = (ContarVehiculosTurnoC(TL01A, TDC) + (ContarVehiculosTurnoC(TL02A, TDC) * 2) + SumarEjesTurno(T01LnnA, TDC)).ToString()
                EE2_TDC.Value = (SumarEjesTurno(T09PnnC, TDC)).ToString()

                ComparativoTurno.ReportSource.Parameters.Add(A01_TDC)
                ComparativoTurno.ReportSource.Parameters.Add(M01_TDC)
                ComparativoTurno.ReportSource.Parameters.Add(B02_TDC)
                ComparativoTurno.ReportSource.Parameters.Add(B03_TDC)
                ComparativoTurno.ReportSource.Parameters.Add(B04_TDC)
                ComparativoTurno.ReportSource.Parameters.Add(C02_TDC)
                ComparativoTurno.ReportSource.Parameters.Add(C03_TDC)
                ComparativoTurno.ReportSource.Parameters.Add(C04_TDC)
                ComparativoTurno.ReportSource.Parameters.Add(C05_TDC)
                ComparativoTurno.ReportSource.Parameters.Add(C06_TDC)
                ComparativoTurno.ReportSource.Parameters.Add(C07_TDC)
                ComparativoTurno.ReportSource.Parameters.Add(C08_TDC)
                ComparativoTurno.ReportSource.Parameters.Add(C09_TDC)
                ComparativoTurno.ReportSource.Parameters.Add(EE1_TDC)
                ComparativoTurno.ReportSource.Parameters.Add(EE2_TDC)

#End Region

#Region "Tarjeta de Debito"

                A01_TDD.Value = (ContarNormalesTurno(TDD)).ToString()
                M01_TDD.Value = (ContarVehiculosTurnoC(T01M, TDD)).ToString()
                B02_TDD.Value = (ContarVehiculosTurnoC(T02B, TDD)).ToString()
                B03_TDD.Value = (ContarVehiculosTurnoC(T03B, TDD)).ToString()
                B04_TDD.Value = (ContarVehiculosTurnoC(T04B, TDD)).ToString()
                C02_TDD.Value = (ContarVehiculosTurnoC(T02C, TDD)).ToString()
                C03_TDD.Value = (ContarVehiculosTurnoC(T03C, TDD)).ToString()
                C04_TDD.Value = (ContarVehiculosTurnoC(T04C, TDD)).ToString()
                C05_TDD.Value = (ContarVehiculosTurnoC(T05C, TDD)).ToString()
                C06_TDD.Value = (ContarVehiculosTurnoC(T06C, TDD)).ToString()
                C07_TDD.Value = (ContarVehiculosTurnoC(T07C, TDD)).ToString()
                C08_TDD.Value = (ContarVehiculosTurnoC(T08C, TDD)).ToString()
                C09_TDD.Value = (ContarVehiculosTurnoC(T09C, TDD)).ToString()
                EE1_TDD.Value = (ContarVehiculosTurnoC(TL01A, TDD) + (ContarVehiculosTurnoC(TL02A, TDD) * 2) + SumarEjesTurno(T01LnnA, TDD)).ToString()
                EE2_TDD.Value = (SumarEjesTurno(T09PnnC, TDD)).ToString()

                ComparativoTurno.ReportSource.Parameters.Add(A01_TDD)
                ComparativoTurno.ReportSource.Parameters.Add(M01_TDD)
                ComparativoTurno.ReportSource.Parameters.Add(B02_TDD)
                ComparativoTurno.ReportSource.Parameters.Add(B03_TDD)
                ComparativoTurno.ReportSource.Parameters.Add(B04_TDD)
                ComparativoTurno.ReportSource.Parameters.Add(C02_TDD)
                ComparativoTurno.ReportSource.Parameters.Add(C03_TDD)
                ComparativoTurno.ReportSource.Parameters.Add(C04_TDD)
                ComparativoTurno.ReportSource.Parameters.Add(C05_TDD)
                ComparativoTurno.ReportSource.Parameters.Add(C06_TDD)
                ComparativoTurno.ReportSource.Parameters.Add(C07_TDD)
                ComparativoTurno.ReportSource.Parameters.Add(C08_TDD)
                ComparativoTurno.ReportSource.Parameters.Add(C09_TDD)
                ComparativoTurno.ReportSource.Parameters.Add(EE1_TDD)
                ComparativoTurno.ReportSource.Parameters.Add(EE2_TDD)

#End Region

#Region "VSC"

                A01_VSC.Value = (ContarNormalesTurno(VSC)).ToString()
                M01_VSC.Value = (ContarVehiculosTurnoC(T01M, VSC)).ToString()
                B02_VSC.Value = (ContarVehiculosTurnoC(T02B, VSC)).ToString()
                B03_VSC.Value = (ContarVehiculosTurnoC(T03B, VSC)).ToString()
                B04_VSC.Value = (ContarVehiculosTurnoC(T04B, VSC)).ToString()
                C02_VSC.Value = (ContarVehiculosTurnoC(T02C, VSC)).ToString()
                C03_VSC.Value = (ContarVehiculosTurnoC(T03C, VSC)).ToString()
                C04_VSC.Value = (ContarVehiculosTurnoC(T04C, VSC)).ToString()
                C05_VSC.Value = (ContarVehiculosTurnoC(T05C, VSC)).ToString()
                C06_VSC.Value = (ContarVehiculosTurnoC(T06C, VSC)).ToString()
                C07_VSC.Value = (ContarVehiculosTurnoC(T07C, VSC)).ToString()
                C08_VSC.Value = (ContarVehiculosTurnoC(T08C, VSC)).ToString()
                C09_VSC.Value = (ContarVehiculosTurnoC(T09C, VSC)).ToString()
                EE1_VSC.Value = (ContarVehiculosTurnoC(TL01A, VSC) + (ContarVehiculosTurnoC(TL02A, VSC) * 2) + SumarEjesTurno(T01LnnA, VSC)).ToString()
                EE2_VSC.Value = (SumarEjesTurno(T09PnnC, VSC)).ToString()

                ComparativoTurno.ReportSource.Parameters.Add(A01_VSC)
                ComparativoTurno.ReportSource.Parameters.Add(M01_VSC)
                ComparativoTurno.ReportSource.Parameters.Add(B02_VSC)
                ComparativoTurno.ReportSource.Parameters.Add(B03_VSC)
                ComparativoTurno.ReportSource.Parameters.Add(B04_VSC)
                ComparativoTurno.ReportSource.Parameters.Add(C02_VSC)
                ComparativoTurno.ReportSource.Parameters.Add(C03_VSC)
                ComparativoTurno.ReportSource.Parameters.Add(C04_VSC)
                ComparativoTurno.ReportSource.Parameters.Add(C05_VSC)
                ComparativoTurno.ReportSource.Parameters.Add(C06_VSC)
                ComparativoTurno.ReportSource.Parameters.Add(C07_VSC)
                ComparativoTurno.ReportSource.Parameters.Add(C08_VSC)
                ComparativoTurno.ReportSource.Parameters.Add(C09_VSC)
                ComparativoTurno.ReportSource.Parameters.Add(EE1_VSC)
                ComparativoTurno.ReportSource.Parameters.Add(EE2_VSC)

#End Region

#Region "Eludidos"

                A01_Eludidos.Value = (ContarNormalesTurno(Violacion)).ToString()
                M01_Eludidos.Value = (ContarVehiculosTurnoC(T01M, Violacion)).ToString()
                B02_Eludidos.Value = (ContarVehiculosTurnoC(T02B, Violacion)).ToString()
                B03_Eludidos.Value = (ContarVehiculosTurnoC(T03B, Violacion)).ToString()
                B04_Eludidos.Value = (ContarVehiculosTurnoC(T04B, Violacion)).ToString()
                C02_Eludidos.Value = (ContarVehiculosTurnoC(T02C, Violacion)).ToString()
                C03_Eludidos.Value = (ContarVehiculosTurnoC(T03C, Violacion)).ToString()
                C04_Eludidos.Value = (ContarVehiculosTurnoC(T04C, Violacion)).ToString()
                C05_Eludidos.Value = (ContarVehiculosTurnoC(T05C, Violacion)).ToString()
                C06_Eludidos.Value = (ContarVehiculosTurnoC(T06C, Violacion)).ToString()
                C07_Eludidos.Value = (ContarVehiculosTurnoC(T07C, Violacion)).ToString()
                C08_Eludidos.Value = (ContarVehiculosTurnoC(T08C, Violacion)).ToString()
                C09_Eludidos.Value = (ContarVehiculosTurnoC(T09C, Violacion)).ToString()
                EE1_Eludidos.Value = (ContarVehiculosTurnoC(TL01A, Violacion) + (ContarVehiculosTurnoC(TL02A, Violacion) * 2) + SumarEjesTurno(T01LnnA, Violacion)).ToString()
                EE2_Eludidos.Value = (SumarEjesTurno(T09PnnC, Violacion)).ToString()

                ComparativoTurno.ReportSource.Parameters.Add(A01_Eludidos)
                ComparativoTurno.ReportSource.Parameters.Add(M01_Eludidos)
                ComparativoTurno.ReportSource.Parameters.Add(B02_Eludidos)
                ComparativoTurno.ReportSource.Parameters.Add(B03_Eludidos)
                ComparativoTurno.ReportSource.Parameters.Add(B04_Eludidos)
                ComparativoTurno.ReportSource.Parameters.Add(C02_Eludidos)
                ComparativoTurno.ReportSource.Parameters.Add(C03_Eludidos)
                ComparativoTurno.ReportSource.Parameters.Add(C04_Eludidos)
                ComparativoTurno.ReportSource.Parameters.Add(C05_Eludidos)
                ComparativoTurno.ReportSource.Parameters.Add(C06_Eludidos)
                ComparativoTurno.ReportSource.Parameters.Add(C07_Eludidos)
                ComparativoTurno.ReportSource.Parameters.Add(C08_Eludidos)
                ComparativoTurno.ReportSource.Parameters.Add(C09_Eludidos)
                ComparativoTurno.ReportSource.Parameters.Add(EE1_Eludidos)
                ComparativoTurno.ReportSource.Parameters.Add(EE2_Eludidos)

#End Region

#Region "Reclasificados"

                M01_Rec.Value = (0).ToString()
                A01_Rec.Value = (0).ToString()
                B02_Rec.Value = (0).ToString()
                B03_Rec.Value = (0).ToString()
                B04_Rec.Value = (0).ToString()
                C02_Rec.Value = (0).ToString()
                C03_Rec.Value = (0).ToString()
                C04_Rec.Value = (0).ToString()
                C05_Rec.Value = (0).ToString()
                C06_Rec.Value = (0).ToString()
                C07_Rec.Value = (0).ToString()
                C08_Rec.Value = (0).ToString()
                C09_Rec.Value = (0).ToString()
                EE1_Rec.Value = (0).ToString()
                EE2_Rec.Value = (0).ToString()

                ComparativoTurno.ReportSource.Parameters.Add(A01_Rec)
                ComparativoTurno.ReportSource.Parameters.Add(M01_Rec)
                ComparativoTurno.ReportSource.Parameters.Add(B02_Rec)
                ComparativoTurno.ReportSource.Parameters.Add(B03_Rec)
                ComparativoTurno.ReportSource.Parameters.Add(B04_Rec)
                ComparativoTurno.ReportSource.Parameters.Add(C02_Rec)
                ComparativoTurno.ReportSource.Parameters.Add(C03_Rec)
                ComparativoTurno.ReportSource.Parameters.Add(C04_Rec)
                ComparativoTurno.ReportSource.Parameters.Add(C05_Rec)
                ComparativoTurno.ReportSource.Parameters.Add(C06_Rec)
                ComparativoTurno.ReportSource.Parameters.Add(C07_Rec)
                ComparativoTurno.ReportSource.Parameters.Add(C08_Rec)
                ComparativoTurno.ReportSource.Parameters.Add(C09_Rec)
                ComparativoTurno.ReportSource.Parameters.Add(EE1_Rec)
                ComparativoTurno.ReportSource.Parameters.Add(EE2_Rec)

#End Region

            Case 3

#Region "Efectivo"

                A01_E.Value = (ContarNormalesDia(Efectivo)).ToString()
                M01_E.Value = (ContarVehiculosDia(T01M, Efectivo)).ToString()
                B02_E.Value = (ContarVehiculosDia(T02B, Efectivo)).ToString()
                B03_E.Value = (ContarVehiculosDia(T03B, Efectivo)).ToString()
                B04_E.Value = (ContarVehiculosDia(T04B, Efectivo)).ToString()
                C02_E.Value = (ContarVehiculosDia(T02C, Efectivo)).ToString()
                C03_E.Value = (ContarVehiculosDia(T03C, Efectivo)).ToString()
                C04_E.Value = (ContarVehiculosDia(T04C, Efectivo)).ToString()
                C05_E.Value = (ContarVehiculosDia(T05C, Efectivo)).ToString()
                C06_E.Value = (ContarVehiculosDia(T06C, Efectivo)).ToString()
                C07_E.Value = (ContarVehiculosDia(T07C, Efectivo)).ToString()
                C08_E.Value = (ContarVehiculosDia(T08C, Efectivo)).ToString()
                C09_E.Value = (ContarVehiculosDia(T09C, Efectivo)).ToString()
                EE1_E.Value = (ContarVehiculosDia(TL01A, Efectivo) + (ContarVehiculosDia(TL02A, Efectivo) * 2) + SumarEjesDia(T01LnnA, Efectivo)).ToString()
                EE2_E.Value = (SumarEjesDia(T09PnnC, Efectivo)).ToString()

                ComparativoDia.ReportSource.Parameters.Add(A01_E)
                ComparativoDia.ReportSource.Parameters.Add(M01_E)
                ComparativoDia.ReportSource.Parameters.Add(B02_E)
                ComparativoDia.ReportSource.Parameters.Add(B03_E)
                ComparativoDia.ReportSource.Parameters.Add(B04_E)
                ComparativoDia.ReportSource.Parameters.Add(C02_E)
                ComparativoDia.ReportSource.Parameters.Add(C03_E)
                ComparativoDia.ReportSource.Parameters.Add(C04_E)
                ComparativoDia.ReportSource.Parameters.Add(C05_E)
                ComparativoDia.ReportSource.Parameters.Add(C06_E)
                ComparativoDia.ReportSource.Parameters.Add(C07_E)
                ComparativoDia.ReportSource.Parameters.Add(C08_E)
                ComparativoDia.ReportSource.Parameters.Add(C09_E)
                ComparativoDia.ReportSource.Parameters.Add(EE1_E)
                ComparativoDia.ReportSource.Parameters.Add(EE2_E)

#End Region

#Region "RPI"

                A01_RPI.Value = (ContarNormalesDia(Residente)).ToString()
                M01_RPI.Value = (ContarVehiculosDia(T01M, Residente)).ToString()
                B02_RPI.Value = (ContarVehiculosDia(T02B, Residente)).ToString()
                B03_RPI.Value = (ContarVehiculosDia(T03B, Residente)).ToString()
                B04_RPI.Value = (ContarVehiculosDia(T04B, Residente)).ToString()
                C02_RPI.Value = (ContarVehiculosDia(T02C, Residente)).ToString()
                C03_RPI.Value = (ContarVehiculosDia(T03C, Residente)).ToString()
                C04_RPI.Value = (ContarVehiculosDia(T04C, Residente)).ToString()
                C05_RPI.Value = (ContarVehiculosDia(T05C, Residente)).ToString()
                C06_RPI.Value = (ContarVehiculosDia(T06C, Residente)).ToString()
                C07_RPI.Value = (ContarVehiculosDia(T07C, Residente)).ToString()
                C08_RPI.Value = (ContarVehiculosDia(T08C, Residente)).ToString()
                C09_RPI.Value = (ContarVehiculosDia(T09C, Residente)).ToString()
                EE1_RPI.Value = (ContarVehiculosDia(TL01A, Residente) + (ContarVehiculosDia(TL02A, Residente) * 2) + SumarEjesDia(T01LnnA, Residente)).ToString()
                EE2_RPI.Value = (SumarEjesDia(T09PnnC, Residente)).ToString()

                ComparativoDia.ReportSource.Parameters.Add(A01_RPI)
                ComparativoDia.ReportSource.Parameters.Add(M01_RPI)
                ComparativoDia.ReportSource.Parameters.Add(B02_RPI)
                ComparativoDia.ReportSource.Parameters.Add(B03_RPI)
                ComparativoDia.ReportSource.Parameters.Add(B04_RPI)
                ComparativoDia.ReportSource.Parameters.Add(C02_RPI)
                ComparativoDia.ReportSource.Parameters.Add(C03_RPI)
                ComparativoDia.ReportSource.Parameters.Add(C04_RPI)
                ComparativoDia.ReportSource.Parameters.Add(C05_RPI)
                ComparativoDia.ReportSource.Parameters.Add(C06_RPI)
                ComparativoDia.ReportSource.Parameters.Add(C07_RPI)
                ComparativoDia.ReportSource.Parameters.Add(C08_RPI)
                ComparativoDia.ReportSource.Parameters.Add(C09_RPI)
                ComparativoDia.ReportSource.Parameters.Add(EE1_RPI)
                ComparativoDia.ReportSource.Parameters.Add(EE2_RPI)

#End Region

#Region "IAVE"

                A01_IAVE.Value = (ContarNormalesDia(IAVE)).ToString()
                M01_IAVE.Value = (ContarVehiculosDia(T01M, IAVE)).ToString()
                B02_IAVE.Value = (ContarVehiculosDia(T02B, IAVE)).ToString()
                B03_IAVE.Value = (ContarVehiculosDia(T03B, IAVE)).ToString()
                B04_IAVE.Value = (ContarVehiculosDia(T04B, IAVE)).ToString()
                C02_IAVE.Value = (ContarVehiculosDia(T02C, IAVE)).ToString()
                C03_IAVE.Value = (ContarVehiculosDia(T03C, IAVE)).ToString()
                C04_IAVE.Value = (ContarVehiculosDia(T04C, IAVE)).ToString()
                C05_IAVE.Value = (ContarVehiculosDia(T05C, IAVE)).ToString()
                C06_IAVE.Value = (ContarVehiculosDia(T06C, IAVE)).ToString()
                C07_IAVE.Value = (ContarVehiculosDia(T07C, IAVE)).ToString()
                C08_IAVE.Value = (ContarVehiculosDia(T08C, IAVE)).ToString()
                C09_IAVE.Value = (ContarVehiculosDia(T09C, IAVE)).ToString()
                EE1_IAVE.Value = (ContarVehiculosDia(TL01A, IAVE) + (ContarVehiculosDia(TL02A, IAVE) * 2) + SumarEjesDia(T01LnnA, IAVE)).ToString()
                EE2_IAVE.Value = (SumarEjesDia(T09PnnC, IAVE)).ToString()

                ComparativoDia.ReportSource.Parameters.Add(A01_IAVE)
                ComparativoDia.ReportSource.Parameters.Add(M01_IAVE)
                ComparativoDia.ReportSource.Parameters.Add(B02_IAVE)
                ComparativoDia.ReportSource.Parameters.Add(B03_IAVE)
                ComparativoDia.ReportSource.Parameters.Add(B04_IAVE)
                ComparativoDia.ReportSource.Parameters.Add(C02_IAVE)
                ComparativoDia.ReportSource.Parameters.Add(C03_IAVE)
                ComparativoDia.ReportSource.Parameters.Add(C04_IAVE)
                ComparativoDia.ReportSource.Parameters.Add(C05_IAVE)
                ComparativoDia.ReportSource.Parameters.Add(C06_IAVE)
                ComparativoDia.ReportSource.Parameters.Add(C07_IAVE)
                ComparativoDia.ReportSource.Parameters.Add(C08_IAVE)
                ComparativoDia.ReportSource.Parameters.Add(C09_IAVE)
                ComparativoDia.ReportSource.Parameters.Add(EE1_IAVE)
                ComparativoDia.ReportSource.Parameters.Add(EE2_IAVE)

#End Region

#Region "Tarjeta de Credito"

                A01_TDC.Value = (ContarNormalesDia(TDC)).ToString()
                M01_TDC.Value = (ContarVehiculosDia(T01M, TDC)).ToString()
                B02_TDC.Value = (ContarVehiculosDia(T02B, TDC)).ToString()
                B03_TDC.Value = (ContarVehiculosDia(T03B, TDC)).ToString()
                B04_TDC.Value = (ContarVehiculosDia(T04B, TDC)).ToString()
                C02_TDC.Value = (ContarVehiculosDia(T02C, TDC)).ToString()
                C03_TDC.Value = (ContarVehiculosDia(T03C, TDC)).ToString()
                C04_TDC.Value = (ContarVehiculosDia(T04C, TDC)).ToString()
                C05_TDC.Value = (ContarVehiculosDia(T05C, TDC)).ToString()
                C06_TDC.Value = (ContarVehiculosDia(T06C, TDC)).ToString()
                C07_TDC.Value = (ContarVehiculosDia(T07C, TDC)).ToString()
                C08_TDC.Value = (ContarVehiculosDia(T08C, TDC)).ToString()
                C09_TDC.Value = (ContarVehiculosDia(T09C, TDC)).ToString()
                EE1_TDC.Value = (ContarVehiculosDia(TL01A, TDC) + (ContarVehiculosDia(TL02A, TDC) * 2) + SumarEjesDia(T01LnnA, TDC)).ToString()
                EE2_TDC.Value = (SumarEjesDia(T09PnnC, TDC)).ToString()

                ComparativoDia.ReportSource.Parameters.Add(A01_TDC)
                ComparativoDia.ReportSource.Parameters.Add(M01_TDC)
                ComparativoDia.ReportSource.Parameters.Add(B02_TDC)
                ComparativoDia.ReportSource.Parameters.Add(B03_TDC)
                ComparativoDia.ReportSource.Parameters.Add(B04_TDC)
                ComparativoDia.ReportSource.Parameters.Add(C02_TDC)
                ComparativoDia.ReportSource.Parameters.Add(C03_TDC)
                ComparativoDia.ReportSource.Parameters.Add(C04_TDC)
                ComparativoDia.ReportSource.Parameters.Add(C05_TDC)
                ComparativoDia.ReportSource.Parameters.Add(C06_TDC)
                ComparativoDia.ReportSource.Parameters.Add(C07_TDC)
                ComparativoDia.ReportSource.Parameters.Add(C08_TDC)
                ComparativoDia.ReportSource.Parameters.Add(C09_TDC)
                ComparativoDia.ReportSource.Parameters.Add(EE1_TDC)
                ComparativoDia.ReportSource.Parameters.Add(EE2_TDC)

#End Region

#Region "Tarjeta de Debito"

                A01_TDD.Value = (ContarNormalesDia(TDD)).ToString()
                M01_TDD.Value = (ContarVehiculosDia(T01M, TDD)).ToString()
                B02_TDD.Value = (ContarVehiculosDia(T02B, TDD)).ToString()
                B03_TDD.Value = (ContarVehiculosDia(T03B, TDD)).ToString()
                B04_TDD.Value = (ContarVehiculosDia(T04B, TDD)).ToString()
                C02_TDD.Value = (ContarVehiculosDia(T02C, TDD)).ToString()
                C03_TDD.Value = (ContarVehiculosDia(T03C, TDD)).ToString()
                C04_TDD.Value = (ContarVehiculosDia(T04C, TDD)).ToString()
                C05_TDD.Value = (ContarVehiculosDia(T05C, TDD)).ToString()
                C06_TDD.Value = (ContarVehiculosDia(T06C, TDD)).ToString()
                C07_TDD.Value = (ContarVehiculosDia(T07C, TDD)).ToString()
                C08_TDD.Value = (ContarVehiculosDia(T08C, TDD)).ToString()
                C09_TDD.Value = (ContarVehiculosDia(T09C, TDD)).ToString()
                EE1_TDD.Value = (ContarVehiculosDia(TL01A, TDD) + (ContarVehiculosDia(TL02A, TDD) * 2) + SumarEjesDia(T01LnnA, TDD)).ToString()
                EE2_TDD.Value = (SumarEjesDia(T09PnnC, TDD)).ToString()

                ComparativoDia.ReportSource.Parameters.Add(A01_TDD)
                ComparativoDia.ReportSource.Parameters.Add(M01_TDD)
                ComparativoDia.ReportSource.Parameters.Add(B02_TDD)
                ComparativoDia.ReportSource.Parameters.Add(B03_TDD)
                ComparativoDia.ReportSource.Parameters.Add(B04_TDD)
                ComparativoDia.ReportSource.Parameters.Add(C02_TDD)
                ComparativoDia.ReportSource.Parameters.Add(C03_TDD)
                ComparativoDia.ReportSource.Parameters.Add(C04_TDD)
                ComparativoDia.ReportSource.Parameters.Add(C05_TDD)
                ComparativoDia.ReportSource.Parameters.Add(C06_TDD)
                ComparativoDia.ReportSource.Parameters.Add(C07_TDD)
                ComparativoDia.ReportSource.Parameters.Add(C08_TDD)
                ComparativoDia.ReportSource.Parameters.Add(C09_TDD)
                ComparativoDia.ReportSource.Parameters.Add(EE1_TDD)
                ComparativoDia.ReportSource.Parameters.Add(EE2_TDD)

#End Region

#Region "VSC"

                A01_VSC.Value = (ContarNormalesDia(VSC)).ToString()
                M01_VSC.Value = (ContarVehiculosDia(T01M, VSC)).ToString()
                B02_VSC.Value = (ContarVehiculosDia(T02B, VSC)).ToString()
                B03_VSC.Value = (ContarVehiculosDia(T03B, VSC)).ToString()
                B04_VSC.Value = (ContarVehiculosDia(T04B, VSC)).ToString()
                C02_VSC.Value = (ContarVehiculosDia(T02C, VSC)).ToString()
                C03_VSC.Value = (ContarVehiculosDia(T03C, VSC)).ToString()
                C04_VSC.Value = (ContarVehiculosDia(T04C, VSC)).ToString()
                C05_VSC.Value = (ContarVehiculosDia(T05C, VSC)).ToString()
                C06_VSC.Value = (ContarVehiculosDia(T06C, VSC)).ToString()
                C07_VSC.Value = (ContarVehiculosDia(T07C, VSC)).ToString()
                C08_VSC.Value = (ContarVehiculosDia(T08C, VSC)).ToString()
                C09_VSC.Value = (ContarVehiculosDia(T09C, VSC)).ToString()
                EE1_VSC.Value = (ContarVehiculosDia(TL01A, VSC) + (ContarVehiculosDia(TL02A, VSC) * 2) + SumarEjesDia(T01LnnA, VSC)).ToString()
                EE2_VSC.Value = (SumarEjesDia(T09PnnC, VSC)).ToString()

                ComparativoDia.ReportSource.Parameters.Add(A01_VSC)
                ComparativoDia.ReportSource.Parameters.Add(M01_VSC)
                ComparativoDia.ReportSource.Parameters.Add(B02_VSC)
                ComparativoDia.ReportSource.Parameters.Add(B03_VSC)
                ComparativoDia.ReportSource.Parameters.Add(B04_VSC)
                ComparativoDia.ReportSource.Parameters.Add(C02_VSC)
                ComparativoDia.ReportSource.Parameters.Add(C03_VSC)
                ComparativoDia.ReportSource.Parameters.Add(C04_VSC)
                ComparativoDia.ReportSource.Parameters.Add(C05_VSC)
                ComparativoDia.ReportSource.Parameters.Add(C06_VSC)
                ComparativoDia.ReportSource.Parameters.Add(C07_VSC)
                ComparativoDia.ReportSource.Parameters.Add(C08_VSC)
                ComparativoDia.ReportSource.Parameters.Add(C09_VSC)
                ComparativoDia.ReportSource.Parameters.Add(EE1_VSC)
                ComparativoDia.ReportSource.Parameters.Add(EE2_VSC)

#End Region

#Region "Eludidos"

                A01_Eludidos.Value = (ContarNormalesDia(Violacion)).ToString()
                M01_Eludidos.Value = (ContarVehiculosDia(T01M, Violacion)).ToString()
                B02_Eludidos.Value = (ContarVehiculosDia(T02B, Violacion)).ToString()
                B03_Eludidos.Value = (ContarVehiculosDia(T03B, Violacion)).ToString()
                B04_Eludidos.Value = (ContarVehiculosDia(T04B, Violacion)).ToString()
                C02_Eludidos.Value = (ContarVehiculosDia(T02C, Violacion)).ToString()
                C03_Eludidos.Value = (ContarVehiculosDia(T03C, Violacion)).ToString()
                C04_Eludidos.Value = (ContarVehiculosDia(T04C, Violacion)).ToString()
                C05_Eludidos.Value = (ContarVehiculosDia(T05C, Violacion)).ToString()
                C06_Eludidos.Value = (ContarVehiculosDia(T06C, Violacion)).ToString()
                C07_Eludidos.Value = (ContarVehiculosDia(T07C, Violacion)).ToString()
                C08_Eludidos.Value = (ContarVehiculosDia(T08C, Violacion)).ToString()
                C09_Eludidos.Value = (ContarVehiculosDia(T09C, Violacion)).ToString()
                EE1_Eludidos.Value = (ContarVehiculosDia(TL01A, Violacion) + (ContarVehiculosDia(TL02A, Violacion) * 2) + SumarEjesDia(T01LnnA, Violacion)).ToString()
                EE2_Eludidos.Value = (SumarEjesDia(T09PnnC, Violacion)).ToString()

                ComparativoDia.ReportSource.Parameters.Add(A01_Eludidos)
                ComparativoDia.ReportSource.Parameters.Add(M01_Eludidos)
                ComparativoDia.ReportSource.Parameters.Add(B02_Eludidos)
                ComparativoDia.ReportSource.Parameters.Add(B03_Eludidos)
                ComparativoDia.ReportSource.Parameters.Add(B04_Eludidos)
                ComparativoDia.ReportSource.Parameters.Add(C02_Eludidos)
                ComparativoDia.ReportSource.Parameters.Add(C03_Eludidos)
                ComparativoDia.ReportSource.Parameters.Add(C04_Eludidos)
                ComparativoDia.ReportSource.Parameters.Add(C05_Eludidos)
                ComparativoDia.ReportSource.Parameters.Add(C06_Eludidos)
                ComparativoDia.ReportSource.Parameters.Add(C07_Eludidos)
                ComparativoDia.ReportSource.Parameters.Add(C08_Eludidos)
                ComparativoDia.ReportSource.Parameters.Add(C09_Eludidos)
                ComparativoDia.ReportSource.Parameters.Add(EE1_Eludidos)
                ComparativoDia.ReportSource.Parameters.Add(EE2_Eludidos)

#End Region

            Case 4

#Region "Efectivo"

                A01_E.Value = (ContarNormales_CC(CC_Turno, Efectivo)).ToString()
                M01_E.Value = (ContarVehiculos_CC(CC_Turno, T01M, Efectivo)).ToString()
                B02_E.Value = (ContarVehiculos_CC(CC_Turno, T02B, Efectivo)).ToString()
                B03_E.Value = (ContarVehiculos_CC(CC_Turno, T03B, Efectivo)).ToString()
                B04_E.Value = (ContarVehiculos_CC(CC_Turno, T04B, Efectivo)).ToString()
                C02_E.Value = (ContarVehiculos_CC(CC_Turno, T02C, Efectivo)).ToString()
                C03_E.Value = (ContarVehiculos_CC(CC_Turno, T03C, Efectivo)).ToString()
                C04_E.Value = (ContarVehiculos_CC(CC_Turno, T04C, Efectivo)).ToString()
                C05_E.Value = (ContarVehiculos_CC(CC_Turno, T05C, Efectivo)).ToString()
                C06_E.Value = (ContarVehiculos_CC(CC_Turno, T06C, Efectivo)).ToString()
                C07_E.Value = (ContarVehiculos_CC(CC_Turno, T07C, Efectivo)).ToString()
                C08_E.Value = (ContarVehiculos_CC(CC_Turno, T08C, Efectivo)).ToString()
                C09_E.Value = (ContarVehiculos_CC(CC_Turno, T09C, Efectivo)).ToString()
                EE1_E.Value = (ContarVehiculos_CC(CC_Turno, TL01A, Efectivo) + (ContarVehiculos_CC(CC_Turno, TL02A, Efectivo) * 2) + SumarEjes_CC(CC_Turno, T01LnnA, Efectivo)).ToString()
                EE2_E.Value = (SumarEjes_CC(CC_Turno, T09PnnC, Efectivo)).ToString()

                ComparativoCarrilCerrado.ReportSource.Parameters.Add(A01_E)
                ComparativoCarrilCerrado.ReportSource.Parameters.Add(M01_E)
                ComparativoCarrilCerrado.ReportSource.Parameters.Add(B02_E)
                ComparativoCarrilCerrado.ReportSource.Parameters.Add(B03_E)
                ComparativoCarrilCerrado.ReportSource.Parameters.Add(B04_E)
                ComparativoCarrilCerrado.ReportSource.Parameters.Add(C02_E)
                ComparativoCarrilCerrado.ReportSource.Parameters.Add(C03_E)
                ComparativoCarrilCerrado.ReportSource.Parameters.Add(C04_E)
                ComparativoCarrilCerrado.ReportSource.Parameters.Add(C05_E)
                ComparativoCarrilCerrado.ReportSource.Parameters.Add(C06_E)
                ComparativoCarrilCerrado.ReportSource.Parameters.Add(C07_E)
                ComparativoCarrilCerrado.ReportSource.Parameters.Add(C08_E)
                ComparativoCarrilCerrado.ReportSource.Parameters.Add(C09_E)
                ComparativoCarrilCerrado.ReportSource.Parameters.Add(EE1_E)
                ComparativoCarrilCerrado.ReportSource.Parameters.Add(EE2_E)

#End Region

#Region "RPI"

                A01_RPI.Value = (ContarNormales_CC(CC_Turno, Residente)).ToString()
                M01_RPI.Value = (ContarVehiculos_CC(CC_Turno, T01M, Residente)).ToString()
                B02_RPI.Value = (ContarVehiculos_CC(CC_Turno, T02B, Residente)).ToString()
                B03_RPI.Value = (ContarVehiculos_CC(CC_Turno, T03B, Residente)).ToString()
                B04_RPI.Value = (ContarVehiculos_CC(CC_Turno, T04B, Residente)).ToString()
                C02_RPI.Value = (ContarVehiculos_CC(CC_Turno, T02C, Residente)).ToString()
                C03_RPI.Value = (ContarVehiculos_CC(CC_Turno, T03C, Residente)).ToString()
                C04_RPI.Value = (ContarVehiculos_CC(CC_Turno, T04C, Residente)).ToString()
                C05_RPI.Value = (ContarVehiculos_CC(CC_Turno, T05C, Residente)).ToString()
                C06_RPI.Value = (ContarVehiculos_CC(CC_Turno, T06C, Residente)).ToString()
                C07_RPI.Value = (ContarVehiculos_CC(CC_Turno, T07C, Residente)).ToString()
                C08_RPI.Value = (ContarVehiculos_CC(CC_Turno, T08C, Residente)).ToString()
                C09_RPI.Value = (ContarVehiculos_CC(CC_Turno, T09C, Residente)).ToString()
                EE1_RPI.Value = (ContarVehiculos_CC(CC_Turno, TL01A, Residente) + (ContarVehiculos_CC(CC_Turno, TL02A, Residente) * 2) + SumarEjes_CC(CC_Turno, T01LnnA, Residente)).ToString()
                EE2_RPI.Value = (SumarEjes_CC(CC_Turno, T09PnnC, Residente)).ToString()

                ComparativoCarrilCerrado.ReportSource.Parameters.Add(A01_RPI)
                ComparativoCarrilCerrado.ReportSource.Parameters.Add(M01_RPI)
                ComparativoCarrilCerrado.ReportSource.Parameters.Add(B02_RPI)
                ComparativoCarrilCerrado.ReportSource.Parameters.Add(B03_RPI)
                ComparativoCarrilCerrado.ReportSource.Parameters.Add(B04_RPI)
                ComparativoCarrilCerrado.ReportSource.Parameters.Add(C02_RPI)
                ComparativoCarrilCerrado.ReportSource.Parameters.Add(C03_RPI)
                ComparativoCarrilCerrado.ReportSource.Parameters.Add(C04_RPI)
                ComparativoCarrilCerrado.ReportSource.Parameters.Add(C05_RPI)
                ComparativoCarrilCerrado.ReportSource.Parameters.Add(C06_RPI)
                ComparativoCarrilCerrado.ReportSource.Parameters.Add(C07_RPI)
                ComparativoCarrilCerrado.ReportSource.Parameters.Add(C08_RPI)
                ComparativoCarrilCerrado.ReportSource.Parameters.Add(C09_RPI)
                ComparativoCarrilCerrado.ReportSource.Parameters.Add(EE1_RPI)
                ComparativoCarrilCerrado.ReportSource.Parameters.Add(EE2_RPI)

#End Region

#Region "IAVE"

                A01_IAVE.Value = (ContarNormales_CC(CC_Turno, IAVE)).ToString()
                M01_IAVE.Value = (ContarVehiculos_CC(CC_Turno, T01M, IAVE)).ToString()
                B02_IAVE.Value = (ContarVehiculos_CC(CC_Turno, T02B, IAVE)).ToString()
                B03_IAVE.Value = (ContarVehiculos_CC(CC_Turno, T03B, IAVE)).ToString()
                B04_IAVE.Value = (ContarVehiculos_CC(CC_Turno, T04B, IAVE)).ToString()
                C02_IAVE.Value = (ContarVehiculos_CC(CC_Turno, T02C, IAVE)).ToString()
                C03_IAVE.Value = (ContarVehiculos_CC(CC_Turno, T03C, IAVE)).ToString()
                C04_IAVE.Value = (ContarVehiculos_CC(CC_Turno, T04C, IAVE)).ToString()
                C05_IAVE.Value = (ContarVehiculos_CC(CC_Turno, T05C, IAVE)).ToString()
                C06_IAVE.Value = (ContarVehiculos_CC(CC_Turno, T06C, IAVE)).ToString()
                C07_IAVE.Value = (ContarVehiculos_CC(CC_Turno, T07C, IAVE)).ToString()
                C08_IAVE.Value = (ContarVehiculos_CC(CC_Turno, T08C, IAVE)).ToString()
                C09_IAVE.Value = (ContarVehiculos_CC(CC_Turno, T09C, IAVE)).ToString()
                EE1_IAVE.Value = (ContarVehiculos_CC(CC_Turno, TL01A, IAVE) + (ContarVehiculos_CC(CC_Turno, TL02A, IAVE) * 2) + SumarEjes_CC(CC_Turno, T01LnnA, IAVE)).ToString()
                EE2_IAVE.Value = (SumarEjes_CC(CC_Turno, T09PnnC, IAVE)).ToString()

                ComparativoCarrilCerrado.ReportSource.Parameters.Add(A01_IAVE)
                ComparativoCarrilCerrado.ReportSource.Parameters.Add(M01_IAVE)
                ComparativoCarrilCerrado.ReportSource.Parameters.Add(B02_IAVE)
                ComparativoCarrilCerrado.ReportSource.Parameters.Add(B03_IAVE)
                ComparativoCarrilCerrado.ReportSource.Parameters.Add(B04_IAVE)
                ComparativoCarrilCerrado.ReportSource.Parameters.Add(C02_IAVE)
                ComparativoCarrilCerrado.ReportSource.Parameters.Add(C03_IAVE)
                ComparativoCarrilCerrado.ReportSource.Parameters.Add(C04_IAVE)
                ComparativoCarrilCerrado.ReportSource.Parameters.Add(C05_IAVE)
                ComparativoCarrilCerrado.ReportSource.Parameters.Add(C06_IAVE)
                ComparativoCarrilCerrado.ReportSource.Parameters.Add(C07_IAVE)
                ComparativoCarrilCerrado.ReportSource.Parameters.Add(C08_IAVE)
                ComparativoCarrilCerrado.ReportSource.Parameters.Add(C09_IAVE)
                ComparativoCarrilCerrado.ReportSource.Parameters.Add(EE1_IAVE)
                ComparativoCarrilCerrado.ReportSource.Parameters.Add(EE2_IAVE)

#End Region

#Region "Tarjeta de Credito"

                A01_TDC.Value = (ContarNormales_CC(CC_Turno, TDC)).ToString()
                M01_TDC.Value = (ContarVehiculos_CC(CC_Turno, T01M, TDC)).ToString()
                B02_TDC.Value = (ContarVehiculos_CC(CC_Turno, T02B, TDC)).ToString()
                B03_TDC.Value = (ContarVehiculos_CC(CC_Turno, T03B, TDC)).ToString()
                B04_TDC.Value = (ContarVehiculos_CC(CC_Turno, T04B, TDC)).ToString()
                C02_TDC.Value = (ContarVehiculos_CC(CC_Turno, T02C, TDC)).ToString()
                C03_TDC.Value = (ContarVehiculos_CC(CC_Turno, T03C, TDC)).ToString()
                C04_TDC.Value = (ContarVehiculos_CC(CC_Turno, T04C, TDC)).ToString()
                C05_TDC.Value = (ContarVehiculos_CC(CC_Turno, T05C, TDC)).ToString()
                C06_TDC.Value = (ContarVehiculos_CC(CC_Turno, T06C, TDC)).ToString()
                C07_TDC.Value = (ContarVehiculos_CC(CC_Turno, T07C, TDC)).ToString()
                C08_TDC.Value = (ContarVehiculos_CC(CC_Turno, T08C, TDC)).ToString()
                C09_TDC.Value = (ContarVehiculos_CC(CC_Turno, T09C, TDC)).ToString()
                EE1_TDC.Value = (ContarVehiculos_CC(CC_Turno, TL01A, TDC) + (ContarVehiculos_CC(CC_Turno, TL02A, TDC) * 2) + SumarEjes_CC(CC_Turno, T01LnnA, TDC)).ToString()
                EE2_TDC.Value = (SumarEjes_CC(CC_Turno, T09PnnC, TDC)).ToString()

                ComparativoCarrilCerrado.ReportSource.Parameters.Add(A01_TDC)
                ComparativoCarrilCerrado.ReportSource.Parameters.Add(M01_TDC)
                ComparativoCarrilCerrado.ReportSource.Parameters.Add(B02_TDC)
                ComparativoCarrilCerrado.ReportSource.Parameters.Add(B03_TDC)
                ComparativoCarrilCerrado.ReportSource.Parameters.Add(B04_TDC)
                ComparativoCarrilCerrado.ReportSource.Parameters.Add(C02_TDC)
                ComparativoCarrilCerrado.ReportSource.Parameters.Add(C03_TDC)
                ComparativoCarrilCerrado.ReportSource.Parameters.Add(C04_TDC)
                ComparativoCarrilCerrado.ReportSource.Parameters.Add(C05_TDC)
                ComparativoCarrilCerrado.ReportSource.Parameters.Add(C06_TDC)
                ComparativoCarrilCerrado.ReportSource.Parameters.Add(C07_TDC)
                ComparativoCarrilCerrado.ReportSource.Parameters.Add(C08_TDC)
                ComparativoCarrilCerrado.ReportSource.Parameters.Add(C09_TDC)
                ComparativoCarrilCerrado.ReportSource.Parameters.Add(EE1_TDC)
                ComparativoCarrilCerrado.ReportSource.Parameters.Add(EE2_TDC)

#End Region

#Region "Tarjeta de Debito"

                A01_TDD.Value = (ContarNormales_CC(CC_Turno, TDD)).ToString()
                M01_TDD.Value = (ContarVehiculos_CC(CC_Turno, T01M, TDD)).ToString()
                B02_TDD.Value = (ContarVehiculos_CC(CC_Turno, T02B, TDD)).ToString()
                B03_TDD.Value = (ContarVehiculos_CC(CC_Turno, T03B, TDD)).ToString()
                B04_TDD.Value = (ContarVehiculos_CC(CC_Turno, T04B, TDD)).ToString()
                C02_TDD.Value = (ContarVehiculos_CC(CC_Turno, T02C, TDD)).ToString()
                C03_TDD.Value = (ContarVehiculos_CC(CC_Turno, T03C, TDD)).ToString()
                C04_TDD.Value = (ContarVehiculos_CC(CC_Turno, T04C, TDD)).ToString()
                C05_TDD.Value = (ContarVehiculos_CC(CC_Turno, T05C, TDD)).ToString()
                C06_TDD.Value = (ContarVehiculos_CC(CC_Turno, T06C, TDD)).ToString()
                C07_TDD.Value = (ContarVehiculos_CC(CC_Turno, T07C, TDD)).ToString()
                C08_TDD.Value = (ContarVehiculos_CC(CC_Turno, T08C, TDD)).ToString()
                C09_TDD.Value = (ContarVehiculos_CC(CC_Turno, T09C, TDD)).ToString()
                EE1_TDD.Value = (ContarVehiculos_CC(CC_Turno, TL01A, TDD) + (ContarVehiculos_CC(CC_Turno, TL02A, TDD) * 2) + SumarEjes_CC(CC_Turno, T01LnnA, TDD)).ToString()
                EE2_TDD.Value = (SumarEjes_CC(CC_Turno, T09PnnC, TDD)).ToString()

                ComparativoCarrilCerrado.ReportSource.Parameters.Add(A01_TDD)
                ComparativoCarrilCerrado.ReportSource.Parameters.Add(M01_TDD)
                ComparativoCarrilCerrado.ReportSource.Parameters.Add(B02_TDD)
                ComparativoCarrilCerrado.ReportSource.Parameters.Add(B03_TDD)
                ComparativoCarrilCerrado.ReportSource.Parameters.Add(B04_TDD)
                ComparativoCarrilCerrado.ReportSource.Parameters.Add(C02_TDD)
                ComparativoCarrilCerrado.ReportSource.Parameters.Add(C03_TDD)
                ComparativoCarrilCerrado.ReportSource.Parameters.Add(C04_TDD)
                ComparativoCarrilCerrado.ReportSource.Parameters.Add(C05_TDD)
                ComparativoCarrilCerrado.ReportSource.Parameters.Add(C06_TDD)
                ComparativoCarrilCerrado.ReportSource.Parameters.Add(C07_TDD)
                ComparativoCarrilCerrado.ReportSource.Parameters.Add(C08_TDD)
                ComparativoCarrilCerrado.ReportSource.Parameters.Add(C09_TDD)
                ComparativoCarrilCerrado.ReportSource.Parameters.Add(EE1_TDD)
                ComparativoCarrilCerrado.ReportSource.Parameters.Add(EE2_TDD)

#End Region

#Region "VSC"

                A01_VSC.Value = (ContarNormales_CC(CC_Turno, VSC)).ToString()
                M01_VSC.Value = (ContarVehiculos_CC(CC_Turno, T01M, VSC)).ToString()
                B02_VSC.Value = (ContarVehiculos_CC(CC_Turno, T02B, VSC)).ToString()
                B03_VSC.Value = (ContarVehiculos_CC(CC_Turno, T03B, VSC)).ToString()
                B04_VSC.Value = (ContarVehiculos_CC(CC_Turno, T04B, VSC)).ToString()
                C02_VSC.Value = (ContarVehiculos_CC(CC_Turno, T02C, VSC)).ToString()
                C03_VSC.Value = (ContarVehiculos_CC(CC_Turno, T03C, VSC)).ToString()
                C04_VSC.Value = (ContarVehiculos_CC(CC_Turno, T04C, VSC)).ToString()
                C05_VSC.Value = (ContarVehiculos_CC(CC_Turno, T05C, VSC)).ToString()
                C06_VSC.Value = (ContarVehiculos_CC(CC_Turno, T06C, VSC)).ToString()
                C07_VSC.Value = (ContarVehiculos_CC(CC_Turno, T07C, VSC)).ToString()
                C08_VSC.Value = (ContarVehiculos_CC(CC_Turno, T08C, VSC)).ToString()
                C09_VSC.Value = (ContarVehiculos_CC(CC_Turno, T09C, VSC)).ToString()
                EE1_VSC.Value = (ContarVehiculos_CC(CC_Turno, TL01A, VSC) + (ContarVehiculos_CC(CC_Turno, TL02A, VSC) * 2) + SumarEjes_CC(CC_Turno, T01LnnA, VSC)).ToString()
                EE2_VSC.Value = (SumarEjes_CC(CC_Turno, T09PnnC, VSC)).ToString()

                ComparativoCarrilCerrado.ReportSource.Parameters.Add(A01_VSC)
                ComparativoCarrilCerrado.ReportSource.Parameters.Add(M01_VSC)
                ComparativoCarrilCerrado.ReportSource.Parameters.Add(B02_VSC)
                ComparativoCarrilCerrado.ReportSource.Parameters.Add(B03_VSC)
                ComparativoCarrilCerrado.ReportSource.Parameters.Add(B04_VSC)
                ComparativoCarrilCerrado.ReportSource.Parameters.Add(C02_VSC)
                ComparativoCarrilCerrado.ReportSource.Parameters.Add(C03_VSC)
                ComparativoCarrilCerrado.ReportSource.Parameters.Add(C04_VSC)
                ComparativoCarrilCerrado.ReportSource.Parameters.Add(C05_VSC)
                ComparativoCarrilCerrado.ReportSource.Parameters.Add(C06_VSC)
                ComparativoCarrilCerrado.ReportSource.Parameters.Add(C07_VSC)
                ComparativoCarrilCerrado.ReportSource.Parameters.Add(C08_VSC)
                ComparativoCarrilCerrado.ReportSource.Parameters.Add(C09_VSC)
                ComparativoCarrilCerrado.ReportSource.Parameters.Add(EE1_VSC)
                ComparativoCarrilCerrado.ReportSource.Parameters.Add(EE2_VSC)

#End Region

#Region "Eludidos"

                A01_Eludidos.Value = (ContarNormales_CC(CC_Turno, Violacion)).ToString()
                M01_Eludidos.Value = (ContarVehiculos_CC(CC_Turno, T01M, Violacion)).ToString()
                B02_Eludidos.Value = (ContarVehiculos_CC(CC_Turno, T02B, Violacion)).ToString()
                B03_Eludidos.Value = (ContarVehiculos_CC(CC_Turno, T03B, Violacion)).ToString()
                B04_Eludidos.Value = (ContarVehiculos_CC(CC_Turno, T04B, Violacion)).ToString()
                C02_Eludidos.Value = (ContarVehiculos_CC(CC_Turno, T02C, Violacion)).ToString()
                C03_Eludidos.Value = (ContarVehiculos_CC(CC_Turno, T03C, Violacion)).ToString()
                C04_Eludidos.Value = (ContarVehiculos_CC(CC_Turno, T04C, Violacion)).ToString()
                C05_Eludidos.Value = (ContarVehiculos_CC(CC_Turno, T05C, Violacion)).ToString()
                C06_Eludidos.Value = (ContarVehiculos_CC(CC_Turno, T06C, Violacion)).ToString()
                C07_Eludidos.Value = (ContarVehiculos_CC(CC_Turno, T07C, Violacion)).ToString()
                C08_Eludidos.Value = (ContarVehiculos_CC(CC_Turno, T08C, Violacion)).ToString()
                C09_Eludidos.Value = (ContarVehiculos_CC(CC_Turno, T09C, Violacion)).ToString()
                EE1_Eludidos.Value = (ContarVehiculos_CC(CC_Turno, TL01A, Violacion) + (ContarVehiculos_CC(CC_Turno, TL02A, Violacion) * 2) + SumarEjes_CC(CC_Turno, T01LnnA, Violacion)).ToString()
                EE2_Eludidos.Value = (SumarEjes_CC(CC_Turno, T09PnnC, Violacion)).ToString()

                ComparativoCarrilCerrado.ReportSource.Parameters.Add(A01_Eludidos)
                ComparativoCarrilCerrado.ReportSource.Parameters.Add(M01_Eludidos)
                ComparativoCarrilCerrado.ReportSource.Parameters.Add(B02_Eludidos)
                ComparativoCarrilCerrado.ReportSource.Parameters.Add(B03_Eludidos)
                ComparativoCarrilCerrado.ReportSource.Parameters.Add(B04_Eludidos)
                ComparativoCarrilCerrado.ReportSource.Parameters.Add(C02_Eludidos)
                ComparativoCarrilCerrado.ReportSource.Parameters.Add(C03_Eludidos)
                ComparativoCarrilCerrado.ReportSource.Parameters.Add(C04_Eludidos)
                ComparativoCarrilCerrado.ReportSource.Parameters.Add(C05_Eludidos)
                ComparativoCarrilCerrado.ReportSource.Parameters.Add(C06_Eludidos)
                ComparativoCarrilCerrado.ReportSource.Parameters.Add(C07_Eludidos)
                ComparativoCarrilCerrado.ReportSource.Parameters.Add(C08_Eludidos)
                ComparativoCarrilCerrado.ReportSource.Parameters.Add(C09_Eludidos)
                ComparativoCarrilCerrado.ReportSource.Parameters.Add(EE1_Eludidos)
                ComparativoCarrilCerrado.ReportSource.Parameters.Add(EE2_Eludidos)

#End Region

#Region "Reclasificados"

                A01_Rec.Value = (0).ToString() '(ContarSecuenciasTV(NumDeclaracion, Reclasificados, T01A)).ToString()
                M01_Rec.Value = (0).ToString() '(ContarSecuenciasTV(NumDeclaracion, Reclasificados, T01M)).ToString()
                B02_Rec.Value = (0).ToString() '(ContarSecuenciasTV(NumDeclaracion, Reclasificados, T02B)).ToString()
                B03_Rec.Value = (0).ToString() '(ContarSecuenciasTV(NumDeclaracion, Reclasificados, T03B)).ToString()
                B04_Rec.Value = (0).ToString() '(ContarSecuenciasTV(NumDeclaracion, Reclasificados, T04B)).ToString()
                C02_Rec.Value = (0).ToString() '(ContarSecuenciasTV(NumDeclaracion, Reclasificados, T02C)).ToString()
                C03_Rec.Value = (0).ToString() '(ContarSecuenciasTV(NumDeclaracion, Reclasificados, T03C)).ToString()
                C04_Rec.Value = (0).ToString() '(ContarSecuenciasTV(NumDeclaracion, Reclasificados, T04C)).ToString()
                C05_Rec.Value = (0).ToString() '(ContarSecuenciasTV(NumDeclaracion, Reclasificados, T05C)).ToString()
                C06_Rec.Value = (0).ToString() '(ContarSecuenciasTV(NumDeclaracion, Reclasificados, T06C)).ToString()
                C07_Rec.Value = (0).ToString() '(ContarSecuenciasTV(NumDeclaracion, Reclasificados, T07C)).ToString()
                C08_Rec.Value = (0).ToString() '(ContarSecuenciasTV(NumDeclaracion, Reclasificados, T08C)).ToString()
                C09_Rec.Value = (0).ToString() '(ContarSecuenciasTV(NumDeclaracion, Reclasificados, T09C)).ToString()
                EE1_Rec.Value = (0).ToString() '(ContarSecuenciasTV(NumDeclaracion, Reclasificados, T09C)).ToString()
                EE2_Rec.Value = (0).ToString() '(ContarSecuenciasTV(NumDeclaracion, Reclasificados, T09C)).ToString()

                ComparativoCarrilCerrado.ReportSource.Parameters.Add(A01_Rec)
                ComparativoCarrilCerrado.ReportSource.Parameters.Add(M01_Rec)
                ComparativoCarrilCerrado.ReportSource.Parameters.Add(B02_Rec)
                ComparativoCarrilCerrado.ReportSource.Parameters.Add(B03_Rec)
                ComparativoCarrilCerrado.ReportSource.Parameters.Add(B04_Rec)
                ComparativoCarrilCerrado.ReportSource.Parameters.Add(C02_Rec)
                ComparativoCarrilCerrado.ReportSource.Parameters.Add(C03_Rec)
                ComparativoCarrilCerrado.ReportSource.Parameters.Add(C04_Rec)
                ComparativoCarrilCerrado.ReportSource.Parameters.Add(C05_Rec)
                ComparativoCarrilCerrado.ReportSource.Parameters.Add(C06_Rec)
                ComparativoCarrilCerrado.ReportSource.Parameters.Add(C07_Rec)
                ComparativoCarrilCerrado.ReportSource.Parameters.Add(C08_Rec)
                ComparativoCarrilCerrado.ReportSource.Parameters.Add(C09_Rec)
                ComparativoCarrilCerrado.ReportSource.Parameters.Add(EE1_Rec)
                ComparativoCarrilCerrado.ReportSource.Parameters.Add(EE2_Rec)

#End Region

        End Select

    End Sub


#Region "Functions"

    Private Function ConsultarDelegacion(idCaseta As Integer) As String

        Dim ctx As New CLRDataContext()

		Dim NomTramo = (From p In ctx.Plazas
						Join t In ctx.Tramo
								On p.idTramo Equals t.idTramo
						Where p.NoPlaza = idCaseta
						Select t.Tramo).SingleOrDefault()

		Return NomTramo.ToString()

    End Function

    Private Function ConsultarPlaza(idCaseta As Integer) As String


        Dim ctx As New CLRDataContext()

        Dim nombre = (From p In ctx.Plazas
                      Where p.NoPlaza = idCaseta
                      Select p.NomPlaza).SingleOrDefault()

        Dim num = (From n In ctx.Plazas
                   Where n.NoPlaza = idCaseta
                   Select n.Numero_Capufe).SingleOrDefault()

        Return num.ToString() + " - " + nombre.ToString()

    End Function

    Private Function ConsultarTurno(idTurno As Integer) As String

        Dim ctx As New CLRDataContext()

		Dim horario = (From h In ctx.Turnos
					   Where h.idTurno = idTurno
					   Select h.Turno).SingleOrDefault()

		Return horario.ToString()

    End Function

    Private Function ConsultarBolsa(idBolsa As Integer) As String

        Dim ctx As New CLRDataContext()

        Dim control = (From c In ctx.Declaraciones
                       Where c.NoDeclaracion = idBolsa
                       Select c.Bolsa).SingleOrDefault()

        Return control.ToString()

    End Function

    Private Function ConsultarHoraInicio(idBolsa As Integer) As TimeSpan

        Dim ctx As New CLRDataContext()

        Dim horaI = (From h In ctx.Declaraciones
                     Where h.NoDeclaracion = idBolsa
                     Select h.HoraApertura).SingleOrDefault()

        Return horaI

    End Function

    Private Function ConsultarHoraFinal(idBolsa As Integer) As TimeSpan

        Dim ctx As New CLRDataContext()

        Dim horaF = (From h In ctx.Declaraciones
                     Where h.NoDeclaracion = idBolsa
                     Select h.HoraCierre).SingleOrDefault()

        Return horaF

    End Function
    '*
    Private Function SumarMarcado(idBolsa As Integer, ForPago As Integer) As Double

        Dim ctx As New CLRDataContext()
        Dim HoraA As TimeSpan
        Dim HoraC As TimeSpan
        Dim importe

        HoraA = ConsultarHoraInicio(idBolsa)
        HoraC = ConsultarHoraFinal(idBolsa)

        If idTurnoR = 1 Then
            importe = (From i In ctx.Transacciones
                       Where ((i.Fecha = FechaR.AddDays(-1) And i.Hora >= HoraA) Or (i.Fecha = FechaR And i.Hora <= HoraC)) And i.NoPlaza = idPlazaR And i.idTurno = idTurnoR And i.NoCarrilCapufe = CarrilR And i.idPago = ForPago
                       Select i.idTarifa).Sum()

            If importe Is Nothing OrElse importe.ToString() = String.Empty Then
                Return 0
            Else
                Return importe
            End If
        Else
            importe = (From i In ctx.Transacciones
                       Where i.Fecha = FechaR And (i.Hora >= HoraA And i.Hora <= HoraC) And i.NoPlaza = idPlazaR And i.idTurno = idTurnoR And i.NoCarrilCapufe = CarrilR And i.idPago = ForPago
                       Select i.idTarifa).Sum()

            If importe Is Nothing OrElse importe.ToString() = String.Empty Then
                Return 0
            Else
                Return importe
            End If

        End If

    End Function
    '*
    Private Function ContarMarcado(idBolsa As Integer, ForPago As Integer) As Integer

        Dim ctx As New CLRDataContext()
        Dim HoraA As TimeSpan
        Dim HoraC As TimeSpan
        Dim cantidad

        HoraA = ConsultarHoraInicio(idBolsa)
        HoraC = ConsultarHoraFinal(idBolsa)

        If idTurnoR = 1 Then
            cantidad = (From i In ctx.Transacciones
                        Where ((i.Fecha = FechaR.AddDays(-1) And i.Hora >= HoraA) Or (i.Fecha = FechaR And i.Hora <= HoraC)) And i.NoPlaza = idPlazaR And i.idTurno = idTurnoR And i.NoCarrilCapufe = CarrilR And i.Capturado <> True And i.idPago = ForPago
                        Select i.idTarifa).Count()

            Return cantidad

        Else
            cantidad = (From i In ctx.Transacciones
                        Where i.Fecha = FechaR And (i.Hora >= HoraA And i.Hora <= HoraC) And i.NoPlaza = idPlazaR And i.idTurno = idTurnoR And i.NoCarrilCapufe = CarrilR And i.Capturado <> True And i.idPago = ForPago
                        Select i.idTarifa).Count()

            Return cantidad

        End If

    End Function
	'*
	Private Function SumarVerificado(idBolsa As Integer, ForPago As Integer) As Double

        Dim ctx As New CLRDataContext()
        Dim HoraA As TimeSpan
        Dim HoraC As TimeSpan
        Dim importe

        HoraA = ConsultarHoraInicio(idBolsa)
        HoraC = ConsultarHoraFinal(idBolsa)

        If idTurnoR = 1 Then
            importe = (From i In ctx.Transacciones
                       Join d In ctx.Dictaminaciones
                               On i.idDictaminacion Equals d.idDictaminacion
                       Where ((i.Fecha = FechaR.AddDays(-1) And i.Hora > HoraA) Or (i.Fecha = FechaR And i.Hora < HoraC)) And i.NoPlaza = idPlazaR And i.idTurno = idTurnoR And i.NoCarrilCapufe = CarrilR And d.idPago = ForPago And i.Anulado = False
                       Select d.NuevaTarifa).Sum()

            If importe Is Nothing OrElse importe.ToString() = String.Empty Then
                Return 0
            Else
                Return importe
            End If
        Else
            importe = (From i In ctx.Transacciones
                       Join d In ctx.Dictaminaciones
                               On i.idDictaminacion Equals d.idDictaminacion
                       Where i.Fecha = FechaR And (i.Hora > HoraA And i.Hora < HoraC) And i.NoPlaza = idPlazaR And i.idTurno = idTurnoR And i.NoCarrilCapufe = CarrilR And d.idPago = ForPago And i.Anulado = False
                       Select d.NuevaTarifa).Sum()

            If importe Is Nothing OrElse importe.ToString() = String.Empty Then
                Return 0
            Else
                Return importe
            End If

        End If

    End Function
	'*
	Private Function ContarVerificado(idBolsa As Integer, ForPago As Integer) As Integer

        Dim ctx As New CLRDataContext()
        Dim HoraA As TimeSpan
        Dim HoraC As TimeSpan
        Dim cantidad

        HoraA = ConsultarHoraInicio(idBolsa)
        HoraC = ConsultarHoraFinal(idBolsa)

        If idTurnoR = 1 Then
            cantidad = (From i In ctx.Transacciones
                        Join d In ctx.Dictaminaciones
                               On i.idDictaminacion Equals d.idDictaminacion
                        Where ((i.Fecha = FechaR.AddDays(-1) And i.Hora > HoraA) Or (i.Fecha = FechaR And i.Hora < HoraC)) And i.NoPlaza = idPlazaR And i.idTurno = idTurnoR And i.NoCarrilCapufe = CarrilR And d.idPago = ForPago And i.Anulado = False
                        Select d.NuevaTarifa).Count()

            Return cantidad

        Else
            cantidad = (From i In ctx.Transacciones
                        Join d In ctx.Dictaminaciones
                               On i.idDictaminacion Equals d.idDictaminacion
                        Where i.Fecha = FechaR And (i.Hora > HoraA And i.Hora < HoraC) And i.NoPlaza = idPlazaR And i.idTurno = idTurnoR And i.NoCarrilCapufe = CarrilR And d.idPago = ForPago And i.Anulado = False
                        Select d.NuevaTarifa).Count()

            Return cantidad

        End If

    End Function

    Private Function ConsultarAnalista(IdAnalista As Integer) As String

        Dim ctx As New CLRDataContext()

        Dim liquidador = (From l In ctx.PersonalCLR
                          Where l.NoEmpleadoCapufe = IdAnalista
                          Select l.Nombre + " " + l.APaterno + " " + l.AMaterno).SingleOrDefault()

        Return IdAnalista.ToString() + " - " + liquidador.ToString()

    End Function

    Private Function ConsultarEncargado(idBolsa As Integer) As String

        Dim ctx As New CLRDataContext()

        Dim numero = (From e In ctx.Declaraciones
                      Where e.NoDeclaracion = idBolsa
                      Select e.Encargado).SingleOrDefault()

		Dim nombre = (From n In ctx.PersonalPlaza
					  Where n.NoEmpleadoCapufe = numero
					  Select n.Nombre + " " + n.Apellidos).SingleOrDefault()


		Return numero.ToString() + " - " + nombre.ToString()

    End Function

    Private Function ConsultarCajero(idBolsa As Integer) As String

        Dim ctx As New CLRDataContext()

        Select Case idPlazaR
            Case 12
                NumA = 11
            Case 22
                NumA = 21
            Case 32
                NumA = 31
            Case 42
                NumA = 41
            Case 51
                NumA = 51
            Case 62
                NumA = 61
            Case 72
                NumA = 71
            Case 82
                NumA = 81
            Case 92
                NumA = 91
            Case 86
                NumA = 85
            Case 87
                NumA = 88
            Case 88
                NumA = 87
        End Select

        Dim numero = (From e In ctx.Declaraciones
                      Where e.NoDeclaracion = idBolsa
                      Select e.Cajero).SingleOrDefault()

        Dim nombre = (From n In ctx.PersonalPlaza
                      Where n.NoEmpleadoCapufe = numero And (n.NoPlaza = NumA Or n.NoPlaza = idPlazaR)
                      Select n.Nombre + " " + n.Apellidos).SingleOrDefault()


        Return numero.ToString() + " - " + nombre.ToString()

    End Function
	'*
	Private Function SumarDiscrepanciasMarcado(Fecha As Date, idPlaza As Integer, Carril As String, idTurno As Integer, idBolsa As Integer) As Double

        Dim ctx As New CLRDataContext()
        Dim HoraA As TimeSpan
        Dim HoraC As TimeSpan
        Dim discrepancias

        HoraA = ConsultarHoraInicio(idBolsa)
        HoraC = ConsultarHoraFinal(idBolsa)

        If idTurno = 1 Then
            discrepancias = (From d In ctx.Transacciones
                             Where ((d.Fecha = FechaR.AddDays(-1) And d.Hora > HoraA) Or (d.Fecha = FechaR And d.Hora < HoraC)) And d.NoPlaza = idPlaza And d.NoCarrilCapufe = Carril And d.idTurno = idTurno And (d.idVehiculo <> d.PRE Or d.idVehiculo <> d.POST Or d.PRE <> d.POST)
                             Select d.idTarifa).Sum()

            If discrepancias.ToString() Is Nothing OrElse discrepancias.ToString() = String.Empty Then
                Return discrepancias = "0,00"
            Else
                Return discrepancias
            End If
        Else
            discrepancias = (From d In ctx.Transacciones
                             Where d.Fecha = Fecha And (d.Hora > HoraA And d.Hora < HoraC) And d.NoPlaza = idPlaza And d.NoCarrilCapufe = Carril And d.idTurno = idTurno And (d.idVehiculo <> d.PRE Or d.idVehiculo <> d.POST Or d.PRE <> d.POST)
                             Select d.idTarifa).Sum()

            If discrepancias.ToString() Is Nothing OrElse discrepancias.ToString() = String.Empty Then
                Return discrepancias = "0,00"
            Else
                Return discrepancias
            End If
        End If

    End Function
	'*
	Private Function ContarDiscrepanciasMarcado(Fecha As Date, idPlaza As Integer, Carril As String, idTurno As Integer, idBolsa As Integer) As Integer

        Dim ctx As New CLRDataContext()
        Dim HoraA As TimeSpan
        Dim HoraC As TimeSpan
        Dim discrepancias

        HoraA = ConsultarHoraInicio(idBolsa)
        HoraC = ConsultarHoraFinal(idBolsa)

        If idTurno = 1 Then
            discrepancias = (From d In ctx.Transacciones
                             Where ((d.Fecha = FechaR.AddDays(-1) And d.Hora > HoraA) Or (d.Fecha = FechaR And d.Hora < HoraC)) And d.NoPlaza = idPlaza And d.NoCarrilCapufe = Carril And d.idTurno = idTurno And (d.idVehiculo <> d.PRE Or d.idVehiculo <> d.POST Or d.PRE <> d.POST)
                             Select d.idTarifa).Count()

            If discrepancias.ToString() Is Nothing OrElse discrepancias.ToString() = String.Empty Then
                Return discrepancias = "0"
            Else
                Return discrepancias
            End If
        Else
            discrepancias = (From d In ctx.Transacciones
                             Where d.Fecha = Fecha And (d.Hora > HoraA And d.Hora < HoraC) And d.NoPlaza = idPlaza And d.NoCarrilCapufe = Carril And d.idTurno = idTurno And (d.idVehiculo <> d.PRE Or d.idVehiculo <> d.POST Or d.PRE <> d.POST)
                             Select d.idTarifa).Count()

            If discrepancias.ToString() Is Nothing OrElse discrepancias.ToString() = String.Empty Then
                Return discrepancias = "0"
            Else
                Return discrepancias
            End If

        End If

    End Function
	'*
	Private Function SumarDiscrepanciasVerificado(Fecha As Date, idPlaza As Integer, Carril As String, idTurno As Integer, idBolsa As Integer) As Double

        Dim ctx As New CLRDataContext()
        Dim HoraA As TimeSpan
        Dim HoraC As TimeSpan
        Dim discrepancias

        HoraA = ConsultarHoraInicio(idBolsa)
        HoraC = ConsultarHoraFinal(idBolsa)

        If idTurno = 1 Then
            discrepancias = (From d In ctx.Transacciones
                             Join c In ctx.Dictaminaciones
                                     On d.idDictaminacion Equals c.idDictaminacion
                             Where ((d.Fecha = FechaR.AddDays(-1) And d.Hora > HoraA) Or (d.Fecha = FechaR And d.Hora < HoraC)) And d.NoPlaza = idPlaza And d.NoCarrilCapufe = Carril And d.idTurno = idTurno And (c.idVehiculo <> d.PRE Or c.idVehiculo <> d.POST) And d.Anulado = False
                             Select c.NuevaTarifa).Sum()

            If discrepancias.ToString() Is Nothing OrElse discrepancias.ToString() = String.Empty Then
                Return discrepancias = "0,00"
            Else
                Return discrepancias
            End If
        Else
            discrepancias = (From d In ctx.Transacciones
                             Join c In ctx.Dictaminaciones
                                     On d.idDictaminacion Equals c.idDictaminacion
                             Where d.Fecha = Fecha And (d.Hora > HoraA And d.Hora < HoraC) And d.NoPlaza = idPlaza And d.NoCarrilCapufe = Carril And d.idTurno = idTurno And (c.idVehiculo <> d.PRE Or c.idVehiculo <> d.POST) And d.Anulado = False
                             Select c.NuevaTarifa).Sum()

            If discrepancias.ToString() Is Nothing OrElse discrepancias.ToString() = String.Empty Then
                Return discrepancias = "0,00"
            Else
                Return discrepancias
            End If

        End If

    End Function
	'*
	Private Function ContarDiscrepanciasVerificado(Fecha As Date, idPlaza As Integer, Carril As String, idTurno As Integer, idBolsa As Integer) As Integer

        Dim ctx As New CLRDataContext()
        Dim HoraA As TimeSpan
        Dim HoraC As TimeSpan
        Dim discrepancias

        HoraA = ConsultarHoraInicio(idBolsa)
        HoraC = ConsultarHoraFinal(idBolsa)

        If idTurno = 1 Then
            discrepancias = (From d In ctx.Transacciones
                             Join c In ctx.Dictaminaciones
                                     On d.idDictaminacion Equals c.idDictaminacion
                             Where ((d.Fecha = FechaR.AddDays(-1) And d.Hora > HoraA) Or (d.Fecha = FechaR And d.Hora < HoraC)) And d.NoPlaza = idPlaza And d.NoCarrilCapufe = Carril And d.idTurno = idTurno And (c.idVehiculo <> d.PRE Or c.idVehiculo <> d.POST) And d.Anulado = False
                             Select c.NuevaTarifa).Count()

            If discrepancias.ToString() Is Nothing OrElse discrepancias.ToString() = String.Empty Then
                Return discrepancias = "0"
            Else
                Return discrepancias
            End If
        Else
            discrepancias = (From d In ctx.Transacciones
                             Join c In ctx.Dictaminaciones
                                     On d.idDictaminacion Equals c.idDictaminacion
                             Where d.Fecha = Fecha And (d.Hora > HoraA And d.Hora < HoraC) And d.NoPlaza = idPlaza And d.NoCarrilCapufe = Carril And d.idTurno = idTurno And (c.idVehiculo <> d.PRE Or c.idVehiculo <> d.POST) And d.Anulado = False
                             Select c.NuevaTarifa).Count()

            If discrepancias.ToString() Is Nothing OrElse discrepancias.ToString() = String.Empty Then
                Return discrepancias = "0"
            Else
                Return discrepancias
            End If

        End If

    End Function
    '*
    Private Function SumarSecuencias(idBolsa As Integer, Secuencia As String) As Double

        Dim ctx As New CLRDataContext()
        Dim HoraA As TimeSpan
        Dim HoraC As TimeSpan
        Dim importe

        HoraA = ConsultarHoraInicio(idBolsa)
        HoraC = ConsultarHoraFinal(idBolsa)

        If idTurnoR = 1 Then
            importe = (From i In ctx.Transacciones
                       Where ((i.Fecha = FechaR.AddDays(-1) And i.Hora > HoraA) Or (i.Fecha = FechaR And i.Hora < HoraC)) And i.NoPlaza = idPlazaR And i.idTurno = idTurnoR And i.NoCarrilCapufe = CarrilR And i.Obs_Secuencia = Secuencia
                       Select i.idTarifa).Sum()

            If importe Is Nothing OrElse importe.ToString() = String.Empty Then
                Return 0
            Else
                Return importe
            End If
        Else
            importe = (From i In ctx.Transacciones
                       Where i.Fecha = FechaR And (i.Hora > HoraA And i.Hora < HoraC) And i.NoPlaza = idPlazaR And i.idTurno = idTurnoR And i.NoCarrilCapufe = CarrilR And i.Obs_Secuencia = Secuencia
                       Select i.idTarifa).Sum()

            If importe Is Nothing OrElse importe.ToString() = String.Empty Then
                Return 0
            Else
                Return importe
            End If

        End If

    End Function
    '*
    Private Function ContarSecuencias(idBolsa As Integer, Secuencia As String) As Integer

        Dim ctx As New CLRDataContext()
        Dim HoraA As TimeSpan
        Dim HoraC As TimeSpan
        Dim cantidad

        HoraA = ConsultarHoraInicio(idBolsa)
        HoraC = ConsultarHoraFinal(idBolsa)

        If idTurnoR = 1 Then
            cantidad = (From i In ctx.Transacciones
                        Where ((i.Fecha = FechaR.AddDays(-1) And i.Hora > HoraA) Or (i.Fecha = FechaR And i.Hora < HoraC)) And i.NoPlaza = idPlazaR And i.idTurno = idTurnoR And i.NoCarrilCapufe = CarrilR And i.Obs_Secuencia = Secuencia
                        Select i.idTarifa).Count()

            Return cantidad

        Else
            cantidad = (From i In ctx.Transacciones
                        Where i.Fecha = FechaR And (i.Hora > HoraA And i.Hora < HoraC) And i.NoPlaza = idPlazaR And i.idTurno = idTurnoR And i.NoCarrilCapufe = CarrilR And i.Obs_Secuencia = Secuencia
                        Select i.idTarifa).Count()

            Return cantidad

        End If

    End Function
    '*
    Private Function SumarPaso(idBolsa As Integer, Paso As String) As Double

        Dim ctx As New CLRDataContext()
        Dim HoraA As TimeSpan
        Dim HoraC As TimeSpan
        Dim importe

        HoraA = ConsultarHoraInicio(idBolsa)
        HoraC = ConsultarHoraFinal(idBolsa)

        If idTurnoR = 1 Then
            importe = (From i In ctx.Transacciones
                       Where ((i.Fecha = FechaR.AddDays(-1) And i.Hora >= HoraA) Or (i.Fecha = FechaR And i.Hora <= HoraC)) And i.NoPlaza = idPlazaR And i.idTurno = idTurnoR And i.NoCarrilCapufe = CarrilR And i.Obs_Paso = Paso
                       Select i.idTarifa).Sum()

            If importe Is Nothing OrElse importe.ToString() = String.Empty Then
                Return 0
            Else
                Return importe
            End If
        Else
            importe = (From i In ctx.Transacciones
                       Where i.Fecha = FechaR And (i.Hora >= HoraA And i.Hora <= HoraC) And i.NoPlaza = idPlazaR And i.idTurno = idTurnoR And i.NoCarrilCapufe = CarrilR And i.Obs_Paso = Paso
                       Select i.idTarifa).Sum()

            If importe Is Nothing OrElse importe.ToString() = String.Empty Then
                Return 0
            Else
                Return importe
            End If

        End If

    End Function
    '*
    Private Function ContarPaso(idBolsa As Integer, Paso As String) As Integer

        Dim ctx As New CLRDataContext()
        Dim HoraA As TimeSpan
        Dim HoraC As TimeSpan
        Dim cantidad

        HoraA = ConsultarHoraInicio(idBolsa)
        HoraC = ConsultarHoraFinal(idBolsa)

        If idTurnoR = 1 Then
            cantidad = (From i In ctx.Transacciones
                        Where ((i.Fecha = FechaR.AddDays(-1) And i.Hora > HoraA) Or (i.Fecha = FechaR And i.Hora < HoraC)) And i.NoPlaza = idPlazaR And i.idTurno = idTurnoR And i.NoCarrilCapufe = CarrilR And i.Obs_Paso = Paso
                        Select i.idTarifa).Count()

            Return cantidad

        Else
            cantidad = (From i In ctx.Transacciones
                        Where i.Fecha = FechaR And (i.Hora > HoraA And i.Hora < HoraC) And i.NoPlaza = idPlazaR And i.idTurno = idTurnoR And i.NoCarrilCapufe = CarrilR And i.Obs_Paso = Paso
                        Select i.idTarifa).Count()

            Return cantidad

        End If

    End Function

    Private Function ContarBoletos(idBolsa As Integer) As Integer

        Dim ctx As New CLRDataContext()

        Dim cantidad = (From c In ctx.Declaraciones
                        Where c.NoDeclaracion = idBolsa
                        Select c.Boletos).SingleOrDefault()

        Return cantidad

    End Function

    Private Function ObtenerEntregado(idBolsa As Integer) As Double

        Dim ctx As New CLRDataContext()

        Dim importe = (From i In ctx.Declaraciones
                       Where i.Fecha = FechaR And i.NoCarrilCapufe = CarrilR And i.idTurno = idTurnoR And i.NoDeclaracion = idBolsa
                       Select i.ImporteMN).SingleOrDefault()

        Dim importe2 = (From i In ctx.Declaraciones
                        Where i.Fecha = FechaR And i.NoCarrilCapufe = CarrilR And i.idTurno = idTurnoR And i.NoDeclaracion = idBolsa
                        Select i.ImporteDiferencia).SingleOrDefault()

        Return importe + importe2

    End Function

    '***** Turno/Carriles

    '*** Final

    Private Function SumarMarcadoTurno(ForPago As Integer) As Double

        Dim ctx As New CLRDataContext()
        Dim HoraA As New TimeSpan(20, 0, 0)
        Dim HoraC As New TimeSpan(8, 0, 0)
        Dim importe

        If idTurnoR = 1 Then
            importe = (From i In ctx.Transacciones
                       Where ((i.Fecha = FechaR.AddDays(-1) And i.Hora >= HoraA) Or (i.Fecha = FechaR And i.Hora <= HoraC)) And (i.NoPlaza = IdPlazaUno Or i.NoPlaza = IdPlazaDos) And i.idTurno = idTurnoR And i.idPago = ForPago
                       Select i.idTarifa).Sum()

            If importe Is Nothing OrElse importe.ToString() = String.Empty Then
                Return 0
            Else
                Return importe
            End If
        Else
            importe = (From i In ctx.Transacciones
                       Where i.Fecha = FechaR And (i.NoPlaza = IdPlazaUno Or i.NoPlaza = IdPlazaDos) And i.idTurno = idTurnoR And i.idPago = ForPago
                       Select i.idTarifa).Sum()

            If importe Is Nothing OrElse importe.ToString() = String.Empty Then
                Return 0
            Else
                Return importe
            End If
        End If

    End Function

    Private Function ContarMarcadoTurno(ForPago As Integer) As Integer

        Dim ctx As New CLRDataContext()
        Dim HoraA As New TimeSpan(20, 0, 0)
        Dim HoraC As New TimeSpan(8, 0, 0)
        Dim cantidad

        If idTurnoR = 1 Then
            cantidad = (From i In ctx.Transacciones
                        Where ((i.Fecha = FechaR.AddDays(-1) And i.Hora >= HoraA) Or (i.Fecha = FechaR And i.Hora <= HoraC)) And (i.NoPlaza = IdPlazaUno Or i.NoPlaza = IdPlazaDos) And i.idTurno = idTurnoR And i.Capturado <> True And i.idPago = ForPago
                        Select i.idTarifa).Count()

            Return cantidad

        Else
            cantidad = (From i In ctx.Transacciones
                        Where i.Fecha = FechaR And (i.NoPlaza = IdPlazaUno Or i.NoPlaza = IdPlazaDos) And i.idTurno = idTurnoR And i.Capturado <> True And i.idPago = ForPago
                        Select i.idTarifa).Count()

            Return cantidad

        End If

    End Function

    Private Function SumarVerificadoTurno(ForPago As Integer) As Double

        Dim ctx As New CLRDataContext()
        Dim HoraA As New TimeSpan(20, 0, 0)
        Dim HoraC As New TimeSpan(8, 0, 0)
        Dim importe

        If idTurnoR = 1 Then
            importe = (From i In ctx.Transacciones
                       Join d In ctx.Dictaminaciones
                               On i.idDictaminacion Equals d.idDictaminacion
                       Where ((i.Fecha = FechaR.AddDays(-1) And i.Hora >= HoraA) Or (i.Fecha = FechaR And i.Hora <= HoraC)) And (i.NoPlaza = IdPlazaUno Or i.NoPlaza = IdPlazaDos) And i.idTurno = idTurnoR And d.idPago = ForPago And i.Anulado = False
                       Select d.NuevaTarifa).Sum()

            If importe Is Nothing OrElse importe.ToString() = String.Empty Then
                Return 0
            Else
                Return importe
            End If
        Else
            importe = (From i In ctx.Transacciones
                       Join d In ctx.Dictaminaciones
                               On i.idDictaminacion Equals d.idDictaminacion
                       Where i.Fecha = FechaR And (i.NoPlaza = IdPlazaUno Or i.NoPlaza = IdPlazaDos) And i.idTurno = idTurnoR And d.idPago = ForPago And i.Anulado = False
                       Select d.NuevaTarifa).Sum()

            If importe Is Nothing OrElse importe.ToString() = String.Empty Then
                Return 0
            Else
                Return importe
            End If
        End If

    End Function

    Private Function ContarVerificadoTurno(ForPago As Integer) As Integer

        Dim ctx As New CLRDataContext()
        Dim HoraA As New TimeSpan(20, 0, 0)
        Dim HoraC As New TimeSpan(8, 0, 0)
        Dim cantidad

        If idTurnoR = 1 Then
            cantidad = (From i In ctx.Transacciones
                        Join d In ctx.Dictaminaciones
                                On i.idDictaminacion Equals d.idDictaminacion
                        Where ((i.Fecha = FechaR.AddDays(-1) And i.Hora >= HoraA) Or (i.Fecha = FechaR And i.Hora <= HoraC)) And (i.NoPlaza = IdPlazaUno Or i.NoPlaza = IdPlazaDos) And i.idTurno = idTurnoR And d.idPago = ForPago And i.Anulado = False
                        Select d.NuevaTarifa).Count()

            Return cantidad

        Else
            cantidad = (From i In ctx.Transacciones
                        Join d In ctx.Dictaminaciones
                               On i.idDictaminacion Equals d.idDictaminacion
                        Where i.Fecha = FechaR And (i.NoPlaza = IdPlazaUno Or i.NoPlaza = IdPlazaDos) And i.idTurno = idTurnoR And d.idPago = ForPago And i.Anulado = False
                        Select d.NuevaTarifa).Count()
            Return cantidad

        End If

    End Function

    Private Function SumarSecuenciasTurno(Secuencia As String) As Double

        Dim ctx As New CLRDataContext()
        Dim HoraA As New TimeSpan(20, 0, 0)
        Dim HoraC As New TimeSpan(8, 0, 0)
        Dim importe

        If idTurnoR = 1 Then
            importe = (From i In ctx.Transacciones
                       Where ((i.Fecha = FechaR.AddDays(-1) And i.Hora > HoraA) Or (i.Fecha = FechaR And i.Hora < HoraC)) And (i.NoPlaza = IdPlazaUno Or i.NoPlaza = IdPlazaDos) And i.idTurno = idTurnoR And i.Obs_Secuencia = Secuencia
                       Select i.idTarifa).Sum()

            If importe Is Nothing OrElse importe.ToString() = String.Empty Then
                Return 0
            Else
                Return importe
            End If
        Else
            importe = (From i In ctx.Transacciones
                       Where i.Fecha = FechaR And (i.NoPlaza = IdPlazaUno Or i.NoPlaza = IdPlazaDos) And i.idTurno = idTurnoR And i.Obs_Secuencia = Secuencia
                       Select i.idTarifa).Sum()

            If importe Is Nothing OrElse importe.ToString() = String.Empty Then
                Return 0
            Else
                Return importe
            End If

        End If

    End Function

    Private Function ContarSecuenciasTurno(Secuencia As String) As Integer

        Dim ctx As New CLRDataContext()
        Dim HoraA As New TimeSpan(20, 0, 0)
        Dim HoraC As New TimeSpan(8, 0, 0)
        Dim cantidad

        If idTurnoR = 1 Then
            cantidad = (From i In ctx.Transacciones
                        Where ((i.Fecha = FechaR.AddDays(-1) And i.Hora > HoraA) Or (i.Fecha = FechaR And i.Hora < HoraC)) And (i.NoPlaza = IdPlazaUno Or i.NoPlaza = IdPlazaDos) And i.idTurno = idTurnoR And i.Obs_Secuencia = Secuencia
                        Select i.idTarifa).Count()

            Return cantidad

        Else
            cantidad = (From i In ctx.Transacciones
                        Where i.Fecha = FechaR And (i.NoPlaza = IdPlazaUno Or i.NoPlaza = IdPlazaDos) And i.idTurno = idTurnoR And i.Obs_Secuencia = Secuencia
                        Select i.idTarifa).Count()

            Return cantidad

        End If

    End Function

    Private Function SumarPasoTurno(Paso As String) As Double

        Dim ctx As New CLRDataContext()
        Dim HoraA As New TimeSpan(20, 0, 0)
        Dim HoraC As New TimeSpan(8, 0, 0)
        Dim importe

        If idTurnoR = 1 Then
            importe = (From i In ctx.Transacciones
                       Where ((i.Fecha = FechaR.AddDays(-1) And i.Hora >= HoraA) Or (i.Fecha = FechaR And i.Hora <= HoraC)) And (i.NoPlaza = IdPlazaUno Or i.NoPlaza = IdPlazaDos) And i.idTurno = idTurnoR And i.Obs_Paso = Paso
                       Select i.idTarifa).Sum()

            If importe Is Nothing OrElse importe.ToString() = String.Empty Then
                Return 0
            Else
                Return importe
            End If
        Else
            importe = (From i In ctx.Transacciones
                       Where i.Fecha = FechaR And (i.NoPlaza = IdPlazaUno Or i.NoPlaza = IdPlazaDos) And i.idTurno = idTurnoR And i.Obs_Paso = Paso
                       Select i.idTarifa).Sum()

            If importe Is Nothing OrElse importe.ToString() = String.Empty Then
                Return 0
            Else
                Return importe
            End If

        End If

    End Function

    Private Function ContarPasoTurno(Paso As String) As Integer

        Dim ctx As New CLRDataContext()
        Dim HoraA As New TimeSpan(20, 0, 0)
        Dim HoraC As New TimeSpan(8, 0, 0)
        Dim cantidad

        If idTurnoR = 1 Then
            cantidad = (From i In ctx.Transacciones
                        Where ((i.Fecha = FechaR.AddDays(-1) And i.Hora > HoraA) Or (i.Fecha = FechaR And i.Hora < HoraC)) And (i.NoPlaza = IdPlazaUno Or i.NoPlaza = IdPlazaDos) And i.idTurno = idTurnoR And i.Obs_Paso = Paso
                        Select i.idTarifa).Count()

            Return cantidad

        Else
            cantidad = (From i In ctx.Transacciones
                        Where i.Fecha = FechaR And (i.NoPlaza = IdPlazaUno Or i.NoPlaza = IdPlazaDos) And i.idTurno = idTurnoR And i.Obs_Paso = Paso
                        Select i.idTarifa).Count()

            Return cantidad

        End If

    End Function

    Private Function ContarBoletosTurno() As Integer

        Dim cantidad As Integer
        ListarBolsas()

        For i As Integer = 0 To ListaBolsas.Count() - 1
            cantidad += ContarBoletos(ListaBolsas.Item(i))
        Next

        Return cantidad

    End Function

    Private Function ObtenerEntregadoTurno(Turno As Integer) As Double

        Dim ctx As New CLRDataContext()
        Dim importe
        Dim importe2

        Try
            importe = (From i In ctx.Declaraciones
                       Where i.Fecha = FechaR And i.idTurno = idTurnoR
                       Select i.ImporteMN).Sum()

        Catch ex As SqlClient.SqlException
            importe = 0
        End Try

        Try
            importe2 = (From i In ctx.Declaraciones
                        Where i.Fecha = FechaR And i.idTurno = idTurnoR
                        Select i.ImporteDiferencia).Sum()

        Catch ex As SqlClient.SqlException
            importe2 = 0
        End Try

        Return importe + importe2

    End Function

    '************************ Termina Final

    '***** Día/Caseta

    '*********** Final
    Private Function SumarMarcadoDia(ForPago As Integer) As Double

        Dim ctx As New CLRDataContext()
        Dim HoraA As New TimeSpan(20, 0, 0)
        Dim HoraC As New TimeSpan(8, 0, 0)
        Dim Importe1y2
        Dim Importe3

        Try
            Importe1y2 = (From i In ctx.Transacciones
                          Where i.Fecha = FechaR And (i.NoPlaza = IdPlazaUno Or i.NoPlaza = IdPlazaDos) And (i.idTurno = 2 Or i.idTurno = 3) And i.idPago = ForPago
                          Select i.idTarifa).Sum()
        Catch ex As SqlClient.SqlException
            Importe1y2 = 0
        End Try

        Try
            Importe3 = (From i In ctx.Transacciones
                        Where ((i.Fecha = FechaR.AddDays(-1) And i.Hora > HoraA) Or (i.Fecha = FechaR And i.Hora < HoraC)) And (i.NoPlaza = IdPlazaUno Or i.NoPlaza = IdPlazaDos) And i.idTurno = 1 And i.idPago = ForPago
                        Select i.idTarifa).Sum()
        Catch ex As SqlClient.SqlException
            Importe3 = 0
        End Try

        Return Importe1y2 + Importe3

    End Function

    Private Function ContarMarcadoDia(ForPago As Integer) As Integer

        Try

            Dim ctx As New CLRDataContext()
            Dim HoraA As New TimeSpan(20, 0, 0)
            Dim HoraC As New TimeSpan(8, 0, 0)
            Dim Cantidad1y2
            Dim Cantidad3

            Cantidad1y2 = (From i In ctx.Transacciones
                           Where i.Fecha = FechaR And (i.NoPlaza = IdPlazaUno Or i.NoPlaza = IdPlazaDos) And (i.idTurno = 2 Or i.idTurno = 3) And i.Capturado <> True And i.idPago = ForPago
                           Select i.idTarifa).Count()

            Cantidad3 = (From i In ctx.Transacciones
                         Where ((i.Fecha = FechaR.AddDays(-1) And i.Hora > HoraA) Or (i.Fecha = FechaR And i.Hora < HoraC)) And (i.NoPlaza = IdPlazaUno Or i.NoPlaza = IdPlazaDos) And i.idTurno = 1 And i.Capturado <> True And i.idPago = ForPago
                         Select i.idTarifa).Count()

            Return Cantidad1y2 + Cantidad3

        Catch ex As Exception
            RadMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, RadMessageIcon.Error)
        End Try

    End Function

    Private Function SumarVerificadoDia(ForPago As Integer) As Double

        Dim ctx As New CLRDataContext()
        Dim HoraA As New TimeSpan(20, 0, 0)
        Dim HoraC As New TimeSpan(8, 0, 0)
        Dim Importe1y2
        Dim Importe3

        Try
            Importe1y2 = (From i In ctx.Transacciones
                          Join d In ctx.Dictaminaciones
                                  On i.idDictaminacion Equals d.idDictaminacion
                          Where i.Fecha = FechaR And (i.NoPlaza = IdPlazaUno Or i.NoPlaza = IdPlazaDos) And (i.idTurno = 2 Or i.idTurno = 3) And d.idPago = ForPago And i.Anulado = False
                          Select i.idTarifa).Sum()
        Catch ex As SqlClient.SqlException
            Importe1y2 = 0
        End Try

        Try
            Importe3 = (From i In ctx.Transacciones
                        Join d In ctx.Dictaminaciones
                                  On i.idDictaminacion Equals d.idDictaminacion
                        Where ((i.Fecha = FechaR.AddDays(-1) And i.Hora > HoraA) Or (i.Fecha = FechaR And i.Hora < HoraC)) And (i.NoPlaza = IdPlazaUno Or i.NoPlaza = IdPlazaDos) And i.idTurno = 1 And d.idPago = ForPago And i.Anulado = False
                        Select i.idTarifa).Sum()
        Catch ex As SqlClient.SqlException
            Importe3 = 0
        End Try

        Return Importe1y2 + Importe3

    End Function

    Private Function ContarVerificadoDia(ForPago As Integer) As Integer

        Try

            Dim ctx As New CLRDataContext()
            Dim HoraA As New TimeSpan(20, 0, 0)
            Dim HoraC As New TimeSpan(8, 0, 0)
            Dim Cantidad1y2
            Dim Cantidad3

            Cantidad1y2 = (From i In ctx.Transacciones
                           Join d In ctx.Dictaminaciones
                                  On i.idDictaminacion Equals d.idDictaminacion
                           Where i.Fecha = FechaR And (i.NoPlaza = IdPlazaUno Or i.NoPlaza = IdPlazaDos) And (i.idTurno = 2 Or i.idTurno = 3) And d.idPago = ForPago And i.Anulado = False
                           Select i.idTarifa).Count()

            Cantidad3 = (From i In ctx.Transacciones
                         Join d In ctx.Dictaminaciones
                                  On i.idDictaminacion Equals d.idDictaminacion
                         Where ((i.Fecha = FechaR.AddDays(-1) And i.Hora > HoraA) Or (i.Fecha = FechaR And i.Hora < HoraC)) And (i.NoPlaza = IdPlazaUno Or i.NoPlaza = IdPlazaDos) And i.idTurno = 1 And d.idPago = ForPago And i.Anulado = False
                         Select i.idTarifa).Count()

            Return Cantidad1y2 + Cantidad3

        Catch ex As Exception
            RadMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, RadMessageIcon.Error)
        End Try

    End Function

    Private Function SumarSecuenciasDia(Secuencia As String) As Double

        Dim ctx As New CLRDataContext()
        Dim HoraA As New TimeSpan(20, 0, 0)
        Dim HoraC As New TimeSpan(8, 0, 0)
        Dim Importe1y2
        Dim Importe3

        Try
            Importe1y2 = (From i In ctx.Transacciones
                          Where i.Fecha = FechaR And (i.NoPlaza = IdPlazaUno Or i.NoPlaza = IdPlazaDos) And (i.idTurno = 2 Or i.idTurno = 3) And i.Obs_Secuencia = Secuencia
                          Select i.idTarifa).Sum()
        Catch ex As SqlClient.SqlException
            Importe1y2 = 0
        End Try

        Try
            Importe3 = (From i In ctx.Transacciones
                        Where ((i.Fecha = FechaR.AddDays(-1) And i.Hora > HoraA) Or (i.Fecha = FechaR And i.Hora < HoraC)) And (i.NoPlaza = IdPlazaUno Or i.NoPlaza = IdPlazaDos) And i.idTurno = 1 And i.Obs_Secuencia = Secuencia
                        Select i.idTarifa).Sum()
        Catch ex As SqlClient.SqlException
            Importe3 = 0
        End Try

        Return Importe1y2 + Importe3

    End Function

    Private Function ContarSecuenciasDia(Secuencia As String) As Integer

        Try

            Dim ctx As New CLRDataContext()
            Dim HoraA As New TimeSpan(20, 0, 0)
            Dim HoraC As New TimeSpan(8, 0, 0)
            Dim Cantidad1y2
            Dim Cantidad3

            Cantidad1y2 = (From i In ctx.Transacciones
                           Where i.Fecha = FechaR And (i.NoPlaza = IdPlazaUno Or i.NoPlaza = IdPlazaDos) And (i.idTurno = 2 Or i.idTurno = 3) And i.Obs_Secuencia = Secuencia
                           Select i.idTarifa).Count()

            Cantidad3 = (From i In ctx.Transacciones
                         Where ((i.Fecha = FechaR.AddDays(-1) And i.Hora > HoraA) Or (i.Fecha = FechaR And i.Hora < HoraC)) And (i.NoPlaza = IdPlazaUno Or i.NoPlaza = IdPlazaDos) And i.idTurno = 1 And i.Obs_Secuencia = Secuencia
                         Select i.idTarifa).Count()

            Return Cantidad1y2 + Cantidad3

        Catch ex As Exception
            RadMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, RadMessageIcon.Error)
        End Try

    End Function

    Private Function SumarPasoDia(Paso As String) As Double

        Dim ctx As New CLRDataContext()
        Dim HoraA As New TimeSpan(20, 0, 0)
        Dim HoraC As New TimeSpan(8, 0, 0)
        Dim Importe1y2
        Dim Importe3

        Try
            Importe1y2 = (From i In ctx.Transacciones
                          Where i.Fecha = FechaR And (i.NoPlaza = IdPlazaUno Or i.NoPlaza = IdPlazaDos) And (i.idTurno = 2 Or i.idTurno = 3) And i.Obs_Paso = Paso
                          Select i.idTarifa).Sum()
        Catch ex As SqlClient.SqlException
            Importe1y2 = 0
        End Try

        Try
            Importe3 = (From i In ctx.Transacciones
                        Where ((i.Fecha = FechaR.AddDays(-1) And i.Hora > HoraA) Or (i.Fecha = FechaR And i.Hora < HoraC)) And (i.NoPlaza = IdPlazaUno Or i.NoPlaza = IdPlazaDos) And i.idTurno = 1 And i.Obs_Paso = Paso
                        Select i.idTarifa).Sum()
        Catch ex As SqlClient.SqlException
            Importe3 = 0
        End Try

        Return Importe1y2 + Importe3

    End Function

    Private Function ContarPasoDia(Paso As String) As Double

        Try

            Dim ctx As New CLRDataContext()
            Dim HoraA As New TimeSpan(20, 0, 0)
            Dim HoraC As New TimeSpan(8, 0, 0)
            Dim Cantidad1y2
            Dim Cantidad3

            Cantidad1y2 = (From i In ctx.Transacciones
                           Where i.Fecha = FechaR And (i.NoPlaza = IdPlazaUno Or i.NoPlaza = IdPlazaDos) And (i.idTurno = 2 Or i.idTurno = 3) And i.Obs_Paso = Paso
                           Select i.idTarifa).Count()

            Cantidad3 = (From i In ctx.Transacciones
                         Where ((i.Fecha = FechaR.AddDays(-1) And i.Hora > HoraA) Or (i.Fecha = FechaR And i.Hora < HoraC)) And (i.NoPlaza = IdPlazaUno Or i.NoPlaza = IdPlazaDos) And i.idTurno = 1 And i.Obs_Paso = Paso
                         Select i.idTarifa).Count()

            Return Cantidad1y2 + Cantidad3

        Catch ex As Exception
            RadMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, RadMessageIcon.Error)
        End Try

    End Function

    Private Function ContarBoletosDia() As Integer

        Dim ctx As New CLRDataContext()
        Dim cantidad

        Try
            cantidad = (From c In ctx.Declaraciones
                        Where c.Fecha = FechaR And (c.NoPlaza = IdPlazaUno Or c.NoPlaza = IdPlazaDos)
                        Select c.Boletos).Sum()

        Catch ex As SqlClient.SqlException
            cantidad = 0
        End Try

        Return cantidad

    End Function

    '*********** Termina Final

    '************************************ COMPARATIVOS ***********************************

    Private Function ConsultarTarifas(Plaza As Integer, Vehiculo As Integer) As Double

        Try
            Dim ctx As New CLRDataContext()

            Dim tarif = (From t In ctx.Tarifas
                         Where t.NoPlaza = Plaza And t.idVehiculo = Vehiculo
                         Select t.Tarifa).SingleOrDefault()

            Return tarif
        Catch ex As Exception
            RadMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, RadMessageIcon.Error)
        End Try

    End Function

    Private Function ContarVehiculos(idBolsa As Integer, TipoAuto As Integer, TipoPago As Integer) As Integer

        Dim ctx As New CLRDataContext()
        Dim HoraA As TimeSpan
        Dim HoraC As TimeSpan
        Dim total

        HoraA = ConsultarHoraInicio(idBolsa)
        HoraC = ConsultarHoraFinal(idBolsa)

        If idTurnoR = 1 Then
            If TipoAuto = 9 Then
                total = (From t In ctx.Transacciones
                         Join d In ctx.Dictaminaciones
                                 On t.idDictaminacion Equals d.idDictaminacion
                         Where ((t.Fecha = FechaR.AddDays(-1) And t.Hora >= HoraA) Or (t.Fecha = FechaR And t.Hora <= HoraC)) And t.NoPlaza = idPlazaR And t.idTurno = idTurnoR And t.NoCarrilCapufe = CarrilR And (d.idVehiculo = TipoAuto Or d.idVehiculo = 16) And d.idPago = TipoPago And t.Anulado = False
                         Select t.NoEvento).Count()
            Else
                total = (From t In ctx.Transacciones
                         Join d In ctx.Dictaminaciones
                                 On t.idDictaminacion Equals d.idDictaminacion
                         Where ((t.Fecha = FechaR.AddDays(-1) And t.Hora >= HoraA) Or (t.Fecha = FechaR And t.Hora <= HoraC)) And t.NoPlaza = idPlazaR And t.idTurno = idTurnoR And t.NoCarrilCapufe = CarrilR And d.idVehiculo = TipoAuto And d.idPago = TipoPago And t.Anulado = False
                         Select t.NoEvento).Count()
            End If
        Else
            If TipoAuto = 9 Then
                total = (From t In ctx.Transacciones
                         Join d In ctx.Dictaminaciones
                                 On t.idDictaminacion Equals d.idDictaminacion
                         Where t.Fecha = FechaR And (t.Hora >= HoraA And t.Hora <= HoraC) And t.NoPlaza = idPlazaR And t.idTurno = idTurnoR And t.NoCarrilCapufe = CarrilR And (d.idVehiculo = TipoAuto Or d.idVehiculo = 16) And d.idPago = TipoPago And t.Anulado = False
                         Select t.NoEvento).Count()
            Else
                total = (From t In ctx.Transacciones
                         Join d In ctx.Dictaminaciones
                                 On t.idDictaminacion Equals d.idDictaminacion
                         Where t.Fecha = FechaR And (t.Hora >= HoraA And t.Hora <= HoraC) And t.NoPlaza = idPlazaR And t.idTurno = idTurnoR And t.NoCarrilCapufe = CarrilR And d.idVehiculo = TipoAuto And d.idPago = TipoPago And t.Anulado = False
                         Select t.NoEvento).Count()
            End If
        End If

        Return total

    End Function

    Private Function ContarNormales(idBolsa As Integer, TipoPago As Integer) As Integer

        Dim ctx As New CLRDataContext()
        Dim HoraA As TimeSpan
        Dim HoraC As TimeSpan
        Dim total

        HoraA = ConsultarHoraInicio(idBolsa)
        HoraC = ConsultarHoraFinal(idBolsa)

        If idTurnoR = 1 Then
            total = (From t In ctx.Transacciones
                     Join d In ctx.Dictaminaciones
                             On t.idDictaminacion Equals d.idDictaminacion
                     Where ((t.Fecha = FechaR.AddDays(-1) And t.Hora >= HoraA) Or (t.Fecha = FechaR And t.Hora <= HoraC)) And t.NoPlaza = idPlazaR And t.idTurno = idTurnoR And t.NoCarrilCapufe = CarrilR And (d.idVehiculo = 1 Or d.idVehiculo = 10 Or d.idVehiculo = 11 Or d.idVehiculo = 17) And d.idPago = TipoPago And t.Anulado = False
                     Select t.NoEvento).Count()
        Else
            total = (From t In ctx.Transacciones
                     Join d In ctx.Dictaminaciones
                             On t.idDictaminacion Equals d.idDictaminacion
                     Where t.Fecha = FechaR And (t.Hora >= HoraA And t.Hora <= HoraC) And t.NoPlaza = idPlazaR And t.idTurno = idTurnoR And t.NoCarrilCapufe = CarrilR And (d.idVehiculo = 1 Or d.idVehiculo = 10 Or d.idVehiculo = 11 Or d.idVehiculo = 17) And d.idPago = TipoPago And t.Anulado = False
                     Select t.NoEvento).Count()
        End If

        Return total

    End Function

    Private Function ContarEjes(idBolsa As Integer, TipoAuto As Integer, TipoPago As Integer) As Integer

        Dim ctx As New CLRDataContext()
        Dim HoraA As TimeSpan
        Dim HoraC As TimeSpan
        Dim total

        HoraA = ConsultarHoraInicio(idBolsa)
        HoraC = ConsultarHoraFinal(idBolsa)

        If idTurnoR = 1 Then
            total = (From t In ctx.Transacciones
                     Join d In ctx.Dictaminaciones
                             On t.idDictaminacion Equals d.idDictaminacion
                     Where ((t.Fecha = FechaR.AddDays(-1) And t.Hora >= HoraA) Or (t.Fecha = FechaR And t.Hora <= HoraC)) And t.NoPlaza = idPlazaR And t.idTurno = idTurnoR And t.NoCarrilCapufe = CarrilR And d.idVehiculo = TipoAuto And d.idPago = TipoPago And t.Anulado = False
                     Select t.Num_Ejes).SingleOrDefault()
        Else
            total = (From t In ctx.Transacciones
                     Join d In ctx.Dictaminaciones
                             On t.idDictaminacion Equals d.idDictaminacion
                     Where t.Fecha = FechaR And (t.Hora >= HoraA And t.Hora <= HoraC) And t.NoPlaza = idPlazaR And t.idTurno = idTurnoR And t.NoCarrilCapufe = CarrilR And d.idVehiculo = TipoAuto And d.idPago = TipoPago And t.Anulado = False
                     Select t.Num_Ejes).SingleOrDefault()
        End If

        Return total

    End Function

    Private Function SumarEjes(idBolsa As Integer, TipoAuto As Integer, TipoPago As Integer) As Integer

        Dim ctx As New CLRDataContext()
        Dim HoraA As TimeSpan
        Dim HoraC As TimeSpan
        Dim total

        HoraA = ConsultarHoraInicio(idBolsa)
        HoraC = ConsultarHoraFinal(idBolsa)

        If idTurnoR = 1 Then
            Try
                total = (From t In ctx.Transacciones
                         Join d In ctx.Dictaminaciones
                             On t.idDictaminacion Equals d.idDictaminacion
                         Where ((t.Fecha = FechaR.AddDays(-1) And t.Hora >= HoraA) Or (t.Fecha = FechaR And t.Hora <= HoraC)) And t.NoPlaza = idPlazaR And t.idTurno = idTurnoR And t.NoCarrilCapufe = CarrilR And d.idVehiculo = TipoAuto And d.idPago = TipoPago And t.Anulado = False
                         Select t.Num_Ejes).Sum()
            Catch ex As SqlClient.SqlException
                total = 0
            End Try

        Else
            Try
                total = (From t In ctx.Transacciones
                         Join d In ctx.Dictaminaciones
                                 On t.idDictaminacion Equals d.idDictaminacion
                         Where t.Fecha = FechaR And (t.Hora >= HoraA And t.Hora <= HoraC) And t.NoPlaza = idPlazaR And t.idTurno = idTurnoR And t.NoCarrilCapufe = CarrilR And d.idVehiculo = TipoAuto And d.idPago = TipoPago And t.Anulado = False
                         Select t.Num_Ejes).Sum()
            Catch ex As SqlClient.SqlException
                total = 0
            End Try
        End If

        Return total

    End Function

    Private Function ContarSecuenciasTV(idBolsa As Integer, Secuencia As String, TipoAuto As Integer) As Integer

        Dim ctx As New CLRDataContext()
        Dim HoraA As TimeSpan
        Dim HoraC As TimeSpan
        Dim total

        HoraA = ConsultarHoraInicio(idBolsa)
        HoraC = ConsultarHoraFinal(idBolsa)

        If idTurnoR = 1 Then
            total = (From t In ctx.Transacciones
                     Join d In ctx.Dictaminaciones
                             On t.idDictaminacion Equals d.idDictaminacion
                     Where ((t.Fecha = FechaR.AddDays(-1) And t.Hora >= HoraA) Or (t.Fecha = FechaR And t.Hora <= HoraC)) And t.NoPlaza = idPlazaR And t.idTurno = idTurnoR And t.NoCarrilCapufe = CarrilR And d.idVehiculo = TipoAuto And t.Obs_Secuencia = Secuencia And t.Anulado = False
                     Select t.NoEvento).Count()
        Else
            total = (From t In ctx.Transacciones
                     Join d In ctx.Dictaminaciones
                             On t.idDictaminacion Equals d.idDictaminacion
                     Where t.Fecha = FechaR And (t.Hora >= HoraA And t.Hora <= HoraC) And t.NoPlaza = idPlazaR And t.idTurno = idTurnoR And t.NoCarrilCapufe = CarrilR And d.idVehiculo = TipoAuto And t.Obs_Secuencia = Secuencia And t.Anulado = False
                     Select t.NoEvento).Count()
        End If

        Return total

    End Function

    '***** Tuno/Carriles

    '****** Final
    Private Function ContarVehiculosTurnoC(TipoAuto As Integer, TipoPago As Integer) As Integer

        Dim ctx As New CLRDataContext()
        Dim HoraA As New TimeSpan(20, 0, 0)
        Dim HoraC As New TimeSpan(8, 0, 0)
        Dim total

        If idTurnoR = 1 Then
            If TipoAuto = 9 Then
                total = (From t In ctx.Transacciones
                         Join d In ctx.Dictaminaciones
                                 On t.idDictaminacion Equals d.idDictaminacion
                         Where ((t.Fecha = FechaR.AddDays(-1) And t.Hora >= HoraA) Or (t.Fecha = FechaR And t.Hora <= HoraC)) And (t.NoPlaza = IdPlazaUno Or t.NoPlaza = IdPlazaDos) And t.idTurno = idTurnoR And (d.idVehiculo = TipoAuto Or d.idVehiculo = 16) And d.idPago = TipoPago And t.Anulado = False
                         Select t.NoEvento).Count()
            Else
                total = (From t In ctx.Transacciones
                         Join d In ctx.Dictaminaciones
                                 On t.idDictaminacion Equals d.idDictaminacion
                         Where ((t.Fecha = FechaR.AddDays(-1) And t.Hora >= HoraA) Or (t.Fecha = FechaR And t.Hora <= HoraC)) And (t.NoPlaza = IdPlazaUno Or t.NoPlaza = IdPlazaDos) And t.idTurno = idTurnoR And d.idVehiculo = TipoAuto And d.idPago = TipoPago And t.Anulado = False
                         Select t.NoEvento).Count()
            End If
        Else
            If TipoAuto = 9 Then
                total = (From t In ctx.Transacciones
                         Join d In ctx.Dictaminaciones
                                 On t.idDictaminacion Equals d.idDictaminacion
                         Where t.Fecha = FechaR And (t.NoPlaza = IdPlazaUno Or t.NoPlaza = IdPlazaDos) And t.idTurno = idTurnoR And (d.idVehiculo = TipoAuto Or d.idVehiculo = 16) And d.idPago = TipoPago And t.Anulado = False
                         Select t.NoEvento).Count()
            Else
                total = (From t In ctx.Transacciones
                         Join d In ctx.Dictaminaciones
                                 On t.idDictaminacion Equals d.idDictaminacion
                         Where t.Fecha = FechaR And (t.NoPlaza = IdPlazaUno Or t.NoPlaza = IdPlazaDos) And t.idTurno = idTurnoR And d.idVehiculo = TipoAuto And d.idPago = TipoPago And t.Anulado = False
                         Select t.NoEvento).Count()
            End If
        End If

        Return total

    End Function

    Private Function ContarNormalesTurno(TipoPago As Integer) As Integer

        Dim ctx As New CLRDataContext()
        Dim HoraA As New TimeSpan(20, 0, 0)
        Dim HoraC As New TimeSpan(8, 0, 0)
        Dim total

        If idTurnoR = 1 Then
            total = (From t In ctx.Transacciones
                     Join d In ctx.Dictaminaciones
                             On t.idDictaminacion Equals d.idDictaminacion
                     Where ((t.Fecha = FechaR.AddDays(-1) And t.Hora >= HoraA) Or (t.Fecha = FechaR And t.Hora <= HoraC)) And (t.NoPlaza = IdPlazaUno Or t.NoPlaza = IdPlazaDos) And t.idTurno = idTurnoR And (d.idVehiculo = 1 Or d.idVehiculo = 10 Or d.idVehiculo = 11 Or d.idVehiculo = 17) And d.idPago = TipoPago And t.Anulado = False
                     Select t.NoEvento).Count()
        Else
            total = (From t In ctx.Transacciones
                     Join d In ctx.Dictaminaciones
                             On t.idDictaminacion Equals d.idDictaminacion
                     Where t.Fecha = FechaR And (t.NoPlaza = IdPlazaUno Or t.NoPlaza = IdPlazaDos) And t.idTurno = idTurnoR And (d.idVehiculo = 1 Or d.idVehiculo = 10 Or d.idVehiculo = 11 Or d.idVehiculo = 17) And d.idPago = TipoPago And t.Anulado = False
                     Select t.NoEvento).Count()
        End If

        Return total

    End Function

    Private Function SumarEjesTurno(TipoAuto As Integer, TipoPago As Integer) As Integer

        Dim ctx As New CLRDataContext()
        Dim HoraA As New TimeSpan(20, 0, 0)
        Dim HoraC As New TimeSpan(8, 0, 0)
        Dim total

        If idTurnoR = 1 Then
            Try
                total = (From t In ctx.Transacciones
                         Join d In ctx.Dictaminaciones
                             On t.idDictaminacion Equals d.idDictaminacion
                         Where ((t.Fecha = FechaR.AddDays(-1) And t.Hora > HoraA) Or (t.Fecha = FechaR And t.Hora < HoraC)) And (t.NoPlaza = IdPlazaUno Or t.NoPlaza = IdPlazaDos) And t.idTurno = idTurnoR And d.idVehiculo = TipoAuto And d.idPago = TipoPago And t.Anulado = False
                         Select t.Num_Ejes).Sum()
            Catch ex As SqlClient.SqlException
                total = 0
            End Try

        Else
            Try
                total = (From t In ctx.Transacciones
                         Join d In ctx.Dictaminaciones
                                 On t.idDictaminacion Equals d.idDictaminacion
                         Where t.Fecha = FechaR And (t.NoPlaza = IdPlazaUno Or t.NoPlaza = IdPlazaDos) And t.idTurno = idTurnoR And d.idVehiculo = TipoAuto And d.idPago = TipoPago And t.Anulado = False
                         Select t.Num_Ejes).Sum()
            Catch ex As SqlClient.SqlException
                total = 0
            End Try
        End If

        Return total

    End Function

    '********** Termina Final

    '***** Día/Caseta

    Private Function ContarVehiculosDia(TipoAuto As Integer, TipoPago As Integer) As Integer

        Try

            Dim ctx As New CLRDataContext()
            Dim HoraA As New TimeSpan(20, 0, 0)
            Dim HoraC As New TimeSpan(8, 0, 0)
            Dim Cantidad1y2
            Dim Cantidad3

            If TipoAuto = 9 Then
                Cantidad1y2 = (From i In ctx.Transacciones
                               Join d In ctx.Dictaminaciones
                                      On i.idDictaminacion Equals d.idDictaminacion
                               Where i.Fecha = FechaR And (i.NoPlaza = IdPlazaUno Or i.NoPlaza = IdPlazaDos) And (i.idTurno = 2 Or i.idTurno = 3) And (d.idVehiculo = TipoAuto Or d.idVehiculo = 16) And d.idPago = TipoPago And i.Anulado = False
                               Select i.idTarifa).Count()

                Cantidad3 = (From i In ctx.Transacciones
                             Join d In ctx.Dictaminaciones
                                      On i.idDictaminacion Equals d.idDictaminacion
                             Where ((i.Fecha = FechaR.AddDays(-1) And i.Hora > HoraA) Or (i.Fecha = FechaR And i.Hora < HoraC)) And (i.NoPlaza = IdPlazaUno Or i.NoPlaza = IdPlazaDos) And i.idTurno = 1 And (d.idVehiculo = TipoAuto Or d.idVehiculo = 16) And d.idPago = TipoPago And i.Anulado = False
                             Select i.idTarifa).Count()
            Else
                Cantidad1y2 = (From i In ctx.Transacciones
                               Join d In ctx.Dictaminaciones
                                      On i.idDictaminacion Equals d.idDictaminacion
                               Where i.Fecha = FechaR And (i.NoPlaza = IdPlazaUno Or i.NoPlaza = IdPlazaDos) And (i.idTurno = 2 Or i.idTurno = 3) And d.idVehiculo = TipoAuto And d.idPago = TipoPago And i.Anulado = False
                               Select i.idTarifa).Count()

                Cantidad3 = (From i In ctx.Transacciones
                             Join d In ctx.Dictaminaciones
                                      On i.idDictaminacion Equals d.idDictaminacion
                             Where ((i.Fecha = FechaR.AddDays(-1) And i.Hora > HoraA) Or (i.Fecha = FechaR And i.Hora < HoraC)) And (i.NoPlaza = IdPlazaUno Or i.NoPlaza = IdPlazaDos) And i.idTurno = 1 And d.idVehiculo = TipoAuto And d.idPago = TipoPago And i.Anulado = False
                             Select i.idTarifa).Count()
            End If

            Return Cantidad1y2 + Cantidad3

        Catch ex As Exception
            RadMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, RadMessageIcon.Error)
        End Try

    End Function

    Private Function ContarNormalesDia(TipoPago As Integer) As Integer

        Try

            Dim ctx As New CLRDataContext()
            Dim HoraA As New TimeSpan(20, 0, 0)
            Dim HoraC As New TimeSpan(8, 0, 0)
            Dim Cantidad1y2
            Dim Cantidad3

            Cantidad1y2 = (From i In ctx.Transacciones
                           Join d In ctx.Dictaminaciones
                                  On i.idDictaminacion Equals d.idDictaminacion
                           Where i.Fecha = FechaR And (i.NoPlaza = IdPlazaUno Or i.NoPlaza = IdPlazaDos) And (i.idTurno = 2 Or i.idTurno = 3) And (d.idVehiculo = 1 Or d.idVehiculo = 10 Or d.idVehiculo = 11 Or d.idVehiculo = 17) And d.idPago = TipoPago And i.Anulado = False
                           Select i.idTarifa).Count()

            Cantidad3 = (From i In ctx.Transacciones
                         Join d In ctx.Dictaminaciones
                                  On i.idDictaminacion Equals d.idDictaminacion
                         Where ((i.Fecha = FechaR.AddDays(-1) And i.Hora > HoraA) Or (i.Fecha = FechaR And i.Hora < HoraC)) And (i.NoPlaza = IdPlazaUno Or i.NoPlaza = IdPlazaDos) And i.idTurno = 1 And (d.idVehiculo = 1 Or d.idVehiculo = 10 Or d.idVehiculo = 11 Or d.idVehiculo = 17) And d.idPago = TipoPago And i.Anulado = False
                         Select i.idTarifa).Count()

            Return Cantidad1y2 + Cantidad3

        Catch ex As Exception
            RadMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, RadMessageIcon.Error)
        End Try

    End Function

    Private Function SumarEjesDia(TipoAuto As Integer, TipoPago As Integer) As Integer

        Try

            Dim ctx As New CLRDataContext()
            Dim HoraA As New TimeSpan(20, 0, 0)
            Dim HoraC As New TimeSpan(8, 0, 0)
            Dim Cantidad1y2
            Dim Cantidad3

            Try
                Cantidad1y2 = (From i In ctx.Transacciones
                               Join d In ctx.Dictaminaciones
                                  On i.idDictaminacion Equals d.idDictaminacion
                               Where i.Fecha = FechaR And (i.NoPlaza = IdPlazaUno Or i.NoPlaza = IdPlazaDos) And (i.idTurno = 2 Or i.idTurno = 3) And d.idVehiculo = TipoAuto And d.idPago = TipoPago And i.Anulado = False
                               Select i.Num_Ejes).Sum()
            Catch ex As SqlClient.SqlException
                Cantidad1y2 = 0
            End Try

            Try
                Cantidad3 = (From i In ctx.Transacciones
                             Join d In ctx.Dictaminaciones
                                  On i.idDictaminacion Equals d.idDictaminacion
                             Where ((i.Fecha = FechaR.AddDays(-1) And i.Hora > HoraA) Or (i.Fecha = FechaR And i.Hora < HoraC)) And (i.NoPlaza = IdPlazaUno Or i.NoPlaza = IdPlazaDos) And i.idTurno = 1 And d.idVehiculo = TipoAuto And d.idPago = TipoPago And i.Anulado = False
                             Select i.Num_Ejes).Sum()
            Catch ex As SqlClient.SqlException
                Cantidad3 = 0
            End Try

            Return Cantidad1y2 + Cantidad3

        Catch ex As Exception
            RadMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, RadMessageIcon.Error)
        End Try

    End Function

    '*************************** Carriles Cerrados *****************************

    Private Function SumarMarcado_CC(Turno As Integer, ForPago As Integer) As Double

        Dim ctx As New CLRDataContext()
        Dim HoraA
        Dim HoraC
        Dim importe

        If CarrilR.Contains("A") Then
            CC_Plaza = IdPlazaUno
        Else
            CC_Plaza = IdPlazaDos
        End If

        Select Case Turno
            Case 1
                HoraA = New TimeSpan(22, 0, 0)
                HoraC = New TimeSpan(6, 0, 0)
            Case 2
                HoraA = New TimeSpan(6, 0, 0)
                HoraC = New TimeSpan(14, 0, 0)
            Case 3
                HoraA = New TimeSpan(14, 0, 0)
                HoraC = New TimeSpan(22, 0, 0)
        End Select

        If Turno = 1 Then
            importe = (From i In ctx.Transacciones
                       Where ((i.Fecha = FechaR.AddDays(-1) And i.Hora >= HoraA) Or (i.Fecha = FechaR And i.Hora <= HoraC)) And i.NoPlaza = CC_Plaza And (i.idTurno = Turno Or i.idTurno = 0) And i.NoCarrilCapufe = CarrilR And i.idPago = ForPago
                       Select i.idTarifa).Sum()

            If importe Is Nothing OrElse importe.ToString() = String.Empty Then
                Return 0
            Else
                Return importe
            End If
        Else
            importe = (From i In ctx.Transacciones
                       Where i.Fecha = FechaR And (i.Hora >= HoraA And i.Hora <= HoraC) And i.NoPlaza = idPlazaR And (i.idTurno = Turno Or i.idTurno = 0) And i.NoCarrilCapufe = CarrilR And i.idPago = ForPago
                       Select i.idTarifa).Sum()

            If importe Is Nothing OrElse importe.ToString() = String.Empty Then
                Return 0
            Else
                Return importe
            End If

        End If

    End Function

    Private Function ContarMarcado_CC(Turno As Integer, ForPago As Integer) As Integer

        Dim ctx As New CLRDataContext()
        Dim HoraA
        Dim HoraC
        Dim cantidad

        If CarrilR.Contains("A") Then
            CC_Plaza = IdPlazaUno
        Else
            CC_Plaza = IdPlazaDos
        End If

        Select Case Turno
            Case 1
                HoraA = New TimeSpan(22, 0, 0)
                HoraC = New TimeSpan(6, 0, 0)
            Case 2
                HoraA = New TimeSpan(6, 0, 0)
                HoraC = New TimeSpan(14, 0, 0)
            Case 3
                HoraA = New TimeSpan(14, 0, 0)
                HoraC = New TimeSpan(22, 0, 0)
        End Select

        If Turno = 1 Then
            cantidad = (From i In ctx.Transacciones
                        Where ((i.Fecha = FechaR.AddDays(-1) And i.Hora >= HoraA) Or (i.Fecha = FechaR And i.Hora <= HoraC)) And i.NoPlaza = idPlazaR And (i.idTurno = Turno Or i.idTurno = 0) And i.NoCarrilCapufe = CarrilR And i.idPago = ForPago
                        Select i.idTarifa).Count()

            Return cantidad

        Else
            cantidad = (From i In ctx.Transacciones
                        Where i.Fecha = FechaR And (i.Hora >= HoraA And i.Hora <= HoraC) And i.NoPlaza = idPlazaR And (i.idTurno = Turno Or i.idTurno = 0) And i.NoCarrilCapufe = CarrilR And i.idPago = ForPago
                        Select i.idTarifa).Count()

            Return cantidad

        End If

    End Function

    Private Function SumarVerificado_CC(Turno As Integer, ForPago As Integer) As Double

        Dim ctx As New CLRDataContext()
        Dim HoraA
        Dim HoraC
        Dim importe

        If CarrilR.Contains("A") Then
            CC_Plaza = IdPlazaUno
        Else
            CC_Plaza = IdPlazaDos
        End If

        Select Case Turno
            Case 1
                HoraA = New TimeSpan(22, 0, 0)
                HoraC = New TimeSpan(6, 0, 0)
            Case 2
                HoraA = New TimeSpan(6, 0, 0)
                HoraC = New TimeSpan(14, 0, 0)
            Case 3
                HoraA = New TimeSpan(14, 0, 0)
                HoraC = New TimeSpan(22, 0, 0)
        End Select

        If Turno = 1 Then
            importe = (From i In ctx.Transacciones
                       Join d In ctx.Dictaminaciones
                               On i.idDictaminacion Equals d.idDictaminacion
                       Where ((i.Fecha = FechaR.AddDays(-1) And i.Hora > HoraA) Or (i.Fecha = FechaR And i.Hora < HoraC)) And i.NoPlaza = idPlazaR And (i.idTurno = Turno Or i.idTurno = 0) And i.NoCarrilCapufe = CarrilR And d.idPago = ForPago And i.Anulado = False
                       Select d.NuevaTarifa).Sum()

            If importe Is Nothing OrElse importe.ToString() = String.Empty Then
                Return 0
            Else
                Return importe
            End If
        Else
            importe = (From i In ctx.Transacciones
                       Join d In ctx.Dictaminaciones
                               On i.idDictaminacion Equals d.idDictaminacion
                       Where i.Fecha = FechaR And (i.Hora > HoraA And i.Hora < HoraC) And i.NoPlaza = idPlazaR And (i.idTurno = Turno Or i.idTurno = 0) And i.NoCarrilCapufe = CarrilR And d.idPago = ForPago And i.Anulado = False
                       Select d.NuevaTarifa).Sum()

            If importe Is Nothing OrElse importe.ToString() = String.Empty Then
                Return 0
            Else
                Return importe
            End If

        End If

    End Function

    Private Function ContarVerificado_CC(Turno As Integer, ForPago As Integer) As Integer

        Dim ctx As New CLRDataContext()
        Dim HoraA
        Dim HoraC
        Dim cantidad

        If CarrilR.Contains("A") Then
            CC_Plaza = IdPlazaUno
        Else
            CC_Plaza = IdPlazaDos
        End If

        Select Case Turno
            Case 1
                HoraA = New TimeSpan(22, 0, 0)
                HoraC = New TimeSpan(6, 0, 0)
            Case 2
                HoraA = New TimeSpan(6, 0, 0)
                HoraC = New TimeSpan(14, 0, 0)
            Case 3
                HoraA = New TimeSpan(14, 0, 0)
                HoraC = New TimeSpan(22, 0, 0)
        End Select

        If Turno = 1 Then
            cantidad = (From i In ctx.Transacciones
                        Join d In ctx.Dictaminaciones
                               On i.idDictaminacion Equals d.idDictaminacion
                        Where ((i.Fecha = FechaR.AddDays(-1) And i.Hora > HoraA) Or (i.Fecha = FechaR And i.Hora < HoraC)) And i.NoPlaza = idPlazaR And (i.idTurno = Turno Or i.idTurno = 0) And i.NoCarrilCapufe = CarrilR And d.idPago = ForPago And i.Anulado = False
                        Select d.NuevaTarifa).Count()

            Return cantidad

        Else
            cantidad = (From i In ctx.Transacciones
                        Join d In ctx.Dictaminaciones
                               On i.idDictaminacion Equals d.idDictaminacion
                        Where i.Fecha = FechaR And (i.Hora > HoraA And i.Hora < HoraC) And i.NoPlaza = idPlazaR And (i.idTurno = Turno Or i.idTurno = 0) And i.NoCarrilCapufe = CarrilR And d.idPago = ForPago And i.Anulado = False
                        Select d.NuevaTarifa).Count()

            Return cantidad

        End If

    End Function

    Private Function ContarVehiculos_CC(Turno As Integer, TipoAuto As Integer, TipoPago As Integer) As Integer

        Dim ctx As New CLRDataContext()
        Dim HoraA
        Dim HoraC
        Dim total

        If CarrilR.Contains("A") Then
            CC_Plaza = IdPlazaUno
        Else
            CC_Plaza = IdPlazaDos
        End If

        Select Case Turno
            Case 1
                HoraA = New TimeSpan(22, 0, 0)
                HoraC = New TimeSpan(6, 0, 0)
            Case 2
                HoraA = New TimeSpan(6, 0, 0)
                HoraC = New TimeSpan(14, 0, 0)
            Case 3
                HoraA = New TimeSpan(14, 0, 0)
                HoraC = New TimeSpan(22, 0, 0)
        End Select

        If Turno = 1 Then
            If TipoAuto = 9 Then
                total = (From t In ctx.Transacciones
                         Join d In ctx.Dictaminaciones
                                 On t.idDictaminacion Equals d.idDictaminacion
                         Where ((t.Fecha = FechaR.AddDays(-1) And t.Hora >= HoraA) Or (t.Fecha = FechaR And t.Hora <= HoraC)) And t.NoPlaza = CC_Plaza And (t.idTurno = Turno Or t.idTurno = 0) And t.NoCarrilCapufe = CarrilR And (d.idVehiculo = TipoAuto Or d.idVehiculo = 16) And d.idPago = TipoPago And t.Anulado = False
                         Select t.NoEvento).Count()
            Else
                total = (From t In ctx.Transacciones
                         Join d In ctx.Dictaminaciones
                                 On t.idDictaminacion Equals d.idDictaminacion
                         Where ((t.Fecha = FechaR.AddDays(-1) And t.Hora >= HoraA) Or (t.Fecha = FechaR And t.Hora <= HoraC)) And t.NoPlaza = CC_Plaza And (t.idTurno = Turno Or t.idTurno = 0) And t.NoCarrilCapufe = CarrilR And d.idVehiculo = TipoAuto And d.idPago = TipoPago And t.Anulado = False
                         Select t.NoEvento).Count()
            End If
        Else
            If TipoAuto = 9 Then
                total = (From t In ctx.Transacciones
                         Join d In ctx.Dictaminaciones
                                 On t.idDictaminacion Equals d.idDictaminacion
                         Where t.Fecha = FechaR And (t.Hora >= HoraA And t.Hora <= HoraC) And t.NoPlaza = CC_Plaza And (t.idTurno = Turno Or t.idTurno = 0) And t.NoCarrilCapufe = CarrilR And (d.idVehiculo = TipoAuto Or d.idVehiculo = 16) And d.idPago = TipoPago And t.Anulado = False
                         Select t.NoEvento).Count()
            Else
                total = (From t In ctx.Transacciones
                         Join d In ctx.Dictaminaciones
                                 On t.idDictaminacion Equals d.idDictaminacion
                         Where t.Fecha = FechaR And (t.Hora >= HoraA And t.Hora <= HoraC) And t.NoPlaza = CC_Plaza And (t.idTurno = Turno Or t.idTurno = 0) And t.NoCarrilCapufe = CarrilR And d.idVehiculo = TipoAuto And d.idPago = TipoPago And t.Anulado = False
                         Select t.NoEvento).Count()
            End If
        End If

        Return total

    End Function

    Private Function ContarNormales_CC(Turno As Integer, TipoPago As Integer) As Integer

        Dim ctx As New CLRDataContext()
        Dim HoraA
        Dim HoraC
        Dim total

        If CarrilR.Contains("A") Then
            CC_Plaza = IdPlazaUno
        Else
            CC_Plaza = IdPlazaDos
        End If

        Select Case Turno
            Case 1
                HoraA = New TimeSpan(22, 0, 0)
                HoraC = New TimeSpan(6, 0, 0)
            Case 2
                HoraA = New TimeSpan(6, 0, 0)
                HoraC = New TimeSpan(14, 0, 0)
            Case 3
                HoraA = New TimeSpan(14, 0, 0)
                HoraC = New TimeSpan(22, 0, 0)
        End Select

        If Turno = 1 Then
            total = (From t In ctx.Transacciones
                     Join d In ctx.Dictaminaciones
                             On t.idDictaminacion Equals d.idDictaminacion
                     Where ((t.Fecha = FechaR.AddDays(-1) And t.Hora >= HoraA) Or (t.Fecha = FechaR And t.Hora <= HoraC)) And t.NoPlaza = CC_Plaza And (t.idTurno = Turno Or t.idTurno = 0) And t.NoCarrilCapufe = CarrilR And (d.idVehiculo = 1 Or d.idVehiculo = 10 Or d.idVehiculo = 11 Or d.idVehiculo = 17) And d.idPago = TipoPago And t.Anulado = False
                     Select t.NoEvento).Count()
        Else
            total = (From t In ctx.Transacciones
                     Join d In ctx.Dictaminaciones
                             On t.idDictaminacion Equals d.idDictaminacion
                     Where t.Fecha = FechaR And (t.Hora >= HoraA And t.Hora <= HoraC) And t.NoPlaza = CC_Plaza And (t.idTurno = Turno Or t.idTurno = 0) And t.NoCarrilCapufe = CarrilR And (d.idVehiculo = 1 Or d.idVehiculo = 10 Or d.idVehiculo = 11 Or d.idVehiculo = 17) And d.idPago = TipoPago And t.Anulado = False
                     Select t.NoEvento).Count()
        End If

        Return total

    End Function

    Private Function SumarEjes_CC(Turno As Integer, TipoAuto As Integer, TipoPago As Integer) As Integer

        Dim ctx As New CLRDataContext()
        Dim HoraA
        Dim HoraC
        Dim total

        If CarrilR.Contains("A") Then
            CC_Plaza = IdPlazaUno
        Else
            CC_Plaza = IdPlazaDos
        End If

        Select Case Turno
            Case 1
                HoraA = New TimeSpan(22, 0, 0)
                HoraC = New TimeSpan(6, 0, 0)
            Case 2
                HoraA = New TimeSpan(6, 0, 0)
                HoraC = New TimeSpan(14, 0, 0)
            Case 3
                HoraA = New TimeSpan(14, 0, 0)
                HoraC = New TimeSpan(22, 0, 0)
        End Select

        If Turno = 1 Then
            Try
                total = (From t In ctx.Transacciones
                         Join d In ctx.Dictaminaciones
                             On t.idDictaminacion Equals d.idDictaminacion
                         Where ((t.Fecha = FechaR.AddDays(-1) And t.Hora >= HoraA) Or (t.Fecha = FechaR And t.Hora <= HoraC)) And t.NoPlaza = CC_Plaza And (t.idTurno = Turno Or t.idTurno = 0) And t.NoCarrilCapufe = CarrilR And d.idVehiculo = TipoAuto And d.idPago = TipoPago And t.Anulado = False
                         Select t.Num_Ejes).Sum()
            Catch ex As SqlClient.SqlException
                total = 0
            End Try

        Else
            Try
                total = (From t In ctx.Transacciones
                         Join d In ctx.Dictaminaciones
                                 On t.idDictaminacion Equals d.idDictaminacion
                         Where t.Fecha = FechaR And (t.Hora >= HoraA And t.Hora <= HoraC) And t.NoPlaza = CC_Plaza And (t.idTurno = Turno Or t.idTurno = 0) And t.NoCarrilCapufe = CarrilR And d.idVehiculo = TipoAuto And d.idPago = TipoPago And t.Anulado = False
                         Select t.Num_Ejes).Sum()
            Catch ex As SqlClient.SqlException
                total = 0
            End Try
        End If

        Return total

    End Function

#End Region

#Region "Methods"

    Private Sub ContarCarriles()

        Dim ctx As New CLRDataContext()
        Dim HoraA As New TimeSpan(20, 0, 0)
        Dim HoraC As New TimeSpan(8, 0, 0)
        Dim Num

        ListarCarriles(IdPlazaUno, IdPlazaDos)

        For i As Integer = 0 To ListaCarriles.Count - 1

            Dim NumVia As String = ListaCarriles.Item(i)

            If idTurnoR = 1 Then
                Num = (From n In ctx.Declaraciones
                       Where ((n.Fecha = FechaR.AddDays(-1) And n.HoraCierre > HoraA) Or (n.Fecha = FechaR And n.HoraCierre < HoraC)) And (n.NoPlaza = IdPlazaUno Or n.NoPlaza = IdPlazaDos) And n.idTurno = idTurnoR And n.NoCarrilCapufe = NumVia
                       Select n.NoDeclaracion).Count()

                If Num = 0 Then
                    Cerrados += 1
                Else
                    Abiertos += Num
                End If
            Else
                Num = (From n In ctx.Declaraciones
                       Where n.Fecha = FechaR And (n.NoPlaza = IdPlazaUno Or n.NoPlaza = IdPlazaDos) And n.idTurno = idTurnoR And n.NoCarrilCapufe = NumVia
                       Select n.NoDeclaracion).Count()

                If Num = 0 Then
                    Cerrados += 1
                Else
                    Abiertos += Num
                End If

            End If

        Next

    End Sub

    Private Sub ListarCarriles(idUno As Integer, idDos As Integer)

        Dim ctx As New CLRDataContext()

		Dim vias = (From v In ctx.CatalogoCarriles
					Where v.idPlaza = idUno Or v.idPlaza = idDos
					Select v.Carril).ToList()

		For Each i As String In vias
            ListaCarriles.Add(i)
        Next

    End Sub

    Private Sub ListarBolsas()

        Dim ctx As New CLRDataContext()

        Dim HoraA As New TimeSpan(20, 0, 0)
        Dim HoraC As New TimeSpan(8, 0, 0)
        Dim cortes
        Dim vias
        Dim casetas

        If SeleccionReporte <> 3 Then
            ListaBolsas.Clear()
            ListaNumCarril.Clear()
            ListaNumPlazas.Clear()
        End If

        If idTurnoR = 1 Then
            cortes = (From n In ctx.Declaraciones
                      Where ((n.Fecha = FechaR.AddDays(-1) And n.HoraCierre > HoraA) Or (n.Fecha = FechaR And n.HoraCierre < HoraC)) And (n.NoPlaza = IdPlazaUno Or n.NoPlaza = IdPlazaDos) And n.idTurno = idTurnoR Order By n.NoCarrilCapufe Ascending
                      Select n.NoDeclaracion).ToList()

            vias = (From n In ctx.Declaraciones
                    Where ((n.Fecha = FechaR.AddDays(-1) And n.HoraCierre > HoraA) Or (n.Fecha = FechaR And n.HoraCierre < HoraC)) And (n.NoPlaza = IdPlazaUno Or n.NoPlaza = IdPlazaDos) And n.idTurno = idTurnoR Order By n.NoCarrilCapufe Ascending
                    Select n.NoCarrilCapufe).ToList()

            casetas = (From n In ctx.Declaraciones
                       Where ((n.Fecha = FechaR.AddDays(-1) And n.HoraCierre > HoraA) Or (n.Fecha = FechaR And n.HoraCierre < HoraC)) And (n.NoPlaza = IdPlazaUno Or n.NoPlaza = IdPlazaDos) And n.idTurno = idTurnoR Order By n.NoCarrilCapufe Ascending
                       Select n.NoPlaza).ToList()
        Else
            cortes = (From n In ctx.Declaraciones
                      Where n.Fecha = FechaR And (n.NoPlaza = IdPlazaUno Or n.NoPlaza = IdPlazaDos) And n.idTurno = idTurnoR Order By n.NoCarrilCapufe Ascending
                      Select n.NoDeclaracion).ToList()

            vias = (From n In ctx.Declaraciones
                    Where n.Fecha = FechaR And (n.NoPlaza = IdPlazaUno Or n.NoPlaza = IdPlazaDos) And n.idTurno = idTurnoR Order By n.NoCarrilCapufe Ascending
                    Select n.NoCarrilCapufe).ToList()

            casetas = (From n In ctx.Declaraciones
                       Where n.Fecha = FechaR And (n.NoPlaza = IdPlazaUno Or n.NoPlaza = IdPlazaDos) And n.idTurno = idTurnoR Order By n.NoCarrilCapufe Ascending
                       Select n.NoPlaza).ToList()
        End If

        For Each i As Integer In cortes
            ListaBolsas.Add(i)
        Next

        For Each j As String In vias
            ListaNumCarril.Add(j)
        Next

        For Each k As Integer In casetas
            ListaNumPlazas.Add(k)
        Next

    End Sub

#End Region

End Class