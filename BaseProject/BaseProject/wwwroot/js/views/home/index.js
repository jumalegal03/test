var HomeManagement = function () {

    var home = {
        init: function () {
            $(".btn-download").on('click', function () {
                var $btn = $(this);
                var id = $btn.data('id');
                window.open(`/descargar-comunicado/pdf/${id}`.proto().parseURL(), '_blank');
            });
        }
    };
    return {
        init: function () {
            home.init();
        }
    }
}();

$(function () {
    HomeManagement.init();
});