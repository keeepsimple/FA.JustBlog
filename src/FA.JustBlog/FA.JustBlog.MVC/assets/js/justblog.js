function ConvertToSlug(txt) {
    txt = txt.replace(/^\s+|\s+$/g, "");
    txt = txt.toLowerCase();
    txt = txt.replace(/[^a-zA-z0-9 -]/g, "-");
    txt = txt.replace(/(\s+)/g, "-");
    txt = txt.replace(/(-+)/g, "-");

    document.getElementById("UrlSlug").value = txt;
}

$(document).ready(function () {
    $('.select-multiple').select2();
});

$(document).ready(function () {
    $('.select-single').select2();
});