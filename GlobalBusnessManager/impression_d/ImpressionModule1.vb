Module ImpressionModule1
    Dim bmp As Bitmap
    Public Function impressionRappor(dataGrid As DataGridView) As Bitmap
        'bmp = New Bitmap()
        Dim heith_d As Integer
        Dim whith_d As Integer
        heith_d = dataGrid.Height
        whith_d = dataGrid.Width

        'dataGrid.Height = dataGrid.RowCount * dataGrid.RowTemplate.Height

        bmp = New Bitmap(whith_d, heith_d)
        dataGrid.DrawToBitmap(bmp, New Rectangle(10, 10, whith_d - 10, dataGrid.Height - 10))
        dataGrid.Height = heith_d
        MainController.PrintDocument.DefaultPageSettings.Landscape = False
        'PrintDocument1.Print()
        MainController.PrintPreviewDialog.Document = MainController.PrintDocument
        MainController.PrintPreviewDialog.ShowDialog()
        Return bmp
    End Function
End Module
