<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Students.aspx.cs" Inherits="TestJScriptWebApp.Students" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript">
        function test()
        {
            alert("hi");
        }

        function FuncGetStudents()
        {
            alert("getstudents");

            var htmltext="";
            var div = document.getElementById("students");
            
            var request = new XMLHttpRequest()

            request.open('GET', 'http://localhost:8060/api/student', true)

            alert('on request');
            request.onload = function () {
                
                // Begin accessing JSON data here
                var data = JSON.parse(this.response)

                if (request.status >= 200 && request.status < 400) {

                    
                    data.forEach(student => {
                        htmltext = htmltext + student.Name + ":"
                        + student.Age+":"
                        + student.Sex+":"
                        + student.MailID
                        +"<br />"
                    })

                    div.innerHTML = htmltext;
                } else {
                    alert('eror');
                }
            }

            request.send();

            }          
        
    </script>
</head>
<body onload="test()">
    <form id="form1" runat="server">
    <div id="main">

        <div id="button">
            <input id="btnStudents" type="button" value="Getstudents" onclick="FuncGetStudents()" />
        </div>
        <div id="students">


        </div>
    
    </div>

    </form>
</body>
</html>
