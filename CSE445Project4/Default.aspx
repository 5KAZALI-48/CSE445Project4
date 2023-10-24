<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CSE445Project4._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

   <asp:Panel ID="serviceTitle" runat="server" HorizontalAlign="Center">
        <h3><b>XML Service Page</b></h3>
        
    </asp:Panel>

        <h4><b>Description</b></h4>
        <hr />
        <h4>Created an XML file Parks.xml as an instance of provided schema file as requested by project. 
            Also Performing pre-order and post-order functions to treverse given XML files.</h4>
        <br />
        <hr />
        <asp:Label Text="Enter URL Here:" runat="server" />
        <asp:TextBox ID="urlInput" Width="400" runat="server" />
        <asp:Button ID="submitBtn" OnClick="submitBtn_Click" Text="Submit" runat="server" />
        <h><b>or</b></h>
        <asp:Button ID="ParkBtn" Text="Click to Test" OnClick="ParkBtn_Click" runat="server" />  

    <asp:Panel runat="server" ID="outputPanel" CssClass="jumbotron" BorderWidth="3">
        <h4><b> Data Presentation</b></h4>
        <hr />
        <h4>XML Pre-order:</h4>
        <br />
        <asp:Label ID="preText" Text="preorder" runat="server" />
        <hr />
        <h4>XML Post-order:</h4>
        <br />
        <asp:Label ID="postText" Text="postorder" runat="server" />
    </asp:Panel>
    <hr />
    
</asp:Content>
