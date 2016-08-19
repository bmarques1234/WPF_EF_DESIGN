$(document).ready(function () {
    $(".client").on("click", function () {
        var data = parseInt($(this).data("client"),10);
        var partialViewClient = $.ajax({
            type: "GET",
            url: '/Home/SearchClientByID',
            data: {ID: data},
            success: function () {
                $("#ClientInfo").html(partialViewClient.responseText);
            }
        });
        var partialViewContact = $.ajax({
            type: "GET",
            url: '/Home/SearchContact',
            data: { cliId: data },
            success: function () {
                $("#ContactTab").html(partialViewContact.responseText);
            }
        });
        //window.location.href = '/Home/SearchClientByID/' + data;
        //window.location.href = '/Home/DeleteClient/' + data;
    });
    $("#ContactTab").on("click", ".page", function () {
        $(".page").parent().removeClass("active");
        $(this).parent().addClass("active");
        var data = parseInt($(this).data("id"), 10);
        var partialView = $.ajax({
            type: "GET",
            url: '/Home/SearchContactByID',
            data: { ID: data },
            success: function () {
                $("#ContactInfo").html(partialView.responseText);
            }
        });
    });
    $("#BtnNewClient").on("click", function () {
        window.location.href = '/Home/CreateClient/';
    });
    $("#BtnDeleteClient").on("click", function () {
        if ($("#clientName").data("ID") != "") {
            window.location.href = '/Home/DeleteClient/' + parseInt($("#clientName").data("id"),10);
        }
    });
    $("#ContactTab").on("click", "#BtnNewContact", function () {
        if ($("#clientName").data("id") != "") {
            //window.location.href = '/Home/CreateContact/' + parseInt($("#clientName").data("id"), 10);
            var partialView = $.ajax({
                type: "GET",
                url: "/Home/CreateContact",
                data: { Id: parseInt($("#clientName").data("id")) },
                success: function () {
                    $("#ContactTab").html(partialView.responseText);
                }
            });
        }
    });
    $("#ContactTab").on("click", "#BtnDeleteContact", function () {
        if ($(this).data("id") != "") {
            //@Url.Action("DeleteContact", "Home", new { @cliId = parseInt($("#clientName").data("id"), 10), @conId = parseInt($(this).data("id"), 10)});
            //window.location.href = '/Home/DeleteContact/?cliId=' + parseInt($("#clientName").data("id"), 10) + '&conId=' + parseInt($(this).data("id"), 10);
            var partialView = $.ajax({
                type: "GET",
                url: "/Home/DeleteContact",
                data: { cliId: parseInt($("#clientName").data("id")), conId: parseInt($("#BtnDeleteContact").data("id")) },
                success: function () {
                    $("#ContactTab").html(partialView.responseText);
                }
            });
        }
    });

//    $("#BtnSave").on("click", function () {
//        if ($("#clientName").data("ID") != "") {
//            var cli = {
//                Id: /*parseInt($("#clientName").data("id"), 10)*/38,
//                Nome: /*$("#textBoxNome").val()*/"Queror",
//                Endereco: "ivotis",
//                Cidade: "",
//                Estado: "",
//                Telefone: "",
//                Obs: ""};
//            //cli.Contatos = [];
//            //console.log(cli);
//            $.ajax({
//                url: "/Home/SaveClient",
//                type: "GET",
//                dataType: 'json',
//                //data: {
//              //    Id: /*parseInt($("#clientName").data("id"), 10)*/38,
//              //    Nome: /*$("#textBoxNome").val()*/"Queror",
//              //    Endereco: "ivotis",
//              //    Cidade: "",
//                //    Estado: "",
//               //    Telefone: "",
//                //    Obs: ""},
//                data: {cliObj: cli},
//                //data: {teste: "testando"},
//                //data: JSON.stringify({cliObj: cli}),
//                contentType: "application/json; charset = utf-8",
//                success: function () {
//                    alert("olar");
//                },
//                error: function () {
//                    alert("errar");
//                }
//            });
//        }
//    });
});