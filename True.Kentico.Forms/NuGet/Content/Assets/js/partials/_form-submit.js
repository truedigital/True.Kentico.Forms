var formSubmit = (function ($) {

    function submission(evt, $form) {

        var url = $(evt.currentTarget).data('submitRedirect');
        var clear = $(evt.currentTarget).data('submitReset');
        var text = $(evt.currentTarget).data('submitText');

        evt.preventDefault();

        var formData = new FormData();

        $.each($form.serializeArray(), function () {
            formData.append(this.name, this.value);
        });

        if ($('input[type=file]').length) {
            $.each($("input[type=file]").prop('files'), function () {
                var name = $("input[type=file]")[0].name;
                formData.append(name, this);
            });
        }

        $.ajax({
            url: $form.attr('action'),
            type: $form.attr('method'),
            data: formData,
            contentType: false,
            processData: false,
            success: function (response) {

                if (typeof url !== 'undefined') window.location.assign(url);
                if (typeof text !== 'undefined') $form.html(text);
                if (typeof clear !== 'undefined') $form.trigger('reset');

                return false;
            },
            error: function (xhr, textStatus, error) {
                $('[data-submit-message]').html('<p>' + xhr.responseJSON + '</p>');
            }
        });
    }

    return {
        submission: submission
    }

})(jQuery);