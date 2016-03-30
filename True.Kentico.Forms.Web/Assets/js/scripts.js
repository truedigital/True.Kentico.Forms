var debugGrid = (function ($) {

    $('body').append('<div class="grid-debug--trigger">|||</div>')
     .on('click', '.grid-debug--trigger', function(){
        $(this).toggleClass('active');
        $('body').toggleClass('grid--debug');
    });

})(jQuery);
var validation = (function ($) {

    // === VALIDATOR

    if ($('form[data-validate]').length){
        $.ajax({
            url: '/assets/js/vendor/jquery.validate.js',
            dataType: 'script',
            cache: true
        })
        .done(function() {
            setFormDefaults();
            $('form[data-validate]').each(function() {
                $(this).validate();
            });
        });
    }


    // === VALIDATOR SETTINGS

    function setFormDefaults(){

        jQuery.validator.setDefaults({
            debug: true,
            errorClass: 'is-invalid',
            validClass: 'is-valid',
            ignoreTitle: true,
            showErrors: function(errorMap, errorList) {
                this.defaultShowErrors();
                if ($(this.currentForm).is('[data-summary]')){
                    showFormSummary(this, errorMap, errorList);
                }
            },
            errorPlacement: function(error, element) {
                insertFormError(this, error, element);
            },
            highlight: function(element, errorClass, validClass){
                $(element).closest('.form-row').addBack().addClass(errorClass).removeClass(validClass);
            },
            unhighlight: function(element, errorClass, validClass){
                $(element).closest('.form-row').addBack().removeClass(errorClass).addClass(validClass);
            },
            submitHandler: function(form) {
                $(form).find('[data-submit]').attr('disabled', true).addClass('is-disabled');
                form.submit();
            }
        });
    }


    // === FORM ERROR PLACEMENT

    function insertFormError(validator, error, element){

        // Insert error message after the last radio button in a group
        if (element.is('input:radio')){
            var $lastOption = $(element).parent().siblings('.form-radio').addBack().filter(':last')
            error.insertAfter($lastOption);
        }

        // Insert error message after the last checkbox button in a group
        else if (element.is('input:checkbox')){
            var $lastOption = $(element).parent().siblings('.form-checkbox').addBack().filter(':last')
            error.insertAfter($lastOption);
        }

        // Insert error message after element
        else {
            error.insertAfter(element);
        }
    }


    // === FORM SUMMARY

    function showFormSummary(validator, errorMap, errorList){
        var $form = $(validator.currentForm);

        // Insert summary container if needed
        if (!$form.find('.form-summary').length){
            $form.prepend('<div class="form-summary" />');
        }

        var $formSummary = $form.find('.form-summary');
        var errorCount = validator.numberOfInvalids();
        var errorText = (errorCount == '1') ? errorCount + ' error' : errorCount + ' errors';

        // Update summary
        if (errorCount == '0'){
            $formSummary.addClass('is-hidden');
        }
        else {
            $formSummary.html('Form contains ' + errorText).removeClass('is-hidden');
        }
    }


})(jQuery);

//# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbIl9mcm9udC1lbmQtZGVidWcuanMiLCJfdmFsaWRhdGlvbi5qcyJdLCJuYW1lcyI6W10sIm1hcHBpbmdzIjoiQUFBQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUNSQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQSIsImZpbGUiOiJzY3JpcHRzLmpzIiwic291cmNlc0NvbnRlbnQiOlsidmFyIGRlYnVnR3JpZCA9IChmdW5jdGlvbiAoJCkge1xuXG4gICAgJCgnYm9keScpLmFwcGVuZCgnPGRpdiBjbGFzcz1cImdyaWQtZGVidWctLXRyaWdnZXJcIj58fHw8L2Rpdj4nKVxuICAgICAub24oJ2NsaWNrJywgJy5ncmlkLWRlYnVnLS10cmlnZ2VyJywgZnVuY3Rpb24oKXtcbiAgICAgICAgJCh0aGlzKS50b2dnbGVDbGFzcygnYWN0aXZlJyk7XG4gICAgICAgICQoJ2JvZHknKS50b2dnbGVDbGFzcygnZ3JpZC0tZGVidWcnKTtcbiAgICB9KTtcblxufSkoalF1ZXJ5KTsiLCJ2YXIgdmFsaWRhdGlvbiA9IChmdW5jdGlvbiAoJCkge1xyXG5cclxuICAgIC8vID09PSBWQUxJREFUT1JcclxuXHJcbiAgICBpZiAoJCgnZm9ybVtkYXRhLXZhbGlkYXRlXScpLmxlbmd0aCl7XHJcbiAgICAgICAgJC5hamF4KHtcclxuICAgICAgICAgICAgdXJsOiAnL2Fzc2V0cy9qcy92ZW5kb3IvanF1ZXJ5LnZhbGlkYXRlLmpzJyxcclxuICAgICAgICAgICAgZGF0YVR5cGU6ICdzY3JpcHQnLFxyXG4gICAgICAgICAgICBjYWNoZTogdHJ1ZVxyXG4gICAgICAgIH0pXHJcbiAgICAgICAgLmRvbmUoZnVuY3Rpb24oKSB7XHJcbiAgICAgICAgICAgIHNldEZvcm1EZWZhdWx0cygpO1xyXG4gICAgICAgICAgICAkKCdmb3JtW2RhdGEtdmFsaWRhdGVdJykuZWFjaChmdW5jdGlvbigpIHtcclxuICAgICAgICAgICAgICAgICQodGhpcykudmFsaWRhdGUoKTtcclxuICAgICAgICAgICAgfSk7XHJcbiAgICAgICAgfSk7XHJcbiAgICB9XHJcblxyXG5cclxuICAgIC8vID09PSBWQUxJREFUT1IgU0VUVElOR1NcclxuXHJcbiAgICBmdW5jdGlvbiBzZXRGb3JtRGVmYXVsdHMoKXtcclxuXHJcbiAgICAgICAgalF1ZXJ5LnZhbGlkYXRvci5zZXREZWZhdWx0cyh7XHJcbiAgICAgICAgICAgIGRlYnVnOiB0cnVlLFxyXG4gICAgICAgICAgICBlcnJvckNsYXNzOiAnaXMtaW52YWxpZCcsXHJcbiAgICAgICAgICAgIHZhbGlkQ2xhc3M6ICdpcy12YWxpZCcsXHJcbiAgICAgICAgICAgIGlnbm9yZVRpdGxlOiB0cnVlLFxyXG4gICAgICAgICAgICBzaG93RXJyb3JzOiBmdW5jdGlvbihlcnJvck1hcCwgZXJyb3JMaXN0KSB7XHJcbiAgICAgICAgICAgICAgICB0aGlzLmRlZmF1bHRTaG93RXJyb3JzKCk7XHJcbiAgICAgICAgICAgICAgICBpZiAoJCh0aGlzLmN1cnJlbnRGb3JtKS5pcygnW2RhdGEtc3VtbWFyeV0nKSl7XHJcbiAgICAgICAgICAgICAgICAgICAgc2hvd0Zvcm1TdW1tYXJ5KHRoaXMsIGVycm9yTWFwLCBlcnJvckxpc3QpO1xyXG4gICAgICAgICAgICAgICAgfVxyXG4gICAgICAgICAgICB9LFxyXG4gICAgICAgICAgICBlcnJvclBsYWNlbWVudDogZnVuY3Rpb24oZXJyb3IsIGVsZW1lbnQpIHtcclxuICAgICAgICAgICAgICAgIGluc2VydEZvcm1FcnJvcih0aGlzLCBlcnJvciwgZWxlbWVudCk7XHJcbiAgICAgICAgICAgIH0sXHJcbiAgICAgICAgICAgIGhpZ2hsaWdodDogZnVuY3Rpb24oZWxlbWVudCwgZXJyb3JDbGFzcywgdmFsaWRDbGFzcyl7XHJcbiAgICAgICAgICAgICAgICAkKGVsZW1lbnQpLmNsb3Nlc3QoJy5mb3JtLXJvdycpLmFkZEJhY2soKS5hZGRDbGFzcyhlcnJvckNsYXNzKS5yZW1vdmVDbGFzcyh2YWxpZENsYXNzKTtcclxuICAgICAgICAgICAgfSxcclxuICAgICAgICAgICAgdW5oaWdobGlnaHQ6IGZ1bmN0aW9uKGVsZW1lbnQsIGVycm9yQ2xhc3MsIHZhbGlkQ2xhc3Mpe1xyXG4gICAgICAgICAgICAgICAgJChlbGVtZW50KS5jbG9zZXN0KCcuZm9ybS1yb3cnKS5hZGRCYWNrKCkucmVtb3ZlQ2xhc3MoZXJyb3JDbGFzcykuYWRkQ2xhc3ModmFsaWRDbGFzcyk7XHJcbiAgICAgICAgICAgIH0sXHJcbiAgICAgICAgICAgIHN1Ym1pdEhhbmRsZXI6IGZ1bmN0aW9uKGZvcm0pIHtcclxuICAgICAgICAgICAgICAgICQoZm9ybSkuZmluZCgnW2RhdGEtc3VibWl0XScpLmF0dHIoJ2Rpc2FibGVkJywgdHJ1ZSkuYWRkQ2xhc3MoJ2lzLWRpc2FibGVkJyk7XHJcbiAgICAgICAgICAgICAgICBmb3JtLnN1Ym1pdCgpO1xyXG4gICAgICAgICAgICB9XHJcbiAgICAgICAgfSk7XHJcbiAgICB9XHJcblxyXG5cclxuICAgIC8vID09PSBGT1JNIEVSUk9SIFBMQUNFTUVOVFxyXG5cclxuICAgIGZ1bmN0aW9uIGluc2VydEZvcm1FcnJvcih2YWxpZGF0b3IsIGVycm9yLCBlbGVtZW50KXtcclxuXHJcbiAgICAgICAgLy8gSW5zZXJ0IGVycm9yIG1lc3NhZ2UgYWZ0ZXIgdGhlIGxhc3QgcmFkaW8gYnV0dG9uIGluIGEgZ3JvdXBcclxuICAgICAgICBpZiAoZWxlbWVudC5pcygnaW5wdXQ6cmFkaW8nKSl7XHJcbiAgICAgICAgICAgIHZhciAkbGFzdE9wdGlvbiA9ICQoZWxlbWVudCkucGFyZW50KCkuc2libGluZ3MoJy5mb3JtLXJhZGlvJykuYWRkQmFjaygpLmZpbHRlcignOmxhc3QnKVxyXG4gICAgICAgICAgICBlcnJvci5pbnNlcnRBZnRlcigkbGFzdE9wdGlvbik7XHJcbiAgICAgICAgfVxyXG5cclxuICAgICAgICAvLyBJbnNlcnQgZXJyb3IgbWVzc2FnZSBhZnRlciB0aGUgbGFzdCBjaGVja2JveCBidXR0b24gaW4gYSBncm91cFxyXG4gICAgICAgIGVsc2UgaWYgKGVsZW1lbnQuaXMoJ2lucHV0OmNoZWNrYm94Jykpe1xyXG4gICAgICAgICAgICB2YXIgJGxhc3RPcHRpb24gPSAkKGVsZW1lbnQpLnBhcmVudCgpLnNpYmxpbmdzKCcuZm9ybS1jaGVja2JveCcpLmFkZEJhY2soKS5maWx0ZXIoJzpsYXN0JylcclxuICAgICAgICAgICAgZXJyb3IuaW5zZXJ0QWZ0ZXIoJGxhc3RPcHRpb24pO1xyXG4gICAgICAgIH1cclxuXHJcbiAgICAgICAgLy8gSW5zZXJ0IGVycm9yIG1lc3NhZ2UgYWZ0ZXIgZWxlbWVudFxyXG4gICAgICAgIGVsc2Uge1xyXG4gICAgICAgICAgICBlcnJvci5pbnNlcnRBZnRlcihlbGVtZW50KTtcclxuICAgICAgICB9XHJcbiAgICB9XHJcblxyXG5cclxuICAgIC8vID09PSBGT1JNIFNVTU1BUllcclxuXHJcbiAgICBmdW5jdGlvbiBzaG93Rm9ybVN1bW1hcnkodmFsaWRhdG9yLCBlcnJvck1hcCwgZXJyb3JMaXN0KXtcclxuICAgICAgICB2YXIgJGZvcm0gPSAkKHZhbGlkYXRvci5jdXJyZW50Rm9ybSk7XHJcblxyXG4gICAgICAgIC8vIEluc2VydCBzdW1tYXJ5IGNvbnRhaW5lciBpZiBuZWVkZWRcclxuICAgICAgICBpZiAoISRmb3JtLmZpbmQoJy5mb3JtLXN1bW1hcnknKS5sZW5ndGgpe1xyXG4gICAgICAgICAgICAkZm9ybS5wcmVwZW5kKCc8ZGl2IGNsYXNzPVwiZm9ybS1zdW1tYXJ5XCIgLz4nKTtcclxuICAgICAgICB9XHJcblxyXG4gICAgICAgIHZhciAkZm9ybVN1bW1hcnkgPSAkZm9ybS5maW5kKCcuZm9ybS1zdW1tYXJ5Jyk7XHJcbiAgICAgICAgdmFyIGVycm9yQ291bnQgPSB2YWxpZGF0b3IubnVtYmVyT2ZJbnZhbGlkcygpO1xyXG4gICAgICAgIHZhciBlcnJvclRleHQgPSAoZXJyb3JDb3VudCA9PSAnMScpID8gZXJyb3JDb3VudCArICcgZXJyb3InIDogZXJyb3JDb3VudCArICcgZXJyb3JzJztcclxuXHJcbiAgICAgICAgLy8gVXBkYXRlIHN1bW1hcnlcclxuICAgICAgICBpZiAoZXJyb3JDb3VudCA9PSAnMCcpe1xyXG4gICAgICAgICAgICAkZm9ybVN1bW1hcnkuYWRkQ2xhc3MoJ2lzLWhpZGRlbicpO1xyXG4gICAgICAgIH1cclxuICAgICAgICBlbHNlIHtcclxuICAgICAgICAgICAgJGZvcm1TdW1tYXJ5Lmh0bWwoJ0Zvcm0gY29udGFpbnMgJyArIGVycm9yVGV4dCkucmVtb3ZlQ2xhc3MoJ2lzLWhpZGRlbicpO1xyXG4gICAgICAgIH1cclxuICAgIH1cclxuXHJcblxyXG59KShqUXVlcnkpO1xyXG4iXSwic291cmNlUm9vdCI6Ii9zb3VyY2UvIn0=
