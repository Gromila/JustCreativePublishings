<%@ Page Title="Add post" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Add.aspx.cs" Inherits="JustCreativePublishings.WebForms.Views.Post.Add" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
        <div class="form-group">
            <label for="TitleTb">Title:</label>
            <asp:TextBox ID="TitleTb" CssClass="form-control" runat="server"></asp:TextBox>
        </div>
        <div class="form-group">
            <label for="ShortDescription">ShortDescription:</label>
            <asp:TextBox ID="ShortDescription" TextMode="MultiLine" CssClass="form-control" runat="server"></asp:TextBox>
        </div>
        <div class="form-group">
            <label for="Tags">Tags:</label>
            <asp:TextBox ID="Tags" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="panel panel-info">
            <div class="panel-heading">
                <div class="panel-title">Chapter 1</div>
            </div>
            <div class="panel-body">
                <div class="form-group">
                    <label for="Chapter1Title">Title:</label>
                    <asp:TextBox ID="Chapter1Title" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label for="Chapter1Content">Content:</label>
                    <asp:TextBox ID="Chapter1Content" TextMode="MultiLine" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
        </div>
        <div class="panel panel-info">
            <div class="panel-heading">
                <div class="panel-title">Chapter 2</div>
            </div>
            <div class="panel-body">
                <div class="form-group">
                    <label for="Chapter2Title">Title:</label>
                    <asp:TextBox ID="Chapter2Title" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label for="Chapter2.Content">Content:</label>
                    <asp:TextBox ID="Chapter2Content" TextMode="MultiLine" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
        </div>
        <asp:Button CssClass="btn btn-primary" runat="server" Text="Submit" OnClick="SubmitForm"/>
</asp:Content>

