<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="PDF_Splitter.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>PDF Splitter | yash-waghadhare</title>
    <script src="BotFiles/bootstrap.bundle.min.js"></script>
    <link href="BotFiles/bootstrap.min.css" rel="stylesheet" />
    <link href="style.css" rel="stylesheet" />
</head>
<body class="bg-dark text-white">
    <%--start of header--%>
    <header class="p-3 bg-dark text-white">
        <div class="container">
            <div class="d-flex flex-wrap align-items-center justify-content-center justify-content-lg-start">
                <a href="/" class="d-flex align-items-center mb-2 mb-lg-0 text-white text-decoration-none">
                    <svg class="bi me-2" width="40" height="32" role="img" aria-label="Bootstrap">
                        <use xlink:href="#bootstrap"></use></svg>
                </a>
                <ul class="nav col-12 col-lg-auto me-lg-auto mb-2 justify-content-center mb-md-0">
 <li><a href="index.aspx" class="nav-link px-2 text-white">Home</a></li>
                    <li><a href="https://wa.me/message/Z6MB2AWXF7RCI1" class="nav-link px-2 text-white">Contact</a></li>
                    <li><a href="https://yashwaghadhare.github.io/Personal_portfolio"
                            class="nav-link px-2 text-white">Portfolio</a></li>
                    <li><a href="https://yashwaghadhare.github.io/SnakkeGame/"
                            class="nav-link px-2 text-white">PlayGame</a></li>
                </ul>
                <form class="col-12 col-lg-auto mb-3 mb-lg-0 me-lg-3">
                    <input type="search" class="form-control form-control-dark" placeholder="Search..." aria-label="Search">
                </form>
                <div class="text-end">
                    <button type="button" class="btn btn-outline-light me-2">Login</button>
                    <button type="button" class="btn btn-warning">Sign-up</button>
                </div>
            </div>
        </div>
        <hr class="text-white"/>
    </header>
    <%--end of header--%>



    <%-- design part most dangeorus --%>
    <div class="d-flex justify-content-center"">
        <div class="book">
            <%-- for frount change --%>
            <form class=" cover-back d-flex justify-content-center" id="form2" runat="server">
                <div>
                    <asp:FileUpload class="form-control bg-dark text-white" type="file" ID="fileUpload" runat="server" /><br />
                    <asp:TextBox Placeholder="Split range (e.g., 2-4)" ID="txtSplitRange" class="input text-white" name="text" type="text" runat="server"/><hr class="text-white"/>
                     <asp:Button ID="btnSplit" class="btn btn-dark" runat="server" Text="Split" OnClick="btnSplit_Click" />
                    <asp:Button ID="btnDownload" class="btn btn-dark"  runat="server" Text="Download" OnClick="btnDownload_Click" Visible="false" />
                </div>
            </form>

            <%-- for frount --%>
            <div class="cover d-flex justify-content-center">                
                <img src="img/book.gif"/>
            </div>
            
                
        </div>
    </div>

    <%-- end design part most dangeorus --%>

</body>
</html>
