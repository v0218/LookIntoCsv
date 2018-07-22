Imports System.Reflection
Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting

<TestClass()> Public Class Principal

    <TestMethod()> Public Sub AppelPrincipal()
        Context.GetInstance().path = "Files/Bidon.csv"
        Context.GetInstance().splitCharacter = ";"
        Dim le As LoadEnMemoire = New LoadEnMemoire()
        le.Lire(Of Ligne)()
        le.Trier(Of Ligne)(1)
        Dim test = le.Format(Of Ligne)(1, 2)
        Assert.IsTrue(Not (le.GetType() Is Nothing))
    End Sub
    <TestMethod()> Public Sub testGetCustomAttribut()
        Dim l As Ligne = New Ligne
        l.ID = "14"
        l.Nom = "Jean"
        l.Prenom = "Calce"

        Dim f As FieldInfo = SequenceAttribute.GetAttributBySequense(Of Ligne)(2)

        Assert.IsTrue(f.GetValue(l) = l.Nom)
    End Sub
End Class