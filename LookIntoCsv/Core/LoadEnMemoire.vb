Imports System.IO
Imports System.Reflection

Public Class LoadEnMemoire
    Private _result

    ReadOnly Property GetResult()
        Get
            Return _result
        End Get
    End Property

    Public Sub Lire(Of T)()

        Using SR As StreamReader = New StreamReader(Context.GetInstance().path)
            Dim line As String
            _result = New List(Of T)
            ' Lire l'entete
            line = SR.ReadLine()
            Dim lstHeader As IList(Of String) = line.Split(Context.GetInstance().splitCharacter)
            line = SR.ReadLine()

            While line IsNot Nothing

                Console.WriteLine(line)
                'Lire chaque Ligne
                Dim lstRow As IList(Of String) = line.Split(Context.GetInstance().splitCharacter)
                Dim dict As T = Activator.CreateInstance(Of T)()

                For i As Integer = 0 To lstRow.Count() - 1
                    Dim fi As FieldInfo = SequenceAttribute.GetAttributBySequense(Of T)(i + 1)
                    fi.SetValue(dict, lstRow.ElementAt(i))
                Next
                _result.Add(dict)
                line = SR.ReadLine()
            End While
        End Using
    End Sub

    Public Sub Trier(Of T)(sequenceId As Integer)
        Dim r As List(Of T) = CType(_result, List(Of T))
        r.Sort(Function(x, y) SequenceAttribute.GetAttributBySequense(Of T)(sequenceId).GetValue(x) < SequenceAttribute.GetAttributBySequense(Of T)(1).GetValue(y))
    End Sub

    Public Function Format(Of T)(sequenceId As Integer, sequenceId2 As Integer) As Dictionary(Of String, Dictionary(Of String, T))
        Dim retour As Dictionary(Of String, Dictionary(Of String, T)) = New Dictionary(Of String, Dictionary(Of String, T))
        For Each i As T In _result
            Dim retour2 As Dictionary(Of String, T) = New Dictionary(Of String, T)
            If retour.ContainsKey(SequenceAttribute.GetAttributBySequense(Of T)(sequenceId).GetValue(i)) Then
                retour(SequenceAttribute.GetAttributBySequense(Of T)(sequenceId).GetValue(i)).Add(SequenceAttribute.GetAttributBySequense(Of T)(sequenceId2).GetValue(i), i)
            Else
                retour2.Add(SequenceAttribute.GetAttributBySequense(Of T)(sequenceId2).GetValue(i), i)
                retour.Add(SequenceAttribute.GetAttributBySequense(Of T)(sequenceId).GetValue(i), retour2)
            End If

        Next
        Return retour
    End Function

End Class
