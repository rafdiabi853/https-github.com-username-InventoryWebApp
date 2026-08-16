<%@ Page Title="Register" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="InventoryWebApp.Register" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row justify-content-center mt-5">
        <div class="col-md-5">
            <div class="card shadow border-0">
                <div class="card-body p-4">
                    <h3 class="card-title text-center mb-4 fw-bold">Daftar Akun Baru</h3>

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

                    <div class="mb-3">
                        <label class="form-label">Konfirmasi Password</label>
                        <asp:TextBox ID="txtConfirmPassword" runat="server" TextMode="Password" CssClass="form-control" placeholder="Ulangi password"></asp:TextBox>
                    </div>

                    <div class="mb-3">
                        <label class="form-label">Role / Peran</label>
                        <asp:DropDownList ID="ddlRole" runat="server" CssClass="form-select">
                            <asp:ListItem Value="staff">Staff</asp:ListItem>
                            <asp:ListItem Value="admin">Admin</asp:ListItem>
                        </asp:DropDownList>
                    </div>

                    <div class="d-grid gap-2 mt-4">
                        <asp:Button ID="btnRegister" runat="server" Text="Daftar Sekarang" CssClass="btn btn-success" OnClick="btnRegister_Click" />
                    </div>

                    <div class="text-center mt-3">
                        <small>Sudah punya akun? <a href="Login.aspx">Login di sini</a></small>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>