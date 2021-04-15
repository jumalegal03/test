var Profile = (function () {

    var profileForm = null;

    var form = {
        submit: function (formElement) {
            var formData = new FormData($(formElement).get(0));
            $(formElement).find(".btn-submit").addLoader();
            form.disable();
            $.ajax({
                data: formData,
                type: "POST",
                contentType: false,
                processData: false,
                url: $(formElement).attr("action")
            })
                .always(function () {
                    $(formElement).find(".btn-submit").removeLoader();
                    form.enable();
                })
                .done(function () {
                    toastr.success(_app.constants.toastr.message.success.task, _app.constants.toastr.title.success);
                })
                .fail(function (e) {
                    toastr.error(_app.constants.toastr.message.error.task, _app.constants.toastr.title.error);
                    if (e.responseText != null) $("#createAlertText").html(e.responseText);
                    else $("#createAlertText").html(_app.constants.ajax.message.error);
                    $("#createAlert").removeClass("m--hide").show();
                });
        },
        disable: function() {
            $("#PersonalEmail").prop("disable", true);
            $("#PhoneNumber").prop("disable", true);
            $("#CivilStatus").prop("disable", true);
            $("#Address").prop("disable", true);
        },
        enable: function() {
            $("#PersonalEmail").prop("disable", false);
            $("#PhoneNumber").prop("disable", false);
            $("#CivilStatus").prop("disable", false);
            $("#Address").prop("disable", false);
        },
        reset: function () {
            profileForm.resetForm();
        }
    }

    var select2 = {
        init: function () {
            this.civilStatus.init();
        },
        civilStatus: {
            init: function () {
                $(".select2-civilstatus").select2();
            }
        }
    };

    var event = {
        init: function () {
            this.btnCancel.init();
        },
        btnCancel: {
            init: function () {
                $('#btnCancel').click(function () {
                    window.location.href = `/`;
                });
            }
        }
    }
    var fileInputs = {
        init: function () {
            this.picture.init();
        },
        picture: {
            init: function () {
                $("#Picture").on("change",
                    function (e) {
                        var tgt = e.target || window.event.srcElement,
                            files = tgt.files;
                        // FileReader support
                        if (FileReader && files && files.length) {
                            var fr = new FileReader();
                            fr.onload = function () {
                                $("#current-picture").attr("src", fr.result);
                            }
                            fr.readAsDataURL(files[0]);
                        }
                            // Not supported
                        else {
                            console.log("File Reader not supported.");
                        }
                    });
            }
        }
    };

    var validate = {
        init: function () {
            profileForm = $("#profile_form").validate({
                submitHandler: function (formElement, e) {
                    e.preventDefault();
                    form.submit(formElement);
                }
            });
        }
    };

    return {
        init: function () {
            validate.init();
            select2.init();
            event.init();
            fileInputs.init();
        }
    };
}());

$(function () {
    Profile.init();
});

