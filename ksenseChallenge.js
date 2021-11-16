 $(document).ready(function () {
    $.ajax({
        type: "Get",
        url: "https://jsonplaceholder.typicode.com/users",
        contentType: "application/json; charset=utf-8",
        dataType: "json",

        success: function (response) {
            $.each(response, function (key, value) {

             <!--    /*APPEND JSON TO SELECTION OPTIONS */ -->
                $("#resultdata").append($('<option>').text(value.name).attr('value',value.id));
            });
        },
        failure: function (response) {
            alert(response.responseText);
        },
        error: function (response) {
            alert(response.responseText);
        }
    });  
});

$(document).ready(function () {
    $("#btnGet").click(function (e) {
        $("#postdata tr").remove();
        var person = $("#resultdata").val();       
        e.preventDefault();
        $.ajax({
            type: "Get",
            url: "https://jsonplaceholder.typicode.com/posts?userId=" + person,            
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (response) {

                // EXTRACT VALUE FOR HTML HEADER. 
              
                var col = [];
                for (var i = 0; i < response.length; i++) {
                    for (var key in response[i]) {
                        if (col.indexOf(key) === -1) {
                            col.push(key);
                        }
                    }
                }

                // CREATE DYNAMIC TABLE.
                var table = document.createElement("table");

                // CREATE HTML TABLE HEADER ROW USING THE EXTRACTED HEADERS ABOVE.

                var tr = table.insertRow(-1);                   // TABLE ROW.

                for (var i =2; i < col.length; i++) {
                    var th = document.createElement("th");      // TABLE HEADER.
                    th.innerHTML = col[i];
                    tr.appendChild(th);
                }

                // ADD JSON DATA TO THE TABLE AS ROWS.
                for (var i = 2; i < response.length; i++) {

                    tr = table.insertRow(-1);

                    for (var j = 2; j < col.length; j++) {
                        var tabCell = tr.insertCell(-1);
                        tabCell.innerHTML = response[i][col[j]];
                    }
                }

                //  ADD THE NEWLY CREATED TABLE WITH JSON DATA TO A CONTAINER.
                var divContainer = document.getElementById("postdata");
                divContainer.innerHTML = "";
                divContainer.appendChild(table);            
             
            },
            failure: function (response) {
                alert(response.responseText);
            },
            error: function (response) {
                alert(response.responseText);
            }
        });
    });
});