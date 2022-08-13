var login = (function () {
    var configs = {
        urls: {
            login: '',
            home: '',
            cadastrar: ''
        }
    };

    var init = function ($configs) {
        configs = $configs;
    };

    function login() {
        model = $('#form-login').serializeObject();
        
        $.post(configs.urls.login, model).done(function () {
            location.href = (configs.urls.home)

        }).fail(function (msg) {
                site.toast.error(msg);
        });
    }

    function cadastrar() {
        model = $('#form-cadastrar').serializeObject();
        console.log(model);
        $.post(configs.urls.cadastrar, model).done(function () {
            location.href = (configs.urls.login)

        }).fail(function (msg) {
                site.toast.error(msg);
        });
    }

    return {
        init: init,
        login: login,
        cadastrar: cadastrar
    };
})();