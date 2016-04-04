var formSubmit = (function ($) {

    function submission(evt, $form) {

        var url = $(evt.currentTarget).data('submitRedirect');
        var clear = $(evt.currentTarget).data('submitReset');
        var text = $(evt.currentTarget).data('submitText');
        
        evt.preventDefault();

        $.ajax({
            url: this.action,
            type: this.method,
            data: $form.serialize(),
            success: function (response) {
        
                if (typeof url !== 'undefined') window.location.assign(url);
                if (typeof text !== 'undefined') $form.html(text);
                if (typeof clear !== 'undefined') $form.trigger('reset');

                return false;
            },
            error: function () {
                $('[data-submit-message]').text("Sorry, it didn't work");
            }
        });
    }

    return {
        submission: submission
    }

})(jQuery);