$(document).ready(function () {
    $(".client").on("click", function () {
        var data = $(this).data("client");
        window.location.href = '/Home/SearchClientByID/' + data;
        //window.location.href = '/Home/DeleteClient/' + data;
    });
    $("#BtnNewClient").on("click", function () {
        window.location.href = '/Home/CreateClient/';
    });
    $("#BtnDeleteClient").on("click", function () {
        console.log("ID" + $("#clientName").data("ID"));
        if ($("#clientName").data("ID") != "") {
            window.location.href = '/Home/DeleteClient/' + $("#clientName").data("id");
        }
    });
    $("#BtnNewContact").on("click", function () {
        if ($("#clientName").data("ID") != "") {
            window.location.href = '/Home/CreateContact/' + parseInt($("#clientName").data("id"), 10);
        }
    });
    $(".BtnDeleteContact").on("click", function () {
        if ($("#clientName").data("ID") != "") {
            window.location.href = '/Home/DeleteContact/' + parseInt($("#clientName").data("id"), 10) + '/' + parseInt($(this).data("id"), 10);
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