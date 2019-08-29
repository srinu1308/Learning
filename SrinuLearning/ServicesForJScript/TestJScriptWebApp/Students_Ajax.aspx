<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Students_Ajax.aspx.cs" Inherits="TestJScriptWebApp.Students_Ajax" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="Scripts/jquery-1.10.2.js"></script>
    <script type="text/javascript">

        $(function()
        {
            alert("hi");

            $("#btnGetStudents").click(
                function () {
                    
                    $.ajax(
                        {
                            type: "GET",
                            url: "http://localhost:8060/api/student",
                            data: {},
                            contentType: "application/json; charset=utf-8",
                            dataType: "json",
                            success: function(response)
                            {
                                var text = "";
                                $.each(response,function(index, emp)
                                {
                                    text = text + emp.Name + ":"
                                    + emp.Age + ":"
                                    + emp.Sex + ":"
                                    + emp.MailID + "<br />";                                    
                                })

                                $("#divGetStudents").html(text);
                            },
                            complete: function()
                            {
                                alert("completed");
                            },
                            failure: function (jqXHR, textStatus, errorThrown) {
                                alert("HTTP Status: " + jqXHR.status + "; Error Text: " + jqXHR.responseText); // Display error message  
                            }
                        })

                }
                );
            
        })

    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div id="main">
        <div id="divbutton">
            <input type="button" value="GetStudents" id="btnGetStudents" />
        </div>
        <div id="divGetStudents">

        </div>
    </div>
    </form>
</body>
</html>
