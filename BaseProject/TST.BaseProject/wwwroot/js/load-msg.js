$(function () {
    $.ajax({
        url: "/api/mensajes/alumno/get".proto().parseURL()
    }).done(function (result) {
        $(".number-notification").html(`${result.length}`);
        result.forEach(function (e, i) {
            let tmp = `<div class="m-list-timeline__item"><span class="m-list-timeline__badge -m-list-timeline__badge--state-success"></span><span class="m-list-timeline__text"><strong>${e.title}</strong><p>${e.text}</p></span><span class="m-list-timeline__time">${e.time}</span></div>`;
            $(".m-list-timeline__items").append(`${tmp}`);
        });
    });
});