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

    var productDatatable = null;

    var options = {
        responsive: true,
        processing: true,
        serverSide: true,
        bFilter: false,
        ajax: {
            url: "/get-productos".proto().parseURL(),
            data: function (d) {
                delete d.columns;
                d.category = $("#category-filter").val();
                d.search = $("#search").val().toUpperCase();
            }
        },
        columns: [
            {
                title: "Imagen",
                data: null,
                orderable: false,
                render: function (data, type, row) {
                    var tmp = "";
                    if (row.img)
                        tmp += `<img src="${row.img}" width="50px" />`;
                    else
                        tmp += `<img src="/assets/css/images/img-default.png" width="50px" />`;
                    return tmp;
                }
            },
            { title: "Nombre", data: "name" },
            { title: "Descripción", data: "description" },
            {
                title: "Precio",
                data: null,
                render: function (data, type, row, meta) {
                    var render = "";
                    render += "S/. " + row.amount.toFixed(2);
                    return render;
                },
            },
            { title: "Stock", data: "stock" },
            { title: "Categoría", data: "category" },
            {
                title: "Opciones",
                data: null,
                orderable: false,
                render: function (data, type, row) {
                    var tmp = "";
                    tmp += `<button data-id="${row.id}" class="btn btn-info btn-sm m-btn m-btn--icon btn-detail">`;
                    tmp += `<span><i class="la la-eye"></i><span>Detalle</span></span></button> `;
                    tmp += `<button data-id="${row.id}" class="btn btn-success btn-sm m-btn m-btn--icon btn-shop">`;
                    tmp += `<span><i class="la la-shopping-cart"></i><span>Comprar</span></span></button> `;
                    return tmp;
                }
            }
        ]
    };

    var search = {
        init: function () {
            $("#search").doneTyping(function () {
                datatable.init();
            });
        }
    };

    var datatable = {
        init: function () {
            if (productDatatable === null) {
                productDatatable = $(".product-datatable").DataTable(options);
                this.initEvents();
            }
            else {
                productDatatable.ajax.reload();
            }
        },
        initEvents: function () {

            productDatatable.on("click", ".btn-detail", function () {
                let id = $(this).data("id");
                form.detail.load(id);
            });

            productDatatable.on("click", ".btn-shop", function () {
                let id = $(this).data("id");
                swal({
                    title: "¿Está seguro?",
                    text: "¿Estás seguro que deseas comprar el producto?",
                    type: "warning",
                    showCancelButton: true,
                    confirmButtonText: "Sí",
                    confirmButtonClass: "btn btn-success m-btn m-btn--custom",
                    cancelButtonText: "Cancelar",
                    showLoaderOnConfirm: true,
                    allowOutsideClick: () => !swal.isLoading(),
                    preConfirm: () => {
                        return new Promise((resolve) => {
                            $.ajax({
                                url: `/comprar/post`.proto().parseURL(),
                                type: "POST",
                                data: {
                                    id: id
                                },
                                success: function (result) {
                                    productDatatable.ajax.reload();
                                    swal({
                                        type: "success",
                                        title: "Completado",
                                        text: "El producto ha sido comprado con éxito",
                                        confirmButtonText: "Excelente"
                                    });
                                },
                                error: function (errormessage) {
                                    swal({
                                        type: "error",
                                        title: "Ups",
                                        confirmButtonClass: "btn btn-danger m-btn m-btn--custom",
                                        confirmButtonText: "Entendido",
                                        text: errormessage.responseText
                                    });
                                }
                            });
                        });
                    }
                });
            });
        },
    };


    var select2 = {
        init: function () {
            this.category.init();
        },
        category: {
            init: function () {
                $.ajax({
                    url: "/categorias/get".proto().parseURL()
                }).done(function (result) {
                    $(".select2-category")
                        .select2({
                            data: result,
                            dropdownParent: $(".select2-category").closest(".modal-body")
                        });
                    $("#category-filter")
                        .on("change", function () {
                            datatable.init();
                        }).select2({
                        }).trigger("change");
                });
            }
        },
    }


    var form = {
        detail: {
            load: function (id) {
                mApp.blockPage();
                $.ajax({
                    url: `/${id}/get`.proto().parseURL()
                })
                    .always(function () {
                        mApp.unblockPage();
                    })
                    .done(function (result) {
                        $("#img").attr("src", result.img)
                        $("#Name").val(result.name);
                        $("#Name").val(result.name);
                        $("#Description").val(result.description);
                        $("#Amount").val(result.amount);
                        $("#Category").val(result.category.name);
                        $("#detail-modal").modal("show");
                    })
                    .fail(function () {
                        toastr.error(_app.constants.toastr.message.error.task, _app.constants.toastr.title.error);
                    });
            }
        },
    };

    return {
        init: function () {
            home.init();
            search.init();
            select2.init();
        }
    }
}();

$(function () {
    HomeManagement.init();
});