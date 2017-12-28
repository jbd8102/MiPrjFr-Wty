<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TestModal.aspx.cs" Inherits="Demo.WhoIs.WebUI.TestModal" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <title>Test modal</title>
    <link rel="stylesheet" href="Scripts/Bis/jquery-ui.css" />
    <script type="text/javascript" src="Scripts/Bis/jquery-1.9.1.js" charset="UTF-8"></script>
    <script type="text/javascript" src="Scripts/Bis/jquery-ui.js" charset="UTF-8"></script>

    <script>
        $(function () {
            $("#divTest").dialog({
                modal: true,
                resizable: false,
                buttons: {
                    "Yeah!": function () {
                        $(this).dialog("close");
                    },
                    "Sure, Why Not": function () {
                        $(this).dialog("close");
                    }
                }
            });
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div id="divTest">
            <p>Hey, me just met you, and this is crazy<br />
			But you got cookie, so share it maybe?</p>
        </div>        
    </form>
</body>
</html>
