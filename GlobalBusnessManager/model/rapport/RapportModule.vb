Module RapportModule

    Public Sub rapportView()
        MainController.CLIENT_DATA_VIEW.Visible = False
        MainController.PRODUCT_DATA_GRID.Visible = False
        MainController.VU_RAPPORT.Visible = True
        MainController.FORNISSEUR_DATA_GRID.Visible = False
        MainController.VU_COMMAND.Visible = False
        MainController.STOCK_MANAGER_VIEW.Visible = False
        MainController.RAPPORT_LIST_VIEW.Visible = True

        MainController.BT_DEL_PRODUCT.Enabled = False
        MainController.BT_EDIT_PRODUCT.Enabled = False

        MainController.BT_DELETE_COMMAND.Enabled = False
        MainController.BT_EDIT_COMMAND.Enabled = False

        MainController.BT_DEL_CLIENT.Enabled = False
        MainController.BT_EDIT_ClIENT.Enabled = False
    End Sub
    'All IN One
    Public Sub displayRapportInDataGrid(rapportList As List(Of Rapport))
        If rapportList IsNot Nothing Then
            MainController.RAPPORT_LIST_VIEW.Rows.Clear()
            Try
                For Each rapport As Rapport In rapportList
                    MainController.RAPPORT_LIST_VIEW.Rows.Add(rapport.getId, rapport.getDate, rapport.getClientName, rapport.getContact, rapport.getAdresseLivraison,
                                                              rapport.getProductName, rapport.getPrixAchat, rapport.getPrixVente, rapport.getQuantite,
                                                              rapport.getBenefice, rapport.getAgentFacteur, rapport.getSource, rapport.getLivreur)
                Next
            Catch ex As Exception
                MsgBox("Erreur lors de l'execution du programme. Source: " & ex.ToString)
            End Try
        End If
    End Sub
End Module
