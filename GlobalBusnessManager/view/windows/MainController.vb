﻿
Public Class MainController
#Region "section variable"
    Dim connexion As Connexion
    Dim product As Product
    Dim productManager As ProductManager
    Dim clientManager As ClientManager
    Dim dataGridManager As DataGridManager
    Dim basicCommande As BasicCommand
    Dim basicCommandeManager As BasicCommandManager
    Dim leClient As Client
    Dim productDataController As New DataGridController
    Dim dastBoad As DastBoad
    Dim host As String
    Dim stockManager As StockManager
    Dim mOutObject As OutObject
    Dim mRappor As Rapport
    Dim mRapportManager As RapportManager
    Dim bmp As Bitmap
#End Region
    Private Sub MainController_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.STOCK_MANAGER_VIEW.Visible = False
        activatButton(False)
        Me.PRODUCT_DATA_GRID.Visible = False
        Me.CLIENT_DATA_VIEW.Visible = False
        Me.VU_RAPPORT.Visible = False
        Me.BAR_ETAT.Text = "En attente de connexion"
        host = ""
    End Sub
#Region "Connexion Event"
    Private Sub BT_CON_Click(sender As Object, e As EventArgs) Handles BT_CON.Click
        Dim exite As Boolean = False
        Do
            ConnexionBeeshop.ShowDialog()
            If ConnexionBeeshop.DialogResult = DialogResult.OK Then
                connexion = New Connexion(ConnexionBeeshop.LOGING.Text, ConnexionBeeshop.PASSWORD.Text, host)
                If connexion.establishConnexion Then
                    activatButton(True)
                    productManager = New ProductManager(connexion)
                    clientManager = New ClientManager(connexion)
                    productManager.updateProductDataGrid()
                    clientManager.updateClientDataGrid()
                    dataGridManager = New DataGridManager
                    basicCommandeManager = New BasicCommandManager(connexion)
                    dastBoad = New DastBoad()
                    UpDateTimer.Enabled = True
                    stockManager = New StockManager(connexion)
                    mRapportManager = New RapportManager(connexion)
                    stockManager.uppdateProductStat()
                    mOutObject = New OutObject
                    exite = True
                    'contact je suis tres occuper je ne peut pas venir
                End If
            Else
                exite = True
            End If
        Loop Until (exite)
    End Sub
    Private Sub BT_DCO_Click(sender As Object, e As EventArgs) Handles BT_DCO.Click
        If Not connexion.closeConnexion Then
            UpDateTimer.Enabled = False
            activatButton(False)
            dataGridManager.deconnexionView()

        End If
    End Sub
#End Region
#Region "Parametre de l'hote"
    Private Sub MENU_PROGRAMME_Click(sender As Object, e As EventArgs) Handles MENU_PROGRAMME.Click
        AppConfig.ShowDialog()
        host = AppConfig.SERVER_NAME.Text
    End Sub
#End Region
#Region "Product manager function"
    Private Sub BT_PRODUCT_ADD_Click(sender As Object, e As EventArgs) Handles BT_PRODUCT_ADD.Click
        Ajoute_Un_Produit.ShowDialog()
        If Ajoute_Un_Produit.DialogResult = DialogResult.OK Then
            product = New Product(Ajoute_Un_Produit.CODE_PRODUIT.Text, Ajoute_Un_Produit.NOM_PRODUIT.Text, Ajoute_Un_Produit.PRIX_ACHAT.Text, Ajoute_Un_Produit.PRIX_VENTE.Text, Ajoute_Un_Produit.DESCRIPTION_PRODUIT.Text)
            productManager.addProduct(product)
        End If

    End Sub
    Private Sub BT_EDIT_PRODUCT_Click(sender As Object, e As EventArgs) Handles BT_EDIT_PRODUCT.Click
        product = productManager.getProduct(productManager.getRowSelectedIdValue())
        EditProduct.ShowDialog()
        If EditProduct.DialogResult = DialogResult.Cancel Then
            Exit Sub
        End If
        product.setCode(EditProduct.CODE_PRODUIT.Text)
        product.setNom(EditProduct.NOM_PRODUIT.Text)
        product.setPrixAchat(CInt(EditProduct.PRIX_ACHAT.Text))
        product.setPrixDeVent(CInt(EditProduct.PRIX_VENTE.Text))
        product.setDescription(EditProduct.DESCRIPTION_PRODUIT.Text)
        productManager.edditProduct(product)
    End Sub
    Private Sub BT_DEL_PRODUCT_Click(sender As Object, e As EventArgs) Handles BT_DEL_PRODUCT.Click
        If MsgBox("Etre vous sûr de vouloir supprimer ce produit de la Base de donné ?" & Chr(13) & "Attention: cette action est irréversible.", 4, "Avertissement !") = MsgBoxResult.No Then
            Exit Sub
        End If
        productManager.deletteProduct(productManager.getRowSelectedIdValue())
    End Sub
    Private Sub BT_STOCK_MANAGER_Click(sender As Object, e As EventArgs) Handles BT_STOCK_MANAGER.Click
        'WIN_STOCK_MANAGER.Show()
        Me.STOCK_MANAGER_VIEW.Visible = True
        displayInObject(stockManager.getInObject)
        displayOutObject(stockManager.getOutObject)
    End Sub
    Private Sub BT_ADD_OUT_OBJECT_Click(sender As Object, e As EventArgs)
        AddOutObject.ShowDialog()
        If AddOutObject.DialogResult = DialogResult.Cancel Then
            Exit Sub
        End If
        stockManager.addOutObject(makeOutObjectByDiarlog)
        displayOutObject(stockManager.getOutObject)
    End Sub

    Private Sub BT_ADD_IN_OBJECT_Click(sender As Object, e As EventArgs)
        AddInObject.ShowDialog()
        If AddInObject.DialogResult = DialogResult.Cancel Then
            Exit Sub
        End If
        stockManager.addInObject(makeInObjectByDiarlog)
        displayInObject(stockManager.getInObject)
    End Sub
