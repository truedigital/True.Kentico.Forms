var formSubmit = (function ($) {

    function submission(evt, $form) {

        evt.preventDefault();

        $.ajax({
            url: this.action,
            type: this.method,
            data: $form.serialize(),
            success: function (response) {
                var url = $(evt.currentTarget).data('submitRedirect');
                var clear = $(evt.currentTarget).data('submitClear');
                var text = $(evt.currentTarget).data('submitText');

                if (typeof url !== 'undefined') window.location.assign(url);
                if (typeof text !== 'undefined') $form.html(text);
                if (typeof clear !== 'undefined') $form.trigger('reset');

                return false;
            },
            error: function () {
                $form.find('[data-form-message]').append("Sorry, it didn't work");
            }
        });
    }

    return {
        submission: submission
    }

})(jQuery);