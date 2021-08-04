function ConvertToSlug() {
    txt = document.getElementById("Name");
    txt = txt.replace("^\s+|\s+$", "")
        .toLowerCase()
        .replace("[^a-zA-z0-9 -]", "-")
        .replace("(\s+)", "-")
        .replace("(-+)", "-");

    document.getElementById("UrlSlug").innerHTML = txt;
}