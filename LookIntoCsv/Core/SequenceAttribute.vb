Imports System.Reflection

<System.AttributeUsage(System.AttributeTargets.All)>
Public Class SequenceAttribute
    Inherits Attribute
    Public sequence As Integer
    Sub New(sequence As Integer)
        Me.sequence = sequence
    End Sub

    Shared Function GetAttributBySequense(Of T)(p_sequence As Integer) As FieldInfo
        Dim typeAConvertir As Type = GetType(T)
        Dim typeAConvertirFields As FieldInfo() = typeAConvertir.GetFields()
        For Each typeAConvertirField As FieldInfo In typeAConvertirFields
            Dim attrs() As Attribute = typeAConvertirField.GetCustomAttributes()
            For Each attr As Attribute In attrs
                Dim sequenceAttr As SequenceAttribute = CType(attr, SequenceAttribute)
                If sequenceAttr.sequence = p_sequence Then
                    Return typeAConvertirField
                End If
            Next
        Next
        Return Nothing
    End Function
End Class
