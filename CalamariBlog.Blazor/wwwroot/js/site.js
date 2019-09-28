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