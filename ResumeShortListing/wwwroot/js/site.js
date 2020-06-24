// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


var viewManager = (() => {

    var config = {
        eleContainer: '',
        placeholder: true,
        mandatorySign: false,
        detailView: false
    }



    var init = (userConfig) => {

        $.extend(config, userConfig);

        alterControls();
    }

    var alterControls = () => {

        const eleContainer = config.eleContainer;

        if ($(eleContainer).length > 0) {

            $(eleContainer + ' [data-cntrl]').each((i, cntrl) => {

                var label = $(cntrl).find('label');
                var input = $(cntrl).find('input');

                //Placeholder
                if (config.placeholder) {

                    if (label.length > 0 && input.length > 0) {
                        input.attr('placeholder', label.text());
                    }
                }

            });

        }
    }


    var getFormData = (eleContainer) => {

        if ($(eleContainer).length > 0) {

            const data = {};

            $(eleContainer + ' [data-cntrl] input[name]').each((i, cntrl) => {

                //var $input = $(cntrl).find('input[name]');

                data[$(cntrl).attr('name')] = $(cntrl).val();
            });

            $(eleContainer + ' [data-cntrl-hdn] input[type=hidden]').each((i, hdn) => {
                data[$(hdn).attr('name')] = $(hdn).val();
            });

            return data;
        }
        else {
            return null;
        }
    }


    var setFormData = (eleContainer, data) => {

        if ($(eleContainer).length > 0 && data) {

           

            $(eleContainer + ' [data-cntrl] input[name]').each((i, cntrl) => {                

                var name = $(cntrl).attr('name').charAt(0).toLowerCase() + $(cntrl).attr('name').slice(1);

                $(cntrl).val(data[name]);
            });

            $(eleContainer + ' [data-cntrl-hdn] input[type=hidden]').each((i, cntrl) => {

                var name = $(cntrl).attr('name').charAt(0).toLowerCase() + $(cntrl).attr('name').slice(1);

                $(cntrl).val(data[name]);

                //data[$(hdn).attr('name')] = $(hdn).val();
            });

            
        }
        
    }


    var detailView = () => {

    }


    return {
        init: init,
        getFormData: getFormData,
        setFormData: setFormData
    }

})();
