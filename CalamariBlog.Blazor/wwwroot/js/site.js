WebFontConfig = {
    google: {
        families: [
            'Lora:400,700,400italic,700italic',
            'Open Sans:300italic,400italic,600italic,700italic,800italic,400,300,600,700,800'
        ]
    }
};

(function (d) {
    var wf = d.createElement('script'), s = d.scripts[0];
    wf.src = 'https://ajax.googleapis.com/ajax/libs/webfont/1.6.26/webfont.js';
    wf.async = true;
    s.parentNode.insertBefore(wf, s);
})(document);


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
    var placeholderElement = $("#metaPlaceHolder");

    placeholderElement.append(
        '<title id="title" class="metaTags">Calamari Blog</title>' +
        '<meta property="og:title" content="" id="meta_Title" class="metaTags" />' +
        '<meta property="og:type" content="" id="meta_Type" class="metaTags" />' +
        '<meta property="og:url" content="" id="meta_Url" class="metaTags" />' +
        '<meta property="og:image" content="" id="meta_Image" class="metaTags" />'
    );

    if (model.title) {
        placeholderElement.append(
            '<title id="title" class="metaTags">' + model.title + '</title>' +
            '<meta property="og:title" content="" id="meta_Title" class="metaTags" />'
        );
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