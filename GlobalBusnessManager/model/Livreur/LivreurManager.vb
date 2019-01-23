Imports MySql.Data.MySqlClient

Public Class LivreurManager
    Private mConnexion As MySqlConnection
    Private mReader As MySqlDataReader
    Private mCmd As MySqlCommand
    Private mQuery As String

    Sub New(connexion As Connexion)
        mConnexion = connexion.getConnexion
    End Sub

    Public Function getLivreurByName(name As String) As Livreur
        mQuery = "SELECT * FROM livreur WHERE name = @val1"
        Dim livreur As Livreur
        Try
            mCmd = New MySqlCommand(mQuery, mConnexion)
            mCmd.Parameters.AddWithValue("@val1", name)
            mReader = mCmd.ExecuteReader
            livreur = New Livreur(mReader.GetString("id"), mReader.GetString("name"), mReader.GetString("status"))
        Catch ex As Exception
            MsgBox("Erreur d'execution du script. Veuillez vous assurer que vous etes connecter au reseau")
        Finally
            eraseMemory()
        End Try
        Return livreur
    End Function

    Public Function getAllLivreur() As List(Of Livreur)
        mQuery = "SELECT * FROM livreur"
        Dim listOfLivreur As New List(Of Livreur)
        Try
            mCmd = New MySqlCommand(mQuery, mConnexion)
            mReader = mCmd.ExecuteReader
            While mReader.Read
                listOfLivreur.Add(New Livreur(mReader.GetString("id"), mReader.GetString("name"), mReader.GetString("status")))
            End While
        Catch ex As Exception
            MsgBox("Erreur de l'execution du script. Rassurez vous que vous etes bien connecter au reseau local")
        Finally
            eraseMemory()
        End Try
        Return listOfLivreur
    End Function

    Private Sub eraseMemory()
        If mReader IsNot Nothing Then
            mReader.Dispose()
            mReader.Close()
        End If
        If mCmd IsNot Nothing Then
            mCmd.Dispose()
        End If
    End Sub
End Class
