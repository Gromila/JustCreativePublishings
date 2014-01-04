<%@ Page Title="Last Posts" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="JustCreativePublishings.WebForms.Views.Post.List" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <section style="text-align: center; background-color: #fff">
        <div class="list-group">
            <asp:ListView runat="server" ID="postsList" DataKeyNames="Id" ItemType="JustCreativePublishings.Domain.Entities.Post" SelectMethod="GetPosts">
                <ItemTemplate>
                    <b style="font-size: large; font-style: normal;">
                        <a href="/Views/Post/Show.aspx?id=<%#: Item.Id %>" class="list-group-item">
                            <h4 class="list-group-item-heading"><%#: Item.Title %></h4>
                            <p class="list-group-item-text"><%#: Item.ShortDescription %></p>
                        </a>
                    </b>
                </ItemTemplate>
            </asp:ListView>
        </div>
    </section>

</asp:Content>
