﻿Public Class BasicCommand
    Private mId As Integer
    Private mDate As Date
    Private mProductList As Product
    Private mClientName As String
    Private mClientContact As String
    Private mAdresseDeLivraison As String
    Private mPrixAchat As Integer
    Private mPrixVent As Integer
    Private mQuantite As Integer
    Private mNetToPay As Integer
    Private mCommandStat As String
    Private mIdAgent As String
    Private mSource As String
    Private mLivreur As String

#Region "Constructor"
    Sub New()

    End Sub
    Sub New(productList As Product, client As String, adressDeLivraison As String, netToPay As Integer, commandStat As String, agent As String)
        mProductList = productList
        mClientName = client
        mAdresseDeLivraison = adressDeLivraison
        mNetToPay = netToPay
        mCommandStat = commandStat
        mIdAgent = agent
        mSource = ""
        mLivreur = ""
    End Sub
    Sub New(id As Integer, productList As Product, client As String, adressDeLivraison As String, netToPay As Integer, commandStat As String, agent As String)
        mId = id
        mProductList = productList
        mClientName = client
        mAdresseDeLivraison = adressDeLivraison
        mNetToPay = netToPay
        mCommandStat = commandStat
        mIdAgent = agent
        mSource = ""
        mLivreur = ""
    End Sub
    Sub New(id As Integer, idate As Date, productList As Product, client As String, adressDeLivraison As String, netToPay As Integer, commandStat As String, agent As String)
        mId = id
        mDate = idate
        mProductList = productList
        mClientName = client
        mAdresseDeLivraison = adressDeLivraison
        mNetToPay = netToPay
        mCommandStat = commandStat
        mIdAgent = agent
        mSource = ""
        mLivreur = ""
    End Sub
    Sub New(id As Integer, idate As Date, productList As Product, client As String, adressDeLivraison As String, netToPay As Integer, commandStat As String, agent As String, livreur As String)
        mId = id
        mDate = idate
        mProductList = productList
        mClientName = client
        mAdresseDeLivraison = adressDeLivraison
        mNetToPay = netToPay
        mCommandStat = commandStat
        mIdAgent = agent
        mSource = ""
        mLivreur = livreur
    End Sub
#End Region

#Region "SETTER"
    Private Sub setId(id As Integer)
        mId = id
    End Sub
    Public Sub setQuantite(quantie As Integer)
        mQuantite = quantie
    End Sub
    Public Sub setDate(idate As Date)
        mDate = idate
    End Sub
    Public Sub setProduct(productList As Product)
        mProductList = productList
    End Sub
    Public Sub setClientName(clientName As String)
        mClientName = clientName
    End Sub
    Public Sub setClientContact(clientContact As String)
        mClientContact = clientContact
    End Sub
    Public Sub setAdressLivraison(adress As String)
        mAdresseDeLivraison = adress
    End Sub
    Public Sub setNetToPay(netToPay As Integer)
        mNetToPay = netToPay
    End Sub
    Public Sub setCommandStat(commandStat As String)
        mCommandStat = commandStat
    End Sub
    Public Sub setAgent(agent As String)
        mIdAgent = agent
    End Sub
    Public Sub setSource(source As String)
        mSource = source
    End Sub
    Public Sub setLivreur(livreur As String)
        mLivreur = livreur
    End Sub
#End Region

#Region "GETTER"
    Public Function getId() As Integer
        Return mId
    End Function
    Public Function getQuantite() As Integer
        Return mQuantite
    End Function
    Public Function getDate() As Date
        Return mDate
    End Function
    Public Function getPoduct() As Product
        Return mProductList
    End Function
    Public Function getClientName() As String
        Return mClientName
    End Function
    Public Function getClientContact() As String
        Return mClientContact
    End Function
    Public Function getAdressLivraison() As String
        Return mAdresseDeLivraison
    End Function
    Public Function getNetToPay() As Integer
        Return mNetToPay
    End Function
    Public Function getCommandStat() As String
        Return mCommandStat
    End Function
    Public Function getAgent() As String
        Return mIdAgent
    End Function
    Public Function getSource() As String
        Return mSource
    End Function
    Public Function getLivreur() As String
        Return mLivreur
    End Function
#End Region
End Class
