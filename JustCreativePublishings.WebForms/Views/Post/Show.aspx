<%@ Page Title="Post details" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Show.aspx.cs" Inherits="JustCreativePublishings.WebForms.Views.Post.Show" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="col-md-12">
    <asp:FormView runat="server" CssClass="table" ID="postDetails" ItemType="JustCreativePublishings.Domain.Entities.Post" SelectMethod="GetPost">
        <ItemTemplate>
            <div class="panel panel-info">
                <div class="panel-heading">
                    <div class="panel-title">
                        <h2>
                            <%# Item.Title %>
                            <asp:Button runat="server" onclick="DeletePost" CssClass="btn btn-danger" Text="Delete"/>
                        </h2>          
                    </div>
                </div>
                <div class="panel-body">
                    <blockquote>
                        <p>Created: <%#: Item.CreationDate.ToLocalTime().ToLongDateString() %> <%#:  Item.CreationDate.ToLocalTime().ToLongTimeString() %></p>
                        <p>Updated: <%#: Item.LastUpdateDate.ToLocalTime().ToLongDateString() %> <%# Item.LastUpdateDate.ToLocalTime().ToLongTimeString() %></p>
                        <p><%#: Item.ShortDescription %></p>
                    </blockquote>

                    <div class="chapters">
                        <asp:ListView runat="server"  DataMember="Chapters" ID="chaptersList" SelectMethod="GetChapters" ItemType="JustCreativePublishings.Domain.Entities.Chapter">
                            <ItemTemplate>
                                <div class="panel panel-primary">
                                    <div class="panel-heading">
                                        <h2><%#: Item.OrderNumber %>. <%#: Item.Title %></h2>
                                    </div>
                                    <div class="panel-body">
                                        <%#: Item.Content %>
                                    </div>
                                </div>
                            </ItemTemplate>
                        </asp:ListView>
                    </div>
                </div>
                <div class="panel-footer">
                    <div class="row">
                        <div class="col-md-6">
                            <asp:ListView runat="server" DataMember="Tags" ID="tagsList" SelectMethod="GetTags" ItemType="JustCreativePublishings.Domain.Entities.Tag">
                                <ItemTemplate>
                                    <span class="badge"><a href="/Views/Post/List.aspx?tagId=<%#:Item.Id%>"><%# Item.Content %> [<%#: Item.Posts.Count %>]</a></span>
                                </ItemTemplate>
                            </asp:ListView>
                        </div>
                        <div class="col-md-6">
                            <h4 class="pull-right">Author: Author</h4>
                        </div>
                    </div>
            
                </div>
            </div>            
        </ItemTemplate>
    </asp:FormView>
</div>
</asp:Content>

