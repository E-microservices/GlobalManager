﻿Public Class DataGridManager
    Dim dataGrid As New DataGrid
    Sub New()
        MainController.CLIENT_DATA_VIEW.Visible = False
        MainController.PRODUCT_DATA_GRID.Visible = True
        MainController.VU_RAPPORT.Visible = False
        MainController.FORNISSEUR_DATA_GRID.Visible = False
        MainController.VU_COMMAND.Visible = False
        MainController.STOCK_LIST.Visible = False
        MainController.STOCK_MANAGER_VIEW.Visible = False
        MainController.RAPPORT_LIST_VIEW.Visible = False

        MainController.BT_DEL_PRODUCT.Enabled = False
        MainController.BT_EDIT_PRODUCT.Enabled = False

        MainController.BT_DELETE_COMMAND.Enabled = False
        MainController.BT_EDIT_COMMAND.Enabled = False

        MainController.BT_DEL_CLIENT.Enabled = False
        MainController.BT_EDIT_ClIENT.Enabled = False
    End Sub
    Public Sub deconnexionView()
        MainController.CLIENT_DATA_VIEW.Visible = False
        MainController.PRODUCT_DATA_GRID.Visible = False
        MainController.VU_RAPPORT.Visible = False
        MainController.FORNISSEUR_DATA_GRID.Visible = False
        MainController.VU_COMMAND.Visible = False
        MainController.STOCK_LIST.Visible = False
        MainController.STOCK_MANAGER_VIEW.Visible = False
        MainController.RAPPORT_LIST_VIEW.Visible = False

    End Sub
    Public Sub commandView()
        MainController.CLIENT_DATA_VIEW.Visible = False
        MainController.PRODUCT_DATA_GRID.Visible = False
        MainController.VU_RAPPORT.Visible = False
        MainController.FORNISSEUR_DATA_GRID.Visible = False
        MainController.VU_COMMAND.Visible = True
        MainController.STOCK_LIST.Visible = False
        MainController.STOCK_MANAGER_VIEW.Visible = False
        MainController.RAPPORT_LIST_VIEW.Visible = False

        MainController.BT_DEL_PRODUCT.Enabled = False
        MainController.BT_EDIT_PRODUCT.Enabled = False

        MainController.BT_DELETE_COMMAND.Enabled = False
        MainController.BT_EDIT_COMMAND.Enabled = False

        MainController.BT_DEL_CLIENT.Enabled = False
        MainController.BT_EDIT_ClIENT.Enabled = False
    End Sub
    Public Sub clientView()
        MainController.CLIENT_DATA_VIEW.Visible = True
        MainController.PRODUCT_DATA_GRID.Visible = False
        MainController.VU_RAPPORT.Visible = False
        MainController.FORNISSEUR_DATA_GRID.Visible = False
        MainController.VU_COMMAND.Visible = False
        MainController.STOCK_LIST.Visible = False
        MainController.STOCK_MANAGER_VIEW.Visible = False
        MainController.RAPPORT_LIST_VIEW.Visible = False

        MainController.BT_DEL_PRODUCT.Enabled = False
        MainController.BT_EDIT_PRODUCT.Enabled = False

        MainController.BT_DELETE_COMMAND.Enabled = False
        MainController.BT_EDIT_COMMAND.Enabled = False

        MainController.BT_DEL_CLIENT.Enabled = False
        MainController.BT_EDIT_ClIENT.Enabled = False
    End Sub
    Public Sub productView()
        MainController.CLIENT_DATA_VIEW.Visible = False
        MainController.PRODUCT_DATA_GRID.Visible = True
        MainController.VU_RAPPORT.Visible = False
        MainController.FORNISSEUR_DATA_GRID.Visible = False
        MainController.VU_COMMAND.Visible = False
        MainController.STOCK_LIST.Visible = False
        MainController.STOCK_MANAGER_VIEW.Visible = False
        MainController.RAPPORT_LIST_VIEW.Visible = False

        MainController.BT_DEL_PRODUCT.Enabled = False
        MainController.BT_EDIT_PRODUCT.Enabled = False

        MainController.BT_DELETE_COMMAND.Enabled = False
        MainController.BT_EDIT_COMMAND.Enabled = False

        MainController.BT_DEL_CLIENT.Enabled = False
        MainController.BT_EDIT_ClIENT.Enabled = False
    End Sub
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
    Public Sub fournisseurView()
        MainController.CLIENT_DATA_VIEW.Visible = False
        MainController.PRODUCT_DATA_GRID.Visible = False
        MainController.VU_RAPPORT.Visible = False
        MainController.FORNISSEUR_DATA_GRID.Visible = True
        MainController.VU_COMMAND.Visible = False
        MainController.STOCK_LIST.Visible = False
        MainController.STOCK_MANAGER_VIEW.Visible = False
        MainController.RAPPORT_LIST_VIEW.Visible = False

        MainController.BT_DEL_PRODUCT.Enabled = False
        MainController.BT_EDIT_PRODUCT.Enabled = False

        MainController.BT_DELETE_COMMAND.Enabled = False
        MainController.BT_EDIT_COMMAND.Enabled = False

        MainController.BT_DEL_CLIENT.Enabled = False
        MainController.BT_EDIT_ClIENT.Enabled = False
    End Sub
    Public Sub stockView()
        MainController.CLIENT_DATA_VIEW.Visible = False
        MainController.PRODUCT_DATA_GRID.Visible = False
        MainController.VU_RAPPORT.Visible = False
        MainController.FORNISSEUR_DATA_GRID.Visible = False
        MainController.VU_COMMAND.Visible = False
        MainController.STOCK_LIST.Visible = True
        MainController.STOCK_MANAGER_VIEW.Visible = False
        MainController.RAPPORT_LIST_VIEW.Visible = False

        MainController.BT_DEL_PRODUCT.Enabled = False
        MainController.BT_EDIT_PRODUCT.Enabled = False

        MainController.BT_DELETE_COMMAND.Enabled = False
        MainController.BT_EDIT_COMMAND.Enabled = False

        MainController.BT_DEL_CLIENT.Enabled = False
        MainController.BT_EDIT_ClIENT.Enabled = False
    End Sub
End Class
