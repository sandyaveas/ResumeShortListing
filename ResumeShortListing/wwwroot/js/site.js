// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


var viewManager = (() => {

    var config = {
        eleContainer: '',
        placeholder: true,
        mandatorySign: false,
        detailView: false,
        textAreaCounter: true,
    }



    var init = (userConfig) => {

        $.extend(config, userConfig);

        alterControls();
    }

    var alterControls = () => {


        const eleContainer = config.eleContainer.split(',');

        if ($(eleContainer).length > 0) {

            $(eleContainer).each((i, container) => {

                $(container + ' [data-cntrl]').each((i, cntrl) => {

                    const label = $(cntrl).find('label');
                    const input = $(cntrl).find('input');
                    const textarea = $(cntrl).find('textarea');

                    //Placeholder
                    if (config.placeholder) {

                        if (label.length > 0) {

                            var inputCntrl;

                            if (input.length > 0) {
                                inputCntrl = input;
                            }
                            else if (textarea.length > 0) {
                                inputCntrl = textarea
                            }

                            if (inputCntrl) {
                                inputCntrl.attr('placeholder', label.text());
                            }
                        }
                    }

                    //Apply TextArea Counter
                    if (config.textAreaCounter && textarea.length > 0) {
                        $('<small/>', { class: 'textcounter float-right text-info', text: `${textarea.attr('maxlength')} Character(s) left` }).insertAfter(textarea);
                    }


                });
            });
        }


        if (config.textAreaCounter) {
            applyTextCounter(eleContainer);
        }
    }


    var getFormData = (eleContainer) => {

        if ($(eleContainer).length > 0) {

            const data = {};

            var eleCon = eleContainer + ' [data-cntrl]'

            $(`${eleCon} input[type=text], ${eleCon} input[type=email], ${eleCon} input[type=number], ${eleCon} input[type=hidden], ${eleCon} textarea[name]`).each((i, cntrl) => {

                data[$(cntrl).attr('name')] = $(cntrl).val();
            });

            $(`${eleCon} input[type=checkbox]`).each((i, cntrl) => {

                var name = $(cntrl).attr('name').charAt(0).toLowerCase() + $(cntrl).attr('name').slice(1);

                data[name] = $(cntrl).prop('checked');

            });

            return data;
        }
        else {
            return null;
        }
    }


    var setFormData = (eleContainer, data) => {

        if ($(eleContainer).length > 0 && data) {

            const eleCon = eleContainer + ' [data-cntrl]'

            $(`${eleCon} input[type=text], ${eleCon} input[type=email], ${eleCon} input[type=number], ${eleCon} input[type=hidden], ${eleCon} textarea[name]`).each((i, cntrl) => {

                var name = $(cntrl).attr('name').charAt(0).toLowerCase() + $(cntrl).attr('name').slice(1);

                $(cntrl).val(data[name]);
            });

            $(`${eleCon} input[type=checkbox]`).each((i, cntrl) => {

                var name = $(cntrl).attr('name').charAt(0).toLowerCase() + $(cntrl).attr('name').slice(1);
                
                $(cntrl).prop('checked', data[name]);

            });
        }

    }

    var resetFormData = (eleContainer, resetValidate) => {

        if ($(eleContainer).length > 0) {

            const eleCon = eleContainer + ' [data-cntrl]'

            $(`${eleCon} input[name], ${eleCon} input[type=email], ${eleCon} input[type=number], ${eleCon}, ${eleCon} textarea[name]`).each((i, cntrl) => {

                $(cntrl).val('');

            });


            if (resetValidate) {

                resetValidator(eleContainer);
            }
        }

    }

    var applyValidate = (options) => {

        $(options.eleContainer).validate({
            rules: options.rules,
            messages: options.messages,
            errorElement: 'span',
            errorPlacement: function (error, element) {
                error.addClass('invalid-feedback');
                element.closest('.form-group').append(error);
            },
            highlight: function (element, errorClass, validClass) {
                $(element).addClass('is-invalid');
            },
            unhighlight: function (element, errorClass, validClass) {
                $(element).removeClass('is-invalid');
            }
        });

    }

    var resetValidator = (eleContainer) => {

        const validator = $(eleContainer).validate();

        $(eleContainer).find('.is-invalid').removeClass('is-invalid');
        validator.resetForm();
    }


    var applyTextCounter = (eleContainer) => {

        $(eleContainer).each((i, container) => {

            $(container).on('keydown', 'textarea', function (event) {
                const textarea = event.currentTarget;

                if ($(textarea).next('.textcounter').length > 0) {
                    const maxLength = $(textarea).attr('maxlength');

                    const textareaLength = $(textarea).val().length;

                    $(textarea).next('.textcounter').text(`${maxLength - textareaLength} Character(s) left`);
                }
            });
        });
    }


    var detailView = () => {

    }


    return {
        init: init,
        getFormData: getFormData,
        setFormData: setFormData,
        resetFormData: resetFormData,
        applyValidate: applyValidate,
        resetValidator: resetValidator
    }

})();



var toastr = (() => {

    const Toast = Swal.mixin({
        toast: true,
        position: 'top-end',
        showConfirmButton: false,
        timer: 3000
    });



    var success = (title, message) => {
        Toast.fire({
            icon: 'success',
            title: title != undefined ? title : '',
            text: message != undefined ? message : '',
        });
    }

    var error = (title, message) => {
        Toast.fire({
            icon: 'error',
            title: title != undefined ? title : '',
            text: message != undefined ? message : '',
        });
    }

    return {
        success: success,
        error: error
    }

})();


var confirm = (() => {


    var box = (title, message, callback) => {

        Swal.fire({
            title: title != undefined ? title : '',
            text: message != undefined ? message : '',
            icon: 'warning',
            showCancelButton: true,
            confirmButtonColor: '#3085d6',
            cancelButtonColor: '#d33',
            confirmButtonText: 'Yes, delete it!'
        }).then((result) => {

            if (result.value) {
                if ($.isFunction(callback)) {
                    callback();
                }
            }
        })
    }

    return {
        box: box
    }

})();


var general = (() => {

    var mnthYearName = (month, year, outputFormat) => {

        if (outputFormat == undefined) { outputFormat = 'MMM - YYYY'; }

        const mnthYear = month.toString().length == 1 ? '0' + month.toString() + year.toString() : month.toString() + year.toString();

        return moment(mnthYear, 'MMYYYY').format(outputFormat);
    }

    return {
        mnthYearName: mnthYearName
    }


})();


$('.back-to-top').click(() => {

    $('html, body').animate({
        scrollTop: '0'
    }, 1000);
})

Array.prototype.last = function () { return this[this.length - 1]; }