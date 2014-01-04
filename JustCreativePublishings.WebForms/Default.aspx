<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="JustCreativePublishings.WebForms._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="col-md-4">
        <div class="panel panel-primary">
            <div class="panel-heading">
                <div class="panel-title">
                    <h3>Tags</h3>
                </div>
            </div>
            <div class="panel-body">
                <asp:ListView runat="server" DataKeyNames="Id" ID="tagsList" SelectMethod="GetTags" ItemType="JustCreativePublishings.Domain.Entities.Tag">
                    <ItemTemplate>
                        <span class="badge"><a href="/Views/Post/List.aspx?tagId=<%#:Item.Id%>"><%# Item.Content %> [<%#: Item.Posts.Count %>]</a></span>
                    </ItemTemplate>
                </asp:ListView>
            </div>
        </div>
    </div>
    <div class="col-md-8">
        <div class="panel panel-primary">
            <div class="panel-heading">
                <div class="panel-title">
                    <h3>Top posts</h3>
                </div>
            </div>
            <div class="panel-body">
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
            </div>
        </div>        
    </div>
</asp:Content>
