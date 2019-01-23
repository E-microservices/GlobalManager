Imports MySql.Data.MySqlClient

Public Class RapportManager
    Private mConnexion As MySqlConnection
    Private mReader As MySqlDataReader
    Private mCmd As MySqlCommand
    Private mQuery As String

    Sub New(connexion As Connexion)
        mConnexion = connexion.getConnexion
    End Sub

    Public Sub doRapport(rapport As Rapport)
        mQuery = "INSERT INTO rapport_jour(date_r, nom_client, contact_client, adresse_livraison, produit, prix_achat, prix_vente, quantite, benefice, agent_fact, acquisition, livrer_par)
                  VALUE(@val1, @val2, @val3, @val4, @val5, @val6, @val7, @val8, @val9, @val10, @val11, @val12)"
        mCmd = New MySqlCommand(mQuery, mConnexion)
        Try
            mCmd.Parameters.AddWithValue("@val1", rapport.getDate)
            mCmd.Parameters.AddWithValue("@val2", rapport.getClientName)
            mCmd.Parameters.AddWithValue("@val3", rapport.getContact)
            mCmd.Parameters.AddWithValue("@val4", rapport.getAdresseLivraison)
            mCmd.Parameters.AddWithValue("@val5", rapport.getProductName)
            mCmd.Parameters.AddWithValue("@val6", rapport.getPrixAchat)
            mCmd.Parameters.AddWithValue("@val7", rapport.getPrixVente)
            mCmd.Parameters.AddWithValue("@val8", rapport.getQuantite)
            mCmd.Parameters.AddWithValue("@val9", rapport.getBenefice)
            mCmd.Parameters.AddWithValue("@val10", rapport.getAgentFacteur)
            mCmd.Parameters.AddWithValue("@val11", rapport.getSource)
            mCmd.Parameters.AddWithValue("@val12", rapport.getLivreur)
            mCmd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox("Erreur d'insertion du rapport. Source: " & ex.ToString)
        Finally
            eraseMemory()
        End Try
    End Sub
    Public Function getAllRappor() As List(Of Rapport)
        Dim rapportList As New List(Of Rapport)
        mQuery = "SELECT * FROM rapport_jour ORDER BY id DESC"
        Try
            mCmd = New MySqlCommand(mQuery, mConnexion)
            mReader = mCmd.ExecuteReader
            If mReader IsNot Nothing Then
                While mReader.Read
                    rapportList.Add(New Rapport(CInt(mReader.GetString("id")), CDate(mReader.GetString("date_r")), mReader.GetString("nom_client"),
                                                mReader.GetString("contact_client"), mReader.GetString("adresse_livraison"), mReader.GetString("produit"),
                                                CInt(mReader.GetString("prix_achat")), CInt(mReader.GetString("prix_vente")), CInt(mReader.GetString("quantite")),
                                                CInt(mReader.GetString("benefice")), mReader.GetString("agent_fact"), mReader.GetString("acquisition"), mReader.GetString("livrer_par")))
                End While
            End If
        Catch ex As Exception
            MsgBox("Une erreur est survenu lors de la lecture des données. Source: " & ex.ToString)
        Finally
            eraseMemory()
        End Try
        Return rapportList
    End Function

    Private Sub eraseMemory()
        If mReader IsNot Nothing Then
            mReader.Close()
            mReader.Dispose()
        End If
        If mCmd IsNot Nothing Then
            mCmd.Dispose()
        End If
    End Sub
End Class