#End Region
#Region "Command manager"
    Private Sub BT_ADD_COMMAND_Click(sender As Object, e As EventArgs) Handles BT_ADD_COMMAND.Click
        AddCommandWin.ShowDialog()
        If AddCommandWin.DialogResult = DialogResult.Cancel Then
            Exit Sub
        End If
        basicCommandeManager.addCommand(AddCommandWin.getCommand)
    End Sub
    Private Sub BT_DELETE_COMMAND_Click(sender As Object, e As EventArgs) Handles BT_DELETE_COMMAND.Click
        If MsgBox("Etre vous sûr de vouloir supprimer cette commande de la Base de donné ?" & Chr(13) & "Attention: cette action est irréversible.", 4, "Avertissement !") = MsgBoxResult.No Then
            Exit Sub
        End If
        basicCommandeManager.deleteCommand(basicCommandeManager.getRowSelectedIdValue)
    End Sub
    Private Sub BT_EDIT_COMMAND_Click(sender As Object, e As EventArgs) Handles BT_EDIT_COMMAND.Click

    End Sub
#End Region
#Region "Client manager function"
    Private Sub BT_ADD_CLIENT_Click(sender As Object, e As EventArgs) Handles BT_ADD_CLIENT.Click
        AddClientWin.Text = "Ajouter un client"
        AddClientWin.ShowDialog()
        If AddClientWin.DialogResult = DialogResult.Cancel Then
            MsgBox("Le progralle va sort de la fonction ajouter")
            Exit Sub
        End If
        clientManager.addClient(New Client(AddClientWin.CLIENT_NAME.Text, CInt(AddClientWin.CLIENT_CONTACT.Text), AddClientWin.CLIENT_COMMUNE.Text))
    End Sub
    Private Sub BT_EDIT_ClIENT_Click(sender As Object, e As EventArgs) Handles BT_EDIT_ClIENT.Click
        leClient = clientManager.getClient(clientManager.getRowSelectedIdValue)
        If leClient Is Nothing Then
            MsgBox("Aucune client n'a été selctionner.")
            Exit Sub
        End If
        AddClientWin.Text = "Modification de Client"
        AddClientWin.CLIENT_NAME.Text = leClient.getName
        AddClientWin.CLIENT_CONTACT.Text = leClient.getContact
        AddClientWin.CLIENT_COMMUNE.Text = leClient.getCommune
        AddClientWin.ShowDialog()
        leClient.setName(AddClientWin.CLIENT_NAME.Text)
        leClient.setContact(CInt(AddClientWin.CLIENT_CONTACT.Text))
        leClient.setCommune(AddClientWin.CLIENT_COMMUNE.Text)
        clientManager.edditClient(clientManager.getRowSelectedIdValue, leClient)
    End Sub
    Private Sub BT_DEL_CLIENT_Click(sender As Object, e As EventArgs) Handles BT_DEL_CLIENT.Click
        If MsgBox("Etre vous sûr de vouloir supprimer ce client de DATA BASE ?" & Chr(13) & "Attention: cette action est irréversible.", 4, "Avertissement !") = MsgBoxResult.No Then
            Exit Sub
        End If
        clientManager.deleteClient(clientManager.getRowSelectedIdValue)
    End Sub
