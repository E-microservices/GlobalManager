Public Class Rapport
    Private mId As Integer
    Private mDate As String
    Private mClientName As String
    Private mContact As String
    Private mAdresseLivarison As String
    Private mProduitName As String
    Private mPrixAchat As Integer
    Private mPrixVente As Integer
    Private mQuanite As Integer
    Private mBenefice As Integer
    Private mAgentFacteur As String
    Private mAcquisition As String
    Private mLivreur As String
    Sub New()

    End Sub
    Sub New(idate As Date, clientName As String, contact As String, adresseLivraison As String, productName As String, prixAchat As Integer, prixVente As Integer, quantite As Integer, benefice As Integer, agentFacteur As String, aquisition As String)
        mDate = idate.ToShortDateString
        mClientName = clientName
        mContact = contact
        mAdresseLivarison = adresseLivraison
        mProduitName = productName
        mPrixAchat = prixAchat
        mPrixVente = prixVente
        mQuanite = quantite
        mBenefice = benefice
        mAgentFacteur = agentFacteur
        mAcquisition = aquisition
        mLivreur = ""
    End Sub
    Sub New(id As Integer, idate As Date, clientName As String, contact As String, adresseLivraison As String, productName As String, prixAchat As Integer, prixVente As Integer, quantite As Integer, benefice As Integer, agentFacteur As String, aquisition As String)
        mId = id
        mDate = idate.ToShortDateString
        mClientName = clientName
        mContact = contact
        mAdresseLivarison = adresseLivraison
        mProduitName = productName
        mPrixAchat = prixAchat
        mPrixVente = prixVente
        mQuanite = quantite
        mBenefice = benefice
        mAgentFacteur = agentFacteur
        mAcquisition = aquisition
        mLivreur = ""
    End Sub
    Sub New(id As Integer, idate As Date, clientName As String, contact As String, adresseLivraison As String, productName As String, prixAchat As Integer, prixVente As Integer, quantite As Integer, benefice As Integer, agentFacteur As String, aquisition As String, livreur As String)
        mId = id
        mDate = idate.ToShortDateString
        mClientName = clientName
        mContact = contact
        mAdresseLivarison = adresseLivraison
        mProduitName = productName
        mPrixAchat = prixAchat
        mPrixVente = prixVente
        mQuanite = quantite
        mBenefice = benefice
        mAgentFacteur = agentFacteur
        mAcquisition = aquisition
        mLivreur = livreur
    End Sub

    Private Sub setId(id As Integer)
        mId = id
    End Sub
    Public Sub setDate(idate As Date)
        mDate = idate.ToShortDateString
    End Sub
    Public Sub setClientName(name As String)
        mClientName = name
    End Sub
    Public Sub setContact(contact As String)
        mContact = contact
    End Sub
    Public Sub setAdresseLivarison(adresse As String)
        mAdresseLivarison = adresse
    End Sub
    Public Sub setProductName(name As String)
        mProduitName = name
    End Sub
    Public Sub setPrixAchat(prixAchat As Integer)
        mPrixAchat = prixAchat
    End Sub
    Public Sub setPrixVente(prixVent As Integer)
        mPrixAchat = prixVent
    End Sub
    Public Sub setQuantite(quantite As Integer)
        mQuanite = quantite
    End Sub
    Public Sub setBenefice(benefice As Integer)
        mBenefice = benefice

    End Sub
    Public Sub setAgentFacteur(agentFacteur As String)
        mAgentFacteur = agentFacteur
    End Sub
    Public Sub setAquition(aquisition As String)
        mAcquisition = aquisition
    End Sub
    Public Sub setLivreur(livreur As String)
        mLivreur = livreur
    End Sub

    Public Function getId() As Integer
        Return mId
    End Function
    Public Function getDate() As String
        Return mDate
    End Function
    Public Function getClientName() As String
        Return mClientName
    End Function
    Public Function getContact() As String
        Return mContact
    End Function
    Public Function getAdresseLivraison() As String
        Return mAdresseLivarison
    End Function
    Public Function getProductName() As String
        Return mProduitName
    End Function
    Public Function getPrixAchat() As Integer
        Return mPrixAchat
    End Function
    Public Function getPrixVente() As Integer
        Return mPrixVente
    End Function
    Public Function getQuantite() As Integer
        Return mQuanite
    End Function
    Public Function getBenefice() As Integer
        Return mBenefice
    End Function
    Public Function getAgentFacteur() As String
        Return mAgentFacteur
    End Function
    Public Function getSource() As String
        Return mAcquisition
    End Function
    Public Function getLivreur() As String
        Return mLivreur
    End Function
End Class
