<%@ Page Title="" Language="C#" MasterPageFile="~/caixeiro.Master" AutoEventWireup="true" CodeBehind="caixeiro.aspx.cs" Inherits="CaixeiroViajante.view.caixeiro" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <fieldset style="height: 220px;">
        <legend>Configurações</legend>
        <div style="float: left; width: 45%;">
            <asp:Label ID="lbCidade" runat="server" Text="Capital de Origem" CssClass="label"></asp:Label><br />
            <asp:DropDownList ID="dpdCidade" runat="server" CssClass="input"></asp:DropDownList><br />
        </div>
        <div style="float: left; width: 45%;">
            <asp:Label ID="lbPorpulacao" runat="server" Text="População" CssClass="label"></asp:Label><br />
            <asp:TextBox ID="txtPopulacao" runat="server" Text="500" CssClass="input"></asp:TextBox><br />
        </div>
        <div style="float: left; width: 45%;">
            <asp:Label ID="lbFatorCruzamento" runat="server" Text="Fator de Cruzamento" CssClass="label"></asp:Label><br />
            <asp:DropDownList ID="dpdFatorCruzamento" runat="server" CssClass="input">
                <asp:ListItem>5</asp:ListItem>
                <asp:ListItem>6</asp:ListItem>
                <asp:ListItem>7</asp:ListItem>
                <asp:ListItem>8</asp:ListItem>
                <asp:ListItem>9</asp:ListItem>
                <asp:ListItem>10</asp:ListItem>
                <asp:ListItem>11</asp:ListItem>
                <asp:ListItem Selected="True">12</asp:ListItem>
                <asp:ListItem>13</asp:ListItem>
                <asp:ListItem>14</asp:ListItem>
                <asp:ListItem>15</asp:ListItem>
                <asp:ListItem>16</asp:ListItem>
                <asp:ListItem>17</asp:ListItem>
                <asp:ListItem>18</asp:ListItem>
                <asp:ListItem>19</asp:ListItem>
                <asp:ListItem>20</asp:ListItem>
            </asp:DropDownList><br />
        </div>
        <div style="float: left; width: 45%;">
            <asp:Label ID="lbNumeroEras" runat="server" Text="Número de Eras" CssClass="label"></asp:Label><br />
            <asp:TextBox ID="txtNumeroDeEras" runat="server" Text="300" CssClass="input"></asp:TextBox><br />
        </div>
        <div style="float: left; width: 45%;">
            <asp:Label ID="lbFatorMutacao" runat="server" Text="Fator Mutação" CssClass="label"></asp:Label><br />
            <asp:DropDownList ID="dpdFatorMutacao" runat="server" CssClass="input">
                <asp:ListItem Selected="True">0.3</asp:ListItem>
                <asp:ListItem>0.3</asp:ListItem>
                <asp:ListItem>0.4</asp:ListItem>
                <asp:ListItem>0.5</asp:ListItem>
                <asp:ListItem>0.6</asp:ListItem>
                <asp:ListItem>0.7</asp:ListItem>
                <asp:ListItem>0.8</asp:ListItem>
                <asp:ListItem>0.9</asp:ListItem>
                <asp:ListItem>1.0</asp:ListItem>
            </asp:DropDownList><br />
        </div>
        <div style="float: left; width: 90%; padding-top: 5px; padding-right: 5px;">
            <asp:Button ID="btnProcessar" runat="server" Text="Gerar Rota" CssClass="button" OnClick="btnProcessar_Click" /><br />
            <asp:Label ID="lbTempoAlgoritmo" runat="server" Text="" CssClass="label label-green"></asp:Label>
        </div>
    </fieldset>
    <fieldset style="height: 520px;">
        <legend>Resultado</legend>
        <div style="border-right: solid 1px; border-color: #808080; float: left; width: 180px; height: 445px;">
            <asp:GridView ID="grvPercurso" runat="server" AutoGenerateColumns="true" HeaderStyle-ForeColor="#1328ec">
            </asp:GridView>
        </div>
        <div style="float: left; width: 630px; height: 445px; padding-left: 20px;">
            <asp:Label ID="lbCapitalOrigemDestino" runat="server" Text="Capital Origem/Destino: " CssClass="label label-blue"></asp:Label><br />
            <br />
            <asp:Label ID="lbCapitaisPercorridas" runat="server" Text="Capitais Percorridas..: " CssClass="label label-blue"></asp:Label><br />
            <br />
            <asp:Label ID="lbTotalDistancia" runat="server" Text="Distância Total..: 0km" CssClass="label label-red"></asp:Label><br />
            <asp:Label ID="lbErro" runat="server" Text="" CssClass="label label-green"></asp:Label><br />
        </div>
    </fieldset>
</asp:Content>
