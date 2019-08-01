// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(document).ready(function () {
    $('#form').submit(function (e) {
        e.preventDefault();

        //var formData = new FormData(this);
        var texto = $('#json_inicial').val();
        var $resultado = $('#resultado');
        //console.log(texto);

        $.ajax({
            url: '/Home/Firmar',
            type: "POST",
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            data: { data: texto},
            //contentType: false,
            processData: false,
            success: function (result) {
                // here in result you will get your data
                if (result.status === 200) {
                    console.log('FUNCIONA');
                    $resultado.html(result.responseText);
                } else {
                    console.log('ERROR');
                    $resultado.html('error');
                }
                
            },
            error: function (result) {
                //console.log(result);
                $resultado.html(result.responseText);
            }
        });

    });
});