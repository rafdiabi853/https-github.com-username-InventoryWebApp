<%@ Page Title="Login" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="InventoryWebApp.Login" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row justify-content-center mt-5">
        <div class="col-md-4">
            <div class="card shadow border-0">
                <div class="card-body p-4">
                    <h3 class="card-title text-center mb-4 fw-bold">Login Sistem</h3>

                    <asp:Panel ID="pnlAlert" runat="server" Visible="false" role="alert">
                        <asp:Label ID="lblMessage" runat="server"></asp:Label>
                    </asp:Panel>

                    <div class="mb-3">
                        <label class="form-label">Username</label>
                        <asp:TextBox ID="txtUsername" runat="server" CssClass="form-control" placeholder="Masukkan username"></asp:TextBox>
                    </div>

                    <div class="mb-3">
                        <label class="form-label">Password</label>
                        <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="form-control" placeholder="Masukkan password"></asp:TextBox>
                    </div>

                    <div class="d-grid gap-2 mt-4">
                        <asp:Button ID="btnLogin" runat="server" Text="Login" CssClass="btn btn-primary" OnClick="btnLogin_Click" />
                    </div>

                    <div class="text-center mt-3">
                        <small>Belum punya akun? <a href="Register.aspx">Daftar di sini</a></small>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>