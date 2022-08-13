var admin = (function () {
    var configs = {
        urls: {
            home: '',
            cadastrar: '',
            informacaoRoupas: ''
        }
    };

    var init = function ($configs) {
        configs = $configs;
    };

    function cadastrar() {
        model = $('#form-funcionario').serializeObject();
        console.log(model);
        $.post(configs.urls.cadastrar, model).done(function () {
            location.href = (configs.urls.home)

        }).fail(function (msg) {
                site.toast.error(msg);
        });
    }

    function cadastrarItem() {
        model = $('#form-item').serializeObject();
        console.log(model);
        $.post(configs.urls.cadastrar, model).done(function () {
            location.href = (configs.urls.home)

        }).fail(function (msg) {
                site.toast.error(msg);
        });
    }

    function informacaoRoupa(id) {
        console.log(id);
        console.log(configs.urls.informacaoRoupas);
        $.get(configs.urls.informacaoRoupas, { id : id }).done(function (html) {
            $('.conteudo-roupa').hide()
            $('.informacao-roupa').html(html);
            $('.informacao-roupa').show();
        })
    }


    return {
        init: init,
        cadastrar: cadastrar,
        cadastrarItem: cadastrarItem,
        informacaoRoupa: informacaoRoupa
    };
})();