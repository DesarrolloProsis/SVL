
Public Class Mensajes

    Public Function AlertOK(Mensaje As String, Titulo As String) As Integer

        Dim result As Integer = MessageBox.Show(Mensaje, Titulo, MessageBoxButtons.OK)

        Return result

    End Function

    Public Function AlertOption(Mensaje As String, Titulo As String)

        Dim result As Integer = MessageBox.Show(Mensaje, Titulo, MessageBoxButtons.YesNo)

        Return result

    End Function

End Class
