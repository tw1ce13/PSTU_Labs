// При загрузке страницы скрываем форму
$(document).ready(function () {
    $('#form_place').hide();
});

// При изменении значения в select показываем или скрываем форму
$('#select').change(function () {
    if ($(this).val() === 'place') {
        $('#form_place').show();
    } else {
        $('#form_place').hide();
    }
});
