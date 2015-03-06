<%@ Page Title="About Us" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="Munchies.About" %>
<%@ OutputCache Duration="3600" VaryByParam="none" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-md-12">
            <h2><%: Title %></h2>
            <h3>Munchies.be is designed to make your, and our, lives much easier.</h3>
            <p>
                To do that, we provide a simple service which enables you to find and order delicious food near you.
                Of course, we try to convince restaurants to deliver the food at your doorstep, which is even better!
            </p>
            <p>
                If you own a restaurant and want to work together with us, then <a href="/Contact">get in touch</a> and we'll get you started as soon as possible.
            </p>
            <br/><br/>
            <h6>Rendered on <%= DateTime.Now.ToString("dd/MM/yyyy \"at\" HH:mm:ss") %></h6>
        </div>
    </div>
</asp:Content>
