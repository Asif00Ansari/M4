<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="UserRegistration.aspx.cs" Inherits="FleetTrack.UserRegistration" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="server">
    <div class="container">
        <h2>User Registration Form</h2>
        <table class="form">
             <tr>
                <td>Full Name</td>
                <td>
                    <asp:TextBox ID="txtFullName" CssClass="textboxs" runat="server"></asp:TextBox></td>
                 <asp:HiddenField ID="hdnUserId" runat="server" />
                <td>
                    <asp:RequiredFieldValidator ID="rfvFullName" runat="server"
                        ErrorMessage="UserName is Required" ForeColor="Red" Display="Dynamic"
                        ControlToValidate="txtFullName">

                    </asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td>User Name</td>
                <td>
                    <asp:TextBox ID="txtUserName" CssClass="textboxs" runat="server"></asp:TextBox></td>
                <td>
                    <asp:RequiredFieldValidator ID="RfvUserName" runat="server"
                        ErrorMessage="UserName is Required" ForeColor="Red"
                        ControlToValidate="txtUserName">

                    </asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td>Email Address&nbsp;</td>
                <td>
                    <asp:TextBox ID="txtEmail" CssClass="textboxs" runat="server" TextMode="Email"></asp:TextBox></td>
                <td>
                    <asp:RequiredFieldValidator ID="RfvEmail" runat="server" Display="Dynamic"
                        ErrorMessage="Email Address is Required" ForeColor="Red"
                        ControlToValidate="txtEmail">
                    </asp:RequiredFieldValidator>
                   <asp:RegularExpressionValidator ID="validateEmail"
                       runat="server" ErrorMessage="Invalid email." Display="Dynamic"
                     ControlToValidate ="txtEmail" ForeColor="Red"
                     ValidationExpression="^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$" /></td>
            </tr>
            <tr>
                <td>Password</td>
                <td>
                    <asp:TextBox ID="txtPassword" CssClass="textboxs" runat="server" TextMode="Password"></asp:TextBox></td>
                <td>
                    <asp:RequiredFieldValidator ID="RfvPassword" runat="server"
                        ErrorMessage="Password is Required" ForeColor="Red"
                        ControlToValidate="txtPassword"></asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td>Confirm Password</td>
                <td>
                    <asp:TextBox ID="txtConfirmpassword" CssClass="textboxs" runat="server" TextMode="Password"></asp:TextBox></td>
                <td>
                    <asp:CompareValidator ID="cmprConfirmPass" runat="server" Display="Dynamic"
                        ErrorMessage="Do not match password" ForeColor="Red" ControlToCompare="txtPassword"
                        ControlToValidate="txtConfirmpassword"></asp:CompareValidator>
                    <asp:RequiredFieldValidator ID="RfvConfirmPassword" runat="server"
                        ErrorMessage="Confrim your password" ForeColor="Red" Display="Dynamic"
                        ControlToValidate="txtConfirmpassword"></asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td>&nbsp;IsAdmin</td>
                <td>
                    <%--<asp:CheckBox ID="ChkStatus" runat="server" Checked="true" />--%>
                    <asp:RadioButtonList ID="rdobtnUserType" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                        <asp:ListItem Text="Is Admin" Value="1" />
                        <asp:ListItem Text="Is Driver" Value="0" />
                       
                    </asp:RadioButtonList>
                    
                </td>

                <td><asp:RequiredFieldValidator ID="rfvRole" runat="server"
                        ErrorMessage="Please select user type" ForeColor="Red"
                        ControlToValidate="rdobtnUserType"></asp:RequiredFieldValidator></td>
            </tr>
        </table>
        <div class="btns">
            <asp:Button ID="BtnDelete" CssClass="btn-danger" runat="server" Text="Delete" OnClick="BtnDelete_Click" CausesValidation="False" />
             <asp:Button ID="BtnUpdate" CssClass="btn-warning" runat="server" Text="Update" OnClick="BtnUpdate_Click" />
            <asp:Button ID="BtnSave" CssClass="btn-success" runat="server" Text="Save" OnClick="BtnSave_Click" />
        </div>
        <div class="Grid">
            <asp:GridView ID="GridView1" runat="server"
                AutoGenerateColumns="False"
                AutoGenerateSelectButton="True"
                BorderStyle="None"
                CssClass="Grid"
                EditRowStyle-ForeColor="#0066FF"
                Width="650px"
                BackColor="White"
                BorderColor="#CCCCCC"
                BorderWidth="1px"
                CellPadding="3"
                Height="20px"
                OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
                AllowPaging="True"
                PageSize="5"
                OnPageIndexChanging="GridView1_PageIndexChanging">
                <Columns>
                    <asp:BoundField DataField="UserId"
                        HeaderText="ID"
                        InsertVisible="False" ReadOnly="True"
                        SortExpression="" 
                        />
                    <asp:BoundField DataField="FullName"
                        HeaderText="Name"
                        SortExpression="FullName" />
                    <asp:BoundField DataField="UserName"
                        HeaderText="UserName"
                        SortExpression="UserName" />
                    <asp:BoundField DataField="Email"
                        HeaderText="Email-Address"
                        SortExpression="" />
                   <%-- <asp:BoundField DataField="Password"
                        HeaderText="Password"
                        SortExpression="Password" />--%>
                    <asp:BoundField DataField="UserType"
                        HeaderText="User Type"
                        SortExpression="UserType" />
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:HiddenField ID="hdnIsAdminType" runat="server" Value='<%# Eval("IsAdmin") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>

                <EditRowStyle ForeColor="#0066FF" />

                <FooterStyle BackColor="White" ForeColor="#000066" />
                <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                <RowStyle ForeColor="#000066" />
                <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                <SortedAscendingHeaderStyle BackColor="#007DBB" />
                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                <SortedDescendingHeaderStyle BackColor="#00547E" />

            </asp:GridView>
        </div>
    </div>
</asp:Content>


