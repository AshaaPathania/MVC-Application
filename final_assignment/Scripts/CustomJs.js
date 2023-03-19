window.setTimeout(function () {
    $(".alert").fadeTO(500, 0).slideUP(500, function () {
        $(this).remove();
    });
}, 4000);