#End Region
#Region "RAPPORT SECTION"
    Private Sub BT_RAP_JOUR_Click(sender As Object, e As EventArgs) Handles BT_RAP_JOUR.Click
        displayRapportInDataGrid(mRapportManager.getAllRappor)
        rapportView()
    End Sub
#End Region
#Region "View function"
    Private Sub UpDateTimer_Tick(sender As Object, e As EventArgs) Handles UpDateTimer.Tick
        If dastBoad.upDateDastBoad() Then
            UpDateTimer.Enabled = False
            activatButton(False)
            dataGridManager.deconnexionView()
            connexion.closeConnexion()
        Else
            'basicCommandeManager.updateCommandDataGrid()
            'productManager.updateProductDataGrid()
            'stockManager.updateStockListe()
        End If
    End Sub
    Private Sub BT_VUE_COM_Click(sender As Object, e As EventArgs) Handles BT_VUE_COM.Click
        Try
            basicCommandeManager.updateCommandDataGrid()
            dataGridManager.commandView()
        Catch ex As Exception
            MsgBox("Veuillez vous connceter avant d'afficher les commandes")
        End Try
    End Sub
    Private Sub BT_VUE_PRODUIT_Click(sender As Object, e As EventArgs) Handles BT_VUE_PRODUIT.Click
        productManager.updateProductDataGrid()
        dataGridManager.productView()
    End Sub
    Private Sub BT_VUE_CLIENT_Click(sender As Object, e As EventArgs) Handles BT_VUE_CLIENT.Click
        dataGridManager.clientView()
    End Sub
    Private Sub BT_VUE_FOURNISSEUR_Click(sender As Object, e As EventArgs) Handles BT_VUE_FOURNISSEUR.Click
        dataGridManager.fournisseurView()
    End Sub
    Private Sub BT_PRODUCT_STOCK_Click(sender As Object, e As EventArgs) Handles BT_PRODUCT_STOCK.Click
        stockManager.updateStockListe()
        dataGridManager.stockView()
    End Sub
    Private Sub VU_COMMAND_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles VU_COMMAND.CellClick
        If basicCommandeManager.getSelectedCellContenteValue <> "En Cours" Then
            Exit Sub
        End If
        Me.makeAndSaveOutObject()
        makeAndSaveRapport()
        basicCommandeManager.validateCourrantStat(basicCommandeManager.getRowSelectedIdValue)
    End Sub
#End Region
#Region "Display Srevices"
    Private Sub BT_DISPLAY_PRO_Click(sender As Object, e As EventArgs) Handles BT_DISPLAY_PRO.Click
        productManager.updateProductDataGrid()
        dataGridManager.productView()
    End Sub
    Private Sub BT_DISPLAY_COM_Click(sender As Object, e As EventArgs) Handles BT_DISPLAY_COM.Click
        Try
            basicCommandeManager.updateCommandDataGrid()
            dataGridManager.commandView()
        Catch ex As Exception
            MsgBox("Veuillez vous connceter avant d'afficher les commandes")
        End Try
    End Sub
    Private Sub BT_DISPLAY_CLT_Click(sender As Object, e As EventArgs) Handles BT_DISPLAY_CLT.Click
        dataGridManager.clientView()
    End Sub
