function InitialiseDisqus(config) {
    var disqus_config = function () {
        this.page.url = window.location.href;
        this.page.identifier = config.pageIdentifier;
    };

    (function () { // DON'T EDIT BELOW THIS LINE
        var d = document, s = d.createElement('script');
        s.src = config.embedJsUrl;
        s.setAttribute('data-timestamp', + new Date());
        (d.head || d.body).appendChild(s);
    })();

    return 'success';
}

function SetMetaTags(model) {
    if (model.title) {
        $("#title").text(model.title);
        $("#meta_Title").attr('content', model.title);
    }
    if (model.type) {
        $("#meta_Type").attr('content', model.type);
    }
    if (model.url) {
        $("#meta_Url").attr('content', model.url);
    }
    if (model.image) {
        $("#meta_Image").attr('content', model.image);
    }
}