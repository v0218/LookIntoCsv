Public Class Context
    Shared _instance As Context

    Public path As String
    Public splitCharacter As Char

    Shared Function GetInstance() As Context
        If _instance Is Nothing Then
            _instance = New Context()
        End If
        Return _instance
    End Function
End Class