#End Region
#Region "Function interface"
    Public Sub activatButton(ByVal seting As Boolean)
        With Me.
            BT_VUE_COM.Enabled = seting
            BT_VUE_CLIENT.Enabled = seting
            BT_VUE_PRODUIT.Enabled = seting
            BT_VUE_FOURNISSEUR.Enabled = seting

            BT_ADD_CLIENT.Enabled = seting
            BT_EDIT_ClIENT.Enabled = seting
            BT_DEL_CLIENT.Enabled = seting

            BT_ADD_COMMAND.Enabled = seting
            BT_DELETE_COMMAND.Enabled = seting
            BT_EDIT_COMMAND.Enabled = seting

            BT_PRODUCT_ADD.Enabled = seting
            BT_DEL_PRODUCT.Enabled = seting
            BT_EDIT_PRODUCT.Enabled = seting
            BT_PRODUCT_STOCK.Enabled = seting

            BT_RAP_JOUR.Enabled = seting
            BT_RAP_WEEK.Enabled = seting
            BT_RAP_MONTH.Enabled = seting

        End With
        If seting Then
            Me.BT_CON.Enabled = False
            Me.BT_DCO.Enabled = True
            Me.PRODUCT_DATA_GRID.Visible = True
        Else
            Me.BT_CON.Enabled = True
            Me.BT_DCO.Enabled = False
            Me.PRODUCT_DATA_GRID.Visible = False
        End If
    End Sub
    Public Function getMainConnexion() As Connexion
        Return connexion
    End Function
    Private Sub makeAndSaveOutObject()
        mOutObject.setDate(Date.Now)
        mOutObject.setCause("Acheter par: " + basicCommandeManager.getRowSelectedClientNameValue)
        mOutObject.setProductId(basicCommandeManager.getRowSelectedProductCodeValue)
        mOutObject.setDestination(basicCommandeManager.getRowSelectedClientAdresseValue)
        mOutObject.setQuantite(basicCommandeManager.getRowSelectedQuantiteValue)
        stockManager.addOutObjectByCommand(mOutObject)
        'stockManager.addOutObject(New OutObject())
        'MsgBox(basicCommandeManager.getRowSelectedIdValue)
    End Sub
    Private Sub makeAndSaveRapport()
        product = productManager.getProductByCode(basicCommandeManager.getRowSelectedProductCodeValue)
        Dim benefice As Integer
        benefice = CInt(basicCommandeManager.getRowSelectedQuantiteValue) * (CInt(basicCommandeManager.getRowSelectedPrixUnitaireValue) - CInt(product.getPrixAchat))
        mRappor = New Rapport(CDate(basicCommandeManager.getRowSelectedCommandDateValue).ToLongDateString, basicCommandeManager.getRowSelectedClientNameValue,
                              basicCommandeManager.getRowSelectedClientContactValue, basicCommandeManager.getRowSelectedClientAdresseValue,
                              basicCommandeManager.getRowSelectedProductNameValue, CInt(product.getPrixAchat),
                              CInt(basicCommandeManager.getRowSelectedPrixUnitaireValue), CInt(basicCommandeManager.getRowSelectedQuantiteValue), benefice,
                              basicCommandeManager.getRowSelectedAgentValue, basicCommandeManager.getRowSelectedSourceValue, basicCommandeManager.getRowSelectedLivreurValue)
        mRapportManager.doRapport(mRappor)
    End Sub
    Private Sub makeAndSaveOutProductRapport()
        product = productManager.getProductByCode(AddOutObject.SEARCH_TEXT.Text)
        Dim benefice As Integer
        benefice = 0
        mRappor = New Rapport(Date.Now, "NULL",
                              "NULL", AddOutObject.O_DESTINATION.Text,
                              product.getNom, CInt(product.getPrixAchat),
                              0, CInt(AddOutObject.O_QUANTITE.Text), benefice,
                              AddOutObject.O_CAUSE.Text, "BOUTIQUE")
        mRapportManager.doRapport(mRappor)
    End Sub
#End Region
    Private Sub STOCK_LIST_Click(sender As Object, e As EventArgs) Handles STOCK_LIST.CellValueChanged
        Try
            stockManager.updateProductStockValue()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BT_ADD_IN_OBJECT_Click_1(sender As Object, e As EventArgs) Handles BT_ADD_IN_OBJECT.Click
        AddInObject.ShowDialog()
        If AddInObject.DialogResult = DialogResult.Cancel Then
            Exit Sub
        End If
        stockManager.addInObject(makeInObjectByDiarlog)
        displayInObject(stockManager.getInObject)
    End Sub

    Private Sub BT_ADD_OUT_OBJECT_Click_1(sender As Object, e As EventArgs) Handles BT_ADD_OUT_OBJECT.Click
        AddOutObject.ShowDialog()
        If AddOutObject.DialogResult = DialogResult.Cancel Then
            Exit Sub
        End If
        stockManager.addOutObject(makeOutObjectByDiarlog)
        displayOutObject(stockManager.getOutObject)
        makeAndSaveOutProductRapport()
    End Sub
#Region "IMPRESSION"
    Private Sub BT_IMPRESSION_Click(sender As Object, e As EventArgs) Handles BT_IMPRESSION.Click
        'bmp = impressionRappor(VU_RAPPORT)
        Dim heith_d As Integer
        Dim whith_d As Integer
        heith_d = VU_RAPPORT.Height
        whith_d = VU_RAPPORT.Width

        'VU_RAPPORT.Height = VU_RAPPORT.RowCount * VU_RAPPORT.RowTemplate.Height

        bmp = New Bitmap(whith_d, heith_d)
        VU_RAPPORT.DrawToBitmap(bmp, New Rectangle(0, 0, VU_RAPPORT.Width, VU_RAPPORT.Height))
        VU_RAPPORT.Height = heith_d
        PrintDocument.DefaultPageSettings.Landscape = False
        'PrintDocument1.Print()
        PrintPreviewDialog.Document = PrintDocument
        PrintPreviewDialog.ShowDialog()
    End Sub

    Private Sub PrintDocument_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles PrintDocument.PrintPage
        e.Graphics.DrawImage(bmp, 0, 0)
    End Sub
#End Region
End Class

