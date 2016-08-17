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
    $("#BtnSave").on("click", function () {
        if ($("#clientName").data("ID") != "") {
            /*var cli = {};
            cli.Id = parseInt($("#clientName").data("id"), 10);
            cli.Nome = $("#textBoxNome").val();
            cli.Endereco = "ivotis";
            cli.Cidade = "";
            cli.Estado = "";
            cli.Telefone = "";
            cli.Obs = "";
            //cli.Contatos = [];
            console.log(cli);*/
            $.ajax({
                url: "/Home/SaveClient",
                type: "GET",
                dataType: 'json',
                data: {
                    Id: parseInt($("#clientName").data("id"), 10),
                    Nome: $("#textBoxNome").val(),
                    Endereco: "ivotis",
                    Cidade: "",
                    Estado: "",
                    Telefone: "",
                    Obs: ""
                },
                success: function () {
                    alert("olar");
                },
                error: function () {
                    alert("errar");
                }
            });
        }
    });
});