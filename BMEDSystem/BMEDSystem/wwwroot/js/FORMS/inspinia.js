// Collapse card function
$('.collapse-link').on('click', function () {
    var ibox = $(this).closest('div.card');
    var button = $(this).find('i');
    var content = ibox.children('.card-body');
    content.slideToggle(200);
    button.toggleClass('fa-chevron-up').toggleClass('fa-chevron-down');
    ibox.toggleClass('').toggleClass('border-bottom');
    setTimeout(function () {
        ibox.resize();
        ibox.find('[id^=map-]').resize();
    }, 50);
});

// Close ibox function
$('.close-link').on('click', function () {
    var content = $(this).closest('div.ibox');
    content.remove();
});