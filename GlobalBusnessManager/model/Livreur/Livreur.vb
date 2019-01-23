Public Class Livreur
    Private mId As Integer
    Private mName As String
    Private mStatus As String

    Sub New()
        mId = 0
        mName = "Inconnu"
        mStatus = "Inconnu"
    End Sub
    Sub New(name As String, status As String)
        mId = 0
        mName = name
        mStatus = status
    End Sub
    Sub New(id As Integer, name As String, status As String)
        mId = id
        mName = name
        mStatus = status
    End Sub

    Private Sub setId(id As Integer)
        mId = id
    End Sub
    Public Sub setName(name As String)
        mName = name
    End Sub
    Public Sub setStatus(status As String)
        mStatus = status
    End Sub

#Region "SETTE"
    Public Function getId() As Integer
        Return mId
    End Function
    Public Function getName() As String
        Return mName
    End Function
    Public Function getStatus() As String
        Return mStatus
    End Function
#End Region
End Class
