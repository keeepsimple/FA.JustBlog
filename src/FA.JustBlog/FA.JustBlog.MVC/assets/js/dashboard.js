const $button = document.querySelector('#sidebar-toggle');
const $wrapper = document.querySelector('#wrapper');

$button.addEventListener('click', (e) => {
    e.preventDefault();
    $wrapper.classList.toggle('toggled');
});

$(function () {
    // this will get the full URL at the address bar
    var url = window.location.href;

    // passes on every "a" tag 
    $("#sidebar-supporter a").each(function () {
        // checks if its the same on the address bar
        if (url == (this.href)) {
            $(this).closest("li").addClass("active");
        }
    });
});