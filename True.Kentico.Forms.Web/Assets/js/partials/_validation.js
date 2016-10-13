var validation = (function ($) {

    // === VALIDATOR

    if ($('form[data-validate]').length) {
        $.ajax({
            url: '/assets/js/vendor/jquery.validate.js',
            dataType: 'script',
            cache: true
        })
        .done(function () {
            setFormDefaults();
            $('form[data-validate]').each(function () {
                $(this).validate();
            });
        });
    }

    if ($('.datepicker').length) {
        $.ajax({
            url: '/assets/js/vendor/pikaday.js',
            dataType: 'script',
            cache: true
        })
        .done(function () {
            var picker = new Pikaday({ field: document.querySelector('.datepicker') });
            // picker.show();
        });
    }


    // === VALIDATOR SETTINGS

    function setFormDefaults() {

        jQuery.validator.setDefaults({
            debug: true,
            errorClass: 'is-invalid',
            validClass: 'is-valid',
            ignoreTitle: true,
            focusInvalid: false,
            showErrors: function (errorMap, errorList) {
                this.defaultShowErrors();
                if ($(this.currentForm).is('[data-summary]')) {
                    showFormSummary(this, errorMap, errorList);
                }
            },
            errorPlacement: function (error, element) {
                insertFormError(this, error, element);
            },
            highlight: function (element, errorClass, validClass) {
                $(element).closest('.form-row').addBack().addClass(errorClass).removeClass(validClass);
            },
            unhighlight: function (element, errorClass, validClass) {
                $(element).closest('.form-row').addBack().removeClass(errorClass).addClass(validClass);
            },
            submitHandler: function (form, event) {
                $(form).find('[data-submit]').attr('disabled', true).addClass('is-disabled');
                formSubmit.submission(event, $(form));
            },
            invalidHandler: function(form, validator) {
                var windowWidth = $(window).width();
                if (validator.numberOfInvalids() && windowWidth < 500){
                    var offsetAmount = $(validator.errorList[0].element).offset().top;
                    $('html, body').animate({ scrollTop: offsetAmount - 40 }, 150);
                }
            }
        });

        jQuery.validator.addMethod(
            "regular-expression",
            function (value, element, regexp) {
                var re = new RegExp(regexp);
                return this.optional(element) || re.test(value);
            },
            "Please check your input."
        );
    }


    // === FORM ERROR PLACEMENT

    function insertFormError(validator, error, element) {

        // Insert error message after the last radio button in a group
        if (element.is('input:radio')) {
            var $lastOption = $(element).parent().siblings('.form-radio').addBack().filter(':last');
            error.insertAfter($lastOption);
        }

            // Insert error message after the last checkbox button in a group
        else if (element.is('input:checkbox')) {
            var $lastOption = $(element).parent().siblings('.form-checkbox').addBack().filter(':last');
            error.insertAfter($lastOption);
        }

            // Insert error message after element
        else {
            error.insertAfter(element);
        }
    }


    // === FORM SUMMARY

    function showFormSummary(validator, errorMap, errorList) {
        var $form = $(validator.currentForm);

        // Insert summary container if needed
        if (!$form.find('.form-summary').length) {
            $form.prepend('<div class="form-summary" />');
        }

        var $formSummary = $form.find('.form-summary');
        var errorCount = validator.numberOfInvalids();
        var errorText = (errorCount == '1') ? errorCount + ' error' : errorCount + ' errors';

        // Update summary
        if (errorCount == '0') {
            $formSummary.addClass('is-hidden');
        }
        else {
            $formSummary.html('Form contains ' + errorText).removeClass('is-hidden');
        }
    }


})(jQuery);
