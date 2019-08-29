<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Students_JQuery.aspx.cs" Inherits="TestJScriptWebApp.Students_JQuery" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="Scripts/jquery-1.10.2.js"></script>
    <script type="text/javascript">
        $(function () {

            alert("hi");


            $("#btnStudents").click(function () {

                var apiurl = "http://localhost:8060/api/student";
                $.getJSON(apiurl).done(

                    function (data) {

                        var htmltext = "";
                        $.each(data, function (i, item) {

                            htmltext = htmltext + item.Name + ":"
                            + item.Age + ":"
                            + item.Sex + ":"
                            + item.MailID + "<br />";
                        })

                        $("#divGetStudents").html(htmltext);
                    }
                    );
            })

        })

        
    </script>
    
</head>
<body>
    <form id="form1" runat="server">
    <div id="main">
        <div id="divButton">
            <input type="button" id="btnStudents" value="GetStudents" />
        </div>
        <div id="divGetStudents">

        </div>
    </div>
    </form>
</body>
</html>